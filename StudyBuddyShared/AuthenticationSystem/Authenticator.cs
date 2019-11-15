using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.AuthenticationSystem
{
    public class Authenticator : IAuthenticator
    {
        public AuthenticateResultDelegate ResultDelegate { get; set; }

        public void Login(string username, string password)
        {
            //new Network.Authenticator()
        }

        public void Login(string PrivateKey)
        {
            throw new NotImplementedException();
        }
    }
}
