using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserSystem
{
    public enum PictureUpdateStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FailedToFindUser,
        UsernameEmpty,
        FieldsMissing,
        InvalidBase64,
        InvalidFileType,
        FailedToUpload
    }

    public delegate void UpdatePictureResultDelegate(PictureUpdateStatus status, string pictureLocation);

    public interface IUserProfilePictureUpdater : IPrivateKey
    {
        UpdatePictureResultDelegate Result { get; set; } // Result delegate

        void Upload(string base64); // Upload a new profile picture (binary data must be converted to base64)
    }
}
