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
    class UserReviewManager
    {
        public enum ManagerStatus
        {
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            FailedToFindUser,
            UsernameEmpty,
            MessageEmpty,
            FieldsMissing,
            MessageTooLong,
            NoSelfReview
        }

        public delegate void UserReviewManagerDelegate(ManagerStatus status, UserReview userReview);
        public UserReviewManagerDelegate PostUserReviewResult { get; set; }
        public UserReviewManagerDelegate RemoveUserReviewResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread UserReviewManagerThread;

        public UserReviewManager() : this("") { }
        public UserReviewManager(LocalUser user) : this(user.privateKey) { }
        public UserReviewManager(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public void postReview(UserReview userReview)
        {
            if (UserReviewManagerThread != null && UserReviewManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(userReview.username) || String.IsNullOrWhiteSpace(userReview.username))
            {
                PostUserReviewResult(ManagerStatus.UsernameEmpty, null);
                return;
            }
            if (String.IsNullOrEmpty(userReview.message) || String.IsNullOrWhiteSpace(userReview.message))
            {
                PostUserReviewResult(ManagerStatus.MessageEmpty, null);
                return;
            }
            if (userReview.message.Length > 2000)
            {
                PostUserReviewResult(ManagerStatus.MessageTooLong, null);
                return;
            }

            UserReviewManagerThread = new Thread(() => apiLogic(true, userReview)); // There's probably a better way
            UserReviewManagerThread.Start();
        }

        public void removeUserReview(UserReview userReview)
        {
            if (UserReviewManagerThread != null && UserReviewManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            UserReviewManagerThread = new Thread(() => apiLogic(false, userReview)); // There's probably a better way
            UserReviewManagerThread.Start();
        }


        public void apiLogic(bool post, UserReview userReview)
        {
            JObject obj;
            if (post)
            {
                obj = new APICaller("postReview.php")
                .addParam("privateKey", PrivateKey)
                .addParam("message", userReview.message)
                .addParam("username", userReview.username)
                .addParam("positive", (userReview.karma > 0).ToString())
                .call();
            }
            else
            {
                obj = new APICaller("removeReview.php")
                .addParam("privateKey", PrivateKey)
                .addParam("username", userReview.username)
                .call();
            }
            ManagerStatus status = ManagerStatus.UnknownError;
            if (!Enum.TryParse<ManagerStatus>(obj["message"].ToString(), out status))
            {
                status = ManagerStatus.UnknownError;
            }
            if (post)
            {
                PostUserReviewResult(status, userReview);
            }
            else
            {
                RemoveUserReviewResult(status, userReview);
            }

        }

    }
}
