using StudyBuddyShared.Entity;
using StudyBuddyShared.SystemManager;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        public MyProfileViewModel() : this(LocalUserManager.LocalUser) { }

        public MyProfileViewModel(LocalUser localuser)
        {
            this.User = localuser;
            this.KarmaPoints = localuser.KarmaPoints;
            Badge = KarmaBadgeFetcher.CurrentBadge(localuser.KarmaPoints);
            NextBadge = KarmaBadgeFetcher.NextBadge(localuser.KarmaPoints);
            localuser.OnUpdateHandler += (user) =>
            {
                OnPropertyChanged("User");
                OnPropertyChanged("FirstName");
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
                OnPropertyChanged("ImageLocation");
                Badge = KarmaBadgeFetcher.CurrentBadge(user.KarmaPoints);
                NextBadge = KarmaBadgeFetcher.NextBadge(user.KarmaPoints);
            };
        }
        public User User { get; set; }
        public new string Title { get => "Mano profilis"; set => Title = value; }
        public string FirstName { get => User.FirstName; set => FirstName = value; }
        public string LastName { get => User.LastName; set => LastName = value; }
        public string ImageLocation { get => User.ProfilePictureLocation; set => ImageLocation = value; }
        public string FullName { get => User.FirstName + " " + User.LastName; set => FullName = value; }
        public float KarmaPoints { get; set; }
        public float KarmaPointsForBar { get => (Badge == NextBadge ? 1 : (KarmaPoints - Badge.StartValue)/(NextBadge.StartValue - Badge.StartValue)) ; }
        public string KarmaDescription { get => NextBadge == null || Badge == NextBadge ? KarmaPoints + " XP" : "XP: " + KarmaPoints + "/" + NextBadge.StartValue; }
        public string KarmaBadgeLocation { get => (Badge == null ? "" : Badge.Image); }
        public string KarmaBadgeTitle { get => (Badge == null ? "" : Badge.Title); }

        public KarmaBadge Badge;
        public KarmaBadge NextBadge;
    }
}
