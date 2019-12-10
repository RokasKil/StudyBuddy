using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StudyBuddyShared.Network
{
    public class Registrator
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
        public RegisterResultDelegate RegisterResult { get; set; }
        private Thread registerThread;
        public Registrator() { }
        public Registrator(RegisterResultDelegate registerResult)
        {
            RegisterResult = registerResult;
        }

        public void Register(string username, string password, string password2, string firstName, string lastName, string email)
        {
            if (registerThread != null && registerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }

            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                RegisterResult(RegisterStatus.UsernameEmpty);
                return;
            }

            if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
            {
                RegisterResult(RegisterStatus.PasswordEmpty);
                return;
            }

            if (password != password2)
            {
                RegisterResult(RegisterStatus.PasswordsDoNotMatch);
                return;
            }

            if (String.IsNullOrEmpty(firstName) || String.IsNullOrWhiteSpace(firstName))
            {
                RegisterResult(RegisterStatus.FirstnameEmpty);
                return;
            }

            if (String.IsNullOrEmpty(lastName) || String.IsNullOrWhiteSpace(lastName))
            {
                RegisterResult(RegisterStatus.LastNameEmpty);
                return;
            }
            registerThread = new Thread(() => registerLogic(username, password, firstName, lastName, email)); // There's probably a better way
            registerThread.Start();


        }
        private void registerLogic(string username, string password, string firstName, string lastName, string email)
        {
            JObject obj = new APICaller("register.php")
                .AddParam("username", username)
                .AddParam("password", password)
                .AddParam("firstName", firstName)
                .AddParam("lastName", lastName)
                .AddParam("email", email)
                .Call();
            Console.WriteLine(obj);
            RegisterStatus status = RegisterStatus.UnknownError;
            if (!Enum.TryParse<RegisterStatus>(obj["message"].ToString(), out status))
            {
                status = RegisterStatus.UnknownError;
            }
            RegisterResult(status);
        }
    }
}
