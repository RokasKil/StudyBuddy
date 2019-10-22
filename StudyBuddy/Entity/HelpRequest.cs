using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Entity
{
    public class HelpRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorUsername { get; set; }
        public string Category { get; set; }
        public DateTime timestamp;
    }
}
