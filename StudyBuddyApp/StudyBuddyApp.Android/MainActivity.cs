using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using StudyBuddyApp.Services;
using Android.Content;
using StudyBuddyApp.Droid.Services;

namespace StudyBuddyApp.Droid
{
    [Activity(Label = "StudyBuddyApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.Start, (service) =>
            {
                Intent intent = new Intent(this, typeof(MessagingService));
                StartService(intent);
            });
        }

    }
}