using StudyBuddyApp.Models;
using StudyBuddyShared.SystemManager;
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
        public ObservableCollection<UserReviewModel> Items { get; set; }
        public int MyReviewIndex = -1;
        public UserReviewListPage(UserReviewListViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = viewModel;
            Items = new ObservableCollection<UserReviewModel> { };
            GetUserReviews();
            UserReviewsList.ItemsSource = Items;
            buttonDelete.IsEnabled = false;
            buttonDelete.Text = "";
        }

        private void UserReviewList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            UserReviewsList.SelectedItem = null;
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
                        buttonDelete.IsEnabled = false;
                        buttonDelete.Text = "";
                        Items.Clear();
                        userReviews.ForEach(UserReview =>
                        {
                            if (UserReview.Username == LocalUserManager.LocalUser.Username)
                            {
                                buttonDelete.IsEnabled = true;
                                buttonDelete.Text = viewModel.Delete;
                                MyReviewIndex = Items.Count;
                            }
                            Items.Add(
                                new UserReviewModel()
                                {
                                    Message = UserReview.Message,
                                    Karma = UserReview.Karma,
                                    Username = UserReview.Username,
                                    PostDate = UserReview.PostDate,
                                    UserReview = UserReview,
                                    User = users[UserReview.Username]
                                });
                        });
                    }
                    else
                    {
                        DisplayAlert("Klaida", "Nepavyko įkelti atsiliepimų", "Tęsti");
                    }
                });
            };
            userReviewGetter.Get(viewModel.User.Username);
        }

        public void DeleteReview()
        {
            buttonDelete.IsEnabled = false;
            buttonDelete.Text = "";
            var userReviewRemover = UserReviewSystemManager.NewUserReviewRemover();
            userReviewRemover.Result += (status, userReview) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (status == UserReviewManageStatus.Success)
                    {
                        Items.RemoveAt(MyReviewIndex);
                    }
                    else
                    {
                        DisplayAlert("Klaida", "Nepavyko ištrinti atsiliepimo", "Tęsti");
                        buttonDelete.IsEnabled = true;
                    }
                });
            };
            userReviewRemover.Remove(new UserReview() {Username = viewModel.User.Username});
            
        }

        private void UserReviewsList_Refreshing(object sender, EventArgs e)
        {
            GetUserReviews();
            UserReviewsList.IsRefreshing = false;
        }

        private void buttonDelete_Clicked(object sender, EventArgs e)
        {
            DeleteReview();
        }

        private void UserReviewsList_SizeChanged(object sender, EventArgs e)
        {
            buttonDelete.IsEnabled = false;
        }
    }
}