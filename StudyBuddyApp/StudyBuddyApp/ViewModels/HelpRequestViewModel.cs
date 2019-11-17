using StudyBuddy.Network;
using StudyBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddy.Entity;
using System.Diagnostics;
using StudyBuddyApp.Views;

namespace StudyBuddyApp.ViewModels
{
    public class HelpRequestViewModel : BaseViewModel
    {
        //public string AddText { get; set; }

        //public ObservableCollection<HelpRequestModel> Items { get; set; }
        public HelpRequestViewModel()
        {
            Title = "Prašyti pagalbos";

            //AddText = "Naujas";
            //Description = "Description";
        }
    }
}
