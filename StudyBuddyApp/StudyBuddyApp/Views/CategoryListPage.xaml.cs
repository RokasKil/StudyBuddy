using StudyBuddyShared.Network;
using StudyBuddyApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyApp.SystemManager;
using StudyBuddyShared.CategorySystem;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryListPage : ContentPage
    {
        public ObservableCollection<CategoryModel> Items { get; set; }

        public CategoryListPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<CategoryModel>
            { };

            GetCategories();

            CategoryList.ItemsSource = Items;

            MessagingCenter.Subscribe<CategoryAddPage>(this, "AddPageClosed", (addPage) =>
            {
                AddButton.IsEnabled = true;
            });

        }

        //pasiima kategorijas iš DB
        void GetCategories()
        {
            var categoryGetter = CategorySystemManager.NewCategoryGetter();

            categoryGetter.Result += async (status, categories) =>
            {
                if (status == CategoryGetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
                        categories.ForEach(category =>
                        {
                            Items.Add(new CategoryModel
                            {
                                Title = category.Title,
                                Description = category.Description,
                                CreatorUsername = category.CreatorUsername,
                                CreatedDate = category.CreatedDate,
                                LastUpdatedDate = category.LastUpdatedDate
                            });
                        });
                        //HelpRequestList.IsRefreshing = false;
                        //HelpRequestList.ItemsSource = null;
                        //HelpRequestList.ItemsSource = Items;
                    });
                }
                else
                {
                    await DisplayAlert("Klaida", "Nepavyko įkelti kategorijų", "OK");
                }

            };
            categoryGetter.Get();
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Nu va", "Paspaudei ant kategorijos, mldc", "ok seni");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        //paspaudus 'Pridėti' pereina į langą, kuriame galima pridėti naują kategoriją
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            AddButton.IsEnabled = false;
            await Navigation.PushModalAsync(new NavigationPage(new CategoryAddPage()));
        }

        private void CategoryListPage_Refreshing(object sender, EventArgs e)
        {
            GetCategories();
            CategoryList.IsRefreshing = false;
        }
    }
}
