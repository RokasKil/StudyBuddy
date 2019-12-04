using System;
using System.Collections.Generic;
using System.Text;
using StudyBuddyShared.Entity;

namespace StudyBuddyApp.Models
{
    public class RankingsModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int KarmaPoints { get; set; }
        public int IsLecturer { get; set; }
        public string ProfilePictureLocation { get; set; }
        public User User { get; set; }
    }
}
