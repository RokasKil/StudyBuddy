using Newtonsoft.Json.Linq;
using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBuddyShared.Network
{
    public class KarmaBadgeListGetter
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
        public delegate void GetKarmaBadgeListDelegate(GetStatus status, List<KarmaBadge> karmaBadges);
        public GetKarmaBadgeListDelegate GetKarmaBadgeListResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getKarmaBadgeListThread;

        public KarmaBadgeListGetter() : this("") { }
        public KarmaBadgeListGetter(LocalUser user) : this(user.PrivateKey) { }
        public KarmaBadgeListGetter(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public KarmaBadgeListGetter(GetKarmaBadgeListDelegate getCategoriesResult) : this("", getCategoriesResult) { }
        public KarmaBadgeListGetter(LocalUser user, GetKarmaBadgeListDelegate getKarmaBadgeListResult) : this(user.PrivateKey, getKarmaBadgeListResult) { }
        public KarmaBadgeListGetter(string privateKey, GetKarmaBadgeListDelegate getKarmaBadgeListResult) : this(privateKey)
        {
            GetKarmaBadgeListResult = getKarmaBadgeListResult;
        }

        public void get()
        {
            if (getKarmaBadgeListThread != null && getKarmaBadgeListThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            getKarmaBadgeListThread = new Thread(getLogic);
            getKarmaBadgeListThread.Start();
        }

        private void getLogic()
        {
            JObject obj = new APICaller("getKarmaBadges.php").addParam("privateKey", PrivateKey).call();
            //Console.WriteLine(obj);
            if (obj["status"].ToString() == "success")
            {
                List<KarmaBadge> karmaBadges = new List<KarmaBadge>();
                obj["badges"].ToList().ForEach((KarmaBadge) =>
                {
                    karmaBadges.Add(new KarmaBadge
                    {
                        Image = KarmaBadge["imageLocation"].ToString(),
                        Title = KarmaBadge["name"].ToString(),
                        StartValue = KarmaBadge["starts"].ToObject<int>(),
                    }) ;
                });
                GetKarmaBadgeListResult(GetStatus.Success, karmaBadges);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                GetKarmaBadgeListResult(status, null);
            }
        }
    }
}
