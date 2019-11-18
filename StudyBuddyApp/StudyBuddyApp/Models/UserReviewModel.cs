using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Models
{
    public class UserReviewModel
    {
        public string Message { get; set; }
        public int Karma { get; set; }
        public string Username { get; set; }
        public DateTime PostDate { get; set; }
        public UserReview UserReview { get; set; }
    }
}
