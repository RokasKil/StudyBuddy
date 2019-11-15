using StudyBuddy.Entity;
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
        AuthenticateResultDelegate ResultDelegate { get; set; }

        void Login(string username, string password);

        void Login(string PrivateKey);
    }
}
