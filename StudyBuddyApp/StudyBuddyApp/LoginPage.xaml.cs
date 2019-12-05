using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudyBuddyShared.Entity;
using StudyBuddyShared.SystemManager;
using StudyBuddyShared.AuthenticationSystem;

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
                Application.Current.Properties["notificationTimestamp"] = (long)-1;
                // Dependency injection per interfaces
                IAuthenticator auth = AuthenticationSystemManager.NewAuthenticator();
                auth.Result += LoginResponse;
                auth.Login(UsernameEntry.Text, PasswordEntry.Text);
            };
            if (Application.Current.Properties.ContainsKey("PrivateKey"))
            {
                UsernameEntry.IsEnabled = false;
                PasswordEntry.IsEnabled = false;
                LoadingIndicator.IsRunning = true;
                StatusLabel.IsVisible = false;

                // Dependency injection per interfaces
                var auth = AuthenticationSystemManager.NewAuthenticator();
                auth.Result += LoginResponse;
                auth.Login((string)Application.Current.Properties["PrivateKey"]);
            }
        }

        private void LoginResponse(AuthenticatorStatus status, LocalUser user)
        {
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (status == AuthenticatorStatus.Success)
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