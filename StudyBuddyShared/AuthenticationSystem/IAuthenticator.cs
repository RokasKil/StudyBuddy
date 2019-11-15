using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.AuthenticationSystem
{
    public enum AuthenticatorStatus
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

    public delegate void AuthenticateResultDelegate(AuthenticatorStatus status, LocalUser user);

    public interface IAuthenticator
    {
        AuthenticateResultDelegate Result { get; set; } // Result callback

        void Login(string username, string password); // Login with username and password

        void Login(string PrivateKey); // Login with a known private key
    }
}
