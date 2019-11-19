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
        Boolean isToggledSwitchButton { get; set; }
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = settingsViewModel;
        }
        void OnToggled(object sender, ToggledEventArgs e)
        {
            isToggledSwitchButton = e.Value;
            Application.Current.Properties["DarkMode"] = isToggledSwitchButton;
            Application.Current.SavePropertiesAsync();
        }
    }
}
