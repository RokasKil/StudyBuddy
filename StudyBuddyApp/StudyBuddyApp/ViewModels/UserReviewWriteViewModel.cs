using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class UserReviewWriteViewModel : BaseViewModel
    {
        public User User { get; set; }
        public String Username { get; set; }
        public UserReviewWriteViewModel(User user)
        {
            User = user;
            Title = "Įvertink " + User.Username;
        }
    }
}
