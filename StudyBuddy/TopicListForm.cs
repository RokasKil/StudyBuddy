using StudyBuddyShared.Entity;
using StudyBuddyShared.Network;
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
            this.listViewTopics.ListViewItemSorter = listViewColumnSorter;
            ResizeColumnWidth();
            buttonOpenTopicDescription.Enabled = false;
            buttonRemoveTopic.Enabled = false;
        }

        private void buttonRemoveTopic_click(object sender, EventArgs e)
        {
            if (listViewTopics.Items.Count > 0)
            {
                var confirmResult = MessageBox.Show(
                                 listViewTopics.SelectedItems[0].Text,
                                "Ištrinti šią temą?",
                                 MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    RemoveTopic(listViewTopics.SelectedItems[0].Text);
                }
            }
            else return;
        }
        private void buttonAddTopic_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTopic.Text))
                return;
            FormOpener.OpenForm(new TopicDescriptionForm(localUser, listViewTopics, categories, new Category()
            {
                Title = textBoxTopic.Text,
                CreatorUsername = localUser.Username
            }));
            textBoxTopic.Clear();
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
                            listViewTopics.Items.Clear();
                            categories.ForEach((category) =>
                            {
                                listViewTopics.Items.Add(
                                    new ListViewItem(
                                        new[] { category.Title, category.CreatedDate, category.LastUpdatedDate }));
                                ResizeColumnWidth();

                            });
                            listViewTopics.Enabled = true;
                            labelStatus.Visible = false;
                        }
                        else //Ne
                        {
                            listViewTopics.Items.Clear();
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
            e.NewWidth = listViewTopics.Columns[e.ColumnIndex].Width;
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTopics.SelectedItems.Count > 0)
            {
                buttonRemoveTopic.Enabled = true;
                buttonOpenTopicDescription.Enabled = true;
            }
            else
            {
                buttonRemoveTopic.Enabled = false;
                buttonOpenTopicDescription.Enabled = false;
            }
        }

        private void buttonOpenTopicDescription_Click(object sender, EventArgs e)
        {
            foreach (Category category in categories)
            {
                if (category.Title.Equals(listViewTopics.SelectedItems[0].Text))
                {
                    FormOpener.OpenForm(new TopicDescriptionForm(localUser, listViewTopics, categories, category));
                    break;
                }
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Nustatyti ar paclickintas stulpelis jau yra rikiuojamas
            if (e.Column == listViewColumnSorter.SortColumn)
            {
                //Pakeisti dabartinę stulpelio rikiavimo tvarką
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
                //Nustatyti stulpelio, kuris bus rikiuojamas numerį. Pagal nutylėjimą rikiuojama didėjančia tvarka
                listViewColumnSorter.SortColumn = e.Column;
                listViewColumnSorter.Order = SortOrder.Ascending;
            }
            //Atlikti rikiavimą su naujais rikiavimo nustatymais
            this.listViewTopics.Sort();
        }

        private void ResizeColumnWidth()
        {
            foreach (ColumnHeader column in listViewTopics.Columns)
            {
                column.Width = -2;
            }
        }

        private void RemoveTopic(string title)
        {
            listViewTopics.SelectedItems[0].Remove();
            var categoryManager = new CategoryManager(localUser);
            categoryManager.RemoveCategoryResult += (status, category) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (status == CategoryManager.ManagerStatus.Success)
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Epic fail");
                    }
                });
            };
            foreach(Category category in categories)
            {
                if(category.Title.Equals(title))
                {
                    categoryManager.removeCategory(category);
                    categories.Remove(category);
                    return;
                }
            }
        }
    }
}
