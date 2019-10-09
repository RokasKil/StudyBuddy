using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy
{
    public partial class ProfileForm : Form
    {
        LocalUser localUser;
        User user;
        public ProfileForm(LocalUser localUser, User user)
        {
            this.localUser = localUser;
            this.user = user;
            InitializeComponent();
            this.Text = "Profilis";
        }


        private void Profile_Load(object sender, EventArgs e)
        {
            username.Text = user.username;
            firstName.Text = user.firstName;
            karmaProgressBar.Value = user.KarmaPoints;
            profilePicture.ImageLocation = user.profilePictureLocation;

            if (user.IsLecturer) status.Text = "Dėstytojas";
            else status.Text = "Studentas";
            if(user.username == localUser.username)
            {
                writeMessageButton.Hide();
                leaveReviewButton.Hide();
            }
            else
            {
                button1.Hide();
            }
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            //mainForm.checkProfileButton.Enabled = true;
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EditProfile editProfile = new EditProfile(localUser);
            editProfile.Show();
            this.Hide();

            editProfile.FormClosed += (a, b) =>
            {
                this.Show();
                this.Profile_Load(a, b);
            };
        }
    }
}
