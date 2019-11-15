using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    public class CategoryRemover : CategoryManagerBase, ICategoryRemover
    {
        public CategoryRemover(LocalUser user) : this(user.PrivateKey)
        {
        }

        public CategoryRemover(string privateKey) : base(privateKey)
        {
            categoryManager.RemoveCategoryResult = (status, category) =>
            {
                Result?.Invoke(EnumConverter.Convert<CategoryManageStatus>(status), category);
            };
        }

        public CategoryManageDelegate Result { get; set; }

        public void RemoveCategory(Category category)
        {
            categoryManager.removeCategory(category);
        }
    }
}
