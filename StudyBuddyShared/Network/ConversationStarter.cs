using Newtonsoft.Json.Linq;
using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace StudyBuddyShared.Network
{
    public class ConversationStarter
    {
        public enum ConversationStatus
        {
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            FailedToFindUser,
            UsernameEmpty,
            FieldsMissing
        }

        public delegate void ConversationStartDelegate(ConversationStatus status, Conversation conversation, Dictionary<string, User> users);
        public ConversationStartDelegate ConversationStartResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread startConversationThread;

        public ConversationStarter() : this("") { }
        public ConversationStarter(LocalUser user) : this(user.PrivateKey) { }
        public ConversationStarter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public ConversationStarter(ConversationStartDelegate conversationStartResult) : this("", conversationStartResult) { }
        public ConversationStarter(LocalUser user, ConversationStartDelegate conversationStartResult) : this(user.PrivateKey, conversationStartResult) { }
        public ConversationStarter(string privateKey, ConversationStartDelegate conversationStartResult) : this(privateKey)
        {
            ConversationStartResult = conversationStartResult;
        }

        public void start(string username)
        {
            if (startConversationThread != null && startConversationThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                ConversationStartResult(ConversationStatus.UsernameEmpty, null, null);
                return;
            }
            startConversationThread = new Thread(() => startLogic(username)); // There's probably a better way
            startConversationThread.Start();
        }

        private void startLogic(string username)
        {
            JObject obj = new APICaller("startConversation.php").addParam("username", username).addParam("privateKey", PrivateKey).call();
            if (obj["status"].ToString() == "success")
            {
                Dictionary<string, User>  users = new Dictionary<string, User>();
                Conversation conversation = new Conversation
                {
                    Id = obj["conversation"]["id"].ToObject<int>(),
                    Title = obj["conversation"]["title"].ToString(),
                    Messages = obj["conversation"]["messages"].ToObject<int>(),
                    LastActivity = obj["conversation"]["lastActivity"].ToObject<long>(),
                    LastMessage = "",

                };
                try
                {
                    obj["conversation"]["users"].ToList().ForEach((user) =>
                    {
                        conversation.Users.Add(user.First.ToString());
                    });
                }
                catch(InvalidOperationException e)
                {
                    obj["conversation"]["users"].ToList().ForEach((user) =>
                    {
                        conversation.Users.Add(user.ToString());
                    });
                }
                obj["users"].ToList().ForEach((user) =>
                {
                    users[user.First["username"].ToString()] = new User
                    {
                        Username = user.First["username"].ToString(),
                        FirstName = user.First["firstName"].ToString(),
                        LastName = user.First["lastName"].ToString(),
                        KarmaPoints = user.First["karmaPoints"].ToObject<int>(),
                        IsLecturer = Convert.ToBoolean(user.First["lecturer"].ToObject<int>()),
                        ProfilePictureLocation = user.First["profilePicture"].ToString(),
                    };
                });
                ConversationStartResult(ConversationStatus.Success, conversation, users);
            }
            else
            {
                ConversationStatus status = ConversationStatus.UnknownError;
                if (!Enum.TryParse<ConversationStatus>(obj["message"].ToString(), out status))
                {
                    status = ConversationStatus.UnknownError;
                }
                ConversationStartResult(status, null, null);
            }
        }
    }
}
