using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;
using StudyBuddyApp.Models;
using StudyBuddyApp.ViewModels;
using StudyBuddyShared.Utility.Extensions;
using System.Collections.Generic;
using StudyBuddyShared.SystemManager;
using StudyBuddyShared.CategorySystem;
using StudyBuddyShared.UserSystem;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RankingsViewPage : ContentPage
    {
        public ObservableCollection<RankingsModel> Items { get; set; }
        public bool ProfileOpen { get; set; } = false;
        RankingsViewModel viewModel;
        public RankingsViewPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<RankingsModel>
            { };
            viewModel = new RankingsViewModel();
            RankingsListGetter();
            BindingContext = this.viewModel;
            RankingsList.ItemsSource = Items;
        }

        private void RankingsListGetter()
        {
            var rankingsGetter = UserSystemManager.NewRankingsGetter();
            rankingsGetter.Result += (status, rankings) =>
            {
                if (status == RankingsGetStatus.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Clear();
                        rankings.ForEach(user =>
                        {
                            Items.Add(new RankingsModel
                            {
                                Username = user.Username,
                                Name = user.FirstName + " " + user.LastName,
                                KarmaPoints = user.KarmaPoints,
                                IsLecturer = user.IsLecturer,
                                ProfilePictureLocation = user.ProfilePictureLocation,
                                User = user
                            });
                        });
                        RankingsList.IsRefreshing = false;

                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        RankingsList.IsRefreshing = false;
                    });
                }

            };
            rankingsGetter.Get();
        }


        private void RankingsList_Refreshing(object sender, EventArgs e)
        {
            ProfileOpen = false;
            RankingsListGetter();
        }

        async private void RankingsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            ((ListView)sender).SelectedItem = null;
            if (ProfileOpen)
            {
                return;
            }
            ProfileOpen = true;
            /*
            await Navigation.PushModalAsync(
                new NavigationPage(
                    new ProfileViewPage(
                        new ViewModels.ProfileViewViewModel(((RankingsModel)e.Item).User))));
            */
            await Navigation.PushAsync(new ProfileViewPage(new ViewModels.ProfileViewViewModel(((RankingsModel)e.Item).User)));
        }
    }


}