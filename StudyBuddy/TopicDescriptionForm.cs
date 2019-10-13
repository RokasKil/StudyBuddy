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
    public partial class TopicDescriptionForm : Form
    {
        public TopicDescriptionForm(string topic, string topicDescription)
        {
            InitializeComponent();
            labelTopicDescription.Text = topic;
            this.Text = "Temos aprašas";
            textBoxTopicDescription.Text = topicDescription;
        }

        private void buttonEditTopicDescription_Click(object sender, EventArgs e)
        {
            //Tuo pačiu atnaujinti duomenis duombazėje?
            //TODO
        }
    }
}
