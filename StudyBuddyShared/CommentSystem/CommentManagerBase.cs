using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CommentSystem
{
    public class CommentManagerBase : IPrivateKey
    {
        public CommentManagerBase(LocalUser user) : this(user.PrivateKey)
        {

        }

        public CommentManagerBase(string privateKey)
        {
            this.PrivateKey = privateKey;
            manager = new Network.CommentManager(privateKey);
        }

        protected Network.CommentManager manager;

        public string PrivateKey { get; set; }
    }
}
