using StudyBuddy.Entity;
using StudyBuddy.Network;
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
    public partial class UserReviewTest : Form
    {

        LocalUser localUser;
        List<UserReview> userReviews;
        Dictionary<string, User> users;

        public UserReviewTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new UserReviewGetter(localUser,
                (status, helpRequests, users) =>
                {
                    this.Invoke((MethodInvoker)delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == UserReviewGetter.GetStatus.Success) // Pavyko
                        {
                            this.helpRequests = helpRequests;
                            this.users = users;
                            filter(null, null);
                            searchTextBox.Text = "";
                            searchTextBox.Enabled = true;
                        }
                        else // Ne
                        {
                            searchTextBox.Text = "Nepavyko užkrauti";
                            searchTextBox.Enabled = false;
                        }
                    });
                }
                ).get(true);
        }
    }
}
