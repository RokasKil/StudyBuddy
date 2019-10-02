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
    public partial class TopicListForm : Form
    {
        public TopicListForm()
        {
            InitializeComponent();
        }

        private void TopicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count > 0)
                try { listView.Items.Remove(listView.SelectedItems[0]); }
                catch (System.ArgumentOutOfRangeException)
                {
                    return;
                }
        }   

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TopicTextBox.Text))
                return;
            ListViewItem item = new ListViewItem(TopicTextBox.Text);
            item.SubItems.Add(TopicTextBox.Text);
            listView.Items.Add(item);
            TopicTextBox.Clear();
            TopicTextBox.Focus();

        }
    }
}
