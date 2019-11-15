using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    interface ICategoryUpdater : IPrivateKey
    {
        CategoryManageDelegate Result { get; set; }

        void UpdateCategory(Category category);
    }
}
