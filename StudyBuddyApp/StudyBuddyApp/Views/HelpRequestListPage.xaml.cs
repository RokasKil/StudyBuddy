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

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestListPage : ContentPage
    {
        private Dictionary<string, User> users = null;
        public ObservableCollection<HelpRequestModel> Items { get; set; }
        public ObservableCollection<HelpRequestModel> FilteredItems { get; set; }
        public ObservableCollection<CategoryModel> CategoryItems { get; set; }
        public bool myRequests { get; set; }
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

        private void HelpRequestList_Refreshing(object sender, EventArgs e)
        {
            //AddButton.IsEnabled = true;
            HelpRequestListGetter();
        }

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

        private void HelpRequestListGetter()
        {
            var helpRequestGetter = new HelpRequestGetter(LocalUserManager.LocalUser);
            helpRequestGetter.GetHelpRequestsResult += (status, requests, users) =>
            {
                if (status == HelpRequestGetter.GetStatus.Success)
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
            helpRequestGetter.get(true);
        }
        private void CategoryListGetter()
        {
            var categoriesGetter = new CategoriesGetter(LocalUserManager.LocalUser);
            categoriesGetter.GetCategoriesResult += (status, categories) =>
            {
                if (status == CategoriesGetter.GetStatus.Success)
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
                        FilterFinal();
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
            categoriesGetter.get();
        }

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
                    (!own || helpRequest.Name == LocalUserManager.LocalUser.Username))
                {
                    FilteredItems.Add(helpRequest);
                }
            });

        }

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

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            AddButton.IsEnabled = false;
            await Navigation.PushModalAsync(
                new NavigationPage(
                    new HelpRequestAddPage(
                        new ViewModels.HelpRequestAddViewModel())));
        }


        private void PickCategory_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FilterFinal();

        }

        private void RequestSearchBar_Completed(object sender, EventArgs e)
        {
            FilterFinal();
        }
    }
}
