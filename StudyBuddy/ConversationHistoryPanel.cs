using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using StudyBuddyShared.Entity;

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

        public Label LastMessage { get; set; }
        public Label Username { get; set; }
        public Label Time { get; set; }
        public PictureBox ProfilePicture { get; set; }
        public ConversationHistoryPanel(Conversation conversation, User user) : this(conversation, user, 0) { }

        public ConversationHistoryPanel(Conversation conversation, User user, int position)
        {
            //Dinamiškai užpildoma panel
            Size = new Size(370, 85);
            Margin = new Padding(0, 0, 0, 0);
            Position = position;

            Username = new Label();
            Username.Text = user.FirstName + " " + user.LastName;
            Username.Location = new Point(90, 3);
            Username.Font = new Font(FontFamily.GenericSansSerif, 16);
            Username.AutoSize = true;

            LastMessage = new Label();
            LastMessage.Text = conversation.LastMessage;
            LastMessage.Location = new Point(92, 28);
            LastMessage.Font = new Font(FontFamily.GenericSansSerif, 14);
            LastMessage.AutoSize = false;
            LastMessage.Size = new Size(400, 25);

            Time = new Label();
            Time.Text = DateTimeOffset.FromUnixTimeSeconds(conversation.LastActivity / 1000).LocalDateTime.ToFullDate(); // Padaryt normaliai šitą dalį
            Time.TextAlign = ContentAlignment.MiddleRight;
            Time.Font = new Font(FontFamily.GenericSansSerif, 12);
            Time.AutoSize = false;
            Time.Size = new Size(281, 22);
            Time.Location = new Point(86, 58);


            ProfilePicture = new PictureBox();
            ProfilePicture.Size = new Size(83, 83);
            ProfilePicture.Location = new Point(1, 1);
            ProfilePicture.ImageLocation = user.ProfilePictureLocation;
            ProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(ProfilePicture);
            Controls.Add(Username);
            Controls.Add(Time);
            Controls.Add(LastMessage);

            foreach (Control control in Controls) // Persiunčiami paspaudimai iš labels į panel
            {
                control.Click += (s, args) => OnClick(args);
            }
        }

    }
}
