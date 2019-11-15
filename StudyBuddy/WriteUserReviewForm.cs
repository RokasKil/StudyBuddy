using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;
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
    public partial class WriteUserReviewForm : Form
    {
        LocalUser localUser;
        User user;
        UserReview userReview;

        public WriteUserReviewForm(LocalUser localUser, User user)
        {
            this.localUser = localUser;
            this.user = user;
            InitializeComponent();
            userReview = new UserReview();
        }

        private void UserReviewForm_Load(object sender, EventArgs e)
        {
            labelUsername.Text = user.Username;
            labelFirstName.Text = user.FirstName;
            if (user.IsLecturer) labelStatus.Text = "Dėstytojas";
            else labelStatus.Text = "Studentas";
            pictureBoxProfilePicture.ImageLocation = user.ProfilePictureLocation;
            buttonSendReview.Hide();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            userReview.Username = user.Username;
            userReview.Message = richTextBoxReviewDescription.Text;
            sendingReview(userReview);
            //this.Close();
        }

        private void positiveButton_Click(object sender, EventArgs e)
        {
            userReview.Karma = 1;
            buttonSendReview.Show();
        }

        private void negativeButton_Click(object sender, EventArgs e)
        {
            userReview.Karma = -1;
            buttonSendReview.Show();
        }

        private void sendingReview(UserReview userReview)
        {
            var mngr = new UserReviewManager(localUser);
            mngr.PostUserReviewResult += (status, review) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (status == UserReviewManager.ManagerStatus.Success)
                    {
                        //Console.WriteLine("success in posting");
                        messageToUser.Text = "Atsiliepimas išsiųstas";
                    }
                    else
                    {
                        //Console.WriteLine("failure in posting");
                        messageToUser.Text = "Atsiliepimas neišsiųstas";
                    }
                });
            };
            mngr.postReview(userReview);
        }
    }
}
