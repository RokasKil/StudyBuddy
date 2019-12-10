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
            this.Title = "Atsiliepimai";
            Delete = "Ištrinti";
        }
        public User User { get; set; }
        public string Delete { get; set; }
    }
    
}
