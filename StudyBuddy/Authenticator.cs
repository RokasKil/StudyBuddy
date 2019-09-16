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
        public delegate void LoginResult(bool success, String message);
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
                loginResult(false, "Vartotojo vardas negali būti tuščias");
                return;
            }

            if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
            {
                loginResult(false, "Slaptažodis negali būti tuščias");
                return;
            }

            //TODO: write actual logic need a server tho and stuff
            loginThread = new Thread(() => loginLogic(username, password)); // There's probably a better way
            loginThread.Start();


        }

        private void loginLogic(string username, string password)
        {
            Thread.Sleep(2000);
            loginResult(true, "Success");
        }
    }
}
