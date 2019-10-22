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
using StudyBuddy.Network;

namespace StudyBuddy
{
    public partial class HelpRequestDisplayerForm : Form
    {
        LocalUser localUser;
        User user;

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public delegate void onDelete(HelpRequest helpRequest);
        public onDelete OnDelete;
        public HelpRequest helpRequest;
        public HelpRequestDisplayerForm(LocalUser localUser, HelpRequest helpRequest, User user)
        {
            InitializeComponent();
            this.helpRequest = helpRequest;
            categoryBox.Text = helpRequest.Category;
            titleBox.Text = helpRequest.Title;
            descriptionBox.Text = helpRequest.Description;
            nameBox.Text = user.FirstName + " " + user.LastName;
            pictureBox.ImageLocation = user.ProfilePictureLocation;
            this.localUser = localUser;
            this.user = user;
            this.Text = "Pagalbos prašymas";

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
            if(user.Username == localUser.Username)
            {
                profile.Hide();
                writeMessageButton.Hide();

            }
            else
            {
                removeButton.Hide();
            }
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

        private void removeButton_Click(object sender, EventArgs e)
        {
            removeButton.Enabled = false;
            var confirmResult = MessageBox.Show(
                                 "Ar tikrai norite ištrinti šį prašymą?",
                                "Ištrinti šį prašymą?",
                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                statusLabel.Text = "Trinama";
                var manager = new HelpRequestManager(localUser);
                manager.RemoveHelpRequestResult += (status, helpRequest) =>
                {
                    try
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if(status == HelpRequestManager.ManagerStatus.Success)
                            {
                                OnDelete?.Invoke(helpRequest);
                                this.Close();
                            }
                            else
                            {
                                statusLabel.Text = "Nepavyko ištrinti";
                                removeButton.Enabled = true;
                            }
                        });
                    }
                    catch (Exception)
                    {

                    }
                };
                manager.removeHelpRequest(helpRequest);
            }
            else
            {
                removeButton.Enabled = true;
            }
        }

        private void writeMessageButton_Click(object sender, EventArgs e)
        {
            new MessageForm(localUser, user.Username).Show();
        }
    }
}
