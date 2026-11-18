using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HarryPotterPotions.ViewModels
{
    
    public class InventoryViewModel : INotifyPropertyChanged
    {
        

        private readonly SQLService _sqlService;
        private readonly Repository _repository;
        public ObservableCollection<Item> Inventory => _repository.Inventory;
        public Command ButtonRefreshCommand { get; private set; }
        public Command ButtonSaveCommand { get; private set; }
        public Command ButtonDeleteCommand { get; private set; }
        public Command SearchCommand { get; private set; }
        public Command EditQuantityCommand { get; private set; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                SearchItemByNameAsync();
                // Trigger the search command whenever the search text changes
                //_sqlService.FindItemByNameWildcardAsync(_searchText);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        public InventoryViewModel(SQLService SqlService, Repository repository)
        {
            
            _sqlService = SqlService;
            _repository = repository;

            // this line needs to be looked at
            SeeItemsAsync();

            ////initialize the command property in the constructor
            ButtonRefreshCommand = new Command(async () => await SeeItemsAsync());
            ////ButtonRefreshCommand.CanExecute
            SearchCommand = new Command(async () => await SearchItemByNameAsync());
            EditQuantityCommand = new Command<Item>(async (item) => await UpdateItemQuantityAsync(item, item.Quantity));
            ButtonSaveCommand = new Command<Item>(async (newItem) => await SaveItemAsync(newItem));

            ButtonDeleteCommand = new Command<Item>(async (item) => await RemoveItemAsync(item));
        }

        public async Task SeeItemsAsync()
        {
            //SearchText = string.Empty; // Clear the search text when refreshing the inventory
            Inventory.Clear();
            var items = await _sqlService.BrowseItemsAsync();
            foreach (var item in items)
            {
                Inventory.Add(item);
            }
        }

        public async Task SearchItemByNameAsync()
        {
            Inventory.Clear();
            var items = await _sqlService.FindItemByNameWildcardAsync(SearchText);
            if (items != null)
            {
                foreach (var item in items)
                {
                    Inventory.Add(item);
                }
            }
        }



        //TODO: Add a method to save a new ingredient to the database and update the Inventory collection
        public async Task SaveItemAsync(Item newItem)
        {
            Inventory.Add(newItem);
            int result = await _sqlService.AddItemAsync(newItem);
            if (result != 1)
            {
                Inventory.Remove(newItem);
                //add some error handling here, maybe a message box to the user
            }
        }

        public async Task RemoveItemAsync(Item item)
        {
            if (item == null)
                return;

            int result = await _sqlService.DeleteItemAsync(item);
            if (result == 1)
            {
                Inventory.Remove(item);
            }
        }

        public async Task UpdateItemQuantityAsync(Item item, int newQuantity)
        {
            int itemId = item.Id;
            newQuantity = item.Quantity; // Assuming you want to use the updated quantity from the item object
            int result = await _sqlService.UpdateItemQuantityByIdAsync(itemId, newQuantity);
            if (result == 0)
                return;
            if (result != 0)
            {

                //item.Quantity = newQuantity;

                OnPropertyChanged(nameof(Inventory)); // Notify that the Inventory collection has changed
            }
            SeeItemsAsync(); // Refresh the inventory to reflect the updated quantity
        }

    }
}
