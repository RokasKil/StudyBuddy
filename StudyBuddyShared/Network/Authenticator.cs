using Newtonsoft.Json.Linq;
using StudyBuddyShared.Entity;
using System;
using System.Threading;

namespace StudyBuddyShared.Network
{
    public class Authenticator
    {
        public enum AuthStatus
        {
            UsernameEmpty,
            PasswordEmpty,
            InvalidUsernameOrPassword,
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            FieldsMissing
        }

        public delegate void LoginResultDelegate(AuthStatus status, LocalUser user);
        public LoginResultDelegate LoginResult { get; set; }
        private Thread loginThread;
        public Authenticator() { }
        public Authenticator(LoginResultDelegate loginResult) {
            LoginResult = loginResult;
        }

        public void login(string username, string password)
        {
            if(loginThread != null && loginThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }

            if(String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                LoginResult(AuthStatus.UsernameEmpty, null);
                return;
            }

            if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
            {
                LoginResult(AuthStatus.PasswordEmpty, null);
                return;
            }
            
            loginThread = new Thread(() => loginLogic(username, password)); // There's probably a better way
            loginThread.Start();


        }

        public void login(string privateKey)
        {
            if (loginThread != null && loginThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }

            loginThread = new Thread(() => loginLogic(privateKey));
            loginThread.Start();
        }


        private void loginLogic(string username, string password)
        {
            JObject obj = new APICaller("auth.php").addParam("username", username).addParam("password", password).call();
            if(obj["status"].ToString() == "success")
            {
                LocalUser localUser = new LocalUser
                {
                    Username = obj["user"]["username"].ToString(),
                    FirstName = obj["user"]["firstName"].ToString(),
                    LastName = obj["user"]["lastName"].ToString(),
                    KarmaPoints = obj["user"]["karmaPoints"].ToObject<int>(),
                    IsLecturer = Convert.ToBoolean(obj["user"]["lecturer"].ToObject<int>()),
                    PrivateKey = obj["user"]["privateKey"].ToString(),
                    ProfilePictureLocation = obj["user"]["profilePicture"].ToString()
                };
                LoginResult(AuthStatus.Success, localUser);
            }
            else
            {
                AuthStatus status = AuthStatus.UnknownError;
                if (!Enum.TryParse<AuthStatus>(obj["message"].ToString(), out status))
                {
                    status = AuthStatus.UnknownError;
                }
                LoginResult(status, null);
            }
        }
        private void loginLogic(string privateKey)
        {
            JObject obj = new APICaller("auth.php").addParam("privateKey", privateKey).call();
            if(obj["status"].ToString() == "success")
            {
                LocalUser localUser = new LocalUser
                {
                    Username = obj["user"]["username"].ToString(),
                    FirstName = obj["user"]["firstName"].ToString(),
                    LastName = obj["user"]["lastName"].ToString(),
                    KarmaPoints = obj["user"]["karmaPoints"].ToObject<int>(),
                    IsLecturer = Convert.ToBoolean(obj["user"]["lecturer"].ToObject<int>()),
                    PrivateKey = obj["user"]["privateKey"].ToString(),
                    ProfilePictureLocation = obj["user"]["profilePicture"].ToString()
                };
                LoginResult(AuthStatus.Success, localUser);
            }
            else
            {
                AuthStatus status = AuthStatus.UnknownError;
                if (!Enum.TryParse<AuthStatus>(obj["message"].ToString(), out status))
                {
                    status = AuthStatus.UnknownError;
                }
                LoginResult(status, null);
            }
        }
        
    }
}
