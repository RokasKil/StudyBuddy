using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;

namespace StudyBuddy
{
    public partial class EditProfile : Form
    {
        private LocalUser localUser;

        public EditProfile()
        {
            InitializeComponent();
        }

        public EditProfile(LocalUser localUser)
        {
            this.localUser = localUser;
            InitializeComponent();
            this.Text = "Profilio redagavimas";
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            //username.Text = localUser.username;
            //name.Text = localUser.firstName + " " + localUser.lastName;
            profilePicture.ImageLocation = localUser.ProfilePictureLocation;
            firstNameBox.Text = localUser.FirstName;
            lastNameBox.Text = localUser.LastName;
            resultLabel.Visible = false;
            //usernameBox.Text = localUser.username;

        }

        private void ChangeProfPicButton_Click(object sender, EventArgs e)
        {
            ChangeProfilePictureForm picChangeForm = new ChangeProfilePictureForm(localUser);
            picChangeForm.Show();
            this.Hide();

            picChangeForm.FormClosed += (a, b) =>
            {
                this.EditProfile_Load(a, b);
                this.Show();
            };
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            resultLabel.Visible = false;
            saveChangesButton.Enabled = false;

            new UserUpdater(localUser,
                (status, firstName, lastName) =>
                {
                    this.Invoke((MethodInvoker)delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == UserUpdater.GetStatus.Success) //Pavyko
                        {
                            localUser.FirstName = firstName;
                            localUser.LastName = lastName;
                            saveChangesButton.Enabled = true;
                            resultLabel.Visible = true;
                            localUser.OnUpdateHandler?.Invoke(localUser);

                        }
                        else //Ne
                        {
                            MessageBox.Show("Įvyko klaida","oof", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            saveChangesButton.Enabled = true;
                        }
                    });
                }
                ).get(firstNameBox.Text, lastNameBox.Text);
        }
    }
}
