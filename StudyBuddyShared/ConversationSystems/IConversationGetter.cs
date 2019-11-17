﻿using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.ConversationSystems
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
        GetConversationsDelegate GetConversationsResult { get; set; } // Result delegate

        bool GetUsers { get; set; } // Should get the user dictionary

        void GetConversations();    // Gets conversations
    }
}