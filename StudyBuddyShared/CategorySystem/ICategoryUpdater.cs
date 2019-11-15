using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    public interface ICategoryUpdater : IPrivateKey
    {
        CategoryManageDelegate Result { get; set; } // Return delegate

        void UpdateCategory(Category category); // Update category
    }
}
