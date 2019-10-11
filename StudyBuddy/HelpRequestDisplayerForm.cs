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
        public HelpRequestDisplayerForm(HelpRequest helpRequest, User user)
        {
            InitializeComponent();
            categoryBox.Text = helpRequest.category;
            titleBox.Text = helpRequest.title;
            descriptionBox.Text = helpRequest.description;
            nameBox.Text = user.firstName + " " + user.lastName;
            pictureBox.ImageLocation = user.profilePictureLocation;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void vardasPavardeBox(object sender, EventArgs e)
        {

        }

        private void nuotraukaBox(object sender, EventArgs e)
        {

        }

        private void problemosApibudinimas_Click(object sender, EventArgs e)
        {

        }

        private void kategorija_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
