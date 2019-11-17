using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.HelpRequestSystem
{
    public interface IHelpRequestRemover : IPrivateKey
    {
        HelpRequestManagerDelegate Result { get; set; } // Result delegate

        void Remove(HelpRequest helpRequest); // Remove HelpRequest
    }
}
