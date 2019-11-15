using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.Services
{
    public class MessagingTask // Naudojama MessagingCenter komunikacijai
    {

        public Conversation Conversation { get; set; }
        public Message Message { get; set; }
        public int GetCount { get; set; }
        public Dictionary<string, User> Users { get; set; }
        public Dictionary<int, List<Message>> MessagesDict { get; set; }
        public List<Message> Messages { get; set; }
        public List<Conversation> Conversations { get; set; }

        public MessagingTask( // Viskas optional
            Conversation conversation = null,
            Message message = null,
            int getCount = 0,
            Dictionary<string, User> users = null,
            Dictionary<int, List<Message>> messagesDict = null,
            List<Message> messages = null,
            List<Conversation> conversations = null) {
            Conversation = conversation;
            Message = message;
            GetCount = getCount;
            Users = users;
            MessagesDict = messagesDict;
            Messages = messages;
            Conversations = conversations;
        }

        /// Messages ir jų argumentai

        // No arguments
        public static readonly string Start = "Start"; // Pradeda service

        // No arguments                           
        public static readonly string Stop = "Stop";  // Sustabdo service

        // No arguments                             
        public static readonly string Started = "Started"; // Praneša kad service pradėtas

        // No arguments                       
        public static readonly string GetMessages = "GetMessages"; // Prašo turimų pranešimų

        // Conversation, GetCount, optional Message                      
        public static readonly string GetMessagesLimited = "GetMessagesLimited"; // Prašo turimų pranešimų su limitais

        // MessagesDict, Users
        public static readonly string LocalMessages = "LocalMessages"; // Turimi pranešimai, atsakas į GetMessages

        // Messages, Users
        public static readonly string LocalMessagesLimited = "LocalMessagesLimited"; // Turimi pranešimai, atsakai į GetMessagesLimited

        // MessagesDict, Users
        public static readonly string NewMessages = "Messages"; // Siunčiama gavus naują pranešimą

        // Message                    
        public static readonly string AddMessageToQueue = "AddMessageToQueue"; // Siųsti pranešimą

        // No arguments    
        public static readonly string GetConversations = "GetConversations"; // Gauti turimus pokalbius

        // Conversation, Users
        public static readonly string LocalConversations = "LocalConversations"; // Turimi pokalbiai, atsakas į GetConversations

        ///
    }
}
