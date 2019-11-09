using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Services
{
    public class MessagingTask // Naudojama MessagingCenter komunikacijai
    {
        /// Messages ir jų argumentai
        
        // No arguments
        public static readonly string Start = "Start";

        // No arguments                           
        public static readonly string Stop = "Stop";

        // No arguments                             
        public static readonly string Started = "Started";

        // No arguments                       
        public static readonly string GetMessages = "GetMessages";

        // Tuple<Dictionary<int, List<Message>>, Dictionary<string, User>>
        public static readonly string LocalMessages = "LocalMessages";

        // Tuple<Dictionary<int, List<Message>>, Dictionary<string, User>>
        public static readonly string Messages = "Messages";

        // Message                    
        public static readonly string AddMessageToQueue = "AddMessageToQueue";

        // No arguments    
        public static readonly string GetConversations = "GetConversations";

        // Tuple<List<Conversation>, Dictionary<string, User>>
        public static readonly string LocalConversations = "LocalConversations"; 

        ///
    }
}
