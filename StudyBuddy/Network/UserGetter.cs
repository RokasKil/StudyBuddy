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
    public class UserGetter
    {
        public enum GetStatus
        {
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            FailedToFindUser,
            UsernameEmpty,
            FieldsMissing
        }

        public delegate void GetUserResultDelegate(GetStatus status, User user);
        public GetUserResultDelegate GetUserResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getUserThread;

        public UserGetter() : this("") { }
        public UserGetter(LocalUser user) : this(user.privateKey) { }
        public UserGetter(string privateKey) {
            PrivateKey = privateKey;
        }

        public UserGetter(GetUserResultDelegate getUserResult) : this("", getUserResult) { }
        public UserGetter(LocalUser user, GetUserResultDelegate getUserResult) : this(user.privateKey, getUserResult) { }
        public UserGetter(string privateKey, GetUserResultDelegate getUserResult) : this(privateKey)
        {
            GetUserResult = getUserResult;
        }

        public void get(string username)
        {
            if (getUserThread != null && getUserThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                GetUserResult(GetStatus.UsernameEmpty, null);
                return;
            }
            getUserThread = new Thread(() => getLogic(username)); // There's probably a better way
            getUserThread.Start();
        }

        private void getLogic(string username)
        {
            JObject obj = new APICaller("getUser.php").addParam("username", username).addParam("privateKey", PrivateKey).call();
            if (obj["status"].ToString() == "success")
            {
                User user = new User
                {
                    username = obj["user"]["username"].ToString(),
                    firstName = obj["user"]["firstName"].ToString(),
                    lastName = obj["user"]["lastName"].ToString(),
                    KarmaPoints = obj["user"]["karmaPoints"].ToObject<int>(),
                    IsLecturer = Convert.ToBoolean(obj["user"]["lecturer"].ToObject<int>()),
                    profilePictureLocation = obj["user"]["profilePicture"].ToString()
                };
                GetUserResult(GetStatus.Success, user);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetUserResult(status, null);
            }
        }
    }
}
