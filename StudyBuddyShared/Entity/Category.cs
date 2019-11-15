using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyShared.Entity
{
    public class Category
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorUsername { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdatedDate { get; set; }
    }
}
