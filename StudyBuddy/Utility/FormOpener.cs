using System.Windows.Forms;

namespace StudyBuddy
{
    internal static class FormOpener
    {
        public static void OpenForm(Form form)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name.Equals(form.Name))
                {
                    f.BringToFront();
                    return;
                }
            }
            form.Show();
        }
    }
}