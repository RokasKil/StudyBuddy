using StudyBuddyShared.AuthenticationSystem;
using StudyBuddyShared.SystemManager;
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
            LastName.Completed += (o, e) =>
            {
                if (RegisterButton.IsEnabled)
                {
                    RegisterButton_Clicked(o, e);
                }
            };

        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            RegisterButton.IsEnabled = false;
            RegisterButton.IsVisible = false;
            ActivityIndicator.IsVisible = true;
            ActivityIndicator.IsRunning = true;
            StatusLabel.Text = "";
            string username = Username.Text;
            string password = Password.Text;
            var registrator = AuthenticationSystemManager.NewRegistrator();
            registrator.Result += (status) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {

                    ActivityIndicator.IsVisible = false;
                    ActivityIndicator.IsRunning = false;
                    if (status == RegisterStatus.Success)
                    {
                        MessagingCenter.Send(this, "Success", new Tuple<string, string>(username, password));
                        await Navigation.PopModalAsync();
                        //Success
                    }
                    else
                    {
                        RegisterButton.IsEnabled = true;
                        RegisterButton.IsVisible = true;
                        switch (status)
                        {
                            case RegisterStatus.UsernameEmpty:
                                StatusLabel.Text = "Slapyvardis negali būti tuščias";
                                break;
                            case RegisterStatus.UsernameInvalid:
                                StatusLabel.Text = "Slapyvardis netinkamas";
                                break;
                            case RegisterStatus.UsernameTooShort:
                                StatusLabel.Text = "Slapvyardis per trumpas";
                                break;
                            case RegisterStatus.UsernameTooLong:
                                StatusLabel.Text = "Slapyvardis per ilgas";
                                break;
                            case RegisterStatus.PasswordEmpty:
                                StatusLabel.Text = "Slaptažodis negali būti tuščias";
                                break;
                            case RegisterStatus.PasswordTooShort:
                                StatusLabel.Text = "Slaptažodis per trumpas";
                                break;
                            case RegisterStatus.PasswordTooLong:
                                StatusLabel.Text = "Slaptažodis per ilgas";
                                break;
                            case RegisterStatus.PasswordsDoNotMatch:
                                StatusLabel.Text = "Slaptažodžiai nesutampa";
                                break;
                            case RegisterStatus.FirstnameEmpty:
                                StatusLabel.Text = "Vardas negali būti tuščias";
                                break;
                            case RegisterStatus.FirstnameTooShort:
                                StatusLabel.Text = "Vardas per trumpas";
                                break;
                            case RegisterStatus.FirstnameTooLong:
                                StatusLabel.Text = "Vardas per ilgas";
                                break;
                            case RegisterStatus.FirstnameInvalid:
                                StatusLabel.Text = "Vardas netinkamas";
                                break;
                            case RegisterStatus.LastNameEmpty:
                                StatusLabel.Text = "Pavardė negali būti tuščia";
                                break;
                            case RegisterStatus.LastNameTooShort:
                                StatusLabel.Text = "Pavardė per trumpa";
                                break;
                            case RegisterStatus.LastNameTooLong:
                                StatusLabel.Text = "Pavardė per ilga";
                                break;
                            case RegisterStatus.LastNameInvalid:
                                StatusLabel.Text = "Pavardė netinkama";
                                break;
                            case RegisterStatus.EmailEmpty:
                                StatusLabel.Text = "El. paštas negali būti tuščias";
                                break;
                            case RegisterStatus.EmailTooShort:
                                StatusLabel.Text = "El. paštas per trumpas";
                                break;
                            case RegisterStatus.EmailTooLong:
                                StatusLabel.Text = "El. paštas per ilgas";
                                break;
                            case RegisterStatus.EmailInvalid:
                                StatusLabel.Text = "El. paštas netaisyklingas";
                                break;
                            case RegisterStatus.Success:
                                StatusLabel.Text = "Pavyko";
                                break;
                            case RegisterStatus.JsonReadException:
                                StatusLabel.Text = "Klaidingas rezultatas";
                                break;
                            case RegisterStatus.FailedToConnect:
                                StatusLabel.Text = "Nepavyko susiiekti su serveriu";
                                break;
                            case RegisterStatus.FieldsMissing:
                                StatusLabel.Text = "Trūksta laukų";
                                break;
                            case RegisterStatus.UnknownError:
                                StatusLabel.Text = "Nežinoma klaida";
                                break;
                            default:
                                StatusLabel.Text = "Nežinoma klaida";
                                break;
                        }
                    }
                });
            };
            registrator.Register(username, password, PasswordRepeat.Text, FirstName.Text, LastName.Text, Email.Text);
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Closing");
        }
    }
}