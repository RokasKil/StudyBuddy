using System;
using System.Collections.Generic;
using System.Text;
using StudyBuddy.Entity;
using Xamarin.Forms;
using StudyBuddyApp.Models;

namespace StudyBuddyApp.ViewModels
{

    public class HelpRequestViewPageModel : BaseViewModel
    {
        public HelpRequestModel HelpRequestModel { get; set; }
        public User Creator { get; set; }

        public HelpRequestViewPageModel(User user, HelpRequestModel helpRequest)
        {
            Creator = user;
            HelpRequestModel = helpRequest;
        }
    }
}
