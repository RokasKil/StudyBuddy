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
            this.user = viewModel.User;
        }

        private async void ViewUserReviews_Clicked(object sender, EventArgs e)//TODO
        {
            //await Navigation.PushAsync(new ViewUserReviews(new ViewModels.ViewUserReviewsViewModel(user)));
        }

        private async void WriteUserReview_Clicked(object sender, EventArgs e)//TODO
        {
            //await Navigation.PushAsync(new WriteUserReview(new ViewModels.WriteUserReviewModel(user)));
        }

        private async void StartConversation_Clicked(object sender, EventArgs e)
        {

            var conversationStarter = ConversationSystemManager.NewConversationStarter();
            conversationStarter.Result += (status, conversation, users) =>
            {

            };
            /* await Navigation.PushModalAsync(
                new NavigationPage(
                    new ConversationPage(
                        new ViewModels.ConversationViewModel(((new ConversationModel)e.Item).Conversation, users))));*/
        }
    }
}