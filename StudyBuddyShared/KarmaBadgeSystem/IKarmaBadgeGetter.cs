using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.KarmaBadgeSystem
{
    public enum KarmaBadgeGetStatus
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

    public delegate void GetKarmaBadgeResultDelegate(KarmaBadgeGetStatus status, KarmaBadge karmaBadge);
    public interface IKarmaBadgeGetter : IPrivateKey
    {
        GetKarmaBadgeResultDelegate Result { get; set; } // Result delegate

        void Get(string username); // Get user from username
    }
}
