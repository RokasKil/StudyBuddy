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

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestListPage : ContentPage
    {
        public ObservableCollection<HelpRequestModel> Items { get; set; }

        public HelpRequestListPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<HelpRequestModel>
            {};
            HelpRequestListGetter();

            HelpRequestList.ItemsSource = Items;
        }

        private void HelpRequestList_Refreshing(object sender, EventArgs e)
        {
            HelpRequestListGetter();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void HelpRequestListGetter()
        {
            new HelpRequestGetter(LocalUserManager.LocalUser, (status, requests, users) =>
            {
                if (status == HelpRequestGetter.GetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
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
                        HelpRequestList.IsRefreshing = false;
                        //HelpRequestList.ItemsSource = null;
                        //HelpRequestList.ItemsSource = Items;
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        HelpRequestList.IsRefreshing = false;
                    });
                }

            }).get(true);
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new HelpRequestAddPage()));
        }
    }
}
