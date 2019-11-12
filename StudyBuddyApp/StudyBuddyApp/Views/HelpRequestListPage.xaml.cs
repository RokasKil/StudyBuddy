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

        private readonly IList<User> HelpRequestModels = new List<User>();
        public HelpRequestListPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<HelpRequestModel>
            {
                new HelpRequestModel{ Title = "Matematines Logikos Kolis", Description = "Kaip is kolio surinkti maksimalu invertinima? Mock Mock Mock Mock Mock Mock", Name = "Pukis Pukinskas", Category = "Matematine Logika", Date = "12/12/2019" },
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
                            HelpRequestModels.Add(users[request.CreatorUsername]);
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
            var user = HelpRequestModels.ToList().Find(x => x.Username == selectedItem.HelpRequest.CreatorUsername);
            
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(new NavigationPage(new HelpRequestViewPage(new HelpRequestViewPageModel(user, selectedItem))));
        }
    }
}
