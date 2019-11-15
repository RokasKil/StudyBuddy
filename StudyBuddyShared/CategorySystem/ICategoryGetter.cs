using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    public enum CategoryGetStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FieldsMissing
    }

    public delegate void GetCategoryDelegate(CategoryGetStatus status, List<Category> categories);

    public interface ICategoryGetter : IPrivateKey
    {
        GetCategoryDelegate Result { get; set; } // Result delegate

        void Get(); //Get categories
    }
}
