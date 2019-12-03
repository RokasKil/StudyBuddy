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
using Newtonsoft.Json.Linq;
using StudyBuddyApp.Droid.Utility;
using StudyBuddyApp.Utility;
using StudyBuddyApp.ViewModels;
using StudyBuddyShared.Entity;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationStartAndroid))]
namespace StudyBuddyApp.Droid.Utility
{
    public class NotificationStartAndroid : INotificationStart
    {
        public static Intent Intent { get; set; } = null;
        public ConversationViewModel GetStartModel()
        {
            if (Intent == null)
            {
                return null;
            }
            if (Intent.HasExtra("conversation"))
            {
                Console.WriteLine("Conversation intent");
                Conversation conversation = JObject.Parse(Intent.GetStringExtra("conversation")).ToObject<Conversation>();
                Dictionary<string, User> users = JObject.Parse(Intent.GetStringExtra("users")).ToObject<Dictionary<string, User>>();
                ConversationViewModel model = new ConversationViewModel(conversation, users);
                return model;
            }
            return null;
        }
    }
}