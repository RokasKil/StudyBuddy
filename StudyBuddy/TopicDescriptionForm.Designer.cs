namespace StudyBuddy
{
    partial class TopicDescriptionForm
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
            this.textBoxTopicDescription = new System.Windows.Forms.TextBox();
            this.labelTopicDescription = new System.Windows.Forms.Label();
            this.buttonEditTopicDescription = new System.Windows.Forms.Button();
            this.labelUpdated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTopicDescription
            // 
            this.textBoxTopicDescription.Location = new System.Drawing.Point(12, 38);
            this.textBoxTopicDescription.Multiline = true;
            this.textBoxTopicDescription.Name = "textBoxTopicDescription";
            this.textBoxTopicDescription.Size = new System.Drawing.Size(776, 364);
            this.textBoxTopicDescription.TabIndex = 0;
            // 
            // labelTopicDescription
            // 
            this.labelTopicDescription.AutoSize = true;
            this.labelTopicDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopicDescription.Location = new System.Drawing.Point(13, 10);
            this.labelTopicDescription.Name = "labelTopicDescription";
            this.labelTopicDescription.Size = new System.Drawing.Size(148, 25);
            this.labelTopicDescription.TabIndex = 1;
            this.labelTopicDescription.Text = "Temos aprašas";
            // 
            // buttonEditTopicDescription
            // 
            this.buttonEditTopicDescription.Location = new System.Drawing.Point(612, 408);
            this.buttonEditTopicDescription.Name = "buttonEditTopicDescription";
            this.buttonEditTopicDescription.Size = new System.Drawing.Size(176, 39);
            this.buttonEditTopicDescription.TabIndex = 2;
            this.buttonEditTopicDescription.Text = "Redaguoti";
            this.buttonEditTopicDescription.UseVisualStyleBackColor = true;
            this.buttonEditTopicDescription.Click += new System.EventHandler(this.buttonEditTopicDescription_Click);
            // 
            // labelUpdated
            // 
            this.labelUpdated.AutoSize = true;
            this.labelUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdated.Location = new System.Drawing.Point(7, 416);
            this.labelUpdated.Name = "labelUpdated";
            this.labelUpdated.Size = new System.Drawing.Size(116, 25);
            this.labelUpdated.TabIndex = 3;
            this.labelUpdated.Text = "Atnaujinta!";
            // 
            // TopicDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelUpdated);
            this.Controls.Add(this.buttonEditTopicDescription);
            this.Controls.Add(this.labelTopicDescription);
            this.Controls.Add(this.textBoxTopicDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TopicDescriptionForm";
            this.Text = "TopicDescriptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTopicDescription;
        private System.Windows.Forms.Label labelTopicDescription;
        private System.Windows.Forms.Button buttonEditTopicDescription;
        private System.Windows.Forms.Label labelUpdated;
    }
}