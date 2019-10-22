using Newtonsoft.Json.Linq;
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
    public partial class MainMenuForm : Form
    {
        LocalUser localUser;
        public MainMenuForm(LocalUser localUser)
        {
            InitializeComponent();
            this.localUser = localUser;
            this.Text = "Pagrindinis meniu";
            labelLecturer.Visible = localUser.IsLecturer;
            buttonTopicList.Visible = localUser.IsLecturer;
            MessageBoxManager.Yes = "Taip";
            MessageBoxManager.No = "Ne";
            MessageBoxManager.OK = "Tęsti";
            MessageBoxManager.Register();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
            fillUserValues();
            localUser.OnUpdateHandler += (user) => { fillUserValues(); };
            //new UserReviewTest(localUser).Show();
        }
        public void fillUserValues()
        {
            greetingsLabel.Text = "Labas, " + localUser.Username + " :)";
            //greetingsLabel.Text = "Labas, " +
            //    localUser.FirstName.Substring(0, localUser.FirstName.Length - 2) + "ai" + " :)";
            karmaProgressBar.Value = localUser.KarmaPoints;
            progressLabel.Text = "Tavo progresas " + karmaProgressBar.Value
                + "/" + karmaProgressBar.Maximum;
            
        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void ProgressBar1_Update(int add) // Perdaryt su nauja klase karmai ir delegatais
        {
            //When the profile is liked, add karma points
            //If the profile is disliked, take away karma points
            karmaProgressBar.Value += add;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //User nustatomas property, kad jis siuo metu gali padeti kitiems
            localUser.Advise = !localUser.Advise;
            if (localUser.Advise)
                buttonAdvise.BackColor = Color.Green;
            else
                buttonAdvise.BackColor = Color.Yellow;
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void CheckProfileButton_Click(object sender, EventArgs e)
        {
            //Switch to another form
            ProfileForm profileForm = new ProfileForm(localUser, localUser); // Create profile form and show it
            profileForm.Show();

            buttonCheckProfile.Enabled = false;
            profileForm.FormClosed += (a, b) => { buttonCheckProfile.Enabled = true; };
            /*
            new UserGetter(localUser, (a, b) => {
                this.Invoke((MethodInvoker)delegate
                {
                    ProfileForm profileForm = new ProfileForm(localUser, b);
                    profileForm.Show();
                });
            }).get("tekst2");
            */
            //checkProfileButton.Enabled = false; // prevents from opening a bunch of the same windows
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            FormOpener.OpenForm(new PostForHelpForm(localUser));
        }

        private void ButtonTopic_Click(object sender, EventArgs e)
        {
            FormOpener.OpenForm(new HelpRequestListForm(localUser));
        }

        private void ButtonConversations_Click(object sender, EventArgs e)
        {
            FormOpener.OpenForm(new ConversationHistoryForm(localUser));
        }

        private void buttonTopicList_Click(object sender, EventArgs e)
        {
            FormOpener.OpenForm(new TopicListForm(localUser));
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Properties.Settings.Default.privateKey = "";
            Properties.Settings.Default.remember = false;
            Properties.Settings.Default.Save();
            Application.Restart();
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonUserReviews_Click(object sender, EventArgs e)
        {
            FormOpener.OpenForm(new ViewUserReviewsForm(localUser));
        }
    }   
}
