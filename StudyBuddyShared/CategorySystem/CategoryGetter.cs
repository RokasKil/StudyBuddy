using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    public class CategoryGetter : ICategoryGetter
    {
        public GetCategoryDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        public CategoryGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public CategoryGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
        }

        public void Get()
        {
            throw new NotImplementedException();
        }
    }
}
