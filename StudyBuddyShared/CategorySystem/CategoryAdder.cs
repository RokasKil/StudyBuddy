using System;
using System.Collections.Generic;
using System.Text;
using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;

namespace StudyBuddyShared.CategorySystem
{
    public class CategoryAdder : CategoryManagerBase, ICategoryAdder
    {
        public CategoryAdder(LocalUser user) : this(user.PrivateKey)
        {
        }

        public CategoryAdder(string privateKey) : base(privateKey)
        {
            categoryManager.AddCategoryResult = (status, category) =>
            {
                Result?.Invoke(EnumConverter.Convert<CategoryManageStatus>(status), category);
            };
        }

        public CategoryManageDelegate Result { get; set; }

        public void AddCategory(Category category)
        {
            categoryManager.addCategory(category);
        }
    }
}
