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
    public class MessagePoster
    {
        public enum MessageStatus
        {
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,   
            FieldsMissing,
            ConversationNotFound,
            MessageTooLong,
            MessageEmpty
        }
        
        public delegate void MessagePostDelegate(MessageStatus status, Conversation conversation, string message);
        public MessagePostDelegate PostMessageResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread postMessageThread;

        public MessagePoster() : this("") { }
        public MessagePoster(LocalUser user) : this(user.PrivateKey) { }
        public MessagePoster(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public MessagePoster(MessagePostDelegate postMessageResult) : this("", postMessageResult) { }
        public MessagePoster(LocalUser user, MessagePostDelegate postMessageResult) : this(user.PrivateKey, postMessageResult) { }
        public MessagePoster(string privateKey, MessagePostDelegate postMessageResult) : this(privateKey)
        {
            PostMessageResult = postMessageResult;
        }

        public void post(Conversation conversation, string message)
        {
            if (postMessageThread != null && postMessageThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(message) || String.IsNullOrWhiteSpace(message))
            {
                PostMessageResult(MessageStatus.MessageEmpty, conversation, message);
                return;
            }
            if (conversation == null)
            {
                PostMessageResult(MessageStatus.ConversationNotFound, conversation, message);
                return;
            }
            postMessageThread = new Thread(() => postLogic(conversation, message)); // There's probably a better way
            postMessageThread.Start();
        }

        public void post(int conversation, string message)
        {
            post(new Conversation { Id = conversation }, message);
        }
        private void postLogic(Conversation conversation, string message)
        {
            //Console.Write("Starting to send " + message + "\n");
            JObject obj = new APICaller("postMessage.php").AddParam("conversation", conversation.Id.ToString()).AddParam("message", message).AddParam("privateKey", PrivateKey).Call();

            //Console.Write("Sent " + message + "\n");
            //Console.Write(obj);
            if (obj["status"].ToString() == "success")
            {
                PostMessageResult(MessageStatus.Success, conversation, message);
            }
            else
            {
                MessageStatus status = MessageStatus.UnknownError;
                if (!Enum.TryParse<MessageStatus>(obj["message"].ToString(), out status))
                {
                    status = MessageStatus.UnknownError;
                }
                PostMessageResult(status, null, null);
            }
        }
    }
}
