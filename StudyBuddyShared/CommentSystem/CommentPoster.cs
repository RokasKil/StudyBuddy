using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CommentSystem
{
    public class CommentPoster : CommentManagerBase, ICommentPoster
    {
        public CommentPoster(LocalUser user) : this(user.PrivateKey)
        {
        }

        public CommentPoster(string privateKey) : base(privateKey)
        {
            manager.PostCommentResult = (status, comment) =>
            {
                Result?.Invoke(EnumConverter.Convert<CommentManagerStatus>(status), comment);
            };
        }

        public CommentManagerDelegate Result { get; set; }

        public void PostComment(Comment comment)
        {
            manager.postComment(comment);
        }
    }
}
