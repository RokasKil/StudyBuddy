using Newtonsoft.Json.Linq;
using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StudyBuddyShared.Network
{
    public class CommentsGetter
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
        public delegate void GetCommentsDelegate(GetStatus status, List<Comment> comments, Dictionary<string, User> users);
        public GetCommentsDelegate GetCommentsResult { get; set; }
        public string PrivateKey { get; set; }
        public int helpRequestID;
        private Thread getCategoriesThread;

        public CommentsGetter() : this("") { }
        public CommentsGetter(LocalUser user) : this(user.PrivateKey) { }
        public CommentsGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public CommentsGetter(GetCommentsDelegate getCategoriesResult) : this("", getCategoriesResult) { }
        public CommentsGetter(LocalUser user, GetCommentsDelegate getCategoriesResult) : this(user.PrivateKey, getCategoriesResult) { }
        public CommentsGetter(string privateKey, GetCommentsDelegate getCommentResult) : this(privateKey)
        {
            GetCommentsResult = getCommentResult;
        }

        public void get(int helpRequestID, bool user = true)
        {
            if (getCategoriesThread != null && getCategoriesThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getCategoriesThread = new Thread(()=>getLogic(helpRequestID, user));
            getCategoriesThread.Start();
        }

        private void getLogic(int helpRequestID, bool getUsers)
        {
            var caller = new APICaller("getHelpRequestComments.php").AddParam("privateKey", PrivateKey).
                AddParam("id", helpRequestID.ToString());
            if (getUsers)
            {
                caller.AddParam("user", "");
            }
            JObject obj = caller.Call();
            if (obj["status"].ToString() == "success")
            {
                List<Comment> comments = new List<Comment>();
                Dictionary<string, User> users = null;
                obj["comments"].ToList().ForEach((comment) =>
                {
                    comments.Add(new Comment
                    {
                        Message = comment["message"].ToString(),
                        Username = comment["username"].ToString(),
                        CommentID = comment["id"].ToObject<int>(),
                        CreatedDate = comment["postDate"].ToObject<long>(),
                        HelpRequestID = comment["help_request"].ToObject<int>()
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
                            ProfilePictureLocation = user.First["profilePicture"].ToString()
                        };
                    });
                }
                GetCommentsResult(GetStatus.Success, comments, users);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetCommentsResult(status, null, null);
            }
        }
    }
}
