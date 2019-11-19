using StudyBuddyShared.UserReviewSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.SystemManager
{
    public static class UserReviewSystemManager // Returns implementations of interfaces
    {
        public static IUserReviewGetter NewUserReviewGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new UserReviewGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IUserReviewPoster NewUserReviewPoster()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new UserReviewPoster(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static IUserReviewRemover NewUserReviewRemover()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new UserReviewRemover(LocalUserManager.LocalUser);
            }
            return null;
        }
    }
}
