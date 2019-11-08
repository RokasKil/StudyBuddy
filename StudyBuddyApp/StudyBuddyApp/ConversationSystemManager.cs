using StudyBuddyShared.ConversationSystems;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp
{
    public static class ConversationSystemManager
    {
        static public IConversationGetter NewConversationGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new ConversationGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        static public IConversationStarter NewConversationStarter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new ConversationStarter(LocalUserManager.LocalUser);
            }
            return null;
        }

        static public IMessageGetter NewMessageGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new MessageGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        static public IMessageSender NewMessageSender()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new MessageSender(LocalUserManager.LocalUser);
            }
            return null;
        }
    }
}
