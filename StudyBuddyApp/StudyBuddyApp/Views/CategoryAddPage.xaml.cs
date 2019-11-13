using StudyBuddy.Entity;
using StudyBuddy.Network;
using StudyBuddyApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryAddPage : ContentPage
    {
        public CategoryAddPage()
        {
            InitializeComponent();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            SaveButton.IsEnabled = false;

            if (Title.Text.Length == 0)
            {
                await DisplayAlert("Klaida", "Nenurodytas kategorijos pavadinimas", "OK");
                return;
            }
            else if (Description.Text.Length == 0)
            {
                await DisplayAlert("Klaida", "Nenurodytas kategorijos aprašymas", "OK");
                return;
            }

            AddNewCategory();
        }

        private void AddNewCategory()
        {
            string timestamp = DateTime.Now.ToLongDateString();

            var categoryManager = new CategoryManager(LocalUserManager.LocalUser);
            categoryManager.AddCategoryResult += (status, category) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (status == CategoryManager.ManagerStatus.Success)
                    {
                        DependencyService.Get<IToast>().LongToast("Kategorija sėkmingai pridėta");
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().LongToast("Kategorijos nepavyko pridėti");
                        SaveButton.IsEnabled = true;
                    }
                });
            };
            categoryManager.addCategory(new Category
                {
                  Title = Title.Text,
                  Description = Description.Text,
                  CreatorUsername = LocalUserManager.LocalUser.Username,
                  CreatedDate = timestamp,
                  LastUpdatedDate = timestamp
                }
            );
        }

        private void CategoryAddPage_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPageClosed");
        }
    }
}