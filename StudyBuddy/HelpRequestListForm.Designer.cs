namespace StudyBuddy
{
    partial class HelpRequestListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpRequestListForm));
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.helpRequestsPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2HelpRequest = new System.Windows.Forms.Label();
            this.label1HelpRequest = new System.Windows.Forms.Label();
            this.textBoxHelpRequestDescription = new System.Windows.Forms.TextBox();
            this.textBoxHelpRequestTitle = new System.Windows.Forms.TextBox();
            this.checkBoxOwn = new System.Windows.Forms.CheckBox();
            this.helpRequestsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(16, 47);
            this.comboBoxCategories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(532, 24);
            this.comboBoxCategories.TabIndex = 0;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.categoriesComboBox_SelectedIndexChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Location = new System.Drawing.Point(16, 15);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(532, 22);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // helpRequestsPanel
            // 
            this.helpRequestsPanel.AutoScroll = true;
            this.helpRequestsPanel.Controls.Add(this.panel2);
            this.helpRequestsPanel.Location = new System.Drawing.Point(3, 110);
            this.helpRequestsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.helpRequestsPanel.Name = "helpRequestsPanel";
            this.helpRequestsPanel.Size = new System.Drawing.Size(567, 479);
            this.helpRequestsPanel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2HelpRequest);
            this.panel2.Controls.Add(this.label1HelpRequest);
            this.panel2.Controls.Add(this.textBoxHelpRequestDescription);
            this.panel2.Controls.Add(this.textBoxHelpRequestTitle);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 130);
            this.panel2.TabIndex = 0;
            // 
            // label2HelpRequest
            // 
            this.label2HelpRequest.AutoSize = true;
            this.label2HelpRequest.Location = new System.Drawing.Point(4, 92);
            this.label2HelpRequest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2HelpRequest.Name = "label2HelpRequest";
            this.label2HelpRequest.Size = new System.Drawing.Size(46, 17);
            this.label2HelpRequest.TabIndex = 3;
            this.label2HelpRequest.Text = "label2";
            // 
            // label1HelpRequest
            // 
            this.label1HelpRequest.Location = new System.Drawing.Point(8, 108);
            this.label1HelpRequest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1HelpRequest.Name = "label1HelpRequest";
            this.label1HelpRequest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1HelpRequest.Size = new System.Drawing.Size(555, 18);
            this.label1HelpRequest.TabIndex = 2;
            this.label1HelpRequest.Text = "label1";
            this.label1HelpRequest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxHelpRequestDescription
            // 
            this.textBoxHelpRequestDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHelpRequestDescription.Enabled = false;
            this.textBoxHelpRequestDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxHelpRequestDescription.Location = new System.Drawing.Point(5, 39);
            this.textBoxHelpRequestDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHelpRequestDescription.Multiline = true;
            this.textBoxHelpRequestDescription.Name = "textBoxHelpRequestDescription";
            this.textBoxHelpRequestDescription.ReadOnly = true;
            this.textBoxHelpRequestDescription.Size = new System.Drawing.Size(555, 49);
            this.textBoxHelpRequestDescription.TabIndex = 1;
            this.textBoxHelpRequestDescription.Text = resources.GetString("textBoxHelpRequestDescription.Text");
            // 
            // textBoxHelpRequestTitle
            // 
            this.textBoxHelpRequestTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHelpRequestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxHelpRequestTitle.Location = new System.Drawing.Point(5, 5);
            this.textBoxHelpRequestTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHelpRequestTitle.Name = "textBoxHelpRequestTitle";
            this.textBoxHelpRequestTitle.ReadOnly = true;
            this.textBoxHelpRequestTitle.Size = new System.Drawing.Size(555, 27);
            this.textBoxHelpRequestTitle.TabIndex = 0;
            this.textBoxHelpRequestTitle.Text = "GHGSGFFGg";
            // 
            // checkBoxOwn
            // 
            this.checkBoxOwn.AutoSize = true;
            this.checkBoxOwn.Location = new System.Drawing.Point(17, 81);
            this.checkBoxOwn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxOwn.Name = "checkBoxOwn";
            this.checkBoxOwn.Size = new System.Drawing.Size(141, 21);
            this.checkBoxOwn.TabIndex = 3;
            this.checkBoxOwn.Text = "Tik tavo prašymai";
            this.checkBoxOwn.UseVisualStyleBackColor = true;
            this.checkBoxOwn.CheckedChanged += new System.EventHandler(this.ownCheckBox_CheckedChanged);
            // 
            // HelpRequestListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 591);
            this.Controls.Add(this.checkBoxOwn);
            this.Controls.Add(this.helpRequestsPanel);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboBoxCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "HelpRequestListForm";
            this.Text = "HelpRequestListForm";
            this.Load += new System.EventHandler(this.HelpRequestListForm_Load);
            this.helpRequestsPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel helpRequestsPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2HelpRequest;
        private System.Windows.Forms.Label label1HelpRequest;
        private System.Windows.Forms.TextBox textBoxHelpRequestDescription;
        private System.Windows.Forms.TextBox textBoxHelpRequestTitle;
        private System.Windows.Forms.CheckBox checkBoxOwn;
    }
}