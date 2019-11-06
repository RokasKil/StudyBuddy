using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudyBuddy.Network;
using StudyBuddy.Entity;

namespace StudyBuddyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            UsernameEntry.Completed += (o, e) =>
            {
                PasswordEntry.Focus();
            };
            PasswordEntry.Completed += (o, e) =>
            {
                UsernameEntry.IsEnabled = false;
                PasswordEntry.IsEnabled = false;
                LoadingIndicator.IsRunning = true;
                StatusLabel.IsVisible = false;
                new Authenticator(LoginResponse).login(UsernameEntry.Text, PasswordEntry.Text);
            };
            if (Application.Current.Properties.ContainsKey("PrivateKey"))
            {
                UsernameEntry.IsEnabled = false;
                PasswordEntry.IsEnabled = false;
                LoadingIndicator.IsRunning = true;
                StatusLabel.IsVisible = false;
                new Authenticator(LoginResponse).login((string)Application.Current.Properties["PrivateKey"]);
            }
        }

        private void LoginResponse(Authenticator.AuthStatus status, LocalUser user)
        {
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (status == Authenticator.AuthStatus.Success)
                    {
                        LocalUserManager.LocalUser = user;
                        Application.Current.Properties["PrivateKey"] = user.PrivateKey;
                        Application.Current.SavePropertiesAsync();
                        App.Current.MainPage = new Views.MainPage();

                    }
                    else
                    {
                        UsernameEntry.IsEnabled = true;
                        PasswordEntry.IsEnabled = true;
                        StatusLabel.IsVisible = true;
                        StatusLabel.Text = status.ToString(); // TODO: Localization
                        LoadingIndicator.IsRunning = false;
                    }
                });
            }
        }
    }


}