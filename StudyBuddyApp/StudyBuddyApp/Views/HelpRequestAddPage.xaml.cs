using StudyBuddyShared.Network;
using StudyBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyShared.Entity;
using StudyBuddyApp.Utility;
using StudyBuddyApp.ViewModels;
using StudyBuddyShared.CategorySystem;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestAddPage : ContentPage
    {
        public ObservableCollection<CategoryModel> Items { get; set; }

        //public HelpRequest helpRequest { get; set; }

        HelpRequestAddViewModel viewModel;

        public HelpRequestAddPage(HelpRequestAddViewModel viewModel)
        {
            InitializeComponent();
            Items = new ObservableCollection<CategoryModel>
            { };
            //helpRequest = new HelpRequest { };
            CategorieListGetter();
            BindingContext = this.viewModel = viewModel;
            //BindingContext = requestModel = new HelpRequestModel();
            CategoryList.ItemsSource = Items;
        }

        private void CategorieListGetter()
        {
            //var categoriesGetter = new CategoriesGetter(LocalUserManager.LocalUser);
            //categoriesGetter.GetCategoriesResult +=

            new CategoriesGetter(LocalUserManager.LocalUser, (status, categories) =>
            {
                if (status == CategoriesGetter.GetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
                        categories.ForEach(category =>
                        {
                            Items.Add(new CategoryModel
                            {
                                Title = category.Title,
                                Category = category,
                            });
                        });
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

            }).get();
        }

        private void SendNewHelpRequest()
        {
            var helpRequestManager = new HelpRequestManager(LocalUserManager.LocalUser);
            helpRequestManager.PostHelpRequestResult += (status, helprequest) =>
            {
               
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (status == HelpRequestManager.ManagerStatus.Success)
                    {
                        DependencyService.Get<IToast>().LongToast("Prašymas sėkmingai išsiųstas");
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().LongToast("Prašymas nebuvo išsiųstas");
                        //Console.WriteLine("Epic fail");
                        SaveButton.IsEnabled = true;
                    }
                });
                
            };

            helpRequestManager.postHelpRequest(new HelpRequest
            {
                Title = Title.Text,
                Description = Description.Text,
                CreatorUsername = LocalUserManager.LocalUser.Username,
                Category = Items[CategoryList.SelectedIndex].Title
            });

        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if(CategoryList.SelectedIndex == -1)
            {
                await DisplayAlert("Nepavyko", "Kategorijos laukas yra privalomas", "OK");
                return;
            }
            else if(Title.Text.Length == 0)
            {
                await DisplayAlert("Nepavyko", "Problemos pavadinimo laukas yra privalomas", "OK");
                return;
            }
            else if (Description.Text.Length == 0)
            {
                await DisplayAlert("Nepavyko", "Problemos apibūdinimo laukas yra privalomas", "OK");
                return;
            }
            SaveButton.IsEnabled = false;
            //MessagingCenter.Send(this, "AddItem", Item);
            SendNewHelpRequest();
            
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPageClosed");
        }
    }
}