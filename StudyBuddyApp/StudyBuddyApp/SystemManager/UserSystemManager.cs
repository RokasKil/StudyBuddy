using StudyBuddyShared.UserSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.SystemManager
{
    public static class UserSystemManager // Returns implementations of interfaces
    {
        public static IUserGetter UserGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new UserGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IUserUpdater UserUpdater()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new UserUpdater(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IUserProfilePictureUpdater UserProfilePictureUpdater()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new UserProfilePictureUpdater(LocalUserManager.LocalUser);
            }
            return null;
        }
    }
}
