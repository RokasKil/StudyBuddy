using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class ProfileEditViewModel : BaseViewModel
    {
        public User User { get; set; }
        public string ImageLocation { get; set; }
        public ProfileEditViewModel(LocalUser localuser)
        {
            Title = "Redaguoti profilį";
            this.User = localuser;
            this.ImageLocation = User.ProfilePictureLocation;
        }
    }
}
