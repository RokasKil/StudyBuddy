namespace StudyBuddy
{
    partial class LoginForm
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
            this.textBoxUsernameField = new System.Windows.Forms.TextBox();
            this.textBoxPasswordField = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.checkBoxRememberLogin = new System.Windows.Forms.CheckBox();
            this.pictureBoxStudyBuddyLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStudyBuddyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUsernameField
            // 
            this.textBoxUsernameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBoxUsernameField.Location = new System.Drawing.Point(16, 129);
            this.textBoxUsernameField.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUsernameField.Name = "textBoxUsernameField";
            this.textBoxUsernameField.Size = new System.Drawing.Size(265, 34);
            this.textBoxUsernameField.TabIndex = 0;
            // 
            // textBoxPasswordField
            // 
            this.textBoxPasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBoxPasswordField.Location = new System.Drawing.Point(16, 172);
            this.textBoxPasswordField.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordField.Name = "textBoxPasswordField";
            this.textBoxPasswordField.PasswordChar = '•';
            this.textBoxPasswordField.Size = new System.Drawing.Size(265, 34);
            this.textBoxPasswordField.TabIndex = 1;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonLogin.Location = new System.Drawing.Point(90, 258);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(123, 43);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Prisijungti";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(13, 305);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(267, 16);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxRememberLogin
            // 
            this.checkBoxRememberLogin.AutoSize = true;
            this.checkBoxRememberLogin.Location = new System.Drawing.Point(30, 214);
            this.checkBoxRememberLogin.Name = "checkBoxRememberLogin";
            this.checkBoxRememberLogin.Size = new System.Drawing.Size(121, 21);
            this.checkBoxRememberLogin.TabIndex = 5;
            this.checkBoxRememberLogin.Text = "Atsiminti mane";
            this.checkBoxRememberLogin.UseVisualStyleBackColor = true;
            this.checkBoxRememberLogin.CheckedChanged += new System.EventHandler(this.rememberMe_CheckedChanged);
            // 
            // pictureBoxStudyBuddyLogo
            // 
            this.pictureBoxStudyBuddyLogo.Image = global::StudyBuddy.Properties.Resources.study_buddy;
            this.pictureBoxStudyBuddyLogo.Location = new System.Drawing.Point(12, 24);
            this.pictureBoxStudyBuddyLogo.Name = "pictureBoxStudyBuddyLogo";
            this.pictureBoxStudyBuddyLogo.Size = new System.Drawing.Size(286, 98);
            this.pictureBoxStudyBuddyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStudyBuddyLogo.TabIndex = 5;
            this.pictureBoxStudyBuddyLogo.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 330);
            this.Controls.Add(this.checkBoxRememberLogin);
            this.Controls.Add(this.pictureBoxStudyBuddyLogo);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPasswordField);
            this.Controls.Add(this.textBoxUsernameField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStudyBuddyLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsernameField;
        private System.Windows.Forms.TextBox textBoxPasswordField;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox checkBoxRememberLogin;
        private System.Windows.Forms.PictureBox pictureBoxStudyBuddyLogo;
    }
}

