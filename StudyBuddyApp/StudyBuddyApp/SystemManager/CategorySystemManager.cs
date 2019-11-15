﻿using StudyBuddyShared.CategorySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.SystemManager
{
    public static class CategorySystemManager // Returns implementations of interfaces
    {
        public static ICategoryGetter NewCategoryGetter()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new CategoryGetter(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static ICategoryAdder NewCategoryAdder()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new CategoryAdder(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static ICategoryRemover NewCaregoryRemover()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new CategoryRemover(LocalUserManager.LocalUser);
            }
            return null;
        }

        public static ICategoryUpdater NewCaregoryUpdater()
        {
            if (LocalUserManager.LocalUser != null)
            {
                return new CategoryUpdater(LocalUserManager.LocalUser);
            }
            return null;
        }
    }
}
