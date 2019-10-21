using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using StudyBuddy.Entity;
using StudyBuddy.Network;

namespace StudyBuddy
{
    public partial class PostForHelpForm : Form
    {
        LocalUser localUser;
        List<Category> categories;
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public PostForHelpForm(LocalUser localUser)
        {
            InitializeComponent();
            labelStatus.Visible = false;
            this.localUser = localUser;
            buttonConfirmHelpRequest.Enabled = false;
        }

        private void PostForHelp_Load(object sender, EventArgs e)
        {
            SendMessage(textBoxPostForHelpTitle.Handle, EM_SETCUEBANNER, 0, "Pavadinimas");
            new CategoriesGetter(localUser,
                (status, categories) =>
                {
                    this.Invoke((MethodInvoker)delegate //Grįžtama į main Thread !! SVARBU
                    {
                        if (status == CategoriesGetter.GetStatus.Success) //Pavyko
                        {
                            this.categories = categories;
                            comboBoxCategories.Items.Clear();
                            categories.ForEach((category) =>
                            {
                                comboBoxCategories.Items.Add(category.Title);

                            });
                        }
                        else //Ne
                        {
                            comboBoxCategories.Items.Clear();
                            labelStatus.Visible = true;
                        }
                    });
                }
                ).get();
        }

        private void buttonConfirmHelpRequest_Click(object sender, EventArgs e)
        {
            var helpRequestManager = new HelpRequestManager(localUser);
            helpRequestManager.PostHelpRequestResult += (status, helprequest) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (status == HelpRequestManager.ManagerStatus.Success)
                    {
                        Console.WriteLine("Success");
                        labelStatus.Text = "Pavyko!";
                        labelStatus.Visible = true;
                    }
                    else
                    {
                        Console.WriteLine("Epic fail");
                    }
                });
            };

            helpRequestManager.postHelpRequest(new HelpRequest
            {
                Title = textBoxPostForHelpTitle.Text,
                Description = textBoxPostForHelpDescription.Text,
                CreatorUsername = localUser.username,
                Category = comboBoxCategories.SelectedItem.ToString()
            });
        }

        private void textBoxPostForHelpTitle_TextChanged(object sender, EventArgs e)
        {
            buttonConfirmHelpRequest.Enabled = (
                (textBoxPostForHelpTitle.TextLength > 0) && (textBoxPostForHelpDescription.TextLength > 0));
               
        }

        private void textBoxPostForHelpDescription_TextChanged(object sender, EventArgs e)
        {
            buttonConfirmHelpRequest.Enabled = (
                (textBoxPostForHelpTitle.TextLength > 0) && (textBoxPostForHelpDescription.TextLength > 0));
        }
    }
}
