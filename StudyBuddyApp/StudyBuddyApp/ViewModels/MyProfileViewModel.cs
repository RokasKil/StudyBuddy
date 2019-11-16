using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        public MyProfileViewModel():this( LocalUserManager.LocalUser) { }

        public MyProfileViewModel(LocalUser localuser)
        {
            this.User = localuser;
            this.ImageLocation = User.ProfilePictureLocation;
            this.FirstName = User.FirstName;
            this.LastName = User.LastName;
            this.FullName = User.FirstName + " " + User.LastName;
            this.Title = "Mano profilis";
            localuser.OnUpdateHandler += (user) => OnPropertyChanged("User");
        }
        public User User { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageLocation { get; set; }
        public string FullName { get; set; }
    }
}
