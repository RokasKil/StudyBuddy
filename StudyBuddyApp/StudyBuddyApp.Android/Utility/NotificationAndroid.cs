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
        public void DisplayMessageNotification(Conversation conversation, StudyBuddyShared.Entity.Message message, Dictionary<string, User> users)
        {
            if (!channelInitialized)
            {
                CreateNotificationChannel();
            }
            string title = users[message.Username].FirstName + " " + users[message.Username].LastName;
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
            intent.PutExtra("conversation", conversation.Id);

            PendingIntent pendingIntent = PendingIntent.GetActivity(Application.Context, conversation.Id, intent, PendingIntentFlags.UpdateCurrent);

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
    }
    void BlockNotification(Object obj, Conversation conversation)
    {

    }
    void AllowNotifcation(Object obj, Conversation conversation)
    {

    }
}