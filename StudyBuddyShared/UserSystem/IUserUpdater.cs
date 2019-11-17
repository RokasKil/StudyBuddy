using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserSystem
{
    public enum UserUpdateStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FailedToFindUser,
        UsernameEmpty,
        FieldsMissing,
        InvalidValues
    }

    public delegate void UpdateUserResultDelegate(UserUpdateStatus status, string firstName, string lastName);

    public interface IUserUpdater : IPrivateKey
    {
        UpdateUserResultDelegate Result { get; set; } // Result delegate

        void Update(string firstName, string lastName); // Update username and password info
    }
}
