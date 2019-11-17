using StudyBuddyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyBuddyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyProfilePage : ContentPage
	{
        MyProfileViewModel viewModel = new MyProfileViewModel();
        public MyProfilePage() : this(new MyProfileViewModel()) { }
		public MyProfilePage (MyProfileViewModel viewModel)
		{
			InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        async void buttonEditProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileEditPage(new ViewModels.ProfileEditViewModel()));
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            viewModel.User.OnUpdateHandler?.Invoke(viewModel.User);
        }
    }
}