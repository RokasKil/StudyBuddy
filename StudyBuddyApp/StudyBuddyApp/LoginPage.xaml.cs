using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudyBuddy.Network;

namespace StudyBuddyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            Username.Completed += (o, e) =>
            {
                Password.Focus();
            };
            Password.Completed += (o, e) =>
            {
                new Authenticator((status, user) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (status == Authenticator.AuthStatus.Success)
                        {
                            LocalUserManager.LocalUser = user;
                            App.Current.MainPage = new Views.MainPage();

                        }
                        else
                        {
                            Username.Text = status.ToString();
                        }
                    });
                }).login(Username.Text, Password.Text);
            };
        }
	}
}