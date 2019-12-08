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
using StudyBuddyApp.Views;

namespace StudyBuddyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public bool IsRegisterPageOpen = false;
		public LoginPage ()
		{
			InitializeComponent ();

#pragma warning disable CS0618 // Type or member is obsolete
            RegisterLabel.GestureRecognizers.Add(new TapGestureRecognizer(async (view) =>
            {
                if (!LoadingIndicator.IsRunning && !IsRegisterPageOpen)
                {
                    IsRegisterPageOpen = true;
                    await Navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
                }
            }));
#pragma warning restore CS0618 // Type or member is obsolete

            UsernameEntry.Completed += (o, e) =>
            {
                PasswordEntry.Focus();
            };
            PasswordEntry.Completed += PasswordEntryCompleted;
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
            MessagingCenter.Subscribe<RegisterPage, Tuple<string, string>>(this, "Success", (obj, loginInfo) =>
            {
                UsernameEntry.Text = loginInfo.Item1;
                PasswordEntry.Text = loginInfo.Item2;
                PasswordEntryCompleted(null, null);
            });
            MessagingCenter.Subscribe<RegisterPage>(this, "Closing", (obj) =>
            {
                IsRegisterPageOpen = false;
            });
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
        void PasswordEntryCompleted(object sender, EventArgs eventArgs)
        {
            UsernameEntry.IsEnabled = false;
            PasswordEntry.IsEnabled = false;
            LoadingIndicator.IsRunning = true;
            StatusLabel.IsVisible = false;
            // Dependency injection per interfaces
            IAuthenticator auth = AuthenticationSystemManager.NewAuthenticator();
                auth.Result += LoginResponse;
            auth.Login(UsernameEntry.Text, PasswordEntry.Text);
        }
    }
}