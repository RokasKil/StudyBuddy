using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static StudyBuddy.Network.ConversationStarter;

namespace StudyBuddyShared.ConversationSystems
{
    public delegate void StartConversationDelegate(ConversationStatus status, Conversation conversation, Dictionary<string, User> users);

    public interface IConversationStarter
    {
        StartConversationDelegate StartConversationResult { get; set; }

        void StartConversation(string username);
    }
}
