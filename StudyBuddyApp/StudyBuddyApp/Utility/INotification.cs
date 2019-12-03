using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Utility
{
    // Interface for use with DependencyService
    public interface INotification
    {
        void BlockNotification(Object obj, Conversation conversation);
        void AllowNotifcation(Object obj, Conversation conversation);

        void DisplayMessageNotification(Conversation conversation, Message message, Dictionary<string, User> users);
    }
}
