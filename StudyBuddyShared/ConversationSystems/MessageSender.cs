using StudyBuddy.Entity;
using StudyBuddy.Network;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StudyBuddyShared.ConversationSystems
{
    class MessageSender : IMessageSender, IPrivateKey
    {
        public MessageSender(LocalUser user) : this(user.PrivateKey)
        {

        }

        public MessageSender(string privateKey)
        {
            this.PrivateKey = privateKey;
        }

        public string PrivateKey { get; set; }
       

        public bool Sending { get; private set; } = false;
        
        public MessagePostDelegate PostMessageResult { get; set; }

        public Queue<Message> Queue { get; set; } = new Queue<Message>();

        public bool RetryOnFail { get; set; } = true;

        public int RetryInterval { get; set; } = 250;

        private Message messageBeingSent;

        private MessagePoster poster;

        public void AddMessageToQueue(Message message)
        {
            Queue.Enqueue(message);
            if (Sending)
            {
                sendEnqueuedMessage();
            }
        }

        public bool StartSending()
        {
            if (!Sending)
            {
                Sending = true;
                sendEnqueuedMessage();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool StopSending()
        {
            if (Sending)
            {
                Sending = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MessagePosterDelegate(MessagePoster.MessageStatus status, Conversation conversation, string message)
        {
            //Console.Write(status +  " " + message + "\n");
            if (status == MessagePoster.MessageStatus.Success || status == MessagePoster.MessageStatus.ConversationNotFound || status == MessagePoster.MessageStatus.MessageEmpty)
            {
                //Success
                poster = null;
                PostMessageResult?.Invoke(EnumConverter.Convert<MessageSendStatus>(status), messageBeingSent);
                if (Sending)
                {
                    sendEnqueuedMessage();
                }
            }
            else if (RetryOnFail) // Jei nepavyko
            {
                Thread.Sleep(RetryInterval); // Palaukiam ir bandom išnaujo
                poster = new MessagePoster(PrivateKey, MessagePosterDelegate);
                poster.post(messageBeingSent.Conversation, messageBeingSent.Text);
                return;
            }

        }

        void sendEnqueuedMessage() // Siųst iš eilės
        {
            if (poster == null && Queue.Count > 0)
            {
                messageBeingSent = Queue.Dequeue();
                poster = new MessagePoster(PrivateKey, MessagePosterDelegate);
                poster.post(messageBeingSent.Conversation, messageBeingSent.Text);
            }
        }
    }
}
