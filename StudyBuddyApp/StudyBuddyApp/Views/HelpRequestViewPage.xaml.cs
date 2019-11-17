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
        }
        public void OnImageButtonClicked(object sender, EventArgs e)
        {

        }
        
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            HelpRequestSystemManager.NewHelpRequestRemover().Remove(ViewModel.HelpRequestModel.HelpRequest);
            DependencyService.Get<IToast>().LongToast("Deleted succesfully");
            await Navigation.PopAsync();
        }
    }
}