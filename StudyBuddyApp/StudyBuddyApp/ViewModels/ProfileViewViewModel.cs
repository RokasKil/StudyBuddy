using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class ProfileViewViewModel : BaseViewModel
    {
        public string ImageLocation { get; set; }
        public float KarmaPoints { get; set; }
        public float KarmaPointsForBar { get => KarmaPoints/10; set => KarmaPointsForBar = value; }
        public string KarmaDescription { get => "XP: " + KarmaPoints; set => KarmaDescription = value; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; set => FullName = value; }
        public string UserName { get; set; }
        public User User { get; set; }
        public ProfileViewViewModel(User user)
        {
            this.User = user;
            Title = user.Username + " Profilis";
            this.ImageLocation = user.ProfilePictureLocation;
            this.KarmaPoints = user.KarmaPoints;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserName = user.Username;
        }
    }
}
