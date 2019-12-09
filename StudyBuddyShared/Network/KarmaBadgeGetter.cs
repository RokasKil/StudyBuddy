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
    public class KarmaBadgeGetter
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

        public delegate void GetKarmaBadgeResultDelegate(GetStatus status, KarmaBadge karmaBadge);
        public GetKarmaBadgeResultDelegate GetKarmaBadgeResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getKarmaBadgeThread;

        public KarmaBadgeGetter() : this("") { }
        public KarmaBadgeGetter(LocalUser user) : this(user.PrivateKey) { }
        public KarmaBadgeGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public KarmaBadgeGetter(GetKarmaBadgeResultDelegate getKarmaBadgeResult) : this("", getKarmaBadgeResult) { }
        public KarmaBadgeGetter(LocalUser user, GetKarmaBadgeResultDelegate getKarmaBadgeResult) : this(user.PrivateKey, getKarmaBadgeResult) { }
        public KarmaBadgeGetter(string privateKey, GetKarmaBadgeResultDelegate getKarmaBadgeResult) : this(privateKey)
        {
            GetKarmaBadgeResult = getKarmaBadgeResult;
        }
        public void get(string username)
        {
            if (getKarmaBadgeThread != null && getKarmaBadgeThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                GetKarmaBadgeResult(GetStatus.UsernameEmpty, null);
                return;
            }
            getKarmaBadgeThread = new Thread(() => getLogic(username)); // There's probably a better way
            getKarmaBadgeThread.Start();
        }

        private void getLogic(string username)
        {
            JObject obj = new APICaller("getKarmaBadge.php").addParam("username", username).addParam("privateKey", PrivateKey).call();
            if (obj["status"].ToString() == "success")
            {
                KarmaBadge karmaBadge = new KarmaBadge
                {
                    Image = obj["badge"]["imageLocation"].ToString(),
                    Title = obj["badge"]["name"].ToString()
                };
                GetKarmaBadgeResult(GetStatus.Success, karmaBadge);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetKarmaBadgeResult(status, null);
            }
        }
    }
}
