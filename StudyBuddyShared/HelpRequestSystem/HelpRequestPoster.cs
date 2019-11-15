using System;
using System.Collections.Generic;
using System.Text;
using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;

namespace StudyBuddyShared.HelpRequestSystem
{
    public class HelpRequestPoster : HelpRequestManagerBase, IHelpRequestPoster
    {
        public HelpRequestPoster(LocalUser user) : this(user.PrivateKey)
        {
        }

        public HelpRequestPoster(string privateKey) : base(privateKey)
        {
            manager.PostHelpRequestResult = (status, helpRequest) =>
            {
                Result?.Invoke(EnumConverter.Convert<HelpRequestManageStatus>(status), helpRequest);
            };
        }

        public HelpRequestManagerDelegate Result { get; set; }

        public void Post(HelpRequest helpRequest)
        {
            manager.postHelpRequest(helpRequest);
        }
    }
}
