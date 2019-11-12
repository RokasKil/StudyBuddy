using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudyBuddy.Entity;
using StudyBuddy.Network;
using StudyBuddyApp.Models;
using StudyBuddyApp.ViewModels;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestListPage : ContentPage
    {
        public ObservableCollection<HelpRequestModel> Items { get; set; }

        private Dictionary<string, User> users = null;
        public HelpRequestListPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<HelpRequestModel>
            {
            };
			HelpRequestList.ItemsSource = Items;
            HelpRequestList.IsRefreshing = true;
            HelpRequestList_Refreshing(null, null);
        }

        private void HelpRequestList_Refreshing(object sender, EventArgs e)
        {
            new HelpRequestGetter(LocalUserManager.LocalUser, (status, requests, users) =>
            {
                if (status == HelpRequestGetter.GetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
                        this.users = users;
                        requests.ForEach(request =>
                        {
                            var helpRequestModel = new HelpRequestModel
                            {
                                Title = request.Title,
                                Description = request.Description,
                                Name = users[request.CreatorUsername].FirstName + " " + users[request.CreatorUsername].LastName,
                                Category = request.Category,
                                Date = request.Timestamp.ToLongDateString(),
                                HelpRequest = request
                            };
                            
                            Items.Add(helpRequestModel);
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
    }
}
