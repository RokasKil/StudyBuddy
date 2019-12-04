using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;


namespace StudyBuddyShared.UserSystem
{
    public class RankingsGetter :IRankingsGetter
    {
        public RankingsGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public RankingsGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
            getter = new Network.RankingsGetter(privateKey, (status, helpRequests) =>
            {
                Result?.Invoke(EnumConverter.Convert<RankingsGetStatus>(status), helpRequests);
            });
        }

        private Network.RankingsGetter getter;

        public GetRankingsDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        public void Get()
        {
            getter.get();
        }
    }
}
