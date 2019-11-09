using StudyBuddy.Entity;
using StudyBuddyApp.Models;
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
            //ConversationListView.IsRefreshing = true;
            ConversationListView_Refreshing(null, null);
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
                        this.users = users;
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
            await Navigation.PushModalAsync(
                new NavigationPage(
                    new ConversationPage(
                        new ViewModels.ConversationViewModel(((ConversationModel)e.Item).Conversation, users))));
                
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<IToast>().LongToast(((ViewCell)sender).View.Height.ToString());
            
        }
    }
}
