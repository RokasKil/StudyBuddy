using StudyBuddyShared.Entity;
using StudyBuddyApp.SystemManager;
using StudyBuddyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyApp.Utility;
using StudyBuddyShared.ConversationSystem;
using StudyBuddyApp.Models;
using StudyBuddyShared.Utility.AttachedProperties;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileViewPage : ContentPage
    {
        ProfileViewViewModel viewModel;
        User user;
        public ProfileViewPage(ProfileViewViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            ProgressBarKarma.SetBinding(AttachedProperties.AnimatedProgressProperty,
                                      "Progress");
            this.user = viewModel.User;
        }

        private async void ViewUserReviews_Clicked(object sender, EventArgs e)//TODO
        {
            ViewUserReviews.IsEnabled = false;
            await Navigation.PushAsync(new UserReviewListPage(new UserReviewListViewModel(user)));
        }

        private async void WriteUserReview_Clicked(object sender, EventArgs e)//TODO
        {
            WriteUserReview.IsEnabled = false;
            await Navigation.PushAsync(new UserReviewWritePage(new UserReviewWriteViewModel(user)));
        }

        private void StartConversation_Clicked(object sender, EventArgs e)
        {
            var conversationStarter = ConversationSystemManager.NewConversationStarter();
            LoadingIndicator.IsRunning = true;
            StartConversation.IsEnabled = false;
            conversationStarter.Result += (status, conversation, users) =>
            {
                Device.BeginInvokeOnMainThread(async () => //Grįžtama į main Thread !! SVARBU
                {
                    if (status == ConversationStartStatus.Success) //Pavyko
                    {
                        await Navigation.PushModalAsync(
                        new NavigationPage(
                            new ConversationPage(
                                new ViewModels.ConversationViewModel(conversation, users))));
                        DependencyService.Get<IToast>().LongToast("Pokalbis pradėtas");
                    }
                    else //Ne
                    {
                        await Application.Current.MainPage.DisplayAlert("Klaida", "woops, kažkas netaip", "tęsti");
                    }
                    LoadingIndicator.IsRunning = false;
                    StartConversation.IsEnabled = true;
                });
            };
            conversationStarter.StartConversation(user.Username);
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            StartConversation.IsEnabled = true;
            ViewUserReviews.IsEnabled = true;
            WriteUserReview.IsEnabled = true;
        }
    }
}