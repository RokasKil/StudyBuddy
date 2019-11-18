using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class CategoryViewViewModel : BaseViewModel
    {
        //public string Title { get; set; }
        public string Description { get => Category.Description; set => Category.Description = value; }
        public string CreatorUsername { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdatedDate { get; set; }
        public Category Category { get; set; }

        public CategoryViewViewModel(Category category)
        {
            this.Category = category;
            Description = Category.Description;
            //CreatorUsername = ...
            //...
        }
    }
}
