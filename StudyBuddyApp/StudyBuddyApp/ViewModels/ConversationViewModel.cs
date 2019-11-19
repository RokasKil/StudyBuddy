using StudyBuddyShared.Entity;
using StudyBuddyShared.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class ConversationViewModel : BaseViewModel
    {
        public Conversation Conversation { get; set; }
        public Dictionary<string, User> Users { get; set; }
        public string ImageLocation { get; set; }
        public ConversationViewModel(Conversation conversation, Dictionary<string, User> users)
        {
            this.Conversation = conversation;
            this.Users = users;
            this.Title = users[conversation.Users[0]].FirstName + " " + users[conversation.Users[0]].LastName;
            this.ImageLocation = users[conversation.Users[0]].ProfilePictureLocation;
            Users[LocalUserManager.LocalUser.Username] = LocalUserManager.LocalUser;
        }
    }
}
