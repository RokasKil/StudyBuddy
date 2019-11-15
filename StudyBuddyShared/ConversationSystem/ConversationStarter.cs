using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.ConversationSystem
{

    class ConversationStarter : IConversationStarter, IPrivateKey
    {
        public ConversationStarter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public ConversationStarter(string privateKey)
        {
            this.PrivateKey = privateKey;
        }

        public string PrivateKey { get; set; }

        public StartConversationDelegate Result { get; set; }

        public void StartConversation(string username)
        {
            new StudyBuddyShared.Network.ConversationStarter(PrivateKey, (status, conversation, users) =>
            {
                Result?.Invoke(EnumConverter.Convert<ConversationStartStatus>(status), conversation, users);
            }).start(username);
        }
    }
}
