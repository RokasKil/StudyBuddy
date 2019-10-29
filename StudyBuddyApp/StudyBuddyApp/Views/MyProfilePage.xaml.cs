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
		public MyProfilePage ()
		{
			InitializeComponent ();
            var user = LocalUserManager.LocalUser;
            Name.Text = user.FirstName + " " + user.LastName;
            ProfilePicture.Source = user.ProfilePictureLocation;
		}
	}
}