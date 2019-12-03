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
using Plugin.CurrentActivity;

namespace StudyBuddyApp.Droid
{
    [Activity(Label = "StudyBuddyApp", Icon = "@mipmap/icon", RoundIcon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            CrossCurrentActivity.Current.Activity = this;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            MessagingCenter.Subscribe<MessagingTask>(this, MessagingTask.Start, (service) =>
            {
                Intent intent = new Intent(this, typeof(MessagingService));
                StartService(intent);
            });
            CheckBrand();
        }
        private async void CheckBrand()
        {
            if (Build.Brand.ToLower() == "xiaomi" && !Xamarin.Forms.Application.Current.Properties.ContainsKey("AutoStart"))
            {

                bool action = await App.Current.MainPage.DisplayAlert("Papildomi leidimai", "Norint gauti pranešimus jūsų prietaise reikia papildomų leidimų. Pridėkite programėlę sekančiame lange.", "Gerai", "Ne");
                if (action)
                {
                    Intent intent = new Intent();
                    intent.SetComponent(new ComponentName("com.miui.securitycenter", "com.miui.permcenter.autostart.AutoStartManagementActivity"));
                    StartActivity(intent);
                    Xamarin.Forms.Application.Current.Properties["AutoStart"] = true;
                    await Xamarin.Forms.Application.Current.SavePropertiesAsync();
                }

            }
        }
    }
}