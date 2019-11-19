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
        public async void OnImageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileViewPage(new ViewModels.ProfileViewViewModel(ViewModel.Creator)));
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
                remover.Remove(ViewModel.HelpRequestModel.HelpRequest);
            }
            return;
        }
    }
}
