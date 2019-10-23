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
            textBoxCategoryTitle.Text = helpRequest.Category;
            textBoxHelpRequestTitle.Text = helpRequest.Title;
            TextBoxHelpRequestDescription.Text = helpRequest.Description;
            textBoxProfileName.Text = user.FirstName + " " + user.LastName;
            pictureBoxProfilePicture.ImageLocation = user.ProfilePictureLocation;
            this.localUser = localUser;
            this.user = user;
            this.Text = "Pagalbos prašymas";

            textBoxHelpRequestTitle.MouseDown += TextBox_MouseDown;
            textBoxHelpRequestTitle.MouseUp += TextBox_MouseDown;
            textBoxHelpRequestTitle.GotFocus += TextBox_GotFocus;

            textBoxCategoryTitle.MouseDown += TextBox_MouseDown;
            textBoxCategoryTitle.MouseUp += TextBox_MouseDown;
            textBoxCategoryTitle.GotFocus += TextBox_GotFocus;

            TextBoxHelpRequestDescription.MouseDown += TextBox_MouseDown;
            TextBoxHelpRequestDescription.MouseUp += TextBox_MouseDown;
            TextBoxHelpRequestDescription.GotFocus += TextBox_GotFocus;

            textBoxProfileName.MouseDown += TextBox_MouseDown;
            textBoxProfileName.MouseUp += TextBox_MouseDown;
            textBoxProfileName.GotFocus += TextBox_GotFocus;
            if(user.Username == localUser.Username)
            {
                buttonProfile.Hide();
                buttonWriteMessage.Hide();
            }
            else
            {
                buttonRemove.Hide();
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
            buttonRemove.Enabled = false;
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
                                buttonRemove.Enabled = true;
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
                buttonRemove.Enabled = true;
            }
        }

        private void writeMessageButton_Click(object sender, EventArgs e)
        {
            new MessageForm(localUser, user.Username).Show();
        }
    }
}
