namespace StudyBuddy
{
    partial class EditProfile
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
            this.profilePicture = new System.Windows.Forms.PictureBox();
            this.changeProfPicButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // profilePicture
            // 
            this.profilePicture.Location = new System.Drawing.Point(44, 29);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(151, 150);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 1;
            this.profilePicture.TabStop = false;
            // 
            // changeProfPicButton
            // 
            this.changeProfPicButton.Location = new System.Drawing.Point(44, 210);
            this.changeProfPicButton.Name = "changeProfPicButton";
            this.changeProfPicButton.Size = new System.Drawing.Size(151, 66);
            this.changeProfPicButton.TabIndex = 2;
            this.changeProfPicButton.Text = "Pakeisti profilio nuotrauką";
            this.changeProfPicButton.UseVisualStyleBackColor = true;
            this.changeProfPicButton.Click += new System.EventHandler(this.ChangeProfPicButton_Click);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(304, 85);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(194, 33);
            this.saveChangesButton.TabIndex = 6;
            this.saveChangesButton.Text = "Išsaugoti pakeitimus";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(304, 29);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(194, 22);
            this.firstNameBox.TabIndex = 7;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(241, 32);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(57, 17);
            this.firstNameLabel.TabIndex = 8;
            this.firstNameLabel.Text = "Vardas:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(233, 60);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(65, 17);
            this.lastNameLabel.TabIndex = 9;
            this.lastNameLabel.Text = "Pavardė:";
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(304, 57);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(194, 22);
            this.lastNameBox.TabIndex = 10;
            // 
            // EditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 318);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.changeProfPicButton);
            this.Controls.Add(this.profilePicture);
            this.Name = "EditProfile";
            this.Text = "EditProfile";
            this.Load += new System.EventHandler(this.EditProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.Button changeProfPicButton;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameBox;
    }
}