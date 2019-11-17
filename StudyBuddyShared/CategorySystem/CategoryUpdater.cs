using System;
using System.Collections.Generic;
using System.Text;
using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;

namespace StudyBuddyShared.CategorySystem
{
    public class CategoryUpdater : CategoryManagerBase, ICategoryUpdater
    {
        public CategoryUpdater(LocalUser user) : this(user.PrivateKey)
        {
        }

        public CategoryUpdater(string privateKey) : base(privateKey)
        {
            categoryManager.UpdateCategoryResult = (status, category) =>
            {
                Result?.Invoke(EnumConverter.Convert<CategoryManageStatus>(status), category);
            };
        }

        public CategoryManageDelegate Result { get; set; }

        public void UpdateCategory(Category category)
        {
            categoryManager.updateCategory(category);
        }
    }
}
