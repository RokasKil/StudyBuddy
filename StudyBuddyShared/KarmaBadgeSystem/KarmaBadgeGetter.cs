using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.KarmaBadgeSystem
{
    public class KarmaBadgeGetter : IKarmaBadgeGetter
    {
        public KarmaBadgeGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public KarmaBadgeGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
            getter = new Network.KarmaBadgeGetter(privateKey, (status,  karmaBadge) =>
            {
                Result?.Invoke(EnumConverter.Convert<KarmaBadgeGetStatus>(status), karmaBadge);
            });
        }

        private Network.KarmaBadgeGetter getter;

        public GetKarmaBadgeResultDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        public void Get(string username)
        {
            getter.get(username);
        }
    }
}
