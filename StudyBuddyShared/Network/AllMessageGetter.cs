using Newtonsoft.Json.Linq;
using StudyBuddy.Entity;
using StudyBuddy.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace StudyBuddyShared.Network
{
    public class AllMessageGetter
    {
        public enum MessageStatus
        {
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            FieldsMissing,
            ConversationNotFound
        }

        public delegate void MessageGetDelegate(MessageStatus status, List<Conversation> conversations, Dictionary<int, List<Message>> messages, Dictionary<string, User> users);
        public MessageGetDelegate GetMessageResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getMessageThread;

        public AllMessageGetter() : this("") { }
        public AllMessageGetter(LocalUser user) : this(user.PrivateKey) { }
        public AllMessageGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public AllMessageGetter(MessageGetDelegate getMessageResult) : this("", getMessageResult) { }
        public AllMessageGetter(LocalUser user, MessageGetDelegate getMessageResult) : this(user.PrivateKey, getMessageResult) { }
        public AllMessageGetter(string privateKey, MessageGetDelegate getMessageResult) : this(privateKey)
        {
            GetMessageResult = getMessageResult;
        }

        public void get(long timestamp, bool getUsers, bool waitForMessage)
        {
            if (getMessageThread != null && getMessageThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getMessageThread = new Thread(() => getLogic(timestamp, getUsers, waitForMessage)); // There's probably a better way
            getMessageThread.Start();
        }

        private void getLogic(long timestamp, bool getUsers, bool waitForMessage)
        {
            APICaller caller = new APICaller("getAllMessages.php").addParam("privateKey", PrivateKey).addParam("timestamp", timestamp.ToString());
            if (waitForMessage)
            {
                caller.addParam("wait", "");
            }
            if (getUsers)
            {
                caller.addParam("user", "");
            }
            var obj = caller.call();
            //Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {

                List<Conversation> conversations = new List<Conversation>();
                Dictionary<int, List<Message>> messages = new Dictionary<int, List<Message>>();
                Dictionary<string, User> users = null;
                obj["conversations"].ToList().ForEach((conversation) =>
                {
                    var conv = new Conversation
                    {
                        Id = conversation["id"].ToObject<int>(),
                        Title = conversation["title"].ToString(),
                        Messages = conversation["messages"].ToObject<int>(),
                        LastActivity = conversation["lastActivity"].ToObject<long>(),
                        LastMessage = conversation["lastMessage"].ToString()
                    };
                    conversation["users"].ToList().ForEach((user) =>
                    {
                        conv.Users.Add(user.ToString());
                    });
                    messages[conv.Id] = new List<Message>();
                    conversation["messageArray"].ToList().ForEach((message) =>
                    {
                        messages[conv.Id].Add(new Message
                        {
                            Username = message["username"].ToString(),
                            Text = message["message"].ToString(),
                            Timestamp = message["timestamp"].ToObject<long>(),
                            Conversation = conv.Id
                        });
                    });
                    conversations.Add(conv);
                });
                if (getUsers)
                {
                    users = new Dictionary<string, User>();
                    obj["users"].ToList().ForEach((user) =>
                    {
                        users[user.First["username"].ToString()] = new User
                        {
                            Username = user.First["username"].ToString(),
                            FirstName = user.First["firstName"].ToString(),
                            LastName = user.First["lastName"].ToString(),
                            KarmaPoints = user.First["karmaPoints"].ToObject<int>(),
                            IsLecturer = Convert.ToBoolean(user.First["lecturer"].ToObject<int>()),
                            ProfilePictureLocation = user.First["profilePicture"].ToString()
                        };
                    });
                }
                GetMessageResult(MessageStatus.Success, conversations, messages, users);
            }
            else
            {
                MessageStatus status = MessageStatus.UnknownError;
                if (!Enum.TryParse<MessageStatus>(obj["message"].ToString(), out status))
                {
                    status = MessageStatus.UnknownError;
                }
                GetMessageResult(status, null, null, null);
            }
        }
    }
}
