using StudyBuddyShared.AuthenticationSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.SystemManager
{
    public static class AuthenticationSystemManager // Returns implementations of interfaces
    {
        public static IAuthenticator NewAuthenticator()
        {
            return new Authenticator();
        }
    }
}
