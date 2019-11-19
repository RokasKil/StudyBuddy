using StudyBuddyShared.HelpRequestSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.SystemManager
{
    public static class HelpRequestSystemManager  // Returns implementations of interfaces
    {
        public static IHelpRequestGetter NewHelpRequestGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new HelpRequestGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IHelpRequestPoster NewHelpRequestPoster()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new HelpRequestPoster(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IHelpRequestRemover NewHelpRequestRemover()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new HelpRequestRemover(LocalUserManager.LocalUser);
            }
            return null;
        }
    }
}
