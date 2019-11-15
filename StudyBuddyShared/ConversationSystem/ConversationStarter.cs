using StudyBuddy.Entity;
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

        public StartConversationDelegate StartConversationResult { get; set; }

        public void StartConversation(string username)
        {
            new StudyBuddy.Network.ConversationStarter(PrivateKey, (status, conversation, users) =>
            {
                StartConversationResult?.Invoke(EnumConverter.Convert<ConversationStartStatus>(status), conversation, users);
            }).start(username);
        }
    }
}
