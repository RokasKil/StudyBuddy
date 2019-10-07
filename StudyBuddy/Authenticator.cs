using Newtonsoft.Json.Linq;
using System;
using System.Threading;

namespace StudyBuddy
{
    class Authenticator
    {
        public enum authStatus
        {
            UsernameEmpty,
            PasswordEmpty,
            InvalidUsernameOrPassword,
            InvalidPrivateKey,
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError
        }

        public delegate void LoginResult(authStatus status, LocalUser user);
        public LoginResult loginResult;
        private Thread loginThread;

        public void login(string username, string password)
        {
            if(loginThread != null && loginThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }

            if(String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                loginResult(authStatus.UsernameEmpty, null);
                return;
            }

            if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
            {
                loginResult(authStatus.PasswordEmpty, null);
                return;
            }

            //TODO: write actual logic need a server tho and stuff
            loginThread = new Thread(() => loginLogic(username, password)); // There's probably a better way
            loginThread.Start();


        }
        
        private void loginLogic(string username, string password)
        {
            JObject obj = new APICaller("auth.php").addParam("username", username).addParam("password", password).call();
            if(obj["status"].ToString() == "success")
            {
                LocalUser localUser = new LocalUser
                {
                    username = obj["user"]["username"].ToString(),
                    firstName = obj["user"]["firstName"].ToString(),
                    lastName = obj["user"]["lastName"].ToString(),
                    KarmaPoints = obj["user"]["karmaPoints"].ToObject<int>(),
                    IsLecturer = Convert.ToBoolean(obj["user"]["lecturer"].ToObject<int>()),
                    privateKey = obj["user"]["privateKey"].ToString(),
                };
                loginResult(authStatus.Success, localUser);
            }
            else
            {
                authStatus status = authStatus.UnknownError;
                if (!Enum.TryParse<authStatus>(obj["message"].ToString(), out status))
                {
                    status = authStatus.UnknownError;
                }
                loginResult(status, null);
            }
        }
        
    }
}
