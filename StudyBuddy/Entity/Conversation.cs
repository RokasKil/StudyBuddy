using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Entity
{
    public class Conversation
    {
        public int id;
        public string title;
        public List<string> users = new List<string>();
        public int messages;
        public long lastActivity;
        public string lastMessage;
    }
}
