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
                                Console.WriteLine(userReview.username);
                                Console.WriteLine(userReview.karma);
                                Console.WriteLine(userReview.message);
                                Console.WriteLine(userReview.postDate);
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
                ).get(false, "test1");


            if (userReviews == null || users == null) // Dar nėra informacijos
            {
                return;
            }

            
        }

        
    }
}
