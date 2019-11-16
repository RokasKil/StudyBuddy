using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyShared.Entity
{
    public class Conversation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Users { get; set; } = new List<string>();
        public int Messages { get; set; }
        public long LastActivity { get; set; }
        public string LastMessage { get; set; }
    }
}
