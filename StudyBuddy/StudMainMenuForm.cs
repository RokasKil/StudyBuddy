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
    public partial class StudMainMenuForm : Form
    {
        LocalUser localUser;
        public StudMainMenuForm(LocalUser localUser)
        {
            this.localUser = localUser;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
            greetingsLabel.Text = "Welcome back, " + localUser.firstName + " :)";
            karmaProgressBar.Value = localUser.karmaPoints;
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
            localUser.advise = !localUser.advise;
            if (localUser.advise)
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
    }   
}
