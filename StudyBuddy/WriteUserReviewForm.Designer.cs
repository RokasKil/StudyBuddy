namespace StudyBuddy
{
    partial class WriteUserReviewForm
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
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.richTextBoxReviewDescription = new System.Windows.Forms.RichTextBox();
            this.buttonNegativeReview = new System.Windows.Forms.Button();
            this.buttonPositiveReview = new System.Windows.Forms.Button();
            this.buttonSendReview = new System.Windows.Forms.Button();
            this.messageToUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.Location = new System.Drawing.Point(12, 11);
            this.pictureBoxProfilePicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.Size = new System.Drawing.Size(189, 185);
            this.pictureBoxProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProfilePicture.TabIndex = 1;
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFirstName.Location = new System.Drawing.Point(12, 198);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(87, 36);
            this.labelFirstName.TabIndex = 10;
            this.labelFirstName.Text = "name";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(15, 234);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(71, 17);
            this.labelUsername.TabIndex = 11;
            this.labelUsername.Text = "username";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(15, 251);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(46, 17);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "status";
            // 
            // richTextBoxReviewDescription
            // 
            this.richTextBoxReviewDescription.Location = new System.Drawing.Point(207, 11);
            this.richTextBoxReviewDescription.Name = "richTextBoxReviewDescription";
            this.richTextBoxReviewDescription.Size = new System.Drawing.Size(575, 250);
            this.richTextBoxReviewDescription.TabIndex = 13;
            this.richTextBoxReviewDescription.Text = "";
            // 
            // buttonNegativeReview
            // 
            this.buttonNegativeReview.BackColor = System.Drawing.Color.Tomato;
            this.buttonNegativeReview.Location = new System.Drawing.Point(207, 267);
            this.buttonNegativeReview.Name = "buttonNegativeReview";
            this.buttonNegativeReview.Size = new System.Drawing.Size(104, 41);
            this.buttonNegativeReview.TabIndex = 14;
            this.buttonNegativeReview.Text = "Neigiamai";
            this.buttonNegativeReview.UseVisualStyleBackColor = false;
            this.buttonNegativeReview.Click += new System.EventHandler(this.negativeButton_Click);
            // 
            // buttonPositiveReview
            // 
            this.buttonPositiveReview.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonPositiveReview.Location = new System.Drawing.Point(552, 267);
            this.buttonPositiveReview.Name = "buttonPositiveReview";
            this.buttonPositiveReview.Size = new System.Drawing.Size(107, 41);
            this.buttonPositiveReview.TabIndex = 15;
            this.buttonPositiveReview.Text = "Teigiamai";
            this.buttonPositiveReview.UseVisualStyleBackColor = false;
            this.buttonPositiveReview.Click += new System.EventHandler(this.positiveButton_Click);
            // 
            // buttonSendReview
            // 
            this.buttonSendReview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonSendReview.Location = new System.Drawing.Point(665, 267);
            this.buttonSendReview.Name = "buttonSendReview";
            this.buttonSendReview.Size = new System.Drawing.Size(107, 41);
            this.buttonSendReview.TabIndex = 16;
            this.buttonSendReview.Text = "Siųsti";
            this.buttonSendReview.UseVisualStyleBackColor = false;
            this.buttonSendReview.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageToUser
            // 
            this.messageToUser.Location = new System.Drawing.Point(317, 279);
            this.messageToUser.Name = "messageToUser";
            this.messageToUser.Size = new System.Drawing.Size(229, 27);
            this.messageToUser.TabIndex = 17;
            // 
            // WriteUserReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 315);
            this.Controls.Add(this.messageToUser);
            this.Controls.Add(this.buttonSendReview);
            this.Controls.Add(this.buttonPositiveReview);
            this.Controls.Add(this.buttonNegativeReview);
            this.Controls.Add(this.richTextBoxReviewDescription);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.pictureBoxProfilePicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WriteUserReviewForm";
            this.Text = "Atsiliepimas";
            this.Load += new System.EventHandler(this.UserReviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxProfilePicture;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.RichTextBox richTextBoxReviewDescription;
        private System.Windows.Forms.Button buttonNegativeReview;
        private System.Windows.Forms.Button buttonPositiveReview;
        private System.Windows.Forms.Button buttonSendReview;
        private System.Windows.Forms.Label messageToUser;
    }
}