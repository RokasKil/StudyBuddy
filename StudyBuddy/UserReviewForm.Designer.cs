namespace StudyBuddy
{
    partial class UserReviewForm
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
            this.firstName = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.reviewBox1 = new System.Windows.Forms.RichTextBox();
            this.negativeButton = new System.Windows.Forms.Button();
            this.positiveButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageToUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // profilePicture
            // 
            this.profilePicture.Location = new System.Drawing.Point(12, 11);
            this.profilePicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(189, 185);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 1;
            this.profilePicture.TabStop = false;
            // 
            // firstName
            // 
            this.firstName.AutoSize = true;
            this.firstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstName.Location = new System.Drawing.Point(12, 198);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(87, 36);
            this.firstName.TabIndex = 10;
            this.firstName.Text = "name";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(15, 234);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(71, 17);
            this.username.TabIndex = 11;
            this.username.Text = "username";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(15, 251);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(46, 17);
            this.status.TabIndex = 12;
            this.status.Text = "status";
            // 
            // reviewBox1
            // 
            this.reviewBox1.Location = new System.Drawing.Point(207, 11);
            this.reviewBox1.Name = "reviewBox1";
            this.reviewBox1.Size = new System.Drawing.Size(575, 250);
            this.reviewBox1.TabIndex = 13;
            this.reviewBox1.Text = "";
            // 
            // negativeButton
            // 
            this.negativeButton.BackColor = System.Drawing.Color.Tomato;
            this.negativeButton.Location = new System.Drawing.Point(207, 267);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(104, 41);
            this.negativeButton.TabIndex = 14;
            this.negativeButton.Text = "Neigiamai";
            this.negativeButton.UseVisualStyleBackColor = false;
            this.negativeButton.Click += new System.EventHandler(this.negativeButton_Click);
            // 
            // positiveButton
            // 
            this.positiveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.positiveButton.Location = new System.Drawing.Point(552, 267);
            this.positiveButton.Name = "positiveButton";
            this.positiveButton.Size = new System.Drawing.Size(107, 41);
            this.positiveButton.TabIndex = 15;
            this.positiveButton.Text = "Teigiamai";
            this.positiveButton.UseVisualStyleBackColor = false;
            this.positiveButton.Click += new System.EventHandler(this.positiveButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.sendButton.Location = new System.Drawing.Point(665, 267);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(107, 41);
            this.sendButton.TabIndex = 16;
            this.sendButton.Text = "Siųsti";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageToUser
            // 
            this.messageToUser.Location = new System.Drawing.Point(317, 279);
            this.messageToUser.Name = "messageToUser";
            this.messageToUser.Size = new System.Drawing.Size(229, 27);
            this.messageToUser.TabIndex = 17;
            // 
            // UserReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 315);
            this.Controls.Add(this.messageToUser);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.positiveButton);
            this.Controls.Add(this.negativeButton);
            this.Controls.Add(this.reviewBox1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.username);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.profilePicture);
            this.Name = "UserReviewForm";
            this.Text = "Atsiliepimas";
            this.Load += new System.EventHandler(this.UserReviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.RichTextBox reviewBox1;
        private System.Windows.Forms.Button negativeButton;
        private System.Windows.Forms.Button positiveButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label messageToUser;
    }
}