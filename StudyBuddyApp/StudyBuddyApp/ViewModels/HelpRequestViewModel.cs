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
    class HelpRequestViewModel : BaseViewModel
    {
        public string AddText { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ObservableCollection<Item> Items { get; set; }
        public HelpRequestViewModel()
        {
            Title = "Prašyti pagalbos";
            AddText = "Naujas";

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

             MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
