using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class UserReviewWriteViewModel : BaseViewModel
    {
        User User { get; set; }
        String Username { get; set; }
        public UserReviewWriteViewModel(User user)
        {
            User = user;
            Title = "Įvertink " + User.Username;
        }
    }
}
