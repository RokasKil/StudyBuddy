using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.KarmaBadgeSystem
{
     public class KarmaBadgeListGetter : IKarmaBadgeListGetter
    {
        public GetKarmaBadgeListDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        private Network.KarmaBadgeListGetter getter;

        public KarmaBadgeListGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public KarmaBadgeListGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
            getter = new Network.KarmaBadgeListGetter(PrivateKey, (status, karmaBadges) =>
            {
                Result?.Invoke(EnumConverter.Convert<KarmaBadgeListGetStatus>(status), karmaBadges);
            });
        }

        public void Get()
        {
            getter.get();
        }
    }
}
