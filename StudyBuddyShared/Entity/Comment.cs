using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.Entity
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int HelpRequestID { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public long CreatedDate { get; set; }

    }
}
