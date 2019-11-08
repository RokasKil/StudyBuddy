using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static StudyBuddy.Network.MessageGetter; // Fix this maybe

namespace StudyBuddyShared.ConversationSystems
{
    public delegate void MessageGetDelegate(MessageStatus status, List<Conversation> conversations, Dictionary<int, List<Message>> messages, Dictionary<string, User> users);
    interface IMessageGetter
    {
        MessageGetDelegate GetMessageResult { get; set; }

        bool WaitingCall { get; } //Timesout after a minute

        bool Sending { get; }
        
        bool StartGetting();

        bool StopGetting();

        void GetMessages(); // Get once

        MessagePostDelegate PostMessageResult { get; set; }
    }
}
