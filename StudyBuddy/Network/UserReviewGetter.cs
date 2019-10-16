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
    class UserReviewGetter
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
        public delegate void GetUserReviewDelegate(GetStatus status, List<UserReview> userReviews, Dictionary<string, User> users);
        public GetUserReviewDelegate GetUserReviewResult { get; set; }

        public string PrivateKey { get; set; }
        private Thread getUserReviewThread;

        public UserReviewGetter() : this("") { }
        public UserReviewGetter(LocalUser user) : this(user.privateKey) { }
        public UserReviewGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public UserReviewGetter(GetUserReviewDelegate getUserReviewResult) : this("", getUserReviewResult) { }
        public UserReviewGetter(LocalUser user, GetUserReviewDelegate getUserReviewResult) : this(user.privateKey, getUserReviewResult) { }
        public UserReviewGetter(string privateKey, GetUserReviewDelegate getUserReviewResult) : this(privateKey)
        {
            GetUserReviewResult = getUserReviewResult;
        }

        public void get(bool getUsers)
        {
            if (getUserReviewThread != null && getUserReviewThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getUserReviewThread = new Thread(() => getLogic(getUsers));
            getUserReviewThread.Start();
        }

        private void getLogic(bool getUsers)
        {
            APICaller caller = new APICaller("getReviews.php").addParam("privateKey", PrivateKey);
            if (getUsers)
            {
                caller.addParam("user", "");
            }
            JObject obj = caller.call();
            Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<UserReview> userReviews = new List<UserReview>();
                Dictionary<string, User> users = null;
                obj["reviews"].ToList().ForEach((userReview) =>
                {
                    userReviews.Add(new UserReview
                    {
                        message = userReview["message"].ToString(),
                        karma = userReview["karma"].ToObject<int>(),
                        username = userReview["username"].ToString(),
                        postDate = DateTimeOffset.FromUnixTimeSeconds(userReview["postDate"].ToObject<long>()).DateTime
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
                GetUserReviewResult(GetStatus.Success, userReviews, users);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetUserReviewResult(status, null, null);
            }
        }

    }
}
