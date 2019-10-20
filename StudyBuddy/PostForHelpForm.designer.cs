namespace StudyBuddy
{
    partial class PostForHelpForm
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
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.buttonConfirmHelpRequest = new System.Windows.Forms.Button();
            this.textBoxPostForHelpDescription = new System.Windows.Forms.TextBox();
            this.textBoxPostForHelpTitle = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Items.AddRange(new object[] {
            "Kopiuterių Architektūra",
            "Matematinė Analizė",
            "Algoritmų Teorija",
            "Diskrečioji Matematika",
            "Logika"});
            this.comboBoxCategories.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCategories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCategories.MinimumSize = new System.Drawing.Size(9, 0);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(440, 24);
            this.comboBoxCategories.TabIndex = 1;
            this.comboBoxCategories.Text = "Pasirinkti...";
            // 
            // buttonConfirmHelpRequest
            // 
            this.buttonConfirmHelpRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.buttonConfirmHelpRequest.Location = new System.Drawing.Point(329, 307);
            this.buttonConfirmHelpRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConfirmHelpRequest.Name = "buttonConfirmHelpRequest";
            this.buttonConfirmHelpRequest.Size = new System.Drawing.Size(123, 46);
            this.buttonConfirmHelpRequest.TabIndex = 0;
            this.buttonConfirmHelpRequest.Text = "Patvirtinti";
            this.buttonConfirmHelpRequest.UseVisualStyleBackColor = true;
            this.buttonConfirmHelpRequest.Click += new System.EventHandler(this.buttonConfirmHelpRequest_Click);
            // 
            // textBoxPostForHelpDescription
            // 
            this.textBoxPostForHelpDescription.AcceptsReturn = true;
            this.textBoxPostForHelpDescription.AcceptsTab = true;
            this.textBoxPostForHelpDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPostForHelpDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPostForHelpDescription.Location = new System.Drawing.Point(13, 70);
            this.textBoxPostForHelpDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPostForHelpDescription.Multiline = true;
            this.textBoxPostForHelpDescription.Name = "textBoxPostForHelpDescription";
            this.textBoxPostForHelpDescription.Size = new System.Drawing.Size(439, 230);
            this.textBoxPostForHelpDescription.TabIndex = 2;
            this.textBoxPostForHelpDescription.TextChanged += new System.EventHandler(this.textBoxPostForHelpDescription_TextChanged);
            // 
            // textBoxPostForHelpTitle
            // 
            this.textBoxPostForHelpTitle.Location = new System.Drawing.Point(13, 42);
            this.textBoxPostForHelpTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPostForHelpTitle.Name = "textBoxPostForHelpTitle";
            this.textBoxPostForHelpTitle.Size = new System.Drawing.Size(439, 22);
            this.textBoxPostForHelpTitle.TabIndex = 3;
            this.textBoxPostForHelpTitle.TextChanged += new System.EventHandler(this.textBoxPostForHelpTitle_TextChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(7, 328);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(173, 25);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Nepavyko užkrauti";
            // 
            // PostForHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 364);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxPostForHelpTitle);
            this.Controls.Add(this.textBoxPostForHelpDescription);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.buttonConfirmHelpRequest);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PostForHelpForm";
            this.Text = "Seach for help";
            this.Load += new System.EventHandler(this.PostForHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirmHelpRequest;
        private System.Windows.Forms.TextBox textBoxPostForHelpDescription;
        private System.Windows.Forms.TextBox textBoxPostForHelpTitle;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Label labelStatus;
    }
}