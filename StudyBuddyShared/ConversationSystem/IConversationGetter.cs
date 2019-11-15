using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.ConversationSystem
{
    public enum ConversationGetStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FailedToFindUser,
        UsernameEmpty,
        FieldsMissing
    }

    public delegate void GetConversationsDelegate(ConversationGetStatus status, List<Conversation> conversations, Dictionary<string, User> users);

    public interface IConversationGetter : IPrivateKey
    {
        GetConversationsDelegate Result { get; set; } // Result delegate

        bool GetUsers { get; set; } // Should get the user dictionary

        void GetConversations();    // Gets conversations
    }
}
