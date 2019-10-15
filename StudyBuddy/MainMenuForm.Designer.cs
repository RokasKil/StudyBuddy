namespace StudyBuddy
{
    partial class MainMenuForm
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
            this.buttonAdvise = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonCheckProfile = new System.Windows.Forms.Button();
            this.buttonPostForHelp = new System.Windows.Forms.Button();
            this.buttonConversations = new System.Windows.Forms.Button();
            this.buttonTopic = new System.Windows.Forms.Button();
            this.buttonTopicList = new System.Windows.Forms.Button();
            this.labelLecturer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // greetingsLabel
            // 
            this.greetingsLabel.AutoSize = true;
            this.greetingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.greetingsLabel.Location = new System.Drawing.Point(430, 241);
            this.greetingsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.greetingsLabel.Name = "greetingsLabel";
            this.greetingsLabel.Size = new System.Drawing.Size(249, 39);
            this.greetingsLabel.TabIndex = 0;
            this.greetingsLabel.Text = "Welcome back!";
            this.greetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.greetingsLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // karmaProgressBar
            // 
            this.karmaProgressBar.Location = new System.Drawing.Point(437, 370);
            this.karmaProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.karmaProgressBar.Maximum = 1000;
            this.karmaProgressBar.Name = "karmaProgressBar";
            this.karmaProgressBar.Size = new System.Drawing.Size(245, 26);
            this.karmaProgressBar.Step = 1;
            this.karmaProgressBar.TabIndex = 1;
            this.karmaProgressBar.Value = 100;
            this.karmaProgressBar.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.Location = new System.Drawing.Point(432, 343);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(193, 25);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "Your karma progress";
            this.progressLabel.Click += new System.EventHandler(this.Label2_Click);
            // 
            // buttonAdvise
            // 
            this.buttonAdvise.BackColor = System.Drawing.Color.Yellow;
            this.buttonAdvise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdvise.Location = new System.Drawing.Point(848, 46);
            this.buttonAdvise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdvise.Name = "buttonAdvise";
            this.buttonAdvise.Size = new System.Drawing.Size(253, 92);
            this.buttonAdvise.TabIndex = 5;
            this.buttonAdvise.Text = "Galiu patarti";
            this.buttonAdvise.UseVisualStyleBackColor = false;
            this.buttonAdvise.Click += new System.EventHandler(this.Button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 680);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(3, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1113, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.ToolStripStatusLabel1_Click);
            // 
            // buttonCheckProfile
            // 
            this.buttonCheckProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCheckProfile.Location = new System.Drawing.Point(848, 340);
            this.buttonCheckProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCheckProfile.Name = "buttonCheckProfile";
            this.buttonCheckProfile.Size = new System.Drawing.Size(253, 92);
            this.buttonCheckProfile.TabIndex = 7;
            this.buttonCheckProfile.Text = "Peržiūrėti savo profilį";
            this.buttonCheckProfile.UseVisualStyleBackColor = true;
            this.buttonCheckProfile.Click += new System.EventHandler(this.CheckProfileButton_Click);
            // 
            // buttonPostForHelp
            // 
            this.buttonPostForHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostForHelp.Location = new System.Drawing.Point(848, 142);
            this.buttonPostForHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPostForHelp.Name = "buttonPostForHelp";
            this.buttonPostForHelp.Size = new System.Drawing.Size(253, 92);
            this.buttonPostForHelp.TabIndex = 7;
            this.buttonPostForHelp.Text = "Man reikia patarimo";
            this.buttonPostForHelp.UseVisualStyleBackColor = true;
            this.buttonPostForHelp.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // buttonConversations
            // 
            this.buttonConversations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConversations.Location = new System.Drawing.Point(12, 46);
            this.buttonConversations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConversations.Name = "buttonConversations";
            this.buttonConversations.Size = new System.Drawing.Size(253, 92);
            this.buttonConversations.TabIndex = 8;
            this.buttonConversations.Text = "Pokalbiai";
            this.buttonConversations.UseVisualStyleBackColor = true;
            this.buttonConversations.Click += new System.EventHandler(this.ButtonConversations_Click);
            // 
            // buttonTopic
            // 
            this.buttonTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTopic.Location = new System.Drawing.Point(848, 241);
            this.buttonTopic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTopic.Name = "buttonTopic";
            this.buttonTopic.Size = new System.Drawing.Size(253, 92);
            this.buttonTopic.TabIndex = 9;
            this.buttonTopic.Text = "Temos";
            this.buttonTopic.UseVisualStyleBackColor = true;
            this.buttonTopic.Click += new System.EventHandler(this.ButtonTopic_Click);
            // 
            // buttonTopicList
            // 
            this.buttonTopicList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTopicList.Location = new System.Drawing.Point(12, 143);
            this.buttonTopicList.Name = "buttonTopicList";
            this.buttonTopicList.Size = new System.Drawing.Size(253, 92);
            this.buttonTopicList.TabIndex = 10;
            this.buttonTopicList.Text = "Kurti naują temą";
            this.buttonTopicList.UseVisualStyleBackColor = true;
            this.buttonTopicList.Click += new System.EventHandler(this.buttonTopicList_Click);
            // 
            // labelLecturer
            // 
            this.labelLecturer.AutoSize = true;
            this.labelLecturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLecturer.Location = new System.Drawing.Point(16, 7);
            this.labelLecturer.Name = "labelLecturer";
            this.labelLecturer.Size = new System.Drawing.Size(103, 25);
            this.labelLecturer.TabIndex = 11;
            this.labelLecturer.Text = "Dėstytojas";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button1.Location = new System.Drawing.Point(848, 551);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 92);
            this.button1.TabIndex = 12;
            this.button1.Text = "Atsijungti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // logo
            // 
            this.logo.Image = global::StudyBuddy.Properties.Resources.study_buddy;
            this.logo.Location = new System.Drawing.Point(337, 46);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(448, 152);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 13;
            this.logo.TabStop = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 702);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.labelLecturer);
            this.Controls.Add(this.buttonTopicList);
            this.Controls.Add(this.buttonCheckProfile);
            this.Controls.Add(this.buttonTopic);
            this.Controls.Add(this.buttonConversations);
            this.Controls.Add(this.buttonPostForHelp);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonAdvise);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.karmaProgressBar);
            this.Controls.Add(this.greetingsLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainMenuForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetingsLabel;
        private System.Windows.Forms.ProgressBar karmaProgressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button buttonAdvise;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.Button buttonCheckProfile;
        private System.Windows.Forms.Button buttonPostForHelp;
        private System.Windows.Forms.Button buttonConversations;
        private System.Windows.Forms.Button buttonTopic;
        private System.Windows.Forms.Button buttonTopicList;
        private System.Windows.Forms.Label labelLecturer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox logo;
    }
}