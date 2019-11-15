using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.AuthenticationSystem
{
    public class Authenticator : IAuthenticator
    {
        public AuthenticateResultDelegate Result { get; set; }

        private Network.Authenticator authenticator;

        public Authenticator()
        {
            authenticator = new Network.Authenticator((status, user) =>
            {
                Result?.Invoke(EnumConverter.Convert<AuthenticatorStatus>(status), user);
            });
        }

        public void Login(string username, string password)
        {
            authenticator.login(username, password);
        }

        public void Login(string privateKey)
        {
            authenticator.login(privateKey);
        }
    }
}
