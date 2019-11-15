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
    public class UserReviewManager
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
        public UserReviewManager(LocalUser user) : this(user.PrivateKey) { }
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
            if (String.IsNullOrEmpty(userReview.Username) || String.IsNullOrWhiteSpace(userReview.Username))
            {
                PostUserReviewResult(ManagerStatus.UsernameEmpty, null);
                return;
            }
            if (String.IsNullOrEmpty(userReview.Message) || String.IsNullOrWhiteSpace(userReview.Message))
            {
                PostUserReviewResult(ManagerStatus.MessageEmpty, null);
                return;
            }
            if (userReview.Message.Length > 2000)
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
                .addParam("message", userReview.Message)
                .addParam("username", userReview.Username)
                .addParam("positive", (userReview.Karma > 0).ToString())
                .call();
            }
            else
            {
                obj = new APICaller("removeReview.php")
                .addParam("privateKey", PrivateKey)
                .addParam("username", userReview.Username)
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
