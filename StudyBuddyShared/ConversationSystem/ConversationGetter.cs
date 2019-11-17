using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.ConversationSystem
{
    class ConversationGetter : IConversationGetter, IPrivateKey
    {
        public ConversationGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public ConversationGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
        }

        public GetConversationsDelegate Result { get; set; }

        public bool GetUsers { get; set; } = true;

        public string PrivateKey { get; set; }

        public void GetConversations()
        {
            new StudyBuddyShared.Network.ConversationGetter(PrivateKey, (status, conversations, users) =>
            {
                Result?.Invoke(EnumConverter.Convert<ConversationGetStatus>(status), conversations, users);
            }).get(GetUsers);
        }
    }
}
