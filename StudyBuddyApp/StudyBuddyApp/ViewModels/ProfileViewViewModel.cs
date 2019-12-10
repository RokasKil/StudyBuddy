using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class ProfileViewViewModel : BaseViewModel
    {
        public string ImageLocation { get; set; }
        public float KarmaPoints { get; set; }
        public float KarmaPointsForBar { get => (Badge == NextBadge ? 1 : (KarmaPoints - Badge.StartValue) / (NextBadge.StartValue - Badge.StartValue)); }
        public string KarmaDescription { get => NextBadge == null ? "XP: " + KarmaPoints : "XP: " + KarmaPoints + "/" + NextBadge.StartValue; }
        public string KarmaBadgeLocation { get => (Badge == null ? "" : Badge.Image); }
        public string KarmaBadgeTitle { get => (Badge == null ? "" : Badge.Title); }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; set => FullName = value; }
        public string UserName { get; set; }
        public User User { get; set; }

        public KarmaBadge Badge;
        public KarmaBadge NextBadge;
        public ProfileViewViewModel(User user)
        {
            this.User = user;
            Title = user.Username + " profilis";
            this.ImageLocation = user.ProfilePictureLocation;
            this.KarmaPoints = user.KarmaPoints;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserName = user.Username;
            Badge = KarmaBadgeFetcher.CurrentBadge(user.KarmaPoints);
            NextBadge = KarmaBadgeFetcher.NextBadge(user.KarmaPoints);
        }
    }
}
