namespace StudyBuddy
{
    partial class MessageForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelChatUsername = new System.Windows.Forms.Label();
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.richTextBoxChatMessageText = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.labelChatUsername);
            this.panel1.Controls.Add(this.pictureBoxProfilePicture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 69);
            this.panel1.TabIndex = 2;
            // 
            // labelChatUsername
            // 
            this.labelChatUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelChatUsername.Location = new System.Drawing.Point(76, 0);
            this.labelChatUsername.Name = "labelChatUsername";
            this.labelChatUsername.Size = new System.Drawing.Size(433, 66);
            this.labelChatUsername.TabIndex = 2;
            this.labelChatUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxProfilePicture.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.Size = new System.Drawing.Size(75, 69);
            this.pictureBoxProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProfilePicture.TabIndex = 0;
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSendMessage);
            this.panel2.Controls.Add(this.richTextBoxChatMessageText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 449);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 42);
            this.panel2.TabIndex = 3;
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSendMessage.Location = new System.Drawing.Point(476, 0);
            this.buttonSendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(97, 42);
            this.buttonSendMessage.TabIndex = 4;
            this.buttonSendMessage.Text = "Siųsti";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // richTextBoxChatMessageText
            // 
            this.richTextBoxChatMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxChatMessageText.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxChatMessageText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxChatMessageText.MaxLength = 1000;
            this.richTextBoxChatMessageText.Name = "richTextBoxChatMessageText";
            this.richTextBoxChatMessageText.Size = new System.Drawing.Size(469, 41);
            this.richTextBoxChatMessageText.TabIndex = 4;
            this.richTextBoxChatMessageText.Text = "";
            this.richTextBoxChatMessageText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatMessageText_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.richTextBoxChat);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 69);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 380);
            this.panel3.TabIndex = 4;
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.BackColor = System.Drawing.Color.MintCream;
            this.richTextBoxChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxChat.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(573, 380);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            this.richTextBoxChat.Enter += new System.EventHandler(this.TextBoxGotFocus);
            this.richTextBoxChat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chat_MouseDown);
            this.richTextBoxChat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chat_MouseDown);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 491);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MessageForm";
            this.Text = "Pokalbis";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelChatUsername;
        private System.Windows.Forms.PictureBox pictureBoxProfilePicture;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.RichTextBox richTextBoxChatMessageText;
    }
}