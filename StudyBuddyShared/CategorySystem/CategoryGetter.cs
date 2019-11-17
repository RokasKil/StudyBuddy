using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    public class CategoryGetter : ICategoryGetter
    {
        public GetCategoryDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        private Network.CategoriesGetter getter;

        public CategoryGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public CategoryGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
            getter = new Network.CategoriesGetter(PrivateKey, (status, categories) =>
            {
                Result?.Invoke(EnumConverter.Convert<CategoryGetStatus>(status), categories);
            });
        }

        public void Get()
        {
            getter.get();
        }
    }
}
