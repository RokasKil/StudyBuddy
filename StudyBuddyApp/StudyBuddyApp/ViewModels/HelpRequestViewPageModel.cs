using System;
using System.Collections.Generic;
using System.Text;
using StudyBuddyShared.Entity;
using Xamarin.Forms;
using StudyBuddyApp.Models;
using StudyBuddyApp;

namespace StudyBuddyApp.ViewModels
{

    public class HelpRequestViewPageModel : BaseViewModel
    {
        public HelpRequestModel HelpRequestModel { get; set; }
        public User Creator { get; set; }
        public string DeleteButtonText { get; set; }
        public bool DeleteButtonEnabled { get; set; }

        public HelpRequestViewPageModel(User user, HelpRequestModel helpRequest)
        {
            Creator = user;
            HelpRequestModel = helpRequest;
            if(Creator.Username == LocalUserManager.LocalUser.Username)
            {
                DeleteButtonText = "Ištrinti";
                DeleteButtonEnabled = true;
            }
        }
    }
}
