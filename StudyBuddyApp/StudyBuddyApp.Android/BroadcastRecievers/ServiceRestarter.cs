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
using StudyBuddyApp.Droid.Services;

namespace StudyBuddyApp.Droid.BroadcastRecievers
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    [IntentFilter(new[] { MessagingService.SERVICE_KILLED_MESSAGE })]
    public class ServiceRestarter : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
            Intent serviceIntent = new Intent(context, typeof(MessagingService));
            context.StartService(intent);
        }
    }
}