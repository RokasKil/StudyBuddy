using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.AuthenticationSystem
{
    public class Registrator : IRegistrator
    {
        private Network.Registrator registrator;

        public Registrator()
        {
            registrator = new Network.Registrator((status) =>
            {
                Result?.Invoke(EnumConverter.Convert<RegisterStatus>(status));
            });
        }

        public RegisterResultDelegate Result { get; set; }

        public void Register(string username, string password, string password2, string firstName, string lastName, string email)
        {
            registrator.Register(username, password, password2, firstName, lastName, email);
        }
    }
}
