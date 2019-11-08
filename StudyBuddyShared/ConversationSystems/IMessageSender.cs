using System;
using System.Collections.Generic;
using System.Text;

using StudyBuddy.Entity;
using static StudyBuddy.Network.MessagePoster; // Fix this maybe

namespace StudyBuddyShared.ConversationSystems
{
    public delegate void MessagePostDelegate(MessageStatus status, Message message);

    public interface IMessageSender
    {
        Queue<Message> Queue { get; set; } 

        bool RetryOnFail { get; set; }
        
        int RetryInterval { get; set; } // Miliseconds

        bool Sending { get; }

        bool StartSending();

        bool StopSending();

        MessagePostDelegate PostMessageResult { get; set; }

        void AddMessageToQueue(Message message);

    }
}
