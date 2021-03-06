﻿using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CommentSystem
{
    public enum CommentGetStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FieldsMissing
    }

    public delegate void GetCommentDelegate(CommentGetStatus status, List<Comment> comments, Dictionary<string, User> users);

    public interface ICommentGetter : IPrivateKey
    {
        GetCommentDelegate Result { get; set; } // Result delegate

        void Get(int helpRequestID, bool getUsers = true); //Get comments
    }
}
