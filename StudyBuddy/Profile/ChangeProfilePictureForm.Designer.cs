namespace StudyBuddy
{
    partial class ChangeProfilePictureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.dragAndDropOverlay = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(250, 250);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox_LoadCompleted);
            this.pictureBox.LoadProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.pictureBox_LoadProgressChanged);
            // 
            // dragAndDropOverlay
            // 
            this.dragAndDropOverlay.AutoSize = true;
            this.dragAndDropOverlay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dragAndDropOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dragAndDropOverlay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dragAndDropOverlay.Location = new System.Drawing.Point(0, 0);
            this.dragAndDropOverlay.Name = "dragAndDropOverlay";
            this.dragAndDropOverlay.Size = new System.Drawing.Size(103, 13);
            this.dragAndDropOverlay.TabIndex = 2;
            this.dragAndDropOverlay.Text = "Vilkite nuotrauką čia";
            this.dragAndDropOverlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dragAndDropOverlay.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(12, 276);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Naršyti";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Enabled = false;
            this.uploadButton.Location = new System.Drawing.Point(163, 276);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(98, 23);
            this.uploadButton.TabIndex = 4;
            this.uploadButton.Text = "Keisti nuotrauką";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // ChangeProfilePictureForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 311);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.dragAndDropOverlay);
            this.Controls.Add(this.pictureBox);
            this.Name = "ChangeProfilePictureForm";
            this.Text = "Profilio nuotrauka";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChangeProfilePictureForm_FormClosed);
            this.Load += new System.EventHandler(this.ChangeProfilePictureForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ChangeProfilePictureForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ChangeProfilePictureForm_DragEnter);
            this.DragLeave += new System.EventHandler(this.ChangeProfilePictureForm_DragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label dragAndDropOverlay;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button uploadButton;
    }
}