using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyShared.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public long Timestamp { get; set; }
        public int Conversation { get; set; }
    }
}
