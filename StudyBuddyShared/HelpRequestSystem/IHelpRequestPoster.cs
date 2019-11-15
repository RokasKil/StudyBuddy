using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.HelpRequestSystem
{
    public enum HelpRequestManageStatus
    {
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        TitleMissing,
        DescriptionMissing,
        CategoryMissing,
        FailedToFindCategory,
        FieldsMissing,
        FailedToFindHelpRequest     // Failed to find the helpRequest you were going to delete (or it doesn't belong to you)
    }

    public delegate void HelpRequestManagerDelegate(HelpRequestManageStatus status, HelpRequest helpRequest);

    public interface IHelpRequestPoster : IPrivateKey
    {
        HelpRequestManagerDelegate Result { get; set; }  // Result delegate

        void Post(HelpRequest helpRequest); // Post HelpRequest
    }
}
