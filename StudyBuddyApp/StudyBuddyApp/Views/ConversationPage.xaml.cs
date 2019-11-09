using StudyBuddyApp.Models;
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

        public ConversationPage(ConversationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            Items = new ObservableCollection<MessageModel>
            {
                new MessageModel{Message = "žinutė goes here", Date = DateTime.Now.ToFullDate(), Name = "Vardenis", RightSide = false},
                new MessageModel{Message = "žinutė goes here", Date = DateTime.Now.ToFullDate(), Name = "Vardenis1", RightSide = true},
                //new MessageModel{Message = "žinutė goes here ilga labai ciailga labai ciailga labai cia", Date = DateTime.Now.ToFullDate(), Name = "Vardenis2", RightSide = false},
                //new MessageModel{Message = "žinutė goes here", Date = DateTime.Now.ToFullDate(), Name = "Vardenis3", RightSide = false},
                //new MessageModel{Message = "žinutė goes here", Date = DateTime.Now.ToFullDate(), Name = "Vardenis4", RightSide = true},
                //new MessageModel{Message = "žinutė goes hereilga labai ciailga labai ciailga labai ciailga labai cia", Date = DateTime.Now.ToFullDate(), Name = "Vardenis5", RightSide = true},
            };
            MessageListView.ItemsSource = Items;
            var getter = ConversationSystemManager.NewMessageGetter();

            getter.GetMessageResult += (status, conversations, messages, users) => {
                Device.BeginInvokeOnMainThread(() => {
                    if (status == StudyBuddyShared.Network.AllMessageGetter.MessageStatus.Success)
                    {
                        if (messages.ContainsKey(viewModel.Conversation.Id))
                        {
                            messages[viewModel.Conversation.Id].ForEach(message =>
                            {
                                Items.Add(new MessageModel {
                                    Message = message.Text,
                                    Name = viewModel.Users[message.Username].FirstName,
                                    Date = message.Timestamp.ToFullDate(),
                                    RightSide = (message.Username == LocalUserManager.LocalUser.Username)
                                });
                            });
                        }
                    }
                });
            };
            getter.GetUsers = false;
            getter.StartGetting();

            //this.SetBinding(viewModel);
        }
	}
}