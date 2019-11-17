using StudyBuddyShared.Entity;
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
            localuser.OnUpdateHandler += (user) =>
            {
                OnPropertyChanged("User");
                OnPropertyChanged("FirstName");
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
                OnPropertyChanged("ImageLocation");
            };
        }
        public User User { get; set; }
        public new string Title { get => "Mano profilis"; set => Title = value; }
        public string FirstName { get => User.FirstName; set => FirstName = value; }
        public string LastName { get => User.LastName; set => LastName = value; }
        public string ImageLocation { get => User.ProfilePictureLocation; set => ImageLocation = value; }
        public string FullName { get => User.FirstName + " " + User.LastName; set => FullName = value; }
    }
}
