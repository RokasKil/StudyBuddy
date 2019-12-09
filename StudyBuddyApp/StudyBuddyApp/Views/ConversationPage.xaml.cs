using StudyBuddyShared.Entity;
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
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyShared.SystemManager;

namespace StudyBuddyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConversationPage : ContentPage
	{

        ConversationViewModel viewModel;
        public ObservableCollection<MessageModel> Items { get; set; }

        private bool lastVisible = true;

        private long sendEditorLastFocused = 0;

        private bool updatingItems = false;

        private bool gotAllHistory = false;

        public ConversationPage(ConversationViewModel viewModel)
        {
            InitializeComponent();
            if (!viewModel.Users.ContainsKey(LocalUserManager.LocalUser.Username))
            {
                viewModel.Users[LocalUserManager.LocalUser.Username] = LocalUserManager.LocalUser;
            }
            BindingContext = this.viewModel = viewModel;
            Items = new ObservableCollection<MessageModel>
            {

            };
            MessageListView.ItemsSource = Items;
            //Listens messages already loaded
            MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.LocalMessagesLimited, (task)=>
            {
                //Adds them to the list
                MessageRecieverLimited(task);

                //Stops listening
                MessagingCenter.Unsubscribe<MessagingTask>(this, MessagingTask.LocalMessagesLimited);

                MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.LocalMessagesLimited, MessageRecieverLimited);

                //Starts listening for new messages
                MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.NewMessages, MessageReciever);
                MessageListView.ScrollTo(Items.LastOrDefault(), ScrollToPosition.End, false);
            });
            //Ask for messages already loaded
            GetMoreHistory();


        }

        private void GetMoreHistory()
        {
            //Gauti daugiau jau turimų pranešimų
            var task = new MessagingTask();
            task.GetCount = 20;
            task.Message = (Items.Count == 0 ? null : Items.First().MessageObject);
            task.Conversation = viewModel.Conversation;
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MessagingCenter.Send(task, MessagingTask.GetMessagesLimited);
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //Handles messages from messaging service
        public void MessageReciever(MessagingTask task)
        {
            var messages = task.MessagesDict;
            var users = task.Users;
            users[LocalUserManager.LocalUser.Username] = LocalUserManager.LocalUser;
            if (messages.ContainsKey(viewModel.Conversation.Id))
            {
                ParseMessage(messages[viewModel.Conversation.Id], users);
            }
        }
        //Handles messages from messaging service after GetMoreHistory() is called
        public void MessageRecieverLimited(MessagingTask task)
        {
            if(task.Conversation.Id != viewModel.Conversation.Id)
            {
                return;
            }
            Console.WriteLine("Starting adding");
            var topMessage = Items.Count >= 2 ? Items[1] : Items.FirstOrDefault();
            Console.WriteLine(topMessage == null);
            var messages = task.Messages;
            if(messages.Count == 0 || messages[0].Conversation != viewModel.Conversation.Id)
            {
                gotAllHistory = true;
                return;
            }
            var users = task.Users;
            users[LocalUserManager.LocalUser.Username] = LocalUserManager.LocalUser;
            updatingItems = true;
            ParseMessage(messages, users, true);
            updatingItems = false;

            if (topMessage != null && !lastVisible)
            {
                MessageListView.ScrollTo(topMessage, ScrollToPosition.MakeVisible, false);
            }
            else
            {
                MessageListView.ScrollTo(Items.LastOrDefault(), ScrollToPosition.End, false);
            }
            Console.WriteLine("Stopping adding");
        }

        //Adds messages to the list
        public void ParseMessage(List<Message> messages, Dictionary<string, User> users, bool reverse = false) 
        {
            
            MessageListView.BatchBegin();
            int i = 0;
            messages.ForEach(message =>
            {
                var model = new MessageModel
                {
                    Message = message.Text,
                    Name = viewModel.Users[message.Username].FirstName,
                    Date = message.Timestamp.ToFullDate(),
                    RightSide = (message.Username == LocalUserManager.LocalUser.Username),
                    MessageObject = message
                };
                //Ar į pabaigą ar į pradžią dėti pranešimus
                if (reverse)
                {
                    Items.Insert(i, model);
                    i++;
                }
                else
                {
                    Items.Add(model);
                }
            });
            
            //Scrolls to the end if at the bottom (kinda, I did my best)
            if (lastVisible)
            {
                MessageListView.ScrollTo(Items.LastOrDefault(), ScrollToPosition.End, false);
            }
            MessageListView.BatchCommit();
        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {
            //Sends the message to messaging service
            MessagingCenter.Send(
                new MessagingTask(message: new Message { Conversation = viewModel.Conversation.Id, Text = SendEditor.Text }),
                MessagingTask.AddMessageToQueue);
            SendEditor.Text = "";
            //If SendEditor was last focused within half a second refocus it

        }

        //For checking if last element is visible and if it should scroll down when a new message
        private void MessageListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.ItemIndex == 0 && !updatingItems && !gotAllHistory)
            {
                Console.WriteLine("First one appeared");
                GetMoreHistory();
            }
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

        //Disable item selecting
        private void MessageListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessageListView.SelectedItem = null;
        }

        //Pranešama kad puslapis užsidarė
        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ChatClosed");
            DependencyService.Get<INotification>().AllowNotifcation(this, viewModel.Conversation);
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            DependencyService.Get<INotification>().BlockNotification(this, viewModel.Conversation);
        }
    }
}