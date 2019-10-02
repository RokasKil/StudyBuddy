using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
namespace StudyBuddy
{
    public partial class MessageForm : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        public MessageForm()
        {
            InitializeComponent();

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            ipTextBox1.Text = GetLocalIP();
            ipTextBox2.Text = GetLocalIP();

        }

        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            
            foreach(IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(ipTextBox1.Text),Convert.ToInt32(portTextBox1.Text) );
                sck.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(ipTextBox2.Text), Convert.ToInt32(portTextBox2.Text));
                sck.Connect(epRemote);

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

                startButton.Text = "Connected";
                startButton.Enabled = false;

                sendButton.Enabled = true;
                writeMessagetextBox.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                byte[] message = new byte[1500];
                message = enc.GetBytes(writeMessagetextBox.Text);

                sck.Send(message);
                messageListBox.Items.Add("You " + writeMessagetextBox.Text);
                writeMessagetextBox.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);

                if(size > 0)
                {
                    byte[] receivedData = new byte[1464];
                    receivedData = (byte[])aResult.AsyncState;

                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(receivedData);
                    // Iš kitų thread NEGALIMA liesti controls
                    // Reikia naudoti Invoke metodą
                    messageListBox.Invoke((MethodInvoker) delegate { messageListBox.Items.Add("Other: " + receivedMessage); }); 

                }

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
