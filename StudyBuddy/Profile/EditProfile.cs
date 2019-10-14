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
            profilePicture.ImageLocation = localUser.profilePictureLocation;
            firstNameBox.Text = localUser.firstName;
            lastNameBox.Text = localUser.lastName;
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

        }
    }
}
