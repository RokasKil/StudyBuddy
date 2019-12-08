using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CommentSystem
{
    class CommentRemover : CommentManagerBase, ICommentRemover
    {
        public CommentRemover(LocalUser user) : this(user.PrivateKey)
        {
        }

        public CommentRemover(string privateKey) : base(privateKey)
        {
            manager.RemoveCommentResult = (status, helpRequest) =>
            {
                Result?.Invoke(EnumConverter.Convert<CommentManagerStatus>(status), helpRequest);
            };
        }

        public CommentManagerDelegate Result { get; set; }

        public void RemoveComment(Comment comment)
        {
            manager.removeComment(comment);
        }
    }
}
