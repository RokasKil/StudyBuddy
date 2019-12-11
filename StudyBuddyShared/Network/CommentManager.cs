using Newtonsoft.Json.Linq;
using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StudyBuddyShared.Network
{
    public class CommentManager
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
            MessageTooLong
        }

        public delegate void CommentManagerDelegate(ManagerStatus status, Comment comment);
        public CommentManagerDelegate PostCommentResult { get; set; }
        public CommentManagerDelegate RemoveCommentResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread UserReviewManagerThread;

        public CommentManager() : this("") { }
        public CommentManager(LocalUser user) : this(user.PrivateKey) { }
        public CommentManager(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public void postComment(Comment comment)
        {
            if (UserReviewManagerThread != null && UserReviewManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(comment.Message) || String.IsNullOrWhiteSpace(comment.Message))
            {
                PostCommentResult(ManagerStatus.MessageEmpty, null);
                return;
            }
            if (comment.Message.Length > 2000)
            {
                PostCommentResult(ManagerStatus.MessageTooLong, null);
                return;
            }

            UserReviewManagerThread = new Thread(() => apiLogic(true, comment)); // There's probably a better way
            UserReviewManagerThread.Start();
        }

        public void removeComment(Comment comment)
        {
            if (UserReviewManagerThread != null && UserReviewManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            UserReviewManagerThread = new Thread(() => apiLogic(false, comment)); // There's probably a better way
            UserReviewManagerThread.Start();
        }


        public void apiLogic(bool post, Comment comment)
        {
            JObject obj;
            if (post)
            {
                obj = new APICaller("postHelpRequestComment.php")
                .AddParam("privateKey", PrivateKey)
                .AddParam("id", comment.HelpRequestID.ToString())
                .AddParam("message", comment.Message)
                .Call();
            }
            else
            {
                obj = new APICaller("removeHelpRequestComment.php")
                .AddParam("privateKey", PrivateKey)
                .AddParam("id", comment.CommentID.ToString())
                .Call();
            }
            if (obj["status"].ToString() == "success" && post)
            {
                comment.CommentID = obj["id"].ToObject<int>();
            }
            //TODO: get id from result
            ManagerStatus status = ManagerStatus.UnknownError;
            if (!Enum.TryParse<ManagerStatus>(obj["message"].ToString(), out status))
            {
                status = ManagerStatus.UnknownError;
            }
            if (post)
            {
                PostCommentResult(status, comment);
            }
            else
            {
                RemoveCommentResult(status, comment);
            }

        }
    }
}
