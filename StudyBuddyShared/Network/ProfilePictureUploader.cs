using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Network
{
    class ProfilePictureUploader
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

        public delegate void ProfilePictureUploadResultDelegate(GetStatus status, User user);
        public ProfilePictureUploadResultDelegate ProfilePictureResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread getUserThread;

        public ProfilePictureUploader() : this("") { }
        public ProfilePictureUploader(LocalUser user) : this(user.privateKey) { }
        public ProfilePictureUploader(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public ProfilePictureUploader(ProfilePictureUploadResultDelegate ProfilePictureResult) : this("", ProfilePictureResult) { }
        public ProfilePictureUploader(LocalUser user, ProfilePictureUploadResultDelegate ProfilePictureResult) : this(user.privateKey, ProfilePictureResult) { }
        public ProfilePictureUploader(string privateKey, ProfilePictureUploadResultDelegate ProfilePictureResult) : this(privateKey)
        {
            ProfilePictureResult = ProfilePictureResult;
        }

    }
}
