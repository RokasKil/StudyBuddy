using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static StudyBuddy.Network.ConversationGetter;

namespace StudyBuddyShared.ConversationSystems
{
    public delegate void GetConversationsDelegate(GetStatus status, List<Conversation> conversations, Dictionary<string, User> users);

    public interface IConversationGetter : IPrivateKey
    {
        GetConversationsDelegate GetConversationsResult { get; set; } // Result delegate

        bool GetUsers { get; set; } // Should get the user dictionary

        void GetConversations();    // Gets conversations
    }
}
