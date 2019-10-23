namespace StudyBuddy
{
    partial class ProfileForm
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
            this.username = new System.Windows.Forms.Label();
            this.karma = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.firstName = new System.Windows.Forms.Label();
            this.karmaProgressBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.writeMessageButton = new System.Windows.Forms.Button();
            this.leaveReviewButton = new System.Windows.Forms.Button();
            this.readReviewsButton = new System.Windows.Forms.Button();
            this.lastName = new System.Windows.Forms.Label();
            this.karmaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // profilePicture
            // 
            this.profilePicture.Location = new System.Drawing.Point(59, 50);
            this.profilePicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(189, 185);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 0;
            this.profilePicture.TabStop = false;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.username.Location = new System.Drawing.Point(60, 303);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(83, 20);
            this.username.TabIndex = 1;
            this.username.Text = "username";
            // 
            // karma
            // 
            this.karma.AutoSize = true;
            this.karma.Location = new System.Drawing.Point(56, 346);
            this.karma.Name = "karma";
            this.karma.Size = new System.Drawing.Size(101, 17);
            this.karma.TabIndex = 2;
            this.karma.Text = "Karmos taškai:";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // firstName
            // 
            this.firstName.AutoSize = true;
            this.firstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstName.Location = new System.Drawing.Point(57, 245);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(88, 29);
            this.firstName.TabIndex = 9;
            this.firstName.Text = "Vardas";
            // 
            // karmaProgressBar
            // 
            this.karmaProgressBar.Location = new System.Drawing.Point(59, 365);
            this.karmaProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.karmaProgressBar.Maximum = 10;
            this.karmaProgressBar.Name = "karmaProgressBar";
            this.karmaProgressBar.Size = new System.Drawing.Size(189, 18);
            this.karmaProgressBar.TabIndex = 10;
            this.karmaProgressBar.Value = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 464);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 39);
            this.button1.TabIndex = 11;
            this.button1.Text = "Redaguoti profilį";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(115, 31);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(46, 17);
            this.status.TabIndex = 1;
            this.status.Text = "status";
            // 
            // writeMessageButton
            // 
            this.writeMessageButton.Location = new System.Drawing.Point(59, 507);
            this.writeMessageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.writeMessageButton.Name = "writeMessageButton";
            this.writeMessageButton.Size = new System.Drawing.Size(189, 39);
            this.writeMessageButton.TabIndex = 12;
            this.writeMessageButton.Text = "Parašyti žinutę";
            this.writeMessageButton.UseVisualStyleBackColor = true;
            this.writeMessageButton.Click += new System.EventHandler(this.writeMessageButton_Click);
            // 
            // leaveReviewButton
            // 
            this.leaveReviewButton.Location = new System.Drawing.Point(59, 464);
            this.leaveReviewButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leaveReviewButton.Name = "leaveReviewButton";
            this.leaveReviewButton.Size = new System.Drawing.Size(189, 39);
            this.leaveReviewButton.TabIndex = 13;
            this.leaveReviewButton.Text = "Palikti atsiliepimą";
            this.leaveReviewButton.UseVisualStyleBackColor = true;
            this.leaveReviewButton.Click += new System.EventHandler(this.leaveReviewButton_Click);
            // 
            // readReviewsButton
            // 
            this.readReviewsButton.Location = new System.Drawing.Point(59, 421);
            this.readReviewsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.readReviewsButton.Name = "readReviewsButton";
            this.readReviewsButton.Size = new System.Drawing.Size(189, 39);
            this.readReviewsButton.TabIndex = 14;
            this.readReviewsButton.Text = "Skaityti atsiliepimus";
            this.readReviewsButton.UseVisualStyleBackColor = true;
            this.readReviewsButton.Click += new System.EventHandler(this.ReadReviewsButton_Click);
            // 
            // lastName
            // 
            this.lastName.AutoSize = true;
            this.lastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastName.Location = new System.Drawing.Point(57, 274);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(102, 29);
            this.lastName.TabIndex = 15;
            this.lastName.Text = "Pavardė";
            // 
            // karmaLabel
            // 
            this.karmaLabel.AutoSize = true;
            this.karmaLabel.Location = new System.Drawing.Point(56, 385);
            this.karmaLabel.Name = "karmaLabel";
            this.karmaLabel.Size = new System.Drawing.Size(36, 17);
            this.karmaLabel.TabIndex = 16;
            this.karmaLabel.Text = "4/10";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 559);
            this.Controls.Add(this.karmaLabel);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.readReviewsButton);
            this.Controls.Add(this.leaveReviewButton);
            this.Controls.Add(this.writeMessageButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.karmaProgressBar);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.karma);
            this.Controls.Add(this.status);
            this.Controls.Add(this.username);
            this.Controls.Add(this.profilePicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.Text = "Profile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Profile_FormClosed);
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label karma;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.ProgressBar karmaProgressBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button writeMessageButton;
        private System.Windows.Forms.Button leaveReviewButton;
        private System.Windows.Forms.Button readReviewsButton;
        private System.Windows.Forms.Label lastName;
        private System.Windows.Forms.Label karmaLabel;
    }
}