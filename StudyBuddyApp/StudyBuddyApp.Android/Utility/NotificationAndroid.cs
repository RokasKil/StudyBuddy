using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;
using StudyBuddyApp.Droid.Utility;
using StudyBuddyApp.Utility;
using StudyBuddyShared.Entity;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationAndroid))]
namespace StudyBuddyApp.Droid.Utility
{
    public class NotificationAndroid : INotification
    {
        private string channelName = "MessageNotifications";
        private string channelId = "0";
        private string channelDescription = "Pranešimų kanalas";
        private bool channelInitialized = false;
        private NotificationManager manager;
        private Dictionary<int, List<WeakReference>> blocks = new Dictionary<int, List<WeakReference>>();
        // Display notifications
        public void DisplayMessageNotification(Conversation conversation, StudyBuddyShared.Entity.Message message, Dictionary<string, User> users)
        {
            //Check if running in foreground
            if ( !Xamarin.Forms.DependencyService.Get<IBackgroundChecker>().IsInBackground() && IsBlocked(conversation))
            {
                return;
            }
            if (!channelInitialized)
            {
                CreateNotificationChannel();
            }
            string title = users[message.Username].FirstName + " " + users[message.Username].LastName;
            Intent intent = new Intent(Application.Context, typeof(SplashActivity));
            intent.PutExtra("conversation", JObject.FromObject(conversation).ToString());
            intent.PutExtra("users", JObject.FromObject(users).ToString());
            intent.SetFlags(ActivityFlags.ReorderToFront);

            PendingIntent pendingIntent = PendingIntent.GetActivity(Application.Context, conversation.Id, intent, PendingIntentFlags.UpdateCurrent);
            //Build notification
            NotificationCompat.Builder builder = new NotificationCompat.Builder(Application.Context, channelId)
                .SetContentIntent(pendingIntent)
                .SetContentTitle(title)
                .SetContentText(message.Text)
                .SetLargeIcon(BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Mipmap.icon))
                .SetSmallIcon(Resource.Mipmap.launcher_foreground)
                .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);

            var notification = builder.Build();
            manager.Notify(conversation.Id, notification);
        }
        //Create a notification channel (android thing)
        private void CreateNotificationChannel()
        {
            manager = (NotificationManager) Application.Context.GetSystemService(Context.NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelNameJava = new Java.Lang.String(channelName);
                var channel = new NotificationChannel(channelId, channelNameJava, NotificationImportance.Default)
                {
                    Description = channelDescription
                };
                manager.CreateNotificationChannel(channel);
            }

            channelInitialized = true;
        }

        private bool IsBlocked(Conversation conversation)
        {
            if (!blocks.ContainsKey(conversation.Id))
            {
                return false;
            }
            blocks[conversation.Id].RemoveAll((reference) => !reference.IsAlive);
            return blocks[conversation.Id].Count != 0;
        }

        //Weak refrence leidžia objektui būt pašilintum
        public void BlockNotification(Object obj, Conversation conversation)
        {
            if (!blocks.ContainsKey(conversation.Id))
            {
                blocks[conversation.Id] = new List<WeakReference>();
            }
            blocks[conversation.Id].Add(new WeakReference(obj));
        }
        
        public void AllowNotifcation(Object obj, Conversation conversation)
        {
            if (blocks.ContainsKey(conversation.Id))
            {
                blocks[conversation.Id].RemoveAll((reference) => reference.Target.Equals(obj) || !reference.IsAlive);
            }
        }
    }
}