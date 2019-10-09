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

        private void TextBoxGotFocus(object sender, EventArgs args)
        {
            HideCaret(chat.Handle);
            //ActiveControl = richTextBox3;
        }

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
            Color color2 = Color.Red;
            messageStyle("message\n", color, fBold);
            //messageStyle("message", color2, fBold);
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

        private void chat_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(chat.Handle);
        }
    }
}
