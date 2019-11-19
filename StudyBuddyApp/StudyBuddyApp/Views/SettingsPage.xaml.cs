using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyApp.ViewModels;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        readonly SettingsViewModel settingsViewModel = new SettingsViewModel();
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = settingsViewModel;
            if (Application.Current.Properties.ContainsKey("DarkMode"))
            {
                DarkModeSwitch.IsToggled = (bool)Application.Current.Properties["DarkMode"];
            }
            else
            {
                DarkModeSwitch.IsToggled = false;
            }
        }
        void OnToggled(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties["DarkMode"] = e.Value;
            Application.Current.SavePropertiesAsync();
        }
    }
}
