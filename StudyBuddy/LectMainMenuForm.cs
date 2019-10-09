using StudyBuddy.Entity;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudyBuddy
{
    public partial class LectMainMenuForm : Form
    {
        LocalUser localUser;
        
        public LectMainMenuForm(LocalUser localUser)
        {
            this.localUser = localUser;
            InitializeComponent();
            this.Text = "Main menu";
            

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
            greetingsLabel.Text = "Welcome back, " + localUser.firstName + " :)";
            karmaProgressBar.Value = localUser.KarmaPoints;
            progressLabel.Text = "Your karma progress is " + karmaProgressBar.Value
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
            //User nustatomas property kad jis siuo metu gali padeti kitiems
            localUser.Advise = !localUser.Advise;
            if (localUser.Advise)
                adviseButton.BackColor = Color.Green;
            else
                adviseButton.BackColor = Color.Yellow;
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            TopicListForm topicListForm = new TopicListForm();
            topicListForm.Show();
        }

        private void CheckProfileButton_Click(object sender, EventArgs e)
        {
            //Switch to another form
            ProfileForm profileForm = new ProfileForm(localUser, localUser); // Create profile form and show it
            profileForm.Show();

            checkProfileButton.Enabled = false;
            profileForm.FormClosed += (a, b) => { checkProfileButton.Enabled = true; };
            //checkProfileButton.Enabled = false; // prevents from opening a bunch of the same windows
        }
    }   
}
