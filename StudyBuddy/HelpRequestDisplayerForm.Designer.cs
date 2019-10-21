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
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.categoryBox = new System.Windows.Forms.TextBox();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.profile = new System.Windows.Forms.Button();
            this.writeMessageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionBox
            // 
            this.descriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionBox.Location = new System.Drawing.Point(21, 85);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ReadOnly = true;
            this.descriptionBox.Size = new System.Drawing.Size(352, 243);
            this.descriptionBox.TabIndex = 0;
            this.descriptionBox.Text = "Aprašymas";
            // 
            // categoryBox
            // 
            this.categoryBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.categoryBox.Location = new System.Drawing.Point(21, 58);
            this.categoryBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categoryBox.Multiline = true;
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.ReadOnly = true;
            this.categoryBox.Size = new System.Drawing.Size(352, 23);
            this.categoryBox.TabIndex = 1;
            this.categoryBox.Text = "Kategorija";
            // 
            // titleBox
            // 
            this.titleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleBox.Location = new System.Drawing.Point(21, 12);
            this.titleBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleBox.Multiline = true;
            this.titleBox.Name = "titleBox";
            this.titleBox.ReadOnly = true;
            this.titleBox.Size = new System.Drawing.Size(352, 42);
            this.titleBox.TabIndex = 2;
            this.titleBox.Text = "Pavadinimas";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(401, 12);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(230, 230);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // nameBox
            // 
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(401, 246);
            this.nameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameBox.Multiline = true;
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(230, 30);
            this.nameBox.TabIndex = 4;
            this.nameBox.Text = "Vardas Pavardė";
            this.nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // profile
            // 
            this.profile.Location = new System.Drawing.Point(401, 282);
            this.profile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(105, 46);
            this.profile.TabIndex = 5;
            this.profile.Text = "Profilis";
            this.profile.UseVisualStyleBackColor = true;
            this.profile.Click += new System.EventHandler(this.profile_Click);
            // 
            // writeMessageButton
            // 
            this.writeMessageButton.Location = new System.Drawing.Point(526, 282);
            this.writeMessageButton.Margin = new System.Windows.Forms.Padding(4);
            this.writeMessageButton.Name = "writeMessageButton";
            this.writeMessageButton.Size = new System.Drawing.Size(105, 46);
            this.writeMessageButton.TabIndex = 6;
            this.writeMessageButton.Text = "Parašyti žinutę";
            this.writeMessageButton.UseVisualStyleBackColor = true;
            // 
            // HelpRequestDisplayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 359);
            this.Controls.Add(this.writeMessageButton);
            this.Controls.Add(this.profile);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.descriptionBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HelpRequestDisplayerForm";
            this.Text = "Help Request";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.TextBox categoryBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button profile;
        private System.Windows.Forms.Button writeMessageButton;
    }
}