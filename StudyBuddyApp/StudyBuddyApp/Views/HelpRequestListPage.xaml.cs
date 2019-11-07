using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudyBuddy.Entity;
using StudyBuddy.Network;
using StudyBuddyApp.Models;

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
            {
                new HelpRequestModel{ Title = "test1", Description = "sfdlk4dl", Name = "Shrekas", Category = "kategorija", Date = "61513ad5 a6d "  },
                new HelpRequestModel{ Title = "tesasdt2", Description = "sf3kdl", Name = "testas",  },
                new HelpRequestModel{ Title = "test3", Description = "sfd2lkdl", Name = "asdg" },
                new HelpRequestModel{ Title = "test4", Description = "sf1dlkdl", Name = "jljksd"  },
            };
			
			HelpRequestList.ItemsSource = Items;
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
                        requests.ForEach(request =>
                        {
                            Items.Add(new HelpRequestModel
                            {
                                Title = request.Title,
                                Description = request.Description,
                                Name = users[request.CreatorUsername].FirstName + " " + users[request.CreatorUsername].LastName,
                                Category = request.Category,
                                Date = request.Timestamp.ToLongDateString(),
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

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
