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
    class RankingsGetter
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

        public delegate void GetRankingsDelegate(GetStatus status, List<User> rankings);
        public GetRankingsDelegate GetRankingsResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getRankingsThread;

        public RankingsGetter() : this("") { }
        public RankingsGetter(LocalUser user) : this(user.PrivateKey) { }
        public RankingsGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public RankingsGetter(GetRankingsDelegate getRankingsResult) : this("", getRankingsResult) { }
        public RankingsGetter(LocalUser user, GetRankingsDelegate getRankingsResult) : this(user.PrivateKey, getRankingsResult) { }
        public RankingsGetter(string privateKey, GetRankingsDelegate getRankingsResult) : this(privateKey)
        {
            GetRankingsResult = getRankingsResult;
        }

        public void get()
        {
            if (getRankingsThread != null && getRankingsThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getRankingsThread = new Thread(() => getLogic());
            getRankingsThread.Start();
        }

        private void getLogic()
        {
            APICaller caller = new APICaller("getRankings.php").AddParam("privateKey", PrivateKey);

            JObject obj = caller.Call();
            //Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<User> rankings = new List<User>();
                obj["users"].ToList().ForEach((user) =>
                {
                    rankings.Add(new User
                    {
                        Username = user["username"].ToString(),
                        FirstName = user["firstName"].ToString(),
                        LastName = user["lastName"].ToString(),
                        KarmaPoints = user["karmaPoints"].ToObject<int>(),
                        IsLecturer = Convert.ToBoolean(user["lecturer"].ToObject<int>()),
                        ProfilePictureLocation = user["profilePicture"].ToString()
                    });
                });
                GetRankingsResult(GetStatus.Success, rankings);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetRankingsResult(status, null);
            }
        }
    }
}
