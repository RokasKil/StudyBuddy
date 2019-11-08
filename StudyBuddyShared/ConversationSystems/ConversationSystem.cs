using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using StudyBuddy.Entity;
using StudyBuddy.Network;
using StudyBuddyShared.Network;

namespace StudyBuddyShared.ConversationSystems
{
    public class ConversationSystem : IConversationSystem
    {


        public ConversationSystem(LocalUser user) : this(user.PrivateKey)
        {

        }

        public ConversationSystem(string privateKey)
        {
            this.PrivateKey = privateKey;
        }

        public string PrivateKey { get; set; }

        public MessageGetDelegate GetMessageResult { get; set; }

        public bool WaitingCall { get; set; } = true;

        public bool Sending { get; private set; } = false;

        public bool Getting { get; private set; } = false;

        public MessagePostDelegate PostMessageResult { get; set; }

        public Queue<Message> Queue { get; set; } = new Queue<Message>();

        public bool RetryOnFail { get; set; } = true;

        public int RetryInterval { get; set; } = 250;

        public int TimeBetweenCalls { get; set; } = 0;

        public bool GetUsers { get; set; } = true;

        public long TimeStamp { get; set; } = 0;

        private AllMessageGetter getter;

        private Message messageBeingSent;

        private MessagePoster poster;

        public void AddMessageToQueue(Message message)
        {
            Queue.Enqueue(message);
            if (Sending)
            {

            }
        }

        public bool GetMessages()
        {
            if (getter == null)
            {
                new AllMessageGetter(PrivateKey, (status, conversations, messages, users) =>
                {
                    GetMessageResult?.Invoke(status, conversations, messages, users);
                }).get(TimeStamp, GetUsers, WaitingCall);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void MessageGetterDelegate(AllMessageGetter.MessageStatus status, List<Conversation> conversations, Dictionary<int, List<Message>> messages, Dictionary<string, User> users)
        {
            if (Getting)
            {
                getter = new AllMessageGetter(privateKey, MessageGetterDelegate);
            }
            else
            {
                getter = null;
            }
            GetMessageResult?.Invoke(status, conversations, messages, users);
            getter?.get(TimeStamp, GetUsers, WaitingCall);
        }

        public bool StartGetting()
        {
            if (!Getting)
            {
                Getting = true;
                if (getter == null) { 
                    getter = new AllMessageGetter(PrivateKey, MessageGetterDelegate);
                    getter.get(TimeStamp, GetUsers, WaitingCall);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StopGetting()
        {
            if (Getting)
            {
                Getting = false;
                return true;
            }
            else
            {
                return false;
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
                PostMessageResult?.Invoke(status, messageBeingSent);
                if (Sending)
                {
                    sendEnqueuedMessage();
                }
            }
            else if(RetryOnFail) // Jei nepavyko
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
