using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyApp.ViewModels;
using StudyBuddyApp.SystemManager;
using StudyBuddyApp.Utility;
using StudyBuddyShared.Network;
using StudyBuddyShared.HelpRequestSystem;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestViewPage : ContentPage
    {
        readonly HelpRequestViewPageModel ViewModel;
        public HelpRequestViewPage(HelpRequestViewPageModel helpRequestViewPageModel)
        {
            InitializeComponent();
            ViewModel = helpRequestViewPageModel;
            BindingContext = ViewModel;

            if(ViewModel.Creator.Username == LocalUserManager.LocalUser.Username)
            {
                deleteButton.IsEnabled = true;
            }
            else
            {
                deleteButton.IsEnabled = false;
            }
        }
        public void OnImageButtonClicked(object sender, EventArgs e)
        {

        }
        
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (await DisplayActionSheet("Do you really want to delete that?", "No", "Yes") == "Yes")
            {
               // HelpRequestSystemManager.NewHelpRequestRemover().Result +=
               //  async (status, helpRequest) =>
               // {
                        HelpRequestSystemManager.NewHelpRequestRemover().Remove(ViewModel.HelpRequestModel.HelpRequest);
                        DependencyService.Get<IToast>().LongToast("Deleted succesfully");
                        await Navigation.PopAsync();
               // };
            }
            return;
        }
    }
}
