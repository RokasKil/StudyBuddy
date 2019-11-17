using StudyBuddyShared.Network;
using StudyBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudyBuddyShared.Entity;
using System.Diagnostics;
using StudyBuddyApp.Views;

namespace StudyBuddyApp.ViewModels
{
    public class HelpRequestAddViewModel : BaseViewModel
    {
        //public string AddText { get; set; }

        //public ObservableCollection<HelpRequestModel> Items { get; set; }

        public String Send { get; set; }
        public String CategoryGeneral { get; set; }

        public String RequestDescription { get; set; }
        public String RequestName { get; set; }
        public HelpRequestAddViewModel()
        {
            Title = "Prašyti pagalbos";
            Send = "Siųsti";
            CategoryGeneral = "Kategorija";
            RequestDescription = "Problemos apibūdinimas";
            RequestName = "Problemos pavadinimas";
            //AddText = "Naujas";
            //Description = "Description";
        }
    }
}
