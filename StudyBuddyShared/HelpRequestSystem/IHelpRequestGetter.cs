using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.HelpRequestSystem
{
    public enum HelpRequestGetStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FieldsMissing
    }

    public delegate void GetHelpRequestsDelegate(HelpRequestGetStatus status, List<HelpRequest> helpRequests, Dictionary<string, User> users);

    public interface IHelpRequestGetter : IPrivateKey
    {
        GetHelpRequestsDelegate Result { get; set; } // Result delegate

        void Get(bool getUsers = true); // Get help requests, if getUsers == true then it will also get a dictionary of users
    }
}
