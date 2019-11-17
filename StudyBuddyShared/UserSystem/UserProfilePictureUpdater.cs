using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserSystem
{
    public class UserProfilePictureUpdater : IUserProfilePictureUpdater
    {
        public UserProfilePictureUpdater(LocalUser user) : this(user.PrivateKey)
        {

        }

        public UserProfilePictureUpdater(string privateKey)
        {
            this.PrivateKey = privateKey;
            updater = new Network.ProfilePictureUpdater(privateKey, (status, pictureLocation) =>
            {
                Result?.Invoke(EnumConverter.Convert<PictureUpdateStatus>(status), pictureLocation);
            });
        }

        private Network.ProfilePictureUpdater updater;

        public UpdatePictureResultDelegate Result { get; set; }

        public string PrivateKey { get; set; }

        public void Upload(string base64)
        {
            updater.get(base64);
        }
    }
}
