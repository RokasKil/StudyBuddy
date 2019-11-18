using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class UserReviewListViewModel : BaseViewModel
    {
        public UserReviewListViewModel(User user)
        {
            User = user;
        }
        public User User { get; set; }
    }
    
}
