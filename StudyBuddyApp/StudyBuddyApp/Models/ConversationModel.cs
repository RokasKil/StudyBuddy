using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Models
{
    public class ConversationModel
    {
        public string Title { get; set; }
        public string LastMessage { get; set; }
        public string Date { get; set; }
        public string ImageLocation { get; set; }
        public Conversation Conversation { get; set; }
    }
}
