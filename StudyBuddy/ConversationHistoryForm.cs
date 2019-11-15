using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy
{
    public partial class ConversationHistoryForm : Form
    {
        List<ConversationHistoryPanel> panels = new List<ConversationHistoryPanel>();
        int widthWithScroll;
        int widthWithoutScroll;
        LocalUser localUser;
        Dictionary<string, User> users;
        List<Conversation> conversations;

        public ConversationHistoryForm(LocalUser localUser)
        {
            InitializeComponent();
            this.Text = "Pokalbiai";
            this.localUser = localUser;
        }
        bool loading = true;
        private void ConversationHistoryForm_Load(object sender, EventArgs e)
        {
            //Apskaičiuojam lango dydį su scroll bar ir be jo
            ClientSize = new Size(370 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 400);
            widthWithScroll = Size.Width;
            ClientSize = new Size(370, 400);
            widthWithoutScroll = Size.Width;
            statusLabelLoading.Text = "Kraunama...";
            new ConversationGetter(localUser,
                (status, conversations, users) =>
                {
                    this.Invoke((MethodInvoker)delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == ConversationGetter.GetStatus.Success) // Pavyko
                        {
                            statusLabelLoading.Hide();
                            this.conversations = conversations;
                            this.users = users;
                            this.conversations.ForEach((conversation) =>
                            {
                                var panel = new ConversationHistoryPanel(conversation, users[conversation.Users[0]], panels.Count());
                                MessageForm Form = null;
                                MessageForm.NewMessage handler = (message) =>
                                {
                                    if(message.Username == localUser.Username)
                                    {
                                        panel.LastMessage.Text = "Tu: " + message.Text;
                                    }
                                    else
                                    {
                                        panel.LastMessage.Text = message.Text;
                                    }
                                    /*panel.Time.Text = DateTimeOffset.FromUnixTimeSeconds(message.Timestamp / 1000).LocalDateTime.ToFullDate();
                                    if(panel.Position != 0)
                                    {
                                        panels.ForEach((panelEntry) =>
                                        {
                                            if(panel.Position > panelEntry.Position)
                                            {
                                                panelEntry.Position++;
                                            }
                                        });
                                        panel.Position = 0;
                                    }*/
                                };
                                panel.Click += (o, a) =>
                                {
                                    Form = new MessageForm(localUser, conversation, users);
                                    
                                    Form.NewMessageHandler += handler;
                                    Form.Show();

                                };
                                panel.HandleDestroyed += (a, b) =>
                                {
                                    if(Form != null)
                                    {
                                        Form.NewMessageHandler -= handler;
                                        Console.WriteLine("Handler removed");
                                    }
                                };
                                panels.Add(panel);
                            });
                            Controls.AddRange(panels.ToArray());
                        }
                        else // Ne
                        {
                            statusLabelLoading.Text = "Nepavyko užkrauti";
                        }
                    });
                }
                ).get(true);

            if (panels.Count * 85 > ClientSize.Height) // Tikrinama ar turi pradėti su scroll bar
            {
                ClientSize = new Size(370 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 400);
                MinimumSize = new Size(widthWithScroll, 200);
                MaximumSize = new Size(widthWithScroll, 2000);

            }
            else
            {
                MinimumSize = new Size(widthWithoutScroll, 200);
                MaximumSize = new Size(widthWithoutScroll, 2000);
            }
            loading = false;
        }

        private void ConversationHistoryForm_Resize(object sender, EventArgs e)
        {
            if (loading)
            {
                return;
            }

            if (panels.Count * 85 > ClientSize.Height) // Tikrinama ar turi atsirasti scroll bar
            {
                if(ClientSize.Width != 370)
                {
                    ClientSize = new Size(370 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, ClientSize.Height + (HorizontalScroll.Visible ? System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight : 0));
                    MinimumSize = new Size(widthWithScroll, 200);
                    MaximumSize = new Size(widthWithScroll, 2000);
                }
            }
            else
            {
                if (ClientSize.Width != 370)
                {
                    ClientSize = new Size(370, ClientSize.Height);
                    MinimumSize = new Size(widthWithoutScroll, 200);
                    MaximumSize = new Size(widthWithoutScroll, 2000);
                }
            }
        }
    }
}
