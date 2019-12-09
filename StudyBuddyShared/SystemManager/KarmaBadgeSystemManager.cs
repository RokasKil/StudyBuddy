using StudyBuddyShared.KarmaBadgeSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.SystemManager
{
    public static class KarmaBadgeSystemManager // Returns implementations of interfaces
    {
        public static IKarmaBadgeGetter NewKarmaBadgeGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new KarmaBadgeGetter(LocalUserManager.LocalUser);
            }
            return null;
        }
        public static IKarmaBadgeListGetter NewKarmaBadgeListGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new KarmaBadgeListGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

    }
}
