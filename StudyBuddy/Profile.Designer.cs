namespace StudyBuddy
{
    partial class Profile
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
            this.button1 = new System.Windows.Forms.Button();
            this.givesHelp = new System.Windows.Forms.Label();
            this.feedback = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.leaveFeedbackButton = new System.Windows.Forms.Button();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.getsHelp = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // profilePicture
            // 
            this.profilePicture.Location = new System.Drawing.Point(47, 35);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(151, 150);
            this.profilePicture.TabIndex = 0;
            this.profilePicture.TabStop = false;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(44, 215);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(71, 17);
            this.username.TabIndex = 1;
            this.username.Text = "username";
            this.username.Click += new System.EventHandler(this.Label1_Click);
            // 
            // karma
            // 
            this.karma.AutoSize = true;
            this.karma.Location = new System.Drawing.Point(44, 255);
            this.karma.Name = "karma";
            this.karma.Size = new System.Drawing.Size(94, 17);
            this.karma.TabIndex = 2;
            this.karma.Text = "Karma taškai:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Parašyti žinutę";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // givesHelp
            // 
            this.givesHelp.AutoSize = true;
            this.givesHelp.Location = new System.Drawing.Point(292, 35);
            this.givesHelp.Name = "givesHelp";
            this.givesHelp.Size = new System.Drawing.Size(99, 17);
            this.givesHelp.TabIndex = 4;
            this.givesHelp.Text = "Gali padėti su:";
            this.givesHelp.Click += new System.EventHandler(this.Courses_Click);
            // 
            // feedback
            // 
            this.feedback.AutoSize = true;
            this.feedback.Location = new System.Drawing.Point(292, 244);
            this.feedback.Name = "feedback";
            this.feedback.Size = new System.Drawing.Size(82, 17);
            this.feedback.TabIndex = 5;
            this.feedback.Text = "Atsiliepimai:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(295, 55);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(389, 60);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(295, 264);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(389, 139);
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // leaveFeedbackButton
            // 
            this.leaveFeedbackButton.Location = new System.Drawing.Point(47, 363);
            this.leaveFeedbackButton.Name = "leaveFeedbackButton";
            this.leaveFeedbackButton.Size = new System.Drawing.Size(151, 40);
            this.leaveFeedbackButton.TabIndex = 8;
            this.leaveFeedbackButton.Text = "Palikti atsiliepimą";
            this.leaveFeedbackButton.UseVisualStyleBackColor = true;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // getsHelp
            // 
            this.getsHelp.AutoSize = true;
            this.getsHelp.Location = new System.Drawing.Point(292, 135);
            this.getsHelp.Name = "getsHelp";
            this.getsHelp.Size = new System.Drawing.Size(133, 17);
            this.getsHelp.TabIndex = 9;
            this.getsHelp.Text = "Ieško pagalbos ties:";
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(295, 155);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(389, 60);
            this.listView3.TabIndex = 10;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.getsHelp);
            this.Controls.Add(this.leaveFeedbackButton);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.feedback);
            this.Controls.Add(this.givesHelp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.karma);
            this.Controls.Add(this.username);
            this.Controls.Add(this.profilePicture);
            this.Name = "Profile";
            this.Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label karma;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label givesHelp;
        private System.Windows.Forms.Label feedback;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button leaveFeedbackButton;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label getsHelp;
        private System.Windows.Forms.ListView listView3;
    }
}