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
            this.SuspendLayout();
            // 
            // ConversationHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 250);
            this.ClientSize = new System.Drawing.Size(354, 361);
            this.Name = "ConversationHistoryForm";
            this.Text = "ConversationHistoryForm";
            this.Load += new System.EventHandler(this.ConversationHistoryForm_Load);
            this.Resize += new System.EventHandler(this.ConversationHistoryForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}