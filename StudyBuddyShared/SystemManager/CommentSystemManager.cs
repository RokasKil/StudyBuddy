using StudyBuddyShared.CommentSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.SystemManager
{
    public static class CommentSystemManager// Returns implementations of interfaces
    {
        public static ICommentGetter NewCommentGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new CommentGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static ICommentPoster NewCommentPoster()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new CommentPoster(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static ICommentRemover NewCommentRemover()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new CommentRemover(LocalUserManager.LocalUser);
            }
            return null;
        }
    }
}
