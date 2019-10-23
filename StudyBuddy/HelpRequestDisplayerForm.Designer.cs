namespace StudyBuddy
{
    partial class HelpRequestDisplayerForm
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
            this.TextBoxHelpRequestDescription = new System.Windows.Forms.TextBox();
            this.textBoxCategoryTitle = new System.Windows.Forms.TextBox();
            this.textBoxHelpRequestTitle = new System.Windows.Forms.TextBox();
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonWriteMessage = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxHelpRequestDescription
            // 
            this.TextBoxHelpRequestDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxHelpRequestDescription.Location = new System.Drawing.Point(16, 69);
            this.TextBoxHelpRequestDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBoxHelpRequestDescription.Multiline = true;
            this.TextBoxHelpRequestDescription.Name = "TextBoxHelpRequestDescription";
            this.TextBoxHelpRequestDescription.ReadOnly = true;
            this.TextBoxHelpRequestDescription.Size = new System.Drawing.Size(264, 197);
            this.TextBoxHelpRequestDescription.TabIndex = 6;
            this.TextBoxHelpRequestDescription.Text = "Aprašymas";
            // 
            // textBoxCategoryTitle
            // 
            this.textBoxCategoryTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCategoryTitle.Location = new System.Drawing.Point(16, 47);
            this.textBoxCategoryTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCategoryTitle.Multiline = true;
            this.textBoxCategoryTitle.Name = "textBoxCategoryTitle";
            this.textBoxCategoryTitle.ReadOnly = true;
            this.textBoxCategoryTitle.Size = new System.Drawing.Size(264, 19);
            this.textBoxCategoryTitle.TabIndex = 1;
            this.textBoxCategoryTitle.Text = "Kategorija";
            // 
            // textBoxHelpRequestTitle
            // 
            this.textBoxHelpRequestTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHelpRequestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHelpRequestTitle.Location = new System.Drawing.Point(16, 10);
            this.textBoxHelpRequestTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxHelpRequestTitle.Multiline = true;
            this.textBoxHelpRequestTitle.Name = "textBoxHelpRequestTitle";
            this.textBoxHelpRequestTitle.ReadOnly = true;
            this.textBoxHelpRequestTitle.Size = new System.Drawing.Size(264, 34);
            this.textBoxHelpRequestTitle.TabIndex = 2;
            this.textBoxHelpRequestTitle.Text = "Pavadinimas";
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.Location = new System.Drawing.Point(301, 10);
            this.pictureBoxProfilePicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.Size = new System.Drawing.Size(172, 187);
            this.pictureBoxProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProfilePicture.TabIndex = 3;
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProfileName.Location = new System.Drawing.Point(301, 200);
            this.textBoxProfileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxProfileName.Multiline = true;
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.ReadOnly = true;
            this.textBoxProfileName.Size = new System.Drawing.Size(172, 24);
            this.textBoxProfileName.TabIndex = 4;
            this.textBoxProfileName.Text = "Vardas Pavardė";
            this.textBoxProfileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonProfile
            // 
            this.buttonProfile.Location = new System.Drawing.Point(301, 229);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(79, 37);
            this.buttonProfile.TabIndex = 5;
            this.buttonProfile.Text = "Profilis";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.profile_Click);
            // 
            // buttonWriteMessage
            // 
            this.buttonWriteMessage.Location = new System.Drawing.Point(394, 229);
            this.buttonWriteMessage.Name = "buttonWriteMessage";
            this.buttonWriteMessage.Size = new System.Drawing.Size(79, 37);
            this.buttonWriteMessage.TabIndex = 0;
            this.buttonWriteMessage.Text = "Parašyti žinutę";
            this.buttonWriteMessage.UseVisualStyleBackColor = true;
            this.buttonWriteMessage.Click += new System.EventHandler(this.writeMessageButton_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(353, 229);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 37);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.Text = "Pašalinti";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(301, 273);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(172, 18);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HelpRequestDisplayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 292);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonWriteMessage);
            this.Controls.Add(this.buttonProfile);
            this.Controls.Add(this.textBoxProfileName);
            this.Controls.Add(this.pictureBoxProfilePicture);
            this.Controls.Add(this.textBoxHelpRequestTitle);
            this.Controls.Add(this.textBoxCategoryTitle);
            this.Controls.Add(this.TextBoxHelpRequestDescription);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HelpRequestDisplayerForm";
            this.Text = "Help Request";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxHelpRequestDescription;
        private System.Windows.Forms.TextBox textBoxCategoryTitle;
        private System.Windows.Forms.TextBox textBoxHelpRequestTitle;
        private System.Windows.Forms.PictureBox pictureBoxProfilePicture;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Button buttonWriteMessage;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Label statusLabel;
    }
}