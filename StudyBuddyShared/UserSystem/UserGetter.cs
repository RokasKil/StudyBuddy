using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserSystem
{
    public class UserGetter : IUserGetter
    {
        public UserGetter(LocalUser user) : this(user.PrivateKey)
        {

        }

        public UserGetter(string privateKey)
        {
            this.PrivateKey = privateKey;
            getter = new Network.UserGetter(privateKey, (status, user) =>
            {
                Result?.Invoke(EnumConverter.Convert<UserGetStatus>(status), user);
            });
        }

        private Network.UserGetter getter;

        public GetUserResultDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        public void Get(string username)
        {
            getter.get(username);
        }
    }
}
