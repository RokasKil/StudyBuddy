using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class ProfileEditViewModel : BaseViewModel
    {
        public User user;
        public string ImageLocation { get; set; }
        public ProfileEditViewModel(LocalUser localuser)
        {
            Title = "Redaguoti profilį";
            this.user = localuser;
            this.ImageLocation = user.ProfilePictureLocation;
        }
    }
}
