namespace StudyBuddy
{
    partial class ConversationHistoryForm
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
            this.statusLabelLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusLabelLoading
            // 
            this.statusLabelLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabelLoading.Location = new System.Drawing.Point(16, 11);
            this.statusLabelLoading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabelLoading.Name = "statusLabelLoading";
            this.statusLabelLoading.Size = new System.Drawing.Size(440, 28);
            this.statusLabelLoading.TabIndex = 0;
            this.statusLabelLoading.Text = "Kraunama...";
            this.statusLabelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConversationHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 250);
            this.ClientSize = new System.Drawing.Size(472, 444);
            this.Controls.Add(this.statusLabelLoading);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConversationHistoryForm";
            this.Text = "ConversationHistoryForm";
            this.Load += new System.EventHandler(this.ConversationHistoryForm_Load);
            this.Resize += new System.EventHandler(this.ConversationHistoryForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label statusLabelLoading;
    }
}