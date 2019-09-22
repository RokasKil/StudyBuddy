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
        }


        private void LoginForm_Shown(object sender, EventArgs e)
        {
            SendMessage(usernameField.Handle, EM_SETCUEBANNER, 0, "Vartotojas");// Kviečia low level nustatymą (Pretty much black magic kurią kažkada reiks pakeist)
            SendMessage(passwordField.Handle, EM_SETCUEBANNER, 0, "Slaptažodis");
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
            auth.loginResult = new Authenticator.LoginResult(loginResultCallBack);
            //new Form2().Show();
        }
        
        private void loginResultCallBack(bool success, string message)
        {
            if (loginButton.InvokeRequired) // Has to be same thread
            {
                loginButton.Invoke(new Authenticator.LoginResult(loginResultCallBack), new object[] { success, message });
            }
            else
            {
                loginButton.Enabled = true;
                statusLabel.Text = message;
                if (success)
                {
                    //Switch to another form
                    MainForm mainForm = new MainForm(); // Create a the main form and show it
                    mainForm.Show();
                    this.Hide();    // Hide this one
                    mainForm.FormClosed += (s, args) => this.Close(); // When the main form closes close this one too
                }
            }
        }
    }
}
