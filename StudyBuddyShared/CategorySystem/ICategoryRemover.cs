using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    public interface ICategoryRemover : IPrivateKey
    {
        CategoryManageDelegate Result { get; set; } // Return delegate

        void RemoveCategory(Category category); // Remove category
    }
    
}
