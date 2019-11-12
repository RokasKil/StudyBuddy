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

        public HelpRequestAddPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<CategorieModel>
            { };
            CategorieListGetter();
            CategorieList.ItemsSource = Items;
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
    }
}