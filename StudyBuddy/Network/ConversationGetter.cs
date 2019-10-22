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
    public class ConversationGetter
    {
        public enum GetStatus
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
        public delegate void GetConversationsDelegate(GetStatus status, List<Conversation> conversations, Dictionary<string, User> users);
        public GetConversationsDelegate GetConversationsResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getConversationsThread;

        public ConversationGetter() : this("") { }
        public ConversationGetter(LocalUser user) : this(user.privateKey) { }
        public ConversationGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public ConversationGetter(GetConversationsDelegate getConversationsResult) : this("", getConversationsResult) { }
        public ConversationGetter(LocalUser user, GetConversationsDelegate getConversationsResult) : this(user.privateKey, getConversationsResult) { }
        public ConversationGetter(string privateKey, GetConversationsDelegate getConversationsResult) : this(privateKey)
        {
            GetConversationsResult = getConversationsResult;
        }

        public void get(bool getUsers)
        {
            if (getConversationsThread != null && getConversationsThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getConversationsThread = new Thread(() => getLogic(getUsers));
            getConversationsThread.Start();
        }

        private void getLogic(bool getUsers)
        {
            APICaller caller = new APICaller("getConversations.php").addParam("privateKey", PrivateKey);
            if (getUsers)
            {
                caller.addParam("user", "");
            }
            JObject obj = caller.call();
            //Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<Conversation> conversations = new List<Conversation>();

                Dictionary<string, User> users = null;
                obj["conversations"].ToList().ForEach((conversation) =>
                {
                    var conv = new Conversation
                    {
                        id = conversation["id"].ToObject<int>(),
                        title = conversation["title"].ToString(),
                        messages = conversation["messages"].ToObject<int>(),
                        lastActivity = conversation["lastActivity"].ToObject<long>(),
                        lastMessage = conversation["lastMessage"].ToString()
                    };
                    try
                    {
                        conversation["users"].ToList().ForEach((user) =>
                        {
                            conv.users.Add(user.First.ToString());
                        });
                    }
                    catch (InvalidOperationException e)
                    {
                        conversation["users"].ToList().ForEach((user) =>
                        {
                            conv.users.Add(user.ToString());
                        });
                    }
                    conversations.Add(conv);
                });
                
                
                if (getUsers)
                {
                    users = new Dictionary<string, User>();
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
                }
                GetConversationsResult(GetStatus.Success, conversations, users);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetConversationsResult(status, null, null);
            }
        }
    }
}
