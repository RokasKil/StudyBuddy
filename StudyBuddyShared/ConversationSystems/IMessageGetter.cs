using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static StudyBuddyShared.Network.AllMessageGetter; // Fix this maybe

namespace StudyBuddyShared.ConversationSystems
{
    public delegate void MessageGetDelegate(MessageStatus status, List<Conversation> conversations, Dictionary<int, List<Message>> messages, Dictionary<string, User> users);

    public interface IMessageGetter
    {
        MessageGetDelegate GetMessageResult { get; set; }

        bool WaitingCall { get; set; } //  Timesout after a minute

        bool GetUsers { get; set; } // Should get user profiles alongside messages

        int TimeBetweenCalls { get; set; }

        long TimeStamp { get; set; }

        bool Getting { get; }
        
        bool StartGetting();

        bool StopGetting();
        
        bool GetMessages(); // Get once
    }
}
