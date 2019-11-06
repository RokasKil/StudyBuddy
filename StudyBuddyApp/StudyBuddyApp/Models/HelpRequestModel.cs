using System;
using System.Collections.Generic;
using System.Text;

using StudyBuddy.Entity;

namespace StudyBuddyApp.Models
{
    public class HelpRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public HelpRequest HelpRequest { get; set; }
    }
}
