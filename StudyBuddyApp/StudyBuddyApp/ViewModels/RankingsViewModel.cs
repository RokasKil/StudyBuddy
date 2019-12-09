using StudyBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class RankingsViewModel : BaseViewModel
    {
        public ObservableCollection<RankingsModel> Items { get; set; }
        public String PointsName { get; set; }
        public RankingsViewModel()
        {
            Title = "Reitingai";
            PointsName = "Exp: ";
        }
        

    }
}
