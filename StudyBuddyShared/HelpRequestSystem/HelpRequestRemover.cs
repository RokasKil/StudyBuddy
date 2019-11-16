using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.HelpRequestSystem
{
    class HelpRequestRemover : HelpRequestManagerBase, IHelpRequestRemover
    {
        public HelpRequestRemover(LocalUser user) : this(user.PrivateKey)
        {
        }

        public HelpRequestRemover(string privateKey) : base(privateKey)
        {
            manager.RemoveHelpRequestResult = (status, helpRequest) =>
            {
                Result?.Invoke(EnumConverter.Convert<HelpRequestManageStatus>(status), helpRequest);
            };
        }

        public HelpRequestManagerDelegate Result { get; set; }

        public void Remove(HelpRequest helpRequest)
        {
            manager.removeHelpRequest(helpRequest);
        }
    }
}
