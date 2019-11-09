using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StudyBuddyApp.Droid.Utility;
using StudyBuddyApp.Utility;

[assembly: Xamarin.Forms.Dependency(typeof(ToastAndroid))]
namespace StudyBuddyApp.Droid.Utility
{
    public class ToastAndroid : IToast
    {
        public void LongToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}