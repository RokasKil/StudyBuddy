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
    public partial class TopicDescriptionForm : Form
    {
        Category category;
        List<Category> categories;
        ListView listView;
        LocalUser localUser;
        public TopicDescriptionForm(LocalUser localUser, ListView listView, List<Category> categories, Category category)
        {
            InitializeComponent();
            this.localUser = localUser;
            this.listView = listView;
            this.category = category;
            this.categories = categories;
            labelTopicDescription.Text = category.Title;
            this.Text = "Temos aprašas";
            textBoxTopicDescription.Text = category.Description;
            labelUpdated.Visible = false;
        }
        private void buttonEditTopicDescription_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToLongDateString();
            foreach (Category category in categories)
            {
                if ((this.category.Title.Equals(category.Title)))//&&this.category.CreatorUsername.Equals(category.CreatorUsername)) nežinau ar reikia
                {
                    category.Description = textBoxTopicDescription.Text;
                    category.LastUpdatedDate = timestamp;
                    labelUpdated.Visible = true;
                    UpdateListViewEdit();
                    UpdateTopic();
                    return;
                }
            }
            category.CreatedDate = timestamp;
            category.LastUpdatedDate = timestamp;
            category.Description = textBoxTopicDescription.Text;
            categories.Add(category);
            labelUpdated.Visible = true;
            UpdateListViewAdd();
            AddTopic();
            return;
        }
        private void UpdateListViewAdd()
        {
            string timestamp = DateTime.Now.ToFullDate();
            listView.Items.Add(
                new ListViewItem(
                    new[] { category.Title, timestamp, timestamp }));
        }
        private void UpdateListViewEdit()
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text.Equals(category.Title))
                {
                    item.SubItems[2].Text = category.LastUpdatedDate;
                }
            }
        }
        private void AddTopic()
        {
            var categoryManager = new CategoryManager(localUser);
            categoryManager.AddCategoryResult += (status, category) =>
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
            categoryManager.addCategory(category);
        }

        private void UpdateTopic()
        {
            var categoryManager = new CategoryManager(localUser);
            categoryManager.UpdateCategoryResult += (status, category) =>
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
            categoryManager.updateCategory(category);
        }
    }
}
