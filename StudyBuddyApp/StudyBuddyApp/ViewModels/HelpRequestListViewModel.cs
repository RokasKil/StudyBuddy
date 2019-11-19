using StudyBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StudyBuddyApp.ViewModels
{
    public class HelpRequestListViewModel : BaseViewModel
    {
        public ObservableCollection<HelpRequestModel> Items { get; set; }
        public ObservableCollection<CategoryModel> CategoryItems { get; set; }
        public String AddRequest { get; set; }
        public String CategoryGeneral { get; set; }
        public String EntryFind { get; set; }
        public HelpRequestListViewModel()
        {
            Title = "Pagalbos prašymai";
            AddRequest = "Naujas";
            CategoryGeneral = "Kategorija";
            EntryFind = "Ieškoti";

        }
    }
}
