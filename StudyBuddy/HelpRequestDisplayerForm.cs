﻿using System;
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
            categoryBox.Text = helpRequest.Category;
            titleBox.Text = helpRequest.Title;
            descriptionBox.Text = helpRequest.Description;
            nameBox.Text = user.firstName + " " + user.lastName;
            pictureBox.ImageLocation = user.profilePictureLocation;
            this.localUser = localUser;
            this.user = user;
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

        private void profile_Click(object sender, EventArgs e)
        {
            new ProfileForm(localUser, user).Show();
        }
    }
}
