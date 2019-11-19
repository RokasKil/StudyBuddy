using StudyBuddyShared.ConversationSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.SystemManager
{
    public static class ConversationSystemManager // Returns implementations of interfaces
    {
        public static IConversationGetter NewConversationGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new ConversationGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IConversationStarter NewConversationStarter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new ConversationStarter(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IMessageGetter NewMessageGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new MessageGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IMessageSender NewMessageSender()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new MessageSender(LocalUserManager.LocalUser);
            }
            return null;
        }
    }
}
