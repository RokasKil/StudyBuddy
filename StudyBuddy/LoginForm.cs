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
            AcceptButton = loginButton;
        }


        private void LoginForm_Shown(object sender, EventArgs e)
        {
            SendMessage(usernameField.Handle, EM_SETCUEBANNER, 0, "Vartotojas");// Kviečia low level nustatymą (Pretty much black magic kurią kažkada reiks pakeist)
            SendMessage(passwordField.Handle, EM_SETCUEBANNER, 0, "Slaptažodis");
            //new ConversationHistoryForm().Show();
            //new MessageForm().Show();
            
            //ChangeProfilePictureForm f = new ChangeProfilePictureForm();
            //f.Show();

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Jungiamasi...";
            loginButton.Enabled = false;
            auth.login(usernameField.Text, passwordField.Text);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


            auth = new Authenticator();
            auth.LoginResult = new Authenticator.LoginResultDelegate(loginResultCallBack);

            rememberMe.Checked = Properties.Settings.Default.remember;
            
            // uzkomentuoti zemiau eilute kad veiktu auto log in
            //rememberMe.Checked = false;

            if (rememberMe.Checked == true)
            {
                statusLabel.Text = "Jungiamasi...";
                loginButton.Enabled = false;
                string privateKey = Properties.Settings.Default.privateKey;
                auth.login(privateKey);
            }

        }
        
        private void loginResultCallBack(Authenticator.AuthStatus status, LocalUser user)
        {
            if (loginButton.InvokeRequired) // Has to be same thread
            {
                loginButton.Invoke(new Authenticator.LoginResultDelegate(loginResultCallBack), new object[] { status, user });
            }
            else
            {
                loginButton.Enabled = true;
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
                    case Authenticator.AuthStatus.InvalidPrivateKey://Remember login
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

                    if(rememberMe.Checked == true)
                    {
                        Properties.Settings.Default.privateKey = user.privateKey;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.privateKey = "";
                        Properties.Settings.Default.Save();
                    }
                    //Switch to another form
                    MainMenuForm mainForm = new MainMenuForm(user); // Create a the main form and show it
                    mainForm.Show();
                    this.Hide();    // Hide this one
                    mainForm.FormClosed += (s, args) => this.Close(); // When the main form closes close this one too
                }
            }   
        }

        private void rememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (rememberMe.Checked)
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

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
