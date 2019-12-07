using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CommentSystem
{
    public interface ICommentRemover : IPrivateKey
    {
        CommentManagerDelegate Result { get; set; } // Return delegate

        void RemoveComment(Comment comment); // Remove category
    }
}
