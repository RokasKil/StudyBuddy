using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserSystem
{
    public class UserUpdater : IUserUpdater
    {
        public UserUpdater(LocalUser user) : this(user.PrivateKey)
        {

        }

        public UserUpdater(string privateKey)
        {
            this.PrivateKey = privateKey;
            updater = new Network.UserUpdater(privateKey, (status, firstName, lastName) =>
            {
                Result?.Invoke(EnumConverter.Convert<UserUpdateStatus>(status), firstName, lastName);
            });
        }

        private Network.UserUpdater updater;

        public UpdateUserResultDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        public void Update(string firstName, string lastName)
        {
            updater.get(firstName, lastName);
        }
    }
}
