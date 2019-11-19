using StudyBuddyApp.SystemManager;
using StudyBuddyApp.Utility;
using StudyBuddyApp.ViewModels;
using StudyBuddyShared.CategorySystem;
using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;
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
    public partial class CategoryViewPage : ContentPage
    {
        CategoryViewViewModel viewModel;
        public CategoryViewPage(CategoryViewViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (Description.Text.Length == 0)
            {
                await DisplayAlert("Klaida", "Nenurodytas kategorijos aprašymas", "OK");
                return;
            }
            else if (Description.Text.Equals(viewModel.CategoryModel.Category.Description))
            {
                await DisplayAlert("Klaida", "Kategorijos aprašymas nepakeistas, nėra prasmės išsaugoti", "OK");
                return;
            }

            SaveButton.IsEnabled = false;

            //susikuriam naują kategoriją, kurią prilyginsim buvusiai ir atnaujinsim tik pasikeitusius laukus
            var updatedCategory = new Category();
            updatedCategory.Title = viewModel.CategoryModel.Category.Title;
            updatedCategory.Description = Description.Text;
            updatedCategory.LastUpdatedDate = DateTime.Now.ToLongDateString();

            UpdateCategory(updatedCategory);
        }

        private void UpdateCategory(Category updatedCategory)
        {
            var categoryUpdater = CategorySystemManager.NewCategoryUpdater();
            categoryUpdater.Result += (status, category) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (status == CategoryManageStatus.Success)
                    {
                        DependencyService.Get<IToast>().LongToast("Kategorija sėkmingai atnaujinta");
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().LongToast("Kategorijos nepavyko atnaujinti");
                        SaveButton.IsEnabled = true;
                    }
                });
            };
            categoryUpdater.UpdateCategory(updatedCategory);
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Ar tikrai norite ištrinti kategoriją?", "Ištrynus kategoriją dings visi su ja susiję pagalbos prašymai.", "Taip", "Ne");
            if (answer == false) return;
            else
            {
                DeleteButton.IsEnabled = false;
                RemoveTopic();
            }
        }
        
        private void RemoveTopic()
        {
            var categoryRemover = CategorySystemManager.NewCategoryRemover();

            categoryRemover.Result += (status, category) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (status == CategoryManageStatus.Success)
                    {
                        DependencyService.Get<IToast>().LongToast("Kategorija sėkmingai ištrinta");
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().LongToast("Kategorijos nepavyko ištrinti");
                        DeleteButton.IsEnabled = true;
                    }
                });
            };
            categoryRemover.RemoveCategory(viewModel.CategoryModel.Category);
        }
        
    }
}