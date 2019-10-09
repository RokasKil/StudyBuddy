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
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void MessageForm_Load(object sender, EventArgs e)
        {
            Font fBold = new Font("Tahoma", 18, FontStyle.Bold);
            Color color = Color.Blue;
            messageStyle("message", color, fBold);
        }
        private void messageStyle(string message, Color userColor, Font userFont)
        {
           // Font fBold = new Font("Tahoma", 8, FontStyle.Bold);
            chat.SelectionFont = userFont;
            chat.SelectionColor = userColor;
            chat.SelectedText = message;
        }
        private void messageStyle(string message, Color userColor )
        {
            // Font fBold = new Font("Tahoma", 8, FontStyle.Bold);
            //chat.SelectionFont = userFont;
            chat.SelectionColor = userColor;
            chat.SelectedText = message;
        }
    }
}
