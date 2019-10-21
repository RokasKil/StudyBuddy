using Newtonsoft.Json.Linq;
using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace StudyBuddy.Network
{
    class ConversationStarter
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
        public ConversationStarter(LocalUser user) : this(user.privateKey) { }
        public ConversationStarter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public ConversationStarter(ConversationStartDelegate conversationStartResult) : this("", conversationStartResult) { }
        public ConversationStarter(LocalUser user, ConversationStartDelegate conversationStartResult) : this(user.privateKey, conversationStartResult) { }
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
                    id = obj["conversation"]["id"].ToObject<int>(),
                    title = obj["conversation"]["title"].ToString(),
                    messages = obj["conversation"]["messages"].ToObject<int>(),
                    lastActivity = obj["conversation"]["lastActivity"].ToObject<long>(),
                    lastMessage = "",

                };
                try
                {
                    obj["conversation"]["users"].ToList().ForEach((user) =>
                    {
                        conversation.users.Add(user.First.ToString());
                    });
                }
                catch(InvalidOperationException e)
                {
                    obj["conversation"]["users"].ToList().ForEach((user) =>
                    {
                        conversation.users.Add(user.ToString());
                    });
                }
                obj["users"].ToList().ForEach((user) =>
                {
                    users[user.First["username"].ToString()] = new User
                    {
                        username = user.First["username"].ToString(),
                        firstName = user.First["firstName"].ToString(),
                        lastName = user.First["lastName"].ToString(),
                        KarmaPoints = user.First["karmaPoints"].ToObject<int>(),
                        IsLecturer = Convert.ToBoolean(user.First["lecturer"].ToObject<int>()),
                        profilePictureLocation = user.First["profilePicture"].ToString(),
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
