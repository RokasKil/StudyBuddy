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
        public delegate void GetCommentsDelegate(GetStatus status, List<Comment> comments);
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

        public void get(int helpRequestID)
        {
            if (getCategoriesThread != null && getCategoriesThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getCategoriesThread = new Thread(()=>getLogic(helpRequestID));
            getCategoriesThread.Start();
        }

        private void getLogic(int helpRequestID)
        {
            JObject obj = new APICaller("getHelpRequestComments.php").addParam("privateKey", PrivateKey).
                addParam("id", helpRequestID.ToString()).call();//TODO perduoti helprequestid
            if (obj["status"].ToString() == "success")
            {
                List<Comment> comments = new List<Comment>();
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
                GetCommentsResult(GetStatus.Success, comments);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetCommentsResult(status, null);
            }
        }
    }
}
