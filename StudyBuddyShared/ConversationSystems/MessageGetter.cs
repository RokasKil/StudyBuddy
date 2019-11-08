﻿using StudyBuddy.Entity;
using StudyBuddyShared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.ConversationSystems
{
    class MessageGetter : IMessageGetter, IPrivateKey
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
        
        public int RetryInterval { get; set; } = 250;

        public int TimeBetweenCalls { get; set; } = 0;

        public bool GetUsers { get; set; } = true;

        public long TimeStamp { get; set; } = 0;

        private AllMessageGetter getter;

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
                getter = new AllMessageGetter(PrivateKey, MessageGetterDelegate);
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