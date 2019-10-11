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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(12, 85);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ReadOnly = true;
            this.descriptionBox.Size = new System.Drawing.Size(361, 269);
            this.descriptionBox.TabIndex = 0;
            this.descriptionBox.Click += new System.EventHandler(this.problemosApibudinimas_Click);
            this.descriptionBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // categoryBox
            // 
            this.categoryBox.Location = new System.Drawing.Point(12, 12);
            this.categoryBox.Multiline = true;
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.ReadOnly = true;
            this.categoryBox.Size = new System.Drawing.Size(361, 32);
            this.categoryBox.TabIndex = 1;
            this.categoryBox.TextChanged += new System.EventHandler(this.kategorija_TextChanged);
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(12, 50);
            this.titleBox.Multiline = true;
            this.titleBox.Name = "titleBox";
            this.titleBox.ReadOnly = true;
            this.titleBox.Size = new System.Drawing.Size(361, 29);
            this.titleBox.TabIndex = 2;
            this.titleBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(379, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(263, 222);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.nuotraukaBox);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(379, 240);
            this.nameBox.Multiline = true;
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(263, 30);
            this.nameBox.TabIndex = 4;
            this.nameBox.TextChanged += new System.EventHandler(this.vardasPavardeBox);
            // 
            // HelpRequestDisplayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 360);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.descriptionBox);
            this.Name = "HelpRequestDisplayerForm";
            this.Text = "Help Request";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}