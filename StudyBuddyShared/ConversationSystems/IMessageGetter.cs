using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.ConversationSystems
{

    public enum MessageGetAllStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FieldsMissing,
        ConversationNotFound
    }

    public delegate void MessageGetDelegate(MessageGetAllStatus status, List<Conversation> conversations, Dictionary<int, List<Message>> messages, Dictionary<string, User> users);

    public interface IMessageGetter : IPrivateKey
    {
        MessageGetDelegate GetMessageResult { get; set; } // Result delegate

        bool WaitingCall { get; set; } //  Should wait until timeout or new message (Timesouts after a minute)

        bool GetUsers { get; set; } // Should get user profiles alongside messages

        int TimeBetweenCalls { get; set; } // How long between calls

        int TimeBetweenFailedCalls { get; set; } // How long between failed calls

        long TimeStamp { get; set; } // Current timestamp, auto updates on new message   

        bool Getting { get; } // Is active
        
        bool StartGetting(); // Start getting messages

        bool StopGetting();  // Stop getting messages
        
        bool GetMessages(); // Get once
    }
}
