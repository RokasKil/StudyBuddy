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
    public class UserReviewGetter
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
        public UserReviewGetter(LocalUser user) : this(user.PrivateKey) { }
        public UserReviewGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public UserReviewGetter(GetUserReviewDelegate getUserReviewResult) : this("", getUserReviewResult) { }
        public UserReviewGetter(LocalUser user, GetUserReviewDelegate getUserReviewResult) : this(user.PrivateKey, getUserReviewResult) { }
        public UserReviewGetter(string privateKey, GetUserReviewDelegate getUserReviewResult) : this(privateKey)
        {
            GetUserReviewResult = getUserReviewResult;
        }

        public void get(bool getUsers, string username)
        {
            if (getUserReviewThread != null && getUserReviewThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getUserReviewThread = new Thread(() => getLogic(getUsers, username));
            getUserReviewThread.Start();
        }

        private void getLogic(bool getUsers, string username)
        {
            APICaller caller = new APICaller("getReviews.php").AddParam("privateKey", PrivateKey).AddParam("username", username);
            if (getUsers)
            {
                caller.AddParam("user", "");
            }

            JObject obj = caller.Call();
            //Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<UserReview> userReviews = new List<UserReview>();
                Dictionary<string, User> users = null;
                obj["reviews"].ToList().ForEach((userReview) =>
                {
                    userReviews.Add(new UserReview
                    {
                        Message = userReview["message"].ToString(),
                        Karma = userReview["karma"].ToObject<int>(),
                        Username = userReview["username"].ToString(),
                        PostDate = DateTimeOffset.FromUnixTimeSeconds(userReview["postDate"].ToObject<long>()).DateTime
                    });
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

                            //gender = Convert.ToBoolean(user.First["gender"].ToObject<int>()),
                            ProfilePictureLocation = user.First["profilePicture"].ToString()
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
