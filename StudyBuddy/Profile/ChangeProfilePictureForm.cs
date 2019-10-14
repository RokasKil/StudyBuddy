using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyBuddy.Entity;

namespace StudyBuddy
{
    public partial class ChangeProfilePictureForm : Form
    {
        string[] imageFormats = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png", ".exe"};
        private LocalUser localUser;

        public ChangeProfilePictureForm()
        {
            InitializeComponent();
        }

        public ChangeProfilePictureForm(LocalUser localUser)
        {
            this.localUser = localUser;
            InitializeComponent();
            this.Text = "Keisti profilio nuotrauką";
        }

        private void ChangeProfilePictureForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) // Tikrinama ar failas draginamas
            {
                string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop); // Gaunami failai
                // Tikranama ar tinkama failo galūnė
                if (files.Length != 1 || !imageFormats.Any(ext => files[0].EndsWith(ext, StringComparison.CurrentCultureIgnoreCase)))
                {
                    Console.WriteLine(files[0]);
                    e.Effect = DragDropEffects.None;

                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }

            }
            dragAndDropOverlay.Visible = true;
        }

        private void ChangeProfilePictureForm_DragDrop(object sender, DragEventArgs e)
        {
            //Kartojami patikrinimai
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && imageFormats.Any(ext => files[0].EndsWith(ext, StringComparison.CurrentCultureIgnoreCase)))
                {
                    pictureBox.ImageLocation = files[0];// Nustatomas naujas image
                }
            }
            dragAndDropOverlay.Visible = false;
        }

        private void ChangeProfilePictureForm_DragLeave(object sender, EventArgs e)
        {

            dragAndDropOverlay.Visible = false;
        }

        private void ChangeProfilePictureForm_Load(object sender, EventArgs e)
        {
            //Pradiniai nustatymai
            dragAndDropOverlay.AutoSize = false;
            dragAndDropOverlay.BringToFront();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png" ;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Atidaromas failų langas
            if(result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                pictureBox.ImageLocation = file; // Nustatomas naujas failas
            }
        }

        private void pictureBox_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage != 100) { // Kraunamas paveiksliukas
                uploadButton.Enabled = false;
            }
        }

        private void pictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null) // Pavyko užkrauti image
            {
                uploadButton.Enabled = true;
            }
        }

        private void ChangeProfilePictureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           // EditProfile editProfile1 = new EditProfile(localUser);
            //editProfile1.Show();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            var base64String = Convert.ToBase64String(File.ReadAllBytes(pictureBox.ImageLocation));
            //NU IR SITA base64String PERKELIAM I DUOMBAZE
            //kazkaip
        }
    }
}
