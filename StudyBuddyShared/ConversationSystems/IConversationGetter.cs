using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static StudyBuddy.Network.ConversationGetter;

namespace StudyBuddyShared.ConversationSystems
{
    public delegate void GetConversationsDelegate(GetStatus status, List<Conversation> conversations, Dictionary<string, User> users);

    public interface IConversationGetter
    {
        GetConversationsDelegate GetConversationsResult { get; set; }

        bool GetUsers { get; set; }

        void GetConversations();
    }
}
