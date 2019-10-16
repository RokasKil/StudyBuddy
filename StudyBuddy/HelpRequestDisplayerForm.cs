using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public HelpRequestDisplayerForm(LocalUser localUser, HelpRequest helpRequest, User user)
        {
            InitializeComponent();
            categoryBox.Text = helpRequest.category;
            titleBox.Text = helpRequest.title;
            descriptionBox.Text = helpRequest.description;
            nameBox.Text = user.firstName + " " + user.lastName;
            pictureBox.ImageLocation = user.profilePictureLocation;
            this.localUser = localUser;
            this.user = user;
        }

        private void profile_Click(object sender, EventArgs e)
        {
            new ProfileForm(localUser, user).Show();
        }
    }
}
