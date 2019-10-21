namespace StudyBuddy
{
    partial class UserReviewForm
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
            this.listViewUserReviews = new System.Windows.Forms.ListView();
            this.buttonSortReviews = new System.Windows.Forms.Button();
            this.richTextBoxUsername = new System.Windows.Forms.RichTextBox();
            this.progressBarKarma = new System.Windows.Forms.ProgressBar();
            this.labelKarmaProgress = new System.Windows.Forms.Label();
            this.Reviewer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReviewMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReviewKarma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReviewPostDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewUserReviews
            // 
            this.listViewUserReviews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Reviewer,
            this.ReviewMessage,
            this.ReviewKarma,
            this.ReviewPostDate});
            this.listViewUserReviews.GridLines = true;
            this.listViewUserReviews.HideSelection = false;
            this.listViewUserReviews.Location = new System.Drawing.Point(12, 56);
            this.listViewUserReviews.Name = "listViewUserReviews";
            this.listViewUserReviews.Size = new System.Drawing.Size(794, 382);
            this.listViewUserReviews.TabIndex = 0;
            this.listViewUserReviews.UseCompatibleStateImageBehavior = false;
            this.listViewUserReviews.View = System.Windows.Forms.View.Details;
            this.listViewUserReviews.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewUserReviews_ColumnClick);
            this.listViewUserReviews.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewUserReviews_ColumnWidthChanging);
            // 
            // buttonSortReviews
            // 
            this.buttonSortReviews.Location = new System.Drawing.Point(180, 11);
            this.buttonSortReviews.Name = "buttonSortReviews";
            this.buttonSortReviews.Size = new System.Drawing.Size(162, 35);
            this.buttonSortReviews.TabIndex = 1;
            this.buttonSortReviews.Text = "Rūšiuoti";
            this.buttonSortReviews.UseVisualStyleBackColor = true;
            this.buttonSortReviews.Click += new System.EventHandler(this.buttonSortReviews_Click);
            // 
            // richTextBoxUsername
            // 
            this.richTextBoxUsername.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxUsername.Multiline = false;
            this.richTextBoxUsername.Name = "richTextBoxUsername";
            this.richTextBoxUsername.Size = new System.Drawing.Size(162, 34);
            this.richTextBoxUsername.TabIndex = 2;
            this.richTextBoxUsername.Text = "";
            this.richTextBoxUsername.TextChanged += new System.EventHandler(this.richTextBoxUsername_TextChanged);
            // 
            // progressBarKarma
            // 
            this.progressBarKarma.Location = new System.Drawing.Point(657, 17);
            this.progressBarKarma.Maximum = 1000;
            this.progressBarKarma.Name = "progressBarKarma";
            this.progressBarKarma.Size = new System.Drawing.Size(149, 29);
            this.progressBarKarma.TabIndex = 3;
            this.progressBarKarma.Value = 150;
            // 
            // labelKarmaProgress
            // 
            this.labelKarmaProgress.AutoSize = true;
            this.labelKarmaProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKarmaProgress.Location = new System.Drawing.Point(379, 17);
            this.labelKarmaProgress.Name = "labelKarmaProgress";
            this.labelKarmaProgress.Size = new System.Drawing.Size(0, 25);
            this.labelKarmaProgress.TabIndex = 4;
            // 
            // Reviewer
            // 
            this.Reviewer.Text = "Vartotojas";
            // 
            // ReviewMessage
            // 
            this.ReviewMessage.Text = "Atsiliepimas";
            // 
            // ReviewKarma
            // 
            this.ReviewKarma.Text = "Karma";
            // 
            // ReviewPostDate
            // 
            this.ReviewPostDate.Text = "Atsiliepimo data";
            // 
            // UserReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 450);
            this.Controls.Add(this.labelKarmaProgress);
            this.Controls.Add(this.progressBarKarma);
            this.Controls.Add(this.richTextBoxUsername);
            this.Controls.Add(this.buttonSortReviews);
            this.Controls.Add(this.listViewUserReviews);
            this.Name = "UserReviewForm";
            this.Text = "UserReviewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewUserReviews;
        private System.Windows.Forms.Button buttonSortReviews;
        private System.Windows.Forms.RichTextBox richTextBoxUsername;
        private System.Windows.Forms.ProgressBar progressBarKarma;
        private System.Windows.Forms.Label labelKarmaProgress;
        private System.Windows.Forms.ColumnHeader Reviewer;
        private System.Windows.Forms.ColumnHeader ReviewMessage;
        private System.Windows.Forms.ColumnHeader ReviewKarma;
        private System.Windows.Forms.ColumnHeader ReviewPostDate;
    }
}