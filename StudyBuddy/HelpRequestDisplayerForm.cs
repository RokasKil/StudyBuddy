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
using StudyBuddy.Entity;

namespace StudyBuddy
{
    public partial class HelpRequestDisplayerForm : Form
    {
        LocalUser localUser;
        User user;

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);


        public HelpRequestDisplayerForm(LocalUser localUser, HelpRequest helpRequest, User user)
        {
            InitializeComponent();
            categoryBox.Text = helpRequest.Category;
            titleBox.Text = helpRequest.Title;
            descriptionBox.Text = helpRequest.Description;
            nameBox.Text = user.firstName + " " + user.lastName;
            pictureBox.ImageLocation = user.profilePictureLocation;
            this.localUser = localUser;
            this.user = user;

            titleBox.MouseDown += TextBox_MouseDown;
            titleBox.MouseUp += TextBox_MouseDown;
            titleBox.GotFocus += TextBox_GotFocus;

            categoryBox.MouseDown += TextBox_MouseDown;
            categoryBox.MouseUp += TextBox_MouseDown;
            categoryBox.GotFocus += TextBox_GotFocus;

            descriptionBox.MouseDown += TextBox_MouseDown;
            descriptionBox.MouseUp += TextBox_MouseDown;
            descriptionBox.GotFocus += TextBox_GotFocus;

            nameBox.MouseDown += TextBox_MouseDown;
            nameBox.MouseUp += TextBox_MouseDown;
            nameBox.GotFocus += TextBox_GotFocus;
        }

        private void TextBox_GotFocus(object sender, EventArgs args)
        {
            HideCaret(((TextBox)sender).Handle);
        }

        private void TextBox_MouseDown(object sender, EventArgs args)
        {
            HideCaret(((TextBox)sender).Handle);
        }

        private void profile_Click(object sender, EventArgs e)
        {
            new ProfileForm(localUser, user).Show();
        }
    }
}
