using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.ConversationSystem
{
    public delegate void StartConversationDelegate(ConversationStartStatus status, Conversation conversation, Dictionary<string, User> users);

    public enum ConversationStartStatus
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

    public interface IConversationStarter : IPrivateKey
    {
        StartConversationDelegate StartConversationResult { get; set; } // Result delegate

        void StartConversation(string username); // Starts conversation with an user
    }
}
