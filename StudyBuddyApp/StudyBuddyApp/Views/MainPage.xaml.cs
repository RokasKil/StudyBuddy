using StudyBuddyShared.Entity;
using StudyBuddyApp.Models;
using StudyBuddyApp.Services;
using StudyBuddyApp.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyApp.ViewModels;
using StudyBuddyApp.EntityFramework;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        private bool appeared = false;

        public Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Profile, (NavigationPage)Detail);
            MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.Started, (obj) =>
            {
                DependencyService.Get<IToast>().LongToast("Service started");
            });
            MessagingCenter.Subscribe<ConversationViewModel>(this, "Open", async (obj) =>
            {
                await Navigation.PushModalAsync(new NavigationPage(new ConversationPage(obj)));
            });
            // Starts messaging service
            MessagingCenter.Send(new MessagingTask(), MessagingTask.Start);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new MyProfilePage()));
                        break;
                    case (int)MenuItemType.CategoryList:
                        MenuPages.Add(id, new NavigationPage(new CategoryListPage()));
                        break;
                    case (int)MenuItemType.HelpRequestList:
                        MenuPages.Add(id, new NavigationPage(new HelpRequestListPage()));
                        break;
                    case (int)MenuItemType.ConversationListPage:
                        MenuPages.Add(id, new NavigationPage(new ConversationListPage()));
                        break;
                    case (int)MenuItemType.SettingsPage:
                        MenuPages.Add(id, new NavigationPage(new SettingsPage()));
                        break;
                    case (int)MenuItemType.RankingsListPage:
                        MenuPages.Add(id, new NavigationPage(new RankingsViewPage()));
                        break;
                    case (int)MenuItemType.LogOut:
                        Application.Current.Properties.Remove("PrivateKey");
                        await Application.Current.SavePropertiesAsync();
                        //Stops messaging service
                        MessagingCenter.Send(new MessagingTask(), MessagingTask.Stop);
                        new DatabaseContext().Database.EnsureDeleted();
                        App.Current.MainPage = new LoginPage();

                        return;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        private async void MasterDetailPage_Appearing(object sender, EventArgs e)
        {
            if (appeared)
            {
                return;
            }
            appeared = true;
            var model = DependencyService.Get<INotificationStart>().GetStartModel();
            if (model != null)
            {
                await Navigation.PushModalAsync(new NavigationPage(new ConversationPage(model)));
            }
        }
    }
}