using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Models
{
    public class CategoryModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorUsername { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdatedDate { get; set; }
        public Category Category { get; set; }
    }
}
