using StudyBuddyShared.AuthenticationSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.SystemManager
{
    public static class AuthenticationSystemManager // Returns implementations of interfaces
    {
        public static IAuthenticator NewAuthenticator()
        {
            return new Authenticator();
        }
        public static IRegistrator NewRegistrator()
        {
            return new Registrator();
        }
    }
}
