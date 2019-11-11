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
    public class MessageGetter
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

        public delegate void MessageGetDelegate(MessageStatus status, List<Message> messages);
        public MessageGetDelegate GetMessageResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getMessageThread;

        public MessageGetter() : this("") { }
        public MessageGetter(LocalUser user) : this(user.PrivateKey) { }
        public MessageGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public MessageGetter(MessageGetDelegate getMessageResult) : this("", getMessageResult) { }
        public MessageGetter(LocalUser user, MessageGetDelegate getMessageResult) : this(user.PrivateKey, getMessageResult) { }
        public MessageGetter(string privateKey, MessageGetDelegate getMessageResult) : this(privateKey)
        {
            GetMessageResult = getMessageResult;
        }

        public void get(Conversation conversation, long timestamp, bool wait)
        {
            if (getMessageThread != null && getMessageThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (conversation == null)
            {
                GetMessageResult(MessageStatus.ConversationNotFound, null);
                return;
            }
            getMessageThread = new Thread(() => getLogic(conversation, timestamp, wait)); // There's probably a better way
            getMessageThread.Start();
        }

        private void getLogic(Conversation conversation, long timestamp, bool wait)
        {
            APICaller caller = new APICaller("getMessages.php").addParam("privateKey", PrivateKey).addParam("conversation", conversation.Id.ToString()).addParam("timestamp", timestamp.ToString());
            if (wait)
            {
                caller.addParam("wait", "");
            }
            var obj = caller.call();
            //Console.Write(obj);
            if (obj["status"].ToString() == "success")
            {
                List<Message> messages = new List<Message>();

                obj["messages"].ToList().ForEach((message) =>
                {
                    messages.Add(new Message
                    {
                        Username = message["username"].ToString(),
                        Text = message["message"].ToString(),
                        Timestamp = message["timestamp"].ToObject<long>(),
                        Conversation = message["conversation"].ToObject<int>()
                    });
                });
                GetMessageResult(MessageStatus.Success, messages);
            }
            else
            {
                MessageStatus status = MessageStatus.UnknownError;
                if (!Enum.TryParse<MessageStatus>(obj["message"].ToString(), out status))
                {
                    status = MessageStatus.UnknownError;
                }
                GetMessageResult(status, null);
            }
        }
    }
}
