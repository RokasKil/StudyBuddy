using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserReviewSystem
{
    class UserReviewGetter : IUserReviewGetter
    {
        public UserReviewGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public UserReviewGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
            getter = new Network.UserReviewGetter(privateKey, (status, helpRequests, users) =>
            {
                Result?.Invoke(EnumConverter.Convert<UserReviewsGetStatus>(status), helpRequests, users);
            });
        }

        private Network.UserReviewGetter getter;

        public GetUserReviewsDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        public void Get(string username, bool getUsers = true)
        {
            getter.get(getUsers, username);
        }
    }
}
