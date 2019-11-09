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
	public partial class ConversationPage : ContentPage
	{

        ConversationViewModel viewModel;

        private ConversationPage ()
		{
			InitializeComponent ();
		}

        public ConversationPage(ConversationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            //this.SetBinding(viewModel);
        }
	}
}