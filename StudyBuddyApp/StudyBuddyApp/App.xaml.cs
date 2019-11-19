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
            if (Application.Current.Properties.ContainsKey("DarkMode") && (bool)Application.Current.Properties["DarkMode"])
            {
                Current.Resources.MergedDictionaries.Add(new DarkTheme());
            }
            else
            {
                Current.Resources.MergedDictionaries.Add(new LightTheme());
            }
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
