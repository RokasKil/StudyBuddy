using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Models
{
    public enum MenuItemType
    {
        Profile,
        LogOut,
        CategoryList,
        HelpRequestList,
        SettingsPage,
        ConversationListPage,
        HelpRequestAddPage
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
