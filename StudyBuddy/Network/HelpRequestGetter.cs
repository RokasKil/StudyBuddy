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
    class HelpRequestGetter
    {
        public enum GetStatus
        {
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            FieldsMissing
        }
        public delegate void GetHelpRequestsDelegate(GetStatus status, List<HelpRequest> helpRequests, Dictionary<string, User> users);
        public GetHelpRequestsDelegate GetHelpRequestsResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getHelpRequestsThread;

        public HelpRequestGetter() : this("") { }
        public HelpRequestGetter(LocalUser user) : this(user.privateKey) { }
        public HelpRequestGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public HelpRequestGetter(GetHelpRequestsDelegate getHelpRequestsResult) : this("", getHelpRequestsResult) { }
        public HelpRequestGetter(LocalUser user, GetHelpRequestsDelegate getHelpRequestsResult) : this(user.privateKey, getHelpRequestsResult) { }
        public HelpRequestGetter(string privateKey, GetHelpRequestsDelegate getHelpRequestsResult) : this(privateKey)
        {
            GetHelpRequestsResult = getHelpRequestsResult;
        }

        public void get(bool getUsers)
        {
            if (getHelpRequestsThread != null && getHelpRequestsThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getHelpRequestsThread = new Thread(() => getLogic(getUsers));
            getHelpRequestsThread.Start();
        }

        private void getLogic(bool getUsers)
        {
            APICaller caller = new APICaller("getHelpRequests.php").addParam("privateKey", PrivateKey);
            if (getUsers)
            {
                caller.addParam("user", "");
            }
            JObject obj = caller.call();
            Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<HelpRequest> helpRequests = new List<HelpRequest>();
                Dictionary<string, User> users = null;
                obj["helpRequests"].ToList().ForEach((helpRequest) =>
                {
                    helpRequests.Add(new HelpRequest
                    {
                        id = helpRequest["id"].ToObject<int>(),
                        Title = helpRequest["title"].ToString(),
                        Description = helpRequest["description"].ToString(),
                        CreatorUsername = helpRequest["username"].ToString(),
                        Category = helpRequest["category"].ToString(),
                        timestamp = DateTimeOffset.FromUnixTimeSeconds(helpRequest["postDate"].ToObject<long>()).DateTime
                    });
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
                        };
                    });
                }
                GetHelpRequestsResult(GetStatus.Success, helpRequests, users);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetHelpRequestsResult(status, null, null);
            }
        }
    }
}
