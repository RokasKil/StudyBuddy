using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserReviewSystem
{
    public class UserReviewManagerBase : IPrivateKey
    {
        public UserReviewManagerBase(LocalUser user) : this(user.PrivateKey)
        {

        }

        public UserReviewManagerBase(string privateKey)
        {
            this.PrivateKey = privateKey;
            manager = new Network.UserReviewManager(privateKey);
        }

        protected Network.UserReviewManager manager;

        public string PrivateKey { get; set; }
    }
}
