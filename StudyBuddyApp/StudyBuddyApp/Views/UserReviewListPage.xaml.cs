using StudyBuddyApp.Models;
using StudyBuddyApp.SystemManager;
using StudyBuddyApp.ViewModels;
using StudyBuddyShared.Entity;
using StudyBuddyShared.UserReviewSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserReviewListPage : ContentPage
    {
        UserReviewListViewModel viewModel;
        UserReviewsGetStatus status;
        List<UserReview> userReviews;
        Dictionary<string, User> users;
        public ObservableCollection<UserReviewModel> Items { get; set; }
        public UserReviewListPage(UserReviewListViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = viewModel;
            Items = new ObservableCollection<UserReviewModel>{ };
            GetUserReviews();
            UserReviewsList.ItemsSource = Items;

        }

        private void UserReviewList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
        private void GetUserReviews()
        {
            var userReviewSystemManager = UserReviewSystemManager.NewUserReviewGetter();
            userReviewSystemManager.Result += async (status, userReviews, users) =>
            {
                if (status == UserReviewsGetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
                        userReviews.ForEach(category =>
                        {
                            Items.Add(
                                new UserReviewModel
                                {
                                    Message
                                    Karma
                                    Username
                                    PostDate
                                    UserReview
                                });
                        });
                        //HelpRequestList.IsRefreshing = false;
                        //HelpRequestList.ItemsSource = null;
                        //HelpRequestList.ItemsSource = Items;
                    });
                }
                else
                {
                    await DisplayAlert("Klaida", "Nepavyko įkelti kategorijų", "OK");
                }

            };
            userReviewSystemManager.Get(viewModel.User);
        }

        private void UserReviewsList_Refreshing(object sender, EventArgs e)
        {
            GetUserReviews();
            UserReviewsList.IsRefreshing = false;
        }
    }
}