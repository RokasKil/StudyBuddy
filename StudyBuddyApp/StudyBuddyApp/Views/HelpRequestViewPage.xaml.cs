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
    public partial class HelpRequestViewPage : ContentPage
    {
        readonly HelpRequestViewPageModel viewModel;

        public HelpRequestViewPage(HelpRequestViewPageModel helpRequestViewPageModel)
        {
            InitializeComponent();
            viewModel = helpRequestViewPageModel;
            BindingContext = viewModel;
        }
        public async void OnImageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileViewPage(new ViewModels.ProfileViewViewModel(viewModel.Creator)));
        }
    }
}