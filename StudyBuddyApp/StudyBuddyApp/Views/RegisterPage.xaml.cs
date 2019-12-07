using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            Username.Completed += (o, e) =>
            {
                Password.Focus();
            };
            Password.Completed += (o, e) =>
            {
                PasswordRepeat.Focus();
            };
            PasswordRepeat.Completed += (o, e) =>
            {
                Email.Focus();
            };
            Email.Completed += (o, e) =>
            {
                FirstName.Focus();
            };
            FirstName.Completed += (o, e) =>
            {
                LastName.Focus();
            };
        }
    }
}