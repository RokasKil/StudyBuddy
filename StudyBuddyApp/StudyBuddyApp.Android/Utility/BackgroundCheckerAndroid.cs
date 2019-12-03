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
using static Android.App.ActivityManager;

[assembly: Xamarin.Forms.Dependency(typeof(BackgroundCheckerAndroid))]
namespace StudyBuddyApp.Droid.Utility
{
    public class BackgroundCheckerAndroid : IBackgroundChecker
    {
        public bool IsInBackground()
        {
            RunningAppProcessInfo myProcess = new RunningAppProcessInfo();
            GetMyMemoryState(myProcess);

            return myProcess.Importance != Android.App.Importance.Foreground;
        }
    }
}