﻿using Newtonsoft.Json.Linq;
using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBuddyShared.Network
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
        public ConversationGetter(LocalUser user) : this(user.PrivateKey) { }
        public ConversationGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public ConversationGetter(GetConversationsDelegate getConversationsResult) : this("", getConversationsResult) { }
        public ConversationGetter(LocalUser user, GetConversationsDelegate getConversationsResult) : this(user.PrivateKey, getConversationsResult) { }
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
            APICaller caller = new APICaller("getConversations.php").AddParam("privateKey", PrivateKey);
            if (getUsers)
            {
                caller.AddParam("user", "");
            }
            JObject obj = caller.Call();
            //Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<Conversation> conversations = new List<Conversation>();

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
                    try
                    {
                        conversation["users"].ToList().ForEach((user) =>
                        {
                            conv.Users.Add(user.First.ToString());
                        });
                    }
                    catch (InvalidOperationException e)
                    {
                        conversation["users"].ToList().ForEach((user) =>
                        {
                            conv.Users.Add(user.ToString());
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
                            Username = user.First["username"].ToString(),
                            FirstName = user.First["firstName"].ToString(),
                            LastName = user.First["lastName"].ToString(),
                            KarmaPoints = user.First["karmaPoints"].ToObject<int>(),
                            IsLecturer = Convert.ToBoolean(user.First["lecturer"].ToObject<int>()),
                            ProfilePictureLocation = user.First["profilePicture"].ToString(),
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
