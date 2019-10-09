using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // un comment if you want to try messaging
            //Application.Run(new messageForm());
            Application.Run(new HelpRequestDisplayerForm(new Entity.HelpRequest(), new Entity.User()));
            Application.Run(new LoginForm());
        }
    }
}
