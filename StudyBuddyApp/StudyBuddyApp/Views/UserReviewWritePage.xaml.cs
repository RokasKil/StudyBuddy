using StudyBuddyShared.SystemManager;
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

        public UserReviewWritePage(UserReviewWriteViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = viewModel;
            buttonNegativeReview.IsEnabled = false;
            buttonPositiveReview.IsEnabled = false;
            user = viewModel.User;
        }

        private void buttonPositiveReview_Clicked(object sender, EventArgs e)
        {
            SendingReview(1);
        }
        private void buttonNegativeReview_Clicked(object sender, EventArgs e)
        {
            SendingReview(-1);
        }

        private void SendingReview(int karma)
        {

            var mngr = UserReviewSystemManager.NewUserReviewPoster();
            mngr.Result += (status, review) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (status == UserReviewManageStatus.Success)
                    {
                        DependencyService.Get<IToast>().LongToast("Atsiliepimas išsiųstas");
                        if (Navigation.NavigationStack.Contains(this)) {
                            await Navigation.PopAsync();
                        }
                    }
                    else
                    {
                        buttonNegativeReview.IsEnabled = true;
                        buttonPositiveReview.IsEnabled = true;
                        await Application.Current.MainPage.DisplayAlert("Klaida", "Atsiliepimas neišsiųstas, bandykite dar kartą", "tęsti");
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
            buttonNegativeReview.IsEnabled = false;
            buttonPositiveReview.IsEnabled = false;
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Description.Text.Length != 0)
            {
                buttonNegativeReview.IsEnabled = true;
                buttonPositiveReview.IsEnabled = true;
            }
        }
    }
}