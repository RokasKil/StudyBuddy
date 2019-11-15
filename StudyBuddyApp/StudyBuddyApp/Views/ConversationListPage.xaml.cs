using StudyBuddyShared.Entity;
using StudyBuddyApp.Models;
using StudyBuddyApp.Services;
using StudyBuddyApp.Utility;
using StudyBuddyShared.ConversationSystem;
using StudyBuddyShared.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationListPage : ContentPage
    {
        public ObservableCollection<ConversationModel> Items { get; set; }

        public bool ChatOpen { get; set; } = false;

        Dictionary<string, User> users;
        public ConversationListPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<ConversationModel>
            {
                //new ConversationModel{Title = "Vardas", LastMessage = "Žinutė", Date = "Data", ImageLocation = "https://img.webmd.com/dtmcms/live/webmd/consumer_assets/site_images/article_thumbnails/video/caring_for_your_kitten_video/650x350_caring_for_your_kitten_video.jpg"}
            };
			
			ConversationListView.ItemsSource = Items;

            ConversationListView_Refreshing(null, null);
            MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.NewMessages, (task) =>
            {
                //This might be a bit expensive (probably very expensive)
                ConversationListView_Refreshing(null, null);
            });

            MessagingCenter.Subscribe<ConversationPage>(this, "ChatClosed", (page) =>
            {
                ChatOpen = false;
            });
        }

        private void ConversationListView_Refreshing(object sender, EventArgs e)
        {
            //Gets conversations
            MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.LocalConversations, (task) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //Handles the response
                    var conversations = task.Conversations;
                    //DependencyService.Get<IToast>().LongToast("Loaded " + conversations.Count);
                    users = task.Users;
                    this.users[LocalUserManager.LocalUser.Username] = LocalUserManager.LocalUser;
                    Items.Clear();
                    conversations.ForEach(conversation =>
                    {
                        Items.Add(new ConversationModel
                        {
                            Title = users[conversation.Users[0]].FirstName + " " + users[conversation.Users[0]].LastName,
                            LastMessage = conversation.LastMessage,
                            Date = conversation.LastActivity.ToFullDate(),
                            Conversation = conversation,
                            ImageLocation = users[conversation.Users[0]].ProfilePictureLocation
                        });
                    });
                    ConversationListView.IsRefreshing = false;
                    MessagingCenter.Unsubscribe<MessagingTask>(this, MessagingTask.LocalConversations);

                });
            });
            //Ask for conversations
            MessagingCenter.Send(new MessagingTask(), MessagingTask.GetConversations);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //If item is tapped opens the chat for it
            if (e.Item == null)
                return;
                
            ((ListView)sender).SelectedItem = null;
            if (ChatOpen)
            {
                
                return;
            }
            ChatOpen = true;
            await Navigation.PushModalAsync(
                new NavigationPage(
                    new ConversationPage(
                        new ViewModels.ConversationViewModel(((ConversationModel)e.Item).Conversation, users))));
            //Deselect Item
        }
    }
}
