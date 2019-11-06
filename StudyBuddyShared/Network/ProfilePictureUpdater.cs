using Newtonsoft.Json.Linq;
using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBuddy.Network
{
    public class ProfilePictureUpdater
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
            FieldsMissing,
            InvalidBase64,
            InvalidFileType,
            FailedToUpload
        }

        public delegate void UpdatePictureResultDelegate(GetStatus status, string pictureLocation);
        public UpdatePictureResultDelegate UpdatePictureResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread UpdatePictureThread;

        public ProfilePictureUpdater() : this("") { }
        public ProfilePictureUpdater(LocalUser user) : this(user.PrivateKey) { }
        public ProfilePictureUpdater(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public ProfilePictureUpdater(UpdatePictureResultDelegate updatePictureResult) : this("", updatePictureResult) { }
        public ProfilePictureUpdater(LocalUser user, UpdatePictureResultDelegate updatePictureResult) : this(user.PrivateKey, updatePictureResult) { }
        public ProfilePictureUpdater(string privateKey, UpdatePictureResultDelegate updatePictureResult) : this(privateKey)
        {
            UpdatePictureResult = updatePictureResult;
        }

        public void get(string picture)
        {
            if (UpdatePictureThread != null && UpdatePictureThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            /*
            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                UpdatePictureResult(GetStatus.UsernameEmpty);
                return;
            }
            */
            UpdatePictureThread = new Thread(() => getLogic(picture)); // There's probably a better way
            UpdatePictureThread.Start();
        }

        private void getLogic(string picture)
        {
            JObject obj = new APICaller("uploadProfilePicture.php").addParam("privateKey", PrivateKey)
                                                            .addParam("picture", picture)
                                                            .call();
            if (obj["status"].ToString() == "success")
            {
                string pictureLocation = obj["url"].ToString();
                UpdatePictureResult(GetStatus.Success, pictureLocation);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                UpdatePictureResult(status, null);
            }
        }
    }
}
