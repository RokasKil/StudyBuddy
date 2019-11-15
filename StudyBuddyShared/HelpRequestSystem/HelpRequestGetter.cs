using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.HelpRequestSystem
{
    public class HelpRequestGetter : IHelpRequestGetter
    {
        public HelpRequestGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public HelpRequestGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
            getter = new Network.HelpRequestGetter(privateKey, (status, helpRequests, users) =>
            {
                Result?.Invoke(EnumConverter.Convert<HelpRequestGetStatus>(status), helpRequests, users);
            });
        }

        private Network.HelpRequestGetter getter;

        public GetHelpRequestsDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        public void Get(bool getUsers = true)
        {
            getter.get(getUsers);
        }
    }
}
