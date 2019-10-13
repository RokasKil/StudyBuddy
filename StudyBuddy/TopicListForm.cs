using StudyBuddy.Entity;
using StudyBuddy.Network;
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
        List<Category> categories;
        LocalUser localUser;
        private ListViewColumnSorter listViewColumnSorter;
        public TopicListForm(LocalUser localUser)
        {
            InitializeComponent();
            this.localUser = localUser; 
            this.Text = "Kurti naują temą";
            this.AcceptButton = buttonAddTopic;
            listViewColumnSorter = new ListViewColumnSorter();
            this.listView.ListViewItemSorter = listViewColumnSorter;
            ResizeColumnWidth();
            buttonEditTopic.Enabled = false;
            buttonRemoveTopic.Enabled = false;
        }

        private void buttonRemoveTopic_click(object sender, EventArgs e)
        {
            if (listView.Items.Count > 0)
            {
                var confirmResult = MessageBox.Show(
                                 listView.SelectedItems[0].Text,
                                "Ištrinti šią temą?",
                                 MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    listView.SelectedItems[0].Remove();
                }
            }
            else return;
        }
        private void buttonAddTopic_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTopic.Text))
                return;
            string timestamp = DateTime.Now.ToString("yyyy-mm-dd HH:mm");
            listView.Items.Add(
                new ListViewItem(
                    new[] { textBoxTopic.Text, timestamp, timestamp }));
            textBoxTopic.Clear();
            textBoxTopic.Focus();
            ResizeColumnWidth();
        }

        private void TopicListForm_Load(object sender, EventArgs e)
        {
            new CategoriesGetter(localUser,
                (status, categories) =>
                {
                    this.Invoke((MethodInvoker)delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == CategoriesGetter.GetStatus.Success) //Pavyko
                        {
                            this.categories = categories;
                            listView.Items.Clear();
                            categories.ForEach((category) =>
                            {
                                listView.Items.Add(
                                    new ListViewItem(
                                        new[] { category.title, category.createdDate, category.lastUpdatedDate }));

                            });
                            listView.Enabled = true;
                            labelStatus.Visible = false;
                        }
                        else //Ne
                        {
                            listView.Items.Clear();
                            labelStatus.Visible = true;
                        }
                    });
                }
                ).get();
            ResizeColumnWidth();
        }

        //Kad useris negalėtų resizint stulpelių
        private void listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView.Columns[e.ColumnIndex].Width;
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                buttonRemoveTopic.Enabled = true;
                buttonEditTopic.Enabled = true;
            }
            else
            {
                buttonRemoveTopic.Enabled = false;
                buttonEditTopic.Enabled = false;
            }
        }

        private void buttonEditTopic_Click(object sender, EventArgs e)
        {
            foreach(Category category in categories)
            {
                if (category.title.Equals(listView.SelectedItems[0].Text))
                {
                    FormOpener.OpenForm(new TopicDescriptionForm(listView.SelectedItems[0].Text, category.description));
                    break;
                }
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == listViewColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (listViewColumnSorter.Order == SortOrder.Ascending)
                {
                    listViewColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    listViewColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                listViewColumnSorter.SortColumn = e.Column;
                listViewColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();
        }

        private void ResizeColumnWidth()
        {
            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = -2;
            }
        }
    }
}
