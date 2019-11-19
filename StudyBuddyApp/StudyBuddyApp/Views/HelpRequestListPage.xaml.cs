using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;
using StudyBuddyApp.Models;
using StudyBuddyApp.ViewModels;
using StudyBuddyShared.Utility.Extensions;
using System.Collections.Generic;
using StudyBuddyShared.SystemManager;
using StudyBuddyShared.CategorySystem;
using StudyBuddyShared.HelpRequestSystem;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestListPage : ContentPage
    {
        private Dictionary<string, User> users = null;
        // Items yra HelpRequest
        public ObservableCollection<HelpRequestModel> Items { get; set; }
        public ObservableCollection<HelpRequestModel> FilteredItems { get; set; }
        public ObservableCollection<CategoryModel> CategoryItems { get; set; }
        public bool myRequests { get; set; }

        /// <summary>
        /// Kviesdamas naują puslapį nurodomas MyRequest rušiavimui mano HelpRequest
        /// </summary>
        /// <param name="MyRequest">ar tai mano HelpRequest</param>
        public HelpRequestListPage(bool MyRequest = false)
        {
            InitializeComponent();
            myRequests = MyRequest;
            Items = new ObservableCollection<HelpRequestModel>
            { };
            FilteredItems = new ObservableCollection<HelpRequestModel>
            { };
            CategoryItems = new ObservableCollection<CategoryModel>
            {
                new CategoryModel { Title = "Visi", Category = null }
            };
            CategoryListGetter();
            HelpRequestListGetter();

            HelpRequestList.ItemsSource = FilteredItems;
            PickCategory.ItemsSource = CategoryItems;

            MessagingCenter.Subscribe<HelpRequestAddPage>(this, "AddPageClosed", (addPage) =>
            {
                AddButton.IsEnabled = true;
            });
        }
        /// <summary>
        /// Refrešinimui
        /// </summary>
        private void HelpRequestList_Refreshing(object sender, EventArgs e)
        {
            //AddButton.IsEnabled = true;
            HelpRequestListGetter();
        }

        /// <summary>
        /// Eventas kuris atidaro naują puslapį (HelpRequestViewPage) paspaudus Listo Item
        /// </summary>
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var selectedItem = ((ListView)sender).SelectedItem as HelpRequestModel;
            var user = users[selectedItem.HelpRequest.CreatorUsername];

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(new HelpRequestViewPage(new HelpRequestViewPageModel(user, selectedItem)));
        }
        /// <summary>
        /// Gauna visus HelpRequest iš DB ir iš karto filtruoja pagal parametrus
        /// </summary>
        private void HelpRequestListGetter()
        {
            var helpRequestGetter = HelpRequestSystemManager.NewHelpRequestGetter();
            helpRequestGetter.Result += (status, requests, users) =>
            {
                if (status == HelpRequestGetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
                        this.users = users;
                        requests.ForEach(request =>
                        {
                            Items.Add(new HelpRequestModel
                            {
                                Title = request.Title,
                                Description = request.Description,
                                Username = request.CreatorUsername,
                                Name = users[request.CreatorUsername].FirstName + " " + users[request.CreatorUsername].LastName,
                                Category = request.Category,
                                Date = request.Timestamp.ToFullDate(),
                                HelpRequest = request
                            });
                        });

                        FilterFinal();
                        HelpRequestList.IsRefreshing = false;

                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        HelpRequestList.IsRefreshing = false;
                    });
                }

            };
            helpRequestGetter.Get();
        }

        /// <summary>
        /// Gauna visus Categories iš DB
        /// </summary>
        private void CategoryListGetter()
        {
            var categoriesGetter = CategorySystemManager.NewCategoryGetter();
            categoriesGetter.Result += (status, categories) =>
            {
                if (status == CategoryGetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        CategoryItems.Clear();
                        CategoryItems.Add(new CategoryModel
                        {
                            Title = "Visi",
                            Category = null
                        });
                        categories.ForEach(category =>
                        {
                            CategoryItems.Add(new CategoryModel
                            {
                                Title = category.Title,
                                Category = category,
                            });
                        });
                        //FilterFinal();
                        //CategoryList.IsRefreshing = false;
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //CategoryList.IsRefreshing = false;
                    });
                }

            };
            categoriesGetter.Get();
        }
        /// <summary>
        /// Filtruoja helpRequest pagal įvestą String, pasirinką kategoriją, 
        /// bei per profili gali pasirinkti kad žiūrėtų tik savo
        /// </summary>
        /// <param name="search">Įvestas raktas</param>
        /// <param name="category">Pasirinkta kategorija</param>
        /// <param name="own">Ar tai mano HelpRequest</param>
        void Filter(string search = null, string category = null, bool own = false)
        {
            if (Items == null || LocalUserManager.LocalUser == null) // Dar nėra informacijos
            {
                return;
            }
            List<HelpRequestModel> filtered = Items.ToList();
            FilteredItems.Clear();
            filtered.ForEach((helpRequest) =>
            {
                if ((String.IsNullOrEmpty(category) || category == helpRequest.Category) &&
                    (String.IsNullOrEmpty(search) || helpRequest.Title.ToLower().Contains(search) || helpRequest.Description.ToLower().Contains(search)) &&
                    (!own || helpRequest.Username == LocalUserManager.LocalUser.Username))
                {
                    FilteredItems.Add(helpRequest);
                }
            });

        }
        /// <summary>
        /// Filtravimas kuris ignoruoja pirmajį categorijos pasirinkimą nes ten yra default
        /// </summary>
        private void FilterFinal()
        {
            if (PickCategory.SelectedIndex >= 1)
            {
                Filter(RequestSearchBar.Text, CategoryItems[PickCategory.SelectedIndex].Title, myRequests);
            }
            else
            {
                Filter(RequestSearchBar.Text, null, myRequests);
            }
        }

        /// <summary>
        /// Eventas kuris iškviečia nauja puslapį HelpRequestAddPage
        /// </summary>
        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            AddButton.IsEnabled = false;
            await Navigation.PushModalAsync(
                new NavigationPage(
                    new HelpRequestAddPage(
                        new ViewModels.HelpRequestAddViewModel())));
        }

        /// <summary>
        /// Filtruoja, kai vartotojas paspaudžia enter įvedęs tekstą
        /// </summary>
        private void PickCategory_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FilterFinal();
        }
        /// <summary>
        /// filtruoja pakeitus kategoriją
        /// </summary>
        private void RequestSearchBar_Completed(object sender, EventArgs e)
        {
            FilterFinal();
        }
    }
}
