using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy
{
    class HelpRequestListPanel : Panel
    {
        private int position;
        public int Position
        {
            get { return position; }
            set
            {
                position = value;
                this.Location = new Point(0, 106 * position);
                if (position % 2 == 0)
                {
                    this.BackColor = Color.White;
                }
                else
                {
                    this.BackColor = Color.LightGray;
                }
            }
        }
        public HelpRequestListPanel(HelpRequest helpRequest) : this(helpRequest, 0) { }

        public HelpRequestListPanel(HelpRequest helpRequest, int position)
        {
            //Dinamiškai užpildoma panel
            Size = new Size(425, 106);
            Margin = new Padding(0, 0, 0, 0);
            Position = position;

            TextBox title = new TextBox();
            title.Location = new Point(4, 4);
            title.Font = new Font(FontFamily.GenericSansSerif, 14);
            title.AutoSize = false;
            title.BorderStyle = BorderStyle.None;
            title.ReadOnly = true;
            title.Size = new Size(416, 28);
            title.Text = helpRequest.Title;
            title.BackColor = this.BackColor;


            TextBox description = new TextBox();
            description.Location = new Point(4, 32);
            description.Font = new Font(FontFamily.GenericSansSerif, 12);
            description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            description.Enabled = false;
            description.Multiline = true;
            description.ReadOnly = true;
            description.Size = new Size(416, 40);
            description.Text = helpRequest.Description;
            description.BackColor = this.BackColor;

            Label category = new Label();
            category.AutoSize = true;
            category.Location = new Point(3, 75);
            category.Size = new Size(35, 13);
            category.Text = helpRequest.Category;

            Label time = new Label();
            time.Text = helpRequest.timestamp.ToString(" HH:mm:ss yyyy-MM-dd"); // Padaryt normaliai šitą dalį
            time.RightToLeft = RightToLeft.Yes;
            time.AutoSize = false;
            time.Size = new Size(416, 15);
            time.Location = new Point(6, 88);

            Controls.Add(title);
            Controls.Add(description);
            Controls.Add(category);
            Controls.Add(time);

            foreach (Control control in Controls) // Persiunčiami paspaudimai iš labels į panel
            {
                control.Click += (s, args) => OnClick(args);
            }
        }

    }
}
