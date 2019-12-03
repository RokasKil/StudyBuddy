using StudyBuddyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Utility
{
    public interface INotificationStart
    {
        ConversationViewModel GetStartModel();
    }
}
