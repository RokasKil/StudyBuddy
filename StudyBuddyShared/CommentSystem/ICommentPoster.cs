using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CommentSystem
{
    public enum CommentManagerStatus
    {
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        TitleMissing,
        FieldsMissing
    }

    public delegate void CommentManagerDelegate(CommentManagerStatus status, Comment comment);

    public interface ICommentPoster : IPrivateKey
    {
        CommentManagerDelegate Result { get; set; } // Return delegate

        void PostComment(Comment comment); // Add category
    }
}
