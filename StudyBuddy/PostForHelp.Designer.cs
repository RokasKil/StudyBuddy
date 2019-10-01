namespace StudyBuddy
{
    partial class PostForHelp
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
            this.kategorijos = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // kategorijos
            // 
            this.kategorijos.FormattingEnabled = true;
            this.kategorijos.Items.AddRange(new object[] {
            "Kopiuterių Architektūra",
            "Matematinė Analizė",
            "Algoritmų Teorija",
            "Diskrečioji Matematika",
            "Logika"});
            this.kategorijos.Location = new System.Drawing.Point(9, 10);
            this.kategorijos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kategorijos.MinimumSize = new System.Drawing.Size(8, 0);
            this.kategorijos.Name = "kategorijos";
            this.kategorijos.Size = new System.Drawing.Size(324, 21);
            this.kategorijos.TabIndex = 1;
            this.kategorijos.Text = "Pasirinkti...";
            this.kategorijos.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(240, 249);
            this.okButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(92, 37);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // descriptionBox
            // 
            this.descriptionBox.AcceptsReturn = true;
            this.descriptionBox.AcceptsTab = true;
            this.descriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.descriptionBox.Location = new System.Drawing.Point(10, 57);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(323, 187);
            this.descriptionBox.TabIndex = 2;
            this.descriptionBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(10, 34);
            this.titleBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(323, 20);
            this.titleBox.TabIndex = 3;
            this.titleBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // PostForHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 296);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.kategorijos);
            this.Controls.Add(this.okButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PostForHelp";
            this.Text = "Seach for help";
            this.Load += new System.EventHandler(this.PostForHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.ComboBox kategorijos;
    }
}