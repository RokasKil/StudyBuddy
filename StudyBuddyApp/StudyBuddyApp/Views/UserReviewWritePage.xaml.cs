using StudyBuddyApp.SystemManager;
using StudyBuddyApp.Utility;
using StudyBuddyApp.ViewModels;
using StudyBuddyShared.Entity;
using StudyBuddyShared.UserReviewSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserReviewWritePage : ContentPage
    {
        UserReviewWriteViewModel viewModel;
        User user;

        public UserReviewWritePage(User user)
        {
            InitializeComponent();
            this.BindingContext = viewModel = new UserReviewWriteViewModel(user);
            buttonNegativeReview.IsEnabled = false;
            buttonPositiveReview.IsEnabled = false;
            this.user = user;
        }

        private void buttonPositiveReview_Clicked(object sender, EventArgs e)
        {
            sendingReview(1);
        }
        private void buttonNegativeReview_Clicked(object sender, EventArgs e)
        {
            sendingReview(-1);
        }

        private void sendingReview(int karma)
        {

            var mngr = UserReviewSystemManager.NewUserReviewPoster();
            mngr.Result += (status, review) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (status == UserReviewManageStatus.Success)
                    {
                        DependencyService.Get<IToast>().LongToast("Atsiliepimas išsiųstas");
                        Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Klaida", "Atsiliepimas neišsiųstas, bandykite dar kartą", "tęsti"); ;
                    }
                });
            };
            mngr.Post(
                new UserReview()
                {
                    Username = user.Username,
                    Karma = karma,
                    Message = Description.Text
                });
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Description.Text.Length != 0)
            {
                buttonNegativeReview.IsEnabled = true;
                buttonNegativeReview.IsEnabled = true;
            }
        }
    }
}