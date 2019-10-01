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
            System.Windows.Forms.ComboBox kategorijos;
            this.button1 = new System.Windows.Forms.Button();
            this.tekstoLangas = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            kategorijos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kategorijos
            // 
            kategorijos.FormattingEnabled = true;
            kategorijos.Items.AddRange(new object[] {
            "Kopiuterių Architektūra",
            "Matematinė Analizė",
            "Algoritmų Teorija",
            "Diskrečioji Matematika",
            "Logika"});
            kategorijos.Location = new System.Drawing.Point(199, 46);
            kategorijos.MinimumSize = new System.Drawing.Size(10, 0);
            kategorijos.Name = "kategorijos";
            kategorijos.Size = new System.Drawing.Size(430, 24);
            kategorijos.TabIndex = 1;
            kategorijos.Text = "Pasirinkti...";
            kategorijos.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tekstoLangas
            // 
            this.tekstoLangas.AcceptsReturn = true;
            this.tekstoLangas.AcceptsTab = true;
            this.tekstoLangas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tekstoLangas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tekstoLangas.Location = new System.Drawing.Point(199, 101);
            this.tekstoLangas.Multiline = true;
            this.tekstoLangas.Name = "tekstoLangas";
            this.tekstoLangas.Size = new System.Drawing.Size(430, 230);
            this.tekstoLangas.TabIndex = 2;
            this.tekstoLangas.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(199, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(429, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // PostForHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tekstoLangas);
            this.Controls.Add(kategorijos);
            this.Controls.Add(this.button1);
            this.Name = "PostForHelp";
            this.Text = "Seach for help";
            this.Load += new System.EventHandler(this.PostForHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tekstoLangas;
        private System.Windows.Forms.TextBox textBox1;
    }
}