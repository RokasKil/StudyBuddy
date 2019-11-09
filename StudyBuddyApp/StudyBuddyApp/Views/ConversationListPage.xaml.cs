using StudyBuddy.Entity;
using StudyBuddyApp.Models;
using StudyBuddyApp.Services;
using StudyBuddyApp.Utility;
using StudyBuddyShared.ConversationSystems;
using StudyBuddyShared.Utility.Extensions;
using System;
using System.Collections.Generic;
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
            MessagingCenter.Subscribe<MessagingTask, Tuple<Dictionary<int, List<Message>>, Dictionary<string, User>>>(this, MessagingTask.Messages, (task, tuple) =>
            {
                //This might be a bit expensive (probably very expensive)
                ConversationListView_Refreshing(null, null);
            });
        }

        private void ConversationListView_Refreshing(object sender, EventArgs e)
        {
            //Gets conversations
            MessagingCenter.Subscribe<MessagingTask, Tuple<List<Conversation>, Dictionary<string, User>>>(this, MessagingTask.LocalConversations, (obj, tuple) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //Handles the response
                    var conversations = tuple.Item1;
                    //DependencyService.Get<IToast>().LongToast("Loaded " + conversations.Count);
                    users = tuple.Item2;
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
                    MessagingCenter.Unsubscribe<MessagingTask, Tuple<List<Conversation>, Dictionary<string, User>>>(this, MessagingTask.LocalConversations);

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
            await Navigation.PushModalAsync(
                new NavigationPage(
                    new ConversationPage(
                        new ViewModels.ConversationViewModel(((ConversationModel)e.Item).Conversation, users))));
                
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
