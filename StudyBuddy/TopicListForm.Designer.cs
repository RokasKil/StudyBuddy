namespace StudyBuddy
{
    partial class TopicListForm
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
            this.listView = new System.Windows.Forms.ListView();
            this.Topic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Creation_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddTopic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTopic = new System.Windows.Forms.TextBox();
            this.buttonRemoveTopic = new System.Windows.Forms.Button();
            this.buttonOpenTopicDescription = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Topic,
            this.Creation_date,
            this.LastUpdated});
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.LabelEdit = true;
            this.listView.Location = new System.Drawing.Point(11, 67);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(759, 376);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_ColumnWidthChanging);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // Topic
            // 
            this.Topic.Text = "Tema";
            this.Topic.Width = 227;
            // 
            // Creation_date
            // 
            this.Creation_date.Text = "Sukūrimo data";
            this.Creation_date.Width = 235;
            // 
            // LastUpdated
            // 
            this.LastUpdated.Text = "Atnaujinta";
            this.LastUpdated.Width = 398;
            // 
            // buttonAddTopic
            // 
            this.buttonAddTopic.Location = new System.Drawing.Point(11, 35);
            this.buttonAddTopic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddTopic.Name = "buttonAddTopic";
            this.buttonAddTopic.Size = new System.Drawing.Size(100, 27);
            this.buttonAddTopic.TabIndex = 1;
            this.buttonAddTopic.Text = "Pridėti";
            this.buttonAddTopic.UseVisualStyleBackColor = true;
            this.buttonAddTopic.Click += new System.EventHandler(this.buttonAddTopic_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tema:";
            // 
            // textBoxTopic
            // 
            this.textBoxTopic.Location = new System.Drawing.Point(59, 9);
            this.textBoxTopic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTopic.Name = "textBoxTopic";
            this.textBoxTopic.Size = new System.Drawing.Size(157, 22);
            this.textBoxTopic.TabIndex = 3;
            // 
            // buttonRemoveTopic
            // 
            this.buttonRemoveTopic.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.buttonRemoveTopic.Location = new System.Drawing.Point(116, 35);
            this.buttonRemoveTopic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveTopic.Name = "buttonRemoveTopic";
            this.buttonRemoveTopic.Size = new System.Drawing.Size(100, 27);
            this.buttonRemoveTopic.TabIndex = 4;
            this.buttonRemoveTopic.Text = "Ištrinti";
            this.buttonRemoveTopic.UseVisualStyleBackColor = true;
            this.buttonRemoveTopic.Click += new System.EventHandler(this.buttonRemoveTopic_click);
            // 
            // buttonOpenTopicDescription
            // 
            this.buttonOpenTopicDescription.Location = new System.Drawing.Point(553, 447);
            this.buttonOpenTopicDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOpenTopicDescription.Name = "buttonOpenTopicDescription";
            this.buttonOpenTopicDescription.Size = new System.Drawing.Size(217, 36);
            this.buttonOpenTopicDescription.TabIndex = 5;
            this.buttonOpenTopicDescription.Text = "Atidaryti temos aprašą";
            this.buttonOpenTopicDescription.UseVisualStyleBackColor = true;
            this.buttonOpenTopicDescription.Click += new System.EventHandler(this.buttonOpenTopicDescription_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(6, 455);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(190, 25);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Nepavyko užkrauti";
            // 
            // TopicListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 489);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonOpenTopicDescription);
            this.Controls.Add(this.buttonRemoveTopic);
            this.Controls.Add(this.textBoxTopic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddTopic);
            this.Controls.Add(this.listView);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TopicListForm";
            this.Text = "TopicList";
            this.Load += new System.EventHandler(this.TopicListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Topic;
        private System.Windows.Forms.ColumnHeader Creation_date;
        private System.Windows.Forms.Button buttonAddTopic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTopic;
        private System.Windows.Forms.ColumnHeader LastUpdated;
        private System.Windows.Forms.Button buttonRemoveTopic;
        private System.Windows.Forms.Button buttonOpenTopicDescription;
        private System.Windows.Forms.Label labelStatus;
    }
}