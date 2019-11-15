using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserSystem
{
    public enum UserGetStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FailedToFindUser,
        UsernameEmpty,
        FieldsMissing
    }

    public delegate void GetUserResultDelegate(UserGetStatus status, User user);

    public interface IUserGetter : IPrivateKey
    {
        GetUserResultDelegate Result { get; set; } // Result delegate

        void Get(string username); // Get user from username
    }
}
