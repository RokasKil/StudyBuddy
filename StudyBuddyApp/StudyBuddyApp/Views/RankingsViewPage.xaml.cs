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
                        requests.ForEach(request =>
                        {
                            Items.Add(new HelpRequestModel
                            {
                                Title = request.Title,
                                Description = request.Description,
                                Username = request.CreatorUsername,
                                Name = users[request.CreatorUsername].FirstName + " " + users[request.CreatorUsername].LastName,
                                Category = request.Category,
                                Date = request.Timestamp.ToFullDate(),
                                HelpRequest = request
                            });
                        });

                        FilterFinal();
                        HelpRequestList.IsRefreshing = false;

                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        HelpRequestList.IsRefreshing = false;
                    });
                }

            };
            helpRequestGetter.Get();
        }
    }


}