using StudyBuddy.Entity;
using StudyBuddyApp.Models;
using StudyBuddyApp.Services;
using StudyBuddyApp.Utility;
using StudyBuddyApp.ViewModels;
using StudyBuddyShared.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyBuddyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConversationPage : ContentPage
	{

        ConversationViewModel viewModel;
        public ObservableCollection<MessageModel> Items { get; set; }

        private bool lastVisible = true;

        private long sendEditorLastFocused = 0;

        public ConversationPage(ConversationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            Items = new ObservableCollection<MessageModel>
            {

            };
            MessageListView.ItemsSource = Items;
            //Listens messages already loaded
            MessagingCenter.Subscribe<MessagingTask, Tuple<Dictionary<int, List<Message>>, Dictionary <string, User>>>(this, MessagingTask.LocalMessages, (obj, tuple) =>
            {
                //Adds them to the list
                MessageReciever(obj, tuple);
                //Stops listening
                MessagingCenter.Unsubscribe<MessagingTask, Tuple<Dictionary<int, List<Message>>, Dictionary<string, User>>>(this, MessagingTask.LocalMessages);
                //Starts listening for new messages
                MessagingCenter.Subscribe<MessagingTask, Tuple<Dictionary<int, List<Message>>, Dictionary<string, User>>>(this, MessagingTask.Messages, MessageReciever);
                MessageListView.ScrollTo(Items.LastOrDefault(), ScrollToPosition.End, false);
            });
            //Ask for messages already loaded
            MessagingCenter.Send(new MessagingTask(), MessagingTask.GetMessages);

        }

        //Handles messages from messaging service
        public void MessageReciever(MessagingTask task, Tuple<Dictionary<int, List<Message>>, Dictionary<string, User>> tuple)
        {
            var messages = tuple.Item1;
            var users = tuple.Item2;
            users[LocalUserManager.LocalUser.Username] = LocalUserManager.LocalUser;
            if (messages.ContainsKey(viewModel.Conversation.Id))
            {
                ParseMessage(messages[viewModel.Conversation.Id], users);
            }
        }

        public void ParseMessage(List<Message> messages, Dictionary<string, User> users) 
        {
            //Adds messages to the list
            messages.ForEach(message =>
            {
                Items.Add(new MessageModel
                {
                    Message = message.Text,
                    Name = viewModel.Users[message.Username].FirstName,
                    Date = message.Timestamp.ToFullDate(),
                    RightSide = (message.Username == LocalUserManager.LocalUser.Username)
                });
            });
            //Scrolls to the end if at the bottom (kinda, I did my best)
            if(lastVisible)
            {
                MessageListView.ScrollTo(Items.LastOrDefault(), ScrollToPosition.End, false);
            }
        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {
            //Sends the message to messaging service
            MessagingCenter.Send(new MessagingTask(), MessagingTask.AddMessageToQueue, new Message
            {
                Conversation = viewModel.Conversation.Id,
                Text = SendEditor.Text
            });
            SendEditor.Text = "";
            //If SendEditor was last focused within half a second refocus it

        }

        //For checking if last element is visible and if it should scroll down when a new message
        private void MessageListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item.Equals(Items.LastOrDefault()))
            {
                lastVisible = true;
            }
        }

        private void MessageListView_ItemDisappearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item.Equals(Items.LastOrDefault()))
            {
                lastVisible = false;
            }
        }

        private void SendEditor_Unfocused(object sender, FocusEventArgs e)
        {
            sendEditorLastFocused = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        private void FakeEntry_Focused(object sender, FocusEventArgs e)
        {
            //Send message and refocus if needed
            SendButton_Clicked(null, null);
            if (sendEditorLastFocused + 500 >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
            {
                SendEditor.Focus();
            }
            else
            {
                FakeEntry.Unfocus();
            }
        }
    }
}