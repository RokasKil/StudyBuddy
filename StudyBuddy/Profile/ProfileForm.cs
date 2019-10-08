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
        public ProfileForm(LocalUser localUser)
        {
            this.localUser = localUser;
            InitializeComponent();
            this.Text = "Profilis";
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            username.Text = localUser.username;
            firstName.Text = localUser.firstName;
            karmaProgressBar.Value = localUser.KarmaPoints;
            if (localUser.IsLecturer) status.Text = "Dėstytojas";
            else status.Text = "Studentas";
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
        }
    }
}
