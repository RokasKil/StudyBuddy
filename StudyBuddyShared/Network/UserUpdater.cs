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
    public class UserUpdater
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
            InvalidValues
        }

        public delegate void UpdateUserResultDelegate(GetStatus status, string firstName, string lastName);
        public UpdateUserResultDelegate UpdateUserResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread updateUserThread;

        public UserUpdater () : this("") { }
        public UserUpdater(LocalUser user) : this(user.PrivateKey) { }
        public UserUpdater(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public UserUpdater(UpdateUserResultDelegate updateUserResult) : this("", updateUserResult) { }
        public UserUpdater(LocalUser user, UpdateUserResultDelegate updateUserResult) : this(user.PrivateKey, updateUserResult) { }
        public UserUpdater(string privateKey, UpdateUserResultDelegate updateUserResult) : this(privateKey)
        {
            UpdateUserResult = updateUserResult;
        }

        public void get(string firstName, string lastName)
        {
            if (updateUserThread != null && updateUserThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            /*
            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                UpdateUserResult(GetStatus.UsernameEmpty);
                return;
            }
            */
            updateUserThread = new Thread(() => getLogic(firstName, lastName)); // There's probably a better way
            updateUserThread.Start();
        }

        private void getLogic(string firstName, string lastName)
        {
            JObject obj = new APICaller("updateProfile.php").addParam("privateKey", PrivateKey)
                                                            .addParam("firstName", firstName)
                                                            .addParam("lastName", lastName)
                                                            .addParam("gender", "0")
                                                            .call();
            if (obj["status"].ToString() == "success")
            {
                //teehee
                UpdateUserResult(GetStatus.Success, firstName, lastName);
            }
            else
            {
                GetStatus status = GetStatus.UnknownError;
                if (!Enum.TryParse<GetStatus>(obj["message"].ToString(), out status))
                {
                    status = GetStatus.UnknownError;
                }
                UpdateUserResult(status, firstName, lastName);
            }
        }
    }
}
