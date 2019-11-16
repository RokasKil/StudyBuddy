using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    public class CategoryManagerBase : IPrivateKey
    {
        public CategoryManagerBase(LocalUser user) : this(user.PrivateKey)
        {

        }

        public CategoryManagerBase(string privateKey)
        {
            this.PrivateKey = privateKey;
            categoryManager = new Network.CategoryManager(privateKey);
        }

        public string PrivateKey { get; set; }

        protected Network.CategoryManager categoryManager;
    }
}
