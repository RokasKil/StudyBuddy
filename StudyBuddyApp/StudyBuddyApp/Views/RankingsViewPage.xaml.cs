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
        public RankingsViewPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<RankingsModel>
            { };
            RankingsListGetter();
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
            RankingsListGetter();
        }

        private void RankingsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }


}