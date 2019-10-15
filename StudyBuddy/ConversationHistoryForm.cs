using StudyBuddy.Entity;
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

        public ConversationHistoryForm()
        {
            InitializeComponent();
            this.Text = "Pokalbiai";
        }
        bool loading = true;
        private void ConversationHistoryForm_Load(object sender, EventArgs e)
        {
            //Apskaičiuojam lango dydį su scroll bar ir be jo
            ClientSize = new Size(370 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 400);
            widthWithScroll = Size.Width;
            ClientSize = new Size(370, 400);
            widthWithoutScroll = Size.Width;
            //Place holder panels
            /*panels.Add(new ConversationHistoryPanel(new Conversation() { user = new User() { firstName = "Jonas", lastName = "Jonauskas", profilePictureLocation = "https://ichef.bbci.co.uk/news/660/cpsprodpb/EF37/production/_108993216_ok-hand.jpg" }, timestamp = DateTime.Now.AddMinutes(-5), lastMessage = "Hello World(0)!" }, 0));
            panels.Add(new ConversationHistoryPanel(new Conversation() { user = new User() { firstName = "Jonas1", lastName = "Jonauskas1" }, timestamp = DateTime.Now.AddMinutes(-25), lastMessage = "Hello World(1)!" }, 1));
            panels.Add(new ConversationHistoryPanel(new Conversation() { user = new User() { firstName = "Jonas2", lastName = "Jonauskas2" }, timestamp = DateTime.Now.AddMinutes(-55), lastMessage = "Hello World(2)!" }, 2));
            panels.Add(new ConversationHistoryPanel(new Conversation() { user = new User() { firstName = "Jonas3", lastName = "Jonauskas3" }, timestamp = DateTime.Now.AddMinutes(-56), lastMessage = "Hello World(3)!" }, 3));
            panels.Add(new ConversationHistoryPanel(new Conversation() { user = new User() { firstName = "Jonas4", lastName = "Jonauskas4" }, timestamp = DateTime.Now.AddMinutes(-57), lastMessage = "Hello World(4)!" }, 4));
            panels.Add(new ConversationHistoryPanel(new Conversation() { user = new User() { firstName = "Jonas5", lastName = "Jonauskas5" }, timestamp = DateTime.Now.AddMinutes(-59), lastMessage = "Hello World(5)!" }, 5));
            panels.Add(new ConversationHistoryPanel(new Conversation() { user = new User() { firstName = "Jonas6", lastName = "Jonauskas6" }, timestamp = DateTime.Now.AddMinutes(-65), lastMessage = "Hello World(6)!" }, 6));*/
            Controls.AddRange(panels.ToArray());

            if(panels.Count * 85 > ClientSize.Height) // Tikrinama ar turi pradėti su scroll bar
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
