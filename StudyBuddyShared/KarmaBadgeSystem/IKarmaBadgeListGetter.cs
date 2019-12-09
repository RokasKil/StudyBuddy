using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.KarmaBadgeSystem
{
    public enum KarmaBadgeListGetStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FieldsMissing
    }

    public delegate void GetKarmaBadgeListDelegate(KarmaBadgeListGetStatus status, List<KarmaBadge> karmaBadges);

    public interface IKarmaBadgeListGetter : IPrivateKey
    {
        GetKarmaBadgeListDelegate Result { get; set; } // Result delegate

        void Get(); //Get categories
    }
}
