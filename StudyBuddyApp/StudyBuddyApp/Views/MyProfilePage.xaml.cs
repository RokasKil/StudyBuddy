﻿using StudyBuddyApp.ViewModels;
using StudyBuddyShared.Utility.AttachedProperties;
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
	public partial class MyProfilePage : ContentPage
	{
        MyProfileViewModel viewModel = new MyProfileViewModel();
        public MyProfilePage() : this(new MyProfileViewModel()) { }
		public MyProfilePage (MyProfileViewModel viewModel)
		{
			InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            ProgressBarKarma.SetBinding(AttachedProperties.AnimatedProgressProperty, "Progress");
        }

        async void buttonEditProfile_Clicked(object sender, EventArgs e)
        {
            buttonEditProfile.IsEnabled = false;
            await Navigation.PushAsync(new ProfileEditPage(new ViewModels.ProfileEditViewModel()));
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            viewModel.User.OnUpdateHandler?.Invoke(viewModel.User);
            buttonEditProfile.IsEnabled = true;
            ViewUserReviews.IsEnabled = true;
            MyRequests.IsEnabled = true;
        }

        private async void ViewUserReview_Clicked(object sender, EventArgs e)
        {
            ViewUserReviews.IsEnabled = false;
            await Navigation.PushAsync(new UserReviewListPage(new UserReviewListViewModel(viewModel.User)));
        }

        private async void MyRequests_Clicked(object sender, EventArgs e)
        {
            MyRequests.IsEnabled = false;
            await Navigation.PushAsync(new HelpRequestListPage(true));
        }
    }
}