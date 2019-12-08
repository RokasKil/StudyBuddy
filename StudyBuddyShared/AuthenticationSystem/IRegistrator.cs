using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.AuthenticationSystem
{
    public enum RegisterStatus
    {
        UsernameEmpty,
        UsernameInvalid,
        UsernameTooShort,
        UsernameTooLong,
        PasswordEmpty,
        PasswordTooShort,
        PasswordTooLong,
        PasswordsDoNotMatch,
        FirstnameEmpty,
        FirstnameTooShort,
        FirstnameTooLong,
        FirstnameInvalid,
        LastNameEmpty,
        LastNameTooShort,
        LastNameTooLong,
        LastNameInvalid,
        EmailEmpty,
        EmailTooShort,
        EmailTooLong,
        EmailInvalid,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FieldsMissing
    }
    public delegate void RegisterResultDelegate(RegisterStatus status);
    public interface IRegistrator
    {
        RegisterResultDelegate Result { get; set; } // Result callback

        void Register(string username, string password, string password2, string firstName, string lastName, string email); // Register

    }
}
