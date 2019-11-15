using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.HelpRequestSystem
{
    public class HelpRequestManagerBase : IPrivateKey
    {
        public HelpRequestManagerBase(LocalUser user) : this(user.PrivateKey)
        {

        }

        public HelpRequestManagerBase(string privateKey)
        {
            this.PrivateKey = privateKey;
            manager = new Network.HelpRequestManager(privateKey);
        }
        
        protected Network.HelpRequestManager manager;

        public string PrivateKey { get; set; }
    }
}
