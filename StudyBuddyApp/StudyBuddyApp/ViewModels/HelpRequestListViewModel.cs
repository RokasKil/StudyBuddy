using StudyBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    class HelpRequestListViewModel : BaseViewModel
    {
        public ObservableCollection<HelpRequestModel> Items { get; set; }
        public HelpRequestListViewModel()
        {
            Title = "Pagalbos prašymai";
        }
    }
}
