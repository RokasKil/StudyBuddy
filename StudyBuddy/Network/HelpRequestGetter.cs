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
        public delegate void GetHelpRequestsDelegate(GetStatus status, List<HelpRequest> helpRequests);
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

        public void get()
        {
            if (getHelpRequestsThread != null && getHelpRequestsThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getHelpRequestsThread = new Thread(getLogic);
            getHelpRequestsThread.Start();
        }

        private void getLogic()
        {
            JObject obj = new APICaller("getHelpRequests.php").addParam("privateKey", PrivateKey).call();
            Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<HelpRequest> helpRequests = new List<HelpRequest>();
                obj["helpRequests"].ToList().ForEach((helpRequest) =>
                {
                    helpRequests.Add(new HelpRequest
                    {
                        id = helpRequest["id"].ToObject<int>(),
                        title = helpRequest["title"].ToString(),
                        description = helpRequest["description"].ToString(),
                        creatorUsername = helpRequest["username"].ToString(),
                        category = helpRequest["category"].ToString()
                    });
                });
                GetHelpRequestsResult(GetStatus.Success, helpRequests);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetHelpRequestsResult(status, null);
            }
        }
    }
}
