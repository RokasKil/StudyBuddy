using StudyBuddy.Entity;
using StudyBuddyShared.Network;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StudyBuddyShared.ConversationSystems
{
    class MessageGetter : IMessageGetter
    {
        public MessageGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public MessageGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
        }

        public string PrivateKey { get; set; }

        public bool WaitingCall { get; set; } = true;

        public MessageGetDelegate GetMessageResult { get; set; }

        public bool Getting { get; private set; } = false;

        public int TimeBetweenCalls { get; set; } = 0;

        public bool GetUsers { get; set; } = true;

        public long TimeStamp { get; set; } = 0;

        public int TimeBetweenFailedCalls { get; set; } = 250;

        private AllMessageGetter getter;

        public bool GetMessages()
        {
            if (getter == null)
            {
                new AllMessageGetter(PrivateKey, (status, conversations, messages, users) =>
                {
                    GetMessageResult?.Invoke(EnumConverter.Convert<MessageGetAllStatus>(status), conversations, messages, users);
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
                getter = new AllMessageGetter(PrivateKey, MessageGetterDelegate);
            }
            else
            {
                getter = null;
            }
            if(conversations != null && conversations.Count > 0)
                TimeStamp = conversations[conversations.Count - 1].LastActivity;
            GetMessageResult?.Invoke(EnumConverter.Convert<MessageGetAllStatus>(status), conversations, messages, users);
            if (status != AllMessageGetter.MessageStatus.Success)
            {
                Thread.Sleep(TimeBetweenFailedCalls);
            }
            else
            {
                Thread.Sleep(TimeBetweenCalls);
            }
            getter?.get(TimeStamp, GetUsers, WaitingCall);
        }

        public bool StartGetting()
        {
            if (!Getting)
            {
                Getting = true;
                if (getter == null)
                {
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
    }
}