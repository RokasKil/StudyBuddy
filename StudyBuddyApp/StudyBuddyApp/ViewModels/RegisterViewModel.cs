using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RegisterViewModel()
        {
            Title = "Registracija";
            Username = "Slapyvardis:";
            Password = "Slaptažodis:";
            PasswordRepeat = "Pakartokite slaptažodį:";
            Email = "El. paštas:";
            FirstName = "Vardas:";
            LastName = "Pavardė:";
        }
    }
}
