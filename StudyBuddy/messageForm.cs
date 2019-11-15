using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = StudyBuddyShared.Entity.Message;

namespace StudyBuddy
{
    public partial class MessageForm : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public delegate void NewMessage(Message message);
        public NewMessage NewMessageHandler { get; set; }
        string username = null;
        Conversation conversation = null;
        Dictionary<string, User> users = null;
        LocalUser localUser = null;
        MessagePoster poster = null;
        Queue<string> messagesToSend = new Queue<string>();
        List<Message> messages = new List<Message>();
        long timestamp = 0;
        readonly Font mainFont = new Font(FontFamily.GenericSansSerif, 10);
        readonly Font mainFontBold = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

        private void TextBoxGotFocus(object sender, EventArgs args)
        {
            HideCaret(richTextBoxChat.Handle);
        }
        
        public MessageForm(LocalUser localUser, string username) : this()
        {
            this.localUser = localUser;
            this.username = username;
        }

        public MessageForm(LocalUser localUser, Conversation conversation, Dictionary<string, User> users) : this()
        {
            this.localUser = localUser;
            this.conversation = conversation;
            this.users = users;
        }

        private MessageForm()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            messagesToSend.Enqueue(richTextBoxChatMessageText.Text);
            if (poster == null)
            {
                sendEnqueuedMessage();
            }
            richTextBoxChatMessageText.Text = "";
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            //Font fBold = new Font("Tahoma", 18, FontStyle.Bold);
            //Color color = Color.Blue;
            //Color color2 = Color.Red;
            //messageStyle("message\n", color, fBold);
            richTextBoxChat.MouseDown += chat_MouseDown;
            buttonSendMessage.Enabled = false;
            if(conversation != null)
            {
                getMessages();
            }
            else
            {
                new ConversationStarter(localUser, (status, conv, users) =>
                {
                    this.Invoke((MethodInvoker)delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == ConversationStarter.ConversationStatus.Success) //Pavyko
                        {
                            this.conversation = conv;
                            this.users = users;
                            getMessages();
                        }
                        else //Ne
                        {
                            messageStyle("Nepavyko užkrauti", Color.Red);
                        }
                    });
                }).start(username);
            }
        }

        private void getMessages()
        {
            var user = users[conversation.Users[0]];
            pictureBoxProfilePicture.ImageLocation = user.ProfilePictureLocation;
            labelChatUsername.Text = user.FirstName + " " + user.LastName;
            this.Text += " - " + user.FirstName + " " + user.LastName;
            buttonSendMessage.Enabled = true;
            new MessageGetter(localUser, getMessageResponseHandler).get(conversation, timestamp, false);
        }

        private void chatMessageText_KeyDown(object sender, KeyEventArgs e) // Paspaudus enter filtruojama
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.Handled = true;
                if (buttonSendMessage.Enabled)
                {
                    buttonSendMessage.PerformClick();
                }
            }
        }

        private void getMessageResponseHandler(MessageGetter.MessageStatus status, List<Message> messages)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    //Console.Write(status);
                    if (status == MessageGetter.MessageStatus.Success)
                    {
                        parseMessages(messages);
                        Task.Run(() =>
                        {
                            Task.Delay(100).Wait();
                            new MessageGetter(localUser, getMessageResponseHandler).get(conversation, timestamp, true);

                        });
                    }
                });
            }
            catch (InvalidOperationException e)
            {
                //form closed
            }
        }

        private void parseMessages(List<Message> messages)
        {
            messages.ForEach(message =>
            {
                User user;
                Color color;
                if ( message.Username == localUser.Username)
                {
                    user = localUser;
                    color = Color.Black;
                }
                else
                {
                    user = users[message.Username];
                    color = Color.FromArgb(0xFF, 0x00, 0x66, 0x99);
                }
                var date = DateTimeOffset.FromUnixTimeSeconds(message.Timestamp / 1000).LocalDateTime;
                messageStyle("[" + date.ToShortTimeString() + "] " + user.FirstName + " " + user.LastName + ": ", color, mainFontBold);
                messageStyle(message.Text + "\n", color);
                timestamp = Math.Max(timestamp, message.Timestamp);
                NewMessageHandler?.Invoke(message);
            });
            //Console.WriteLine(chat.GetPositionFromCharIndex(chat.TextLength - 1));
            if (messages.Count != 0)
                scrollToEnd();
        }

        private void scrollToEnd()
        {
            int selectionStart = richTextBoxChat.SelectionStart;
            int selectionLength = richTextBoxChat.SelectionLength;
            richTextBoxChat.SelectionStart = richTextBoxChat.TextLength;
            richTextBoxChat.SelectionLength = 0;
            richTextBoxChat.ScrollToCaret();
            richTextBoxChat.SelectionStart = selectionStart;
            richTextBoxChat.SelectionLength = selectionLength;
        }

        private void postMessageResponseHandler(MessagePoster.MessageStatus status, Conversation conversation, string message)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    //Console.Write(status +  " " + message + "\n");
                    if (status == MessagePoster.MessageStatus.Success || status == MessagePoster.MessageStatus.ConversationNotFound || status == MessagePoster.MessageStatus.MessageEmpty)
                    {
                        messagesToSend.Dequeue();
                    }
                    if (messagesToSend.Count > 0)
                    {
                        sendEnqueuedMessage();
                    }
                    else
                    {
                        poster = null;
                    }
                });
            }
            catch (InvalidOperationException e)
            {
                //form closed
            }
        }

        void sendEnqueuedMessage()
        {
            String test = messagesToSend.First();
            poster = new MessagePoster(localUser, new MessagePoster.MessagePostDelegate(postMessageResponseHandler));
            poster.post(conversation, messagesToSend.First());
        }

        private void messageStyle(string message, Color userColor, Font userFont = null)
        {
            // Font fBold = new Font("Tahoma", 8, FontStyle.Bold);
            int selectionStart = richTextBoxChat.SelectionStart;
            int selectionLength = richTextBoxChat.SelectionLength;

            richTextBoxChat.SelectionStart = richTextBoxChat.TextLength;
            richTextBoxChat.SelectionLength = 0;
            if (userFont == null)
            {
                richTextBoxChat.SelectionFont = mainFont;
            }
            else
            {
                richTextBoxChat.SelectionFont = userFont;
            }

            richTextBoxChat.SelectionColor = userColor;
            richTextBoxChat.SelectedText = message;
            richTextBoxChat.SelectionStart = selectionStart;
            richTextBoxChat.SelectionLength = selectionLength;
        }
        private void chat_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(richTextBoxChat.Handle);
        }
    }
}
