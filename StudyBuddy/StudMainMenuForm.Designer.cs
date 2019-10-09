namespace StudyBuddy
{
    partial class StudMainMenuForm
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
            this.greetingsLabel = new System.Windows.Forms.Label();
            this.karmaProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.adviseButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkProfileButton = new System.Windows.Forms.Button();
            this.buttonPostForHelp = new System.Windows.Forms.Button();
            this.buttonConversations = new System.Windows.Forms.Button();
            this.buttonTopic = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // greetingsLabel
            // 
            this.greetingsLabel.AutoSize = true;
            this.greetingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.greetingsLabel.Location = new System.Drawing.Point(306, 267);
            this.greetingsLabel.Name = "greetingsLabel";
            this.greetingsLabel.Size = new System.Drawing.Size(199, 31);
            this.greetingsLabel.TabIndex = 0;
            this.greetingsLabel.Text = "Welcome back!";
            this.greetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.greetingsLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // karmaProgressBar
            // 
            this.karmaProgressBar.Location = new System.Drawing.Point(313, 85);
            this.karmaProgressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.karmaProgressBar.Maximum = 1000;
            this.karmaProgressBar.Name = "karmaProgressBar";
            this.karmaProgressBar.Size = new System.Drawing.Size(184, 21);
            this.karmaProgressBar.Step = 1;
            this.karmaProgressBar.TabIndex = 1;
            this.karmaProgressBar.Value = 100;
            this.karmaProgressBar.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.Location = new System.Drawing.Point(308, 58);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(157, 20);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "Your karma progress";
            this.progressLabel.Click += new System.EventHandler(this.Label2_Click);
            // 
            // adviseButton
            // 
            this.adviseButton.BackColor = System.Drawing.Color.Yellow;
            this.adviseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adviseButton.Location = new System.Drawing.Point(636, 37);
            this.adviseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adviseButton.Name = "adviseButton";
            this.adviseButton.Size = new System.Drawing.Size(190, 75);
            this.adviseButton.TabIndex = 5;
            this.adviseButton.Text = "Galiu patarti";
            this.adviseButton.UseVisualStyleBackColor = false;
            this.adviseButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(835, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.ToolStripStatusLabel1_Click);
            // 
            // checkProfileButton
            // 
            this.checkProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkProfileButton.Location = new System.Drawing.Point(636, 353);
            this.checkProfileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkProfileButton.Name = "checkProfileButton";
            this.checkProfileButton.Size = new System.Drawing.Size(190, 74);
            this.checkProfileButton.TabIndex = 7;
            this.checkProfileButton.Text = "Peržiūrėti savo profilį";
            this.checkProfileButton.UseVisualStyleBackColor = true;
            this.checkProfileButton.Click += new System.EventHandler(this.CheckProfileButton_Click);
            // 
            // buttonPostForHelp
            // 
            this.buttonPostForHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostForHelp.Location = new System.Drawing.Point(636, 142);
            this.buttonPostForHelp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPostForHelp.Name = "buttonPostForHelp";
            this.buttonPostForHelp.Size = new System.Drawing.Size(190, 77);
            this.buttonPostForHelp.TabIndex = 7;
            this.buttonPostForHelp.Text = "Man reikia patarimo";
            this.buttonPostForHelp.UseVisualStyleBackColor = true;
            this.buttonPostForHelp.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // buttonConversations
            // 
            this.buttonConversations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConversations.Location = new System.Drawing.Point(9, 37);
            this.buttonConversations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConversations.Name = "buttonConversations";
            this.buttonConversations.Size = new System.Drawing.Size(192, 75);
            this.buttonConversations.TabIndex = 8;
            this.buttonConversations.Text = "Pokalbiai";
            this.buttonConversations.UseVisualStyleBackColor = true;
            this.buttonConversations.Click += new System.EventHandler(this.ButtonConversations_Click);
            // 
            // buttonTopic
            // 
            this.buttonTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTopic.Location = new System.Drawing.Point(636, 254);
            this.buttonTopic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTopic.Name = "buttonTopic";
            this.buttonTopic.Size = new System.Drawing.Size(190, 77);
            this.buttonTopic.TabIndex = 9;
            this.buttonTopic.Text = "Temos";
            this.buttonTopic.UseVisualStyleBackColor = true;
            this.buttonTopic.Click += new System.EventHandler(this.ButtonTopic_Click);
            // 
            // StudMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 570);
            this.Controls.Add(this.checkProfileButton);
            this.Controls.Add(this.buttonTopic);
            this.Controls.Add(this.buttonConversations);
            this.Controls.Add(this.buttonPostForHelp);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.adviseButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.karmaProgressBar);
            this.Controls.Add(this.greetingsLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StudMainMenuForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetingsLabel;
        private System.Windows.Forms.ProgressBar karmaProgressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button adviseButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.Button checkProfileButton;
        private System.Windows.Forms.Button buttonPostForHelp;
        private System.Windows.Forms.Button buttonConversations;
        private System.Windows.Forms.Button buttonTopic;
    }
}