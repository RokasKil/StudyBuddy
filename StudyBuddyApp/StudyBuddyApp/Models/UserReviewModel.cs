﻿using StudyBuddyShared.Entity;
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
        public string Color { get => Karma > 0 ? "Green" : "Red"; set => Color = value; }
        public string Title { get => Karma > 0 ? "Teigiamas" : "Neigiamas"; set => Title = value; }
        public User User { get; set; }
        public string FullName { get => User.FirstName + " " + User.LastName; set => FullName = value; }

        public string KarmaPoints { get => (UserReview.Karma > 0 ? "+" + UserReview.Karma : UserReview.Karma.ToString()); }
    }
}
