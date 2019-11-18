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
        User user;
        public ObservableCollection<UserReviewModel> Items { get; set; }
        public UserReviewListPage(UserReviewListViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = viewModel;
            Items = new ObservableCollection<UserReviewModel> { };
            GetUserReviews();
            UserReviewsList.ItemsSource = Items;

        }

        private void UserReviewList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
        private void GetUserReviews()
        {
            var userReviewGetter = UserReviewSystemManager.NewUserReviewGetter();
            userReviewGetter.Result += (status, userReviews, users) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (status == UserReviewsGetStatus.Success)
                    {
                        Items.Clear();
                        userReviews.ForEach(UserReview =>
                        {
                            users.TryGetValue(UserReview.Username, out user);
                            Items.Add(
                                new UserReviewModel()
                                {
                                    Message = UserReview.Message,
                                    Karma = UserReview.Karma,
                                    Username = UserReview.Username,
                                    PostDate = UserReview.PostDate,
                                    UserReview = UserReview,
                                    User = user
                                });
                        });
                    }
                    else
                    {
                        DisplayAlert("Klaida", "Nepavyko įkelti kategorijų", "OK");
                    }
                });
            };
            userReviewGetter.Get(viewModel.User.Username);
        }

        private void UserReviewsList_Refreshing(object sender, EventArgs e)
        {
            GetUserReviews();
            UserReviewsList.IsRefreshing = false;
        }
    }
}