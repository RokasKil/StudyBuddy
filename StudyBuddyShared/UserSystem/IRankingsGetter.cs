using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserSystem
{
    public enum RankingsGetStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FieldsMissing
    }

    public delegate void GetRankingsDelegate(RankingsGetStatus status, List<User> users);
    public interface IRankingsGetter : IPrivateKey
    {
        GetRankingsDelegate Result { get; set; } // Result delegate

        void Get();
    }
}
