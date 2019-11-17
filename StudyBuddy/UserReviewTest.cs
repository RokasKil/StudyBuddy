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
    public partial class UserReviewTest : Form
    {

        LocalUser localUser;
        List<UserReview> userReviews;
        Dictionary<string, User> users;

        public UserReviewTest(LocalUser localUser)
        {
            InitializeComponent();
            this.localUser = localUser;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            new UserReviewGetter(localUser,
                (status, userReviews, users) =>
                {
                    this.Invoke((MethodInvoker)delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == UserReviewGetter.GetStatus.Success) // Pavyko
                        {
                            this.userReviews = userReviews;
                            this.users = users;
                            Console.WriteLine("success");
                            //filter(null, null);
                            //searchTextBox.Text = "";
                            //searchTextBox.Enabled = true;

                            foreach (UserReview userReview in userReviews)
                            {
                                Console.WriteLine(userReview.Username);
                                Console.WriteLine(userReview.Karma);
                                Console.WriteLine(userReview.Message);
                                Console.WriteLine(userReview.PostDate);
                                Console.WriteLine();
                            }
                        }
                        else // Ne
                        {
                            Console.WriteLine("error");
                            //searchTextBox.Text = "Nepavyko užkrauti";
                            //searchTextBox.Enabled = false;
                        }
                    });
                }
                ).get(true, "test1");


            if (userReviews == null || users == null) // Dar nėra informacijos
            {
                return;
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var mngr = new UserReviewManager(localUser);
            mngr.PostUserReviewResult += (status, review) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (status == UserReviewManager.ManagerStatus.Success)
                    {
                        Console.WriteLine("success in posting");
                    }
                    else
                    {
                        Console.WriteLine("failure in posting");
                    }
                });
            };
            mngr.postReview(new UserReview { Username = "test1", Message = "Asfsfs", Karma = 1 });
        }
    }
}
