using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.CategorySystem
{
    public enum CategoryManageStatus
    {
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        TitleMissing,
        InvalidUserType,         // Lecturers only!!!
        TitleAlreadyTaken,       // Unique titles only
        FieldsMissing,
        FailedToFindCategory     // Failed to find the category you were going to delete
    }

    public delegate void CategoryManageDelegate(CategoryManageStatus status, Category category);

    interface ICategoryAdder : IPrivateKey
    {
        CategoryManageDelegate Result { get; set; }

        void AddCategory(Category category);
    }
}
