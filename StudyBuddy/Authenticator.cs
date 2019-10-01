using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBuddy
{
    class Authenticator
    {
        public enum authStatus
        {
            usernameEmpty,
            passwordEmpty,
            incorrectCredentials,
            incorrectID,
            failedToConnect,
            success
        }

        public delegate void LoginResult(authStatus status, LocalUser user);
        private delegate void LoginLogic(string username, string password);
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
                loginResult(authStatus.usernameEmpty, null);
                return;
            }

            if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
            {
                loginResult(authStatus.passwordEmpty, null);
                return;
            }

            //TODO: write actual logic need a server tho and stuff
            loginThread = new Thread(() => loginLogic(username, password)); // There's probably a better way
            loginThread.Start();


        }
        
        private void loginLogic(string username, string password)
        {
            Thread.Sleep(2000);
            if(username == "test1" && password == "pass1")
            {
                loginResult(authStatus.success, new LocalUser() { username = "test", firstName = "Jonas", lastName = "Jonaitis", localKey = "key1" });
            }
            else if (username == "test2" && password == "pass2"){
                loginResult(authStatus.success, new LocalUser() { username = "kitasTest", firstName = "Petras", lastName = "Petraitis", localKey = "key2", isLecturer = true });
            }
            else
            {
                loginResult(authStatus.incorrectCredentials, null);
            }

        }
    }
}
