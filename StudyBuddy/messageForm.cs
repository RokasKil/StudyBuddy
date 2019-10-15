using StudyBuddy.Entity;
using StudyBuddy.Network;
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

namespace StudyBuddy
{
    public partial class MessageForm : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        string username = null;
        Conversation conversation = null;
        Dictionary<string, User> users = null;
        LocalUser localUser = null;
        MessagePoster poster = null;
        Queue<string> messagesToSend = new Queue<string>();
        List<Entity.Message> messages = new List<Entity.Message>();
        long timestamp = 0;
        private void TextBoxGotFocus(object sender, EventArgs args)
        {
            HideCaret(chat.Handle);
            //ActiveControl = richTextBox3;
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
            messagesToSend.Enqueue(chatMessageText.Text);
            if (poster == null)
            {
                sendEnqueuedMessage();
            }
            chatMessageText.Text = "";
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            //Font fBold = new Font("Tahoma", 18, FontStyle.Bold);
            //Color color = Color.Blue;
            //Color color2 = Color.Red;
            //messageStyle("message\n", color, fBold);
            sendButton.Enabled = false;
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
                        if (status == ConversationStarter.ConversationStatus.Success) // Pavyko
                        {
                            this.conversation = conv;
                            this.users = users;
                            getMessages();
                        }
                        else // Ne
                        {
                            messageStyle("Nepavyko užkrauti", Color.Red);
                        }
                    });
                }).start(username);
            }
        }

        private void getMessages()
        {
            var user = users[conversation.users[0]];
            pictureBox1.ImageLocation = user.profilePictureLocation;
            name.Text = user.firstName + " " + user.lastName;
            sendButton.Enabled = true;
            new MessageGetter(localUser, getMessageResponseHandler).get(conversation, timestamp, false);
        }

        private void chatMessageText_KeyDown(object sender, KeyEventArgs e) // Paspaudus enter filtruojama
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.Handled = true;
                if (sendButton.Enabled)
                {
                    sendButton.PerformClick();
                    
                }
            }
        }

        private void getMessageResponseHandler(MessageGetter.MessageStatus status, List<Entity.Message> messages)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    Console.Write(status);
                    if (status == MessageGetter.MessageStatus.Success)
                    {
                        parseMessages(messages);
                        Task.Run(() =>
                        {
                            Task.Delay(100).Wait();
                            new MessageGetter(localUser, getMessageResponseHandler).get(conversation, timestamp, false);

                        });
                    }
                });
            }
            catch (InvalidOperationException e)
            {
                //form closed
            }
        }

        private void parseMessages(List<Entity.Message> messages)
        {
            messages.ForEach(message =>
            {

                User user;
                if ( message.username == localUser.username)
                {
                    user = localUser;
                }
                else
                {
                    user = users[message.username];
                }
                var date = DateTimeOffset.FromUnixTimeSeconds(message.timestamp / 1000).LocalDateTime;
                messageStyle("[" + date.ToShortTimeString() + "]" + user.firstName + " " + user.lastName + ": " + message.message + "\n", Color.Blue);
                timestamp = Math.Max(timestamp, message.timestamp);
            });

        }

        private void postMessageResponseHandler(MessagePoster.MessageStatus status, Conversation conversation, string message)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    Console.Write(status +  " " + message + "\n");
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
        private void messageStyle(string message, Color userColor, Font userFont)
        {
            // Font fBold = new Font("Tahoma", 8, FontStyle.Bold);
            int selectionStart = chat.SelectionStart;
            int selectionLength = chat.SelectionLength;

            chat.SelectionStart = chat.TextLength;
            chat.SelectionLength = 0;
            chat.SelectionFont = userFont;
            chat.SelectionColor = userColor;
            chat.SelectedText = message;

            chat.SelectionStart = selectionStart;
            chat.SelectionLength = selectionLength;
        }
        private void messageStyle(string message, Color userColor )
        {
            // Font fBold = new Font("Tahoma", 8, FontStyle.Bold);
            //chat.SelectionFont = userFont;
            int selectionStart = chat.SelectionStart;
            int selectionLength = chat.SelectionLength;

            chat.SelectionStart = chat.TextLength;
            chat.SelectionLength = 0;
            chat.SelectionColor = userColor;
            chat.SelectedText = message;

            chat.SelectionStart = selectionStart;
            chat.SelectionLength = selectionLength;
        }

        private void chat_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(chat.Handle);
        }
    }
}
