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
            this.name = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.Location = new System.Drawing.Point(241, 29);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(50, 20);
            this.name.TabIndex = 3;
            this.name.Text = "name";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(242, 66);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(71, 17);
            this.username.TabIndex = 5;
            this.username.Text = "username";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(296, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Redaguoti asmeninę informaciją";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // EditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 318);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.name);
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
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Button button2;
    }
}