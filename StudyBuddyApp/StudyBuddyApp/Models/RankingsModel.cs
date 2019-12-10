using System;
using System.Collections.Generic;
using System.Text;
using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;

namespace StudyBuddyApp.Models
{
    public class RankingsModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int KarmaPoints { get; set; }
        public bool IsLecturer { get; set; }
        public string ProfilePictureLocation { get; set; }
        public User User { get => user;
            set {
                Badge = KarmaBadgeFetcher.CurrentBadge(value.KarmaPoints);
                user = value; 
            }
        }
        private User user;
        public KarmaBadge Badge = null;
        public string BadgeImageLocation { get => (Badge == null ? "" : Badge.Image); }
    }
}
