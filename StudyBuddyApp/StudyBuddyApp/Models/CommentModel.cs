using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Models
{
    public class CommentModel
    {
        public int HelpRequestID { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string CreatedDate { get; set; }
        public Comment Comment { get; set; }
    }
}
