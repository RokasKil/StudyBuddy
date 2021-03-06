﻿using StudyBuddyShared.Network;
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
using StudyBuddyShared.SystemManager;
using StudyBuddyShared.HelpRequestSystem;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestAddPage : ContentPage
    {
        // Items yra kategoriju 
        public ObservableCollection<CategoryModel> Items { get; set; }
        

        HelpRequestAddViewModel viewModel;

        public HelpRequestAddPage(HelpRequestAddViewModel viewModel)
        {
            InitializeComponent();
            Items = new ObservableCollection<CategoryModel>
            { };
            CategorieListGetter();
            BindingContext = this.viewModel = viewModel;
            CategoryList.ItemsSource = Items;
        }

        /// <summary>
        /// Pasiima visas kategorijas is DB
        /// </summary>
        private void CategorieListGetter()
        {
            var categoriesGetter = CategorySystemManager.NewCategoryGetter();
            categoriesGetter.Result += (status, categories) =>
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
            };
            categoriesGetter.Get();
        }

        /// <summary>
        /// Išsiunčiamas naujai sukurtas helpRequestas
        /// </summary>
        private void SendNewHelpRequest()
        {
            var helpRequestManager = HelpRequestSystemManager.NewHelpRequestPoster();
            helpRequestManager.Result += (status, helprequest) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (status == HelpRequestManageStatus.Success)
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

            helpRequestManager.Post(new HelpRequest
            {
                Title = Title.Text,
                Description = Description.Text,
                CreatorUsername = LocalUserManager.LocalUser.Username,
                Category = Items[CategoryList.SelectedIndex].Title
            });

        }
        /// <summary>
        /// Mygtuko eventas kuris išsiunčia HelpRequest taip pat apsaugo nuotuščių laukų
        /// </summary>
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
        /// <summary>
        /// Perduodamas pranešimas kad puslapis užsidaro kitieks puslapiams
        /// </summary>
        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPageClosed");
        }
    }
}
