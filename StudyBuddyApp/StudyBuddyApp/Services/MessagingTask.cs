using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Services
{
    public class MessagingTask // Naudojama MessagingCenter komunikacijai
    {
        /// Messages 
        public static readonly string Start = "Start";                           // R
        public static readonly string Stop = "Stop";                             // R
        public static readonly string Started = "Started";                       // S
        public static readonly string GetMessages = "GetMessages";               // R
        public static readonly string LocalMessages = "LocalMessages";           // S
        public static readonly string Messages = "Messages";                     // S
        public static readonly string AddMessageToQueue = "AddMessageToQueue";   // R
        public static readonly string GetConversations = "GetConversations";     // R
        public static readonly string LocalConversations = "LocalConversations"; // S
        ///
    }
}
