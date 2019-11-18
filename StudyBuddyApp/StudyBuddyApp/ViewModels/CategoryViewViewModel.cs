using StudyBuddyApp.Models;
using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class CategoryViewViewModel : BaseViewModel
    {
        public CategoryModel CategoryModel { get; set; }

        public CategoryViewViewModel(CategoryModel category)
        {
            CategoryModel = category;
            Title = "Kategorijos redagavimas";
        }
    }
}
