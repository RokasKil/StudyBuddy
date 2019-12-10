using StudyBuddyApp.Models;
using StudyBuddyApp.Views;
using StudyBuddyShared.Entity;
using StudyBuddyShared.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudyBuddyApp.Utility
{
    public static class ProfileOpener
    {
        public static Task OpenProfile(User user)
        {
            MasterDetailPage page = ((MasterDetailPage)Application.Current.MainPage);
            if (user.Username != LocalUserManager.LocalUser.Username)
            {
                if (page.Detail.Navigation.ModalStack.Count == 0)
                {
                    return page.Detail.Navigation.PushAsync(new ProfileViewPage(new ViewModels.ProfileViewViewModel(user)));
                }
                else
                {
                    return page.Detail.Navigation.PushModalAsync(new NavigationPage(new ProfileViewPage(new ViewModels.ProfileViewViewModel(user))));
                }
            }
            else
            {
                return page.Detail.Navigation.PushAsync(new MyProfilePage());
                
            }
        }
    }
}
