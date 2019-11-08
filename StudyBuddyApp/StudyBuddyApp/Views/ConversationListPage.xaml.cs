using StudyBuddyApp.Models;
using StudyBuddyShared.ConversationSystems;
using StudyBuddyShared.Utility.Extensions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static StudyBuddy.Network.ConversationGetter;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationListPage : ContentPage
    {
        public ObservableCollection<ConversationModel> Items { get; set; }

        public ConversationListPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<ConversationModel>
            {
                new ConversationModel{Title = "Vardas", LastMessage = "Žinutė", Date = "Data", ImageLocation = "https://img.webmd.com/dtmcms/live/webmd/consumer_assets/site_images/article_thumbnails/video/caring_for_your_kitten_video/650x350_caring_for_your_kitten_video.jpg"}
            };
			
			ConversationListView.ItemsSource = Items;
        }

        private void ConversationListView_Refreshing(object sender, EventArgs e)
        {
            IConversationGetter getter = ConversationSystemManager.NewConversationGetter();
            getter.GetConversationsResult += (status, conversations, users) =>
            {
                if (status == GetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
                        conversations.ForEach(conversation =>
                        {
                            Items.Add(new ConversationModel
                            {
                                Title = users[conversation.Users[0]].FirstName + " " + users[conversation.Users[0]].LastName,
                                LastMessage = conversation.LastMessage,
                                Date = DateTimeOffset.FromUnixTimeSeconds(conversation.LastActivity / 1000).LocalDateTime.ToFullDate(),
                                Conversation = conversation,
                                ImageLocation = users[conversation.Users[0]].ProfilePictureLocation
                            });
                        });
                        ConversationListView.IsRefreshing = false;
                        //HelpRequestList.ItemsSource = null;
                        //HelpRequestList.ItemsSource = Items;
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        ConversationListView.IsRefreshing = false;
                    });
                }
            };
            getter.GetConversations();
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
