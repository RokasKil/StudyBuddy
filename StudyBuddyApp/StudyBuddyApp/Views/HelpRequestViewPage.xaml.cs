using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StudyBuddyApp.ViewModels;
using StudyBuddyShared.SystemManager;
using StudyBuddyApp.Utility;
using StudyBuddyShared.HelpRequestSystem;

namespace StudyBuddyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestViewPage : ContentPage
    {
        readonly HelpRequestViewPageModel viewModel;
        public HelpRequestViewPage(HelpRequestViewPageModel helpRequestViewPageModel)
        {
            InitializeComponent();
            viewModel = helpRequestViewPageModel;
            BindingContext = viewModel;

            if(viewModel.Creator.Username == LocalUserManager.LocalUser.Username)
            {
                deleteButton.IsEnabled = true;
            }
            else
            {
                deleteButton.IsEnabled = false;
            }
        }
        public async void OnImageButtonClicked(object sender, EventArgs e)
        {
            buttonViewProfile.IsEnabled = false;
            await Navigation.PushAsync(new ProfileViewPage(new ViewModels.ProfileViewViewModel(viewModel.Creator)));
        }
        
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (await DisplayActionSheet("Ar tikrai norite ištrinti?", "Ne", "Taip") == "Taip")
            {
                var remover = HelpRequestSystemManager.NewHelpRequestRemover();
                remover.Result += (status, helpRequest) =>
                  {
                      Device.BeginInvokeOnMainThread(async () =>
                      {
                          if(status == HelpRequestManageStatus.Success)
                          {
                              DependencyService.Get<IToast>().LongToast("Ištrinta sėkmingai");
                              await Navigation.PopAsync();
                          }
                          else                                                                                                                                                                            
                          {
                              DependencyService.Get<IToast>().LongToast("Ištrinti nepavyko");
                          }
                      });
                  };
                remover.Remove(viewModel.HelpRequestModel.HelpRequest);
            }
            return;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            buttonViewProfile.IsEnabled = true;
        }
    }
}
