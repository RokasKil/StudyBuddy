using StudyBuddyApp.Models;
using StudyBuddyApp.Services;
using StudyBuddyApp.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Profile, (NavigationPage)Detail);
            MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.Started, (obj) =>
            {
                DependencyService.Get<IToast>().LongToast("Service started");
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
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new MyProfilePage()));
                        break;
                    case (int)MenuItemType.HelpRequestList:
                        MenuPages.Add(id, new NavigationPage(new HelpRequestListPage()));
                        break;
                    case (int)MenuItemType.ConversationListPage:
                        MenuPages.Add(id, new NavigationPage(new ConversationListPage()));
                        break;
                    case (int)MenuItemType.LogOut:
                        Application.Current.Properties.Remove("PrivateKey");
                        await Application.Current.SavePropertiesAsync();
                        //Stops messaging service
                        MessagingCenter.Send(new MessagingTask(), MessagingTask.Stop);
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
    }
}