using StudyBuddy.Network;
using StudyBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddy.Entity;


namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestAddPage : ContentPage
    {
        public ObservableCollection<CategorieModel> Items { get; set; }

        HelpRequestModel requestModel;

        public HelpRequestAddPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<CategorieModel>
            { };
            CategorieListGetter();

            BindingContext = requestModel = new HelpRequestModel();
            CategoryList.ItemsSource = Items;
        }

        private void CategorieListGetter()
        {
            new CategoriesGetter(LocalUserManager.LocalUser, (status, categories) =>
            {
                if (status == CategoriesGetter.GetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
                        categories.ForEach(categorie =>
                        {
                            Items.Add(new CategorieModel
                            {
                                Title = categorie.Title,
                                category = categorie,
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
            

        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


    }
}