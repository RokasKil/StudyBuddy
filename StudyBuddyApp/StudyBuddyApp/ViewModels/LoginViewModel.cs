using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Login { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Registration { get; set; }
        public LoginViewModel()
        {
            Title = "Prisijungimas";
            Username = "Slapyvardis";
            Password = "Slaptažodis";
            Registration = "Naujas vartotojas";
            Login = "Prisijungti";
        }
    }
}
