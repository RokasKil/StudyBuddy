using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using StudyBuddy.Entity;

namespace StudyBuddy
{
    class ConversationHistoryPanel : Panel
    {
        private int position;
        public int Position
        {
            get { return position; }
            set
            {
                position = value;
                this.Location = new Point(0, 85 * position);
                if(position % 2 == 0)
                {
                    this.BackColor = Color.White;
                }
                else
                {
                    this.BackColor = Color.LightGray;
                }
            }
        }
        public ConversationHistoryPanel(Conversation conversation, User user) : this(conversation, user, 0) { }

        public ConversationHistoryPanel(Conversation conversation, User user, int position)
        {
            //Dinamiškai užpildoma panel
            Size = new Size(370, 85);
            Margin = new Padding(0, 0, 0, 0);
            Position = position;

            Label username = new Label();
            username.Text = user.firstName + " " + user.lastName;
            username.Location = new Point(90, 3);
            username.Font = new Font(FontFamily.GenericSansSerif, 16);
            username.AutoSize = true;

            Label lastMessage = new Label();
            lastMessage.Text = conversation.lastMessage;
            lastMessage.Location = new Point(92, 28);
            lastMessage.Font = new Font(FontFamily.GenericSansSerif, 14);
            lastMessage.AutoSize = true;

            Label time = new Label();
            time.Text = DateTimeOffset.FromUnixTimeSeconds(conversation.lastActivity / 1000).LocalDateTime.ToString(" HH:mm:ss yyyy-MM-dd"); ; // Padaryt normaliai šitą dalį
            time.RightToLeft = RightToLeft.Yes;
            time.Font = new Font(FontFamily.GenericSansSerif, 12);
            time.AutoSize = false;
            time.Size = new Size(281, 22);
            time.Location = new Point(86, 58);


            PictureBox profilePicture = new PictureBox();
            profilePicture.Size = new Size(83, 83);
            profilePicture.Location = new Point(1, 1);
            profilePicture.ImageLocation = user.profilePictureLocation;
            profilePicture.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(profilePicture);
            Controls.Add(username);
            Controls.Add(lastMessage);
            Controls.Add(time);

            foreach(Control control in Controls) // Persiunčiami paspaudimai iš labels į panel
            {
                control.Click += (s, args) => OnClick(args);
            }
        }

    }
}
