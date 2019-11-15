using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    interface ICategoryRemover : IPrivateKey
    {
        CategoryManageDelegate Result { get; set; }

        void RemoveCategory(Category category);
    }
    
}
