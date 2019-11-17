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
    public partial class HelpRequestListForm : Form
    {
        List<HelpRequestListPanel> panels = new List<HelpRequestListPanel>();
        LocalUser localUser;
        List<HelpRequest> helpRequests;
        Dictionary<string, User> users;
        List<Category> categories;
        string lastSearch = null;

        public HelpRequestListForm(LocalUser localUser)
        {
            InitializeComponent();
            ClientSize = new Size(425, ClientSize.Height);
            this.localUser = localUser;
            this.comboBoxCategories.Enabled = false;
            comboBoxCategories.Items.Add("Kraunama...");
            comboBoxCategories.SelectedIndex = 0;
            textBoxSearch.Text = "Kraunama...";
            textBoxSearch.Enabled = false;
            this.Text = "Pagalbos prašymai";
        }

        private void HelpRequestListForm_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            //Gaunami Categories
            new CategoriesGetter(localUser,
                (status, categories) =>
                {
                    this.Invoke((MethodInvoker)delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if(status == CategoriesGetter.GetStatus.Success) // Pavyko
                        {
                            this.categories = categories;
                            comboBoxCategories.Items.Clear();
                            comboBoxCategories.Items.Add("Betkokia kategorija");
                            comboBoxCategories.SelectedIndex = 0;
                            categories.ForEach((category) =>
                            {
                                comboBoxCategories.Items.Add(category.Title);
                            });
                            comboBoxCategories.Enabled = true;
                        }
                        else // Ne
                        {
                            comboBoxCategories.Items.Clear();
                            comboBoxCategories.Items.Add("Nepavyko užkrauti");
                            comboBoxCategories.SelectedIndex = 0;
                        }
                    });
                }
                ).get();
            //Gaunami HelpRequest
            new HelpRequestGetter(localUser,
                (status, helpRequests, users) =>
                {
                    this.Invoke((MethodInvoker) delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if(status == HelpRequestGetter.GetStatus.Success) // Pavyko
                        {
                            this.helpRequests = helpRequests;
                            this.users = users;
                            filter();
                            textBoxSearch.Text = "";
                            textBoxSearch.Enabled = true;
                        }
                        else // Ne
                        {
                            textBoxSearch.Text = "Nepavyko užkrauti";
                            textBoxSearch.Enabled = false;
                        }
                    });
                }
                ).get(true);
        }

        void filter(string search = null, string category = null, bool own = false)
        {
            if(helpRequests == null || users == null) // Dar nėra informacijos
            {
                return;
            }

            panels.ForEach((panel) => { // Trinamos senos panel
                helpRequestsPanel.Controls.Remove(panel);
            });
            panels.Clear();

            if (search != null)
            {
                search = search.ToLower();
            }

            helpRequests.ForEach((helpRequest) =>
            {
                //Simple paieška su ignore case
                if ((String.IsNullOrEmpty(category) || category == helpRequest.Category) &&
                    (String.IsNullOrEmpty(search) || helpRequest.Title.ToLower().Contains(search) || helpRequest.Description.ToLower().Contains(search)) &&
                    (!own || helpRequest.CreatorUsername == localUser.Username))
                {
                    var panel = new HelpRequestListPanel(helpRequest, panels.Count); // Naujas panel
                    panel.Click += (o, e) => { //Sukuriamas onClickListener
                        var displayer = new HelpRequestDisplayerForm(localUser, helpRequest, users[helpRequest.CreatorUsername]);
                        displayer.OnDelete += (_helpRequest) =>
                        {
                            helpRequests.Remove(_helpRequest);
                            filterWithControls();
                        };
                        displayer.Show();
                    };
                    panels.Add(panel); //Pridedmas
                }

            });
            helpRequestsPanel.Controls.AddRange(panels.ToArray()); // Panels pridedami į rodomą srittį

            if (panels.Count * 106 > helpRequestsPanel.Size.Height) //Jeigu yra scroll bar keičiame dydį
            {
                helpRequestsPanel.Size = new Size(425 + SystemInformation.VerticalScrollBarWidth, helpRequestsPanel.ClientSize.Height + SystemInformation.HorizontalScrollBarHeight);
                //helpRequestsPanel.Size = new Size(425 + SystemInformation.VerticalScrollBarWidth, helpRequestsPanel.ClientSize.Height);
                ClientSize = new Size(425 + SystemInformation.VerticalScrollBarWidth, ClientSize.Height);
            }
            else
            {
                helpRequestsPanel.Size = new Size(425, helpRequestsPanel.ClientSize.Height);
                ClientSize = new Size(425, ClientSize.Height);
            }
            lastSearch = search;
        }
        private void filterWithControls()
        {
            if (comboBoxCategories.SelectedIndex == 0) // Pirmas yra betkoks
            {
                filter(search: lastSearch, own: checkBoxOwn.Checked);
            }
            else
            {
                filter(search: lastSearch, category: categories.ElementAt(comboBoxCategories.SelectedIndex - 1).Title, own: checkBoxOwn.Checked);
            }
        }
        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterWithControls();
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e) // Paspaudus enter filtruojama
        {
            if (e.KeyCode == Keys.Enter)
            {
                lastSearch = textBoxSearch.Text;
                filterWithControls();
            }
        }

        private void ownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filterWithControls();
        }
    }
}
