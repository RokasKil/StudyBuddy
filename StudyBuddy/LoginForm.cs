using StudyBuddy.Entity;
using StudyBuddy.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace StudyBuddy
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Truputis magijos kad būtų placeholder tekstas
        /// </summary>
        private const int EM_SETCUEBANNER = 0x1501; 
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        Authenticator auth;
        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = buttonLogin;
            this.Text = "Prisijungimas";
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            SendMessage(textBoxUsernameField.Handle, EM_SETCUEBANNER, 0, "Vartotojas");// Kviečia low level nustatymą (Pretty much black magic kurią kažkada reiks pakeist)
            SendMessage(textBoxPasswordField.Handle, EM_SETCUEBANNER, 0, "Slaptažodis");
            //new ConversationHistoryForm().Show();
            //new MessageForm().Show();
            //ChangeProfilePictureForm f = new ChangeProfilePictureForm();
            //f.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Jungiamasi...";
            buttonLogin.Enabled = false;
            auth.login(textBoxUsernameField.Text, textBoxPasswordField.Text);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            auth = new Authenticator();
            auth.LoginResult = new Authenticator.LoginResultDelegate(loginResultCallBack);
            checkBoxRememberLogin.Checked = Properties.Settings.Default.remember;
            // uzkomentuoti zemiau eilute kad veiktu auto log in
            //rememberMe.Checked = false;
            if (checkBoxRememberLogin.Checked == true)
            {
                statusLabel.Text = "Jungiamasi...";
                buttonLogin.Enabled = false;
                string privateKey = Properties.Settings.Default.privateKey;
                auth.login(privateKey);
            }
        }
        
        private void loginResultCallBack(Authenticator.AuthStatus status, LocalUser user)
        {
            if (buttonLogin.InvokeRequired) //Turi būti tas pats thread
            {
                buttonLogin.Invoke(new Authenticator.LoginResultDelegate(loginResultCallBack), new object[] { status, user });
            }
            else
            {
                buttonLogin.Enabled = true;
                string message = "";
                switch (status)
                {
                    case Authenticator.AuthStatus.UsernameEmpty:
                        message = "Vartotojo vardas negali būti tuščias";
                        break;
                    case Authenticator.AuthStatus.PasswordEmpty:
                        message = "Vartotojo slaptažodis negali būti tuščias";
                        break;
                    case Authenticator.AuthStatus.FailedToConnect:
                        message = "Nepavyko prisijungti prie serverio";
                        break;
                    case Authenticator.AuthStatus.InvalidUsernameOrPassword:
                        message = "Neteisingas vartotojo vardas/slaptažodis";
                        break;
                    case Authenticator.AuthStatus.InvalidPrivateKey: //Prisiminti login
                        message = "Bandykite prisijungti išnaujo";
                        break;
                    case Authenticator.AuthStatus.Success:
                        message = "Success";
                        break;
                    default:
                        message = "Kažkas nepavyko";
                        break;
                }
                statusLabel.Text = message;
                if ((status == Authenticator.AuthStatus.Success))
                { 

                    if(checkBoxRememberLogin.Checked == true)
                    {
                        Properties.Settings.Default.privateKey = user.PrivateKey;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.privateKey = "";
                        Properties.Settings.Default.Save();
                    }
                    //Perjungiama į main menu formą
                    MainMenuForm mainForm = new MainMenuForm(user); //Sukurti pagrindinę formą ir parodyti
                    mainForm.Show();
                    this.Hide();    // Hide this one
                    mainForm.FormClosed += (s, args) => this.Close(); //Kai užsidaro pagrindinė forma, uždaryti ir šitą
                }
            }   
        }

        private void rememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRememberLogin.Checked)
            {
                //Properties.Settings.Default.privateKey = passwordField.Text;
                Properties.Settings.Default.remember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                //Properties.Settings.Default.privateKey = "";
                Properties.Settings.Default.remember = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
