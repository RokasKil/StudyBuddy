using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyApp.Views;
using StudyBuddyApp.Themes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StudyBuddyApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Current.Resources.MergedDictionaries.Add(new DarkTheme());
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
