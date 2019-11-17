using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static StudyBuddyShared.Entity.User;

namespace StudyBuddyApp.ViewModels
{
    public class ProfileEditViewModel : BaseViewModel
    {
        public User User { get; set; }
        public string ImageLocation { get; set; }
        public ProfileEditViewModel() : this(LocalUserManager.LocalUser) { }
        public ProfileEditViewModel(LocalUser localuser)
        {
            Title = "Redaguoti profilį";
            this.User = localuser;
            this.ImageLocation = User.ProfilePictureLocation;
            User.OnUpdateHandler += (user) => OnPropertyChanged("User");
        }
    }
}
