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
    
    public class IngredientInventoryViewModel : INotifyPropertyChanged
    {
        

        private readonly SQLService _sqlService;
        private readonly Repository _repository;
        public ObservableCollection<Ingredient> Inventory => _repository.Inventory;
        public Command ButtonRefreshCommand { get; private set; }
        public Command ButtonSaveCommand { get; private set; }
        public Command ButtonDeleteCommand { get; private set; }
        public Command SearchCommand { get; private set; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                SearchCommand.Execute(null); // Trigger the search command whenever the search text changes
                //_sqlService.FindIngredientByNameWildcardAsync(_searchText);
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

        public IngredientInventoryViewModel(SQLService SqlService, Repository repository)
        {
            
            _sqlService = SqlService;
            _repository = repository;

            // this line needs to be looked at
            _ = SeeIngredientsAsync();

            ////initialize the command property in the constructor
            ButtonRefreshCommand = new Command(async () => await SeeIngredientsAsync());
            ////ButtonRefreshCommand.CanExecute
            SearchCommand = new Command(async () => await SearchIngredientByNameAsync());
            ButtonSaveCommand = new Command(async () => await SaveIngredientAsync());

            ButtonDeleteCommand = new Command<Ingredient>(async (ingredient) => await RemoveIngredientAsync(ingredient));
        }

        public async Task SeeIngredientsAsync()
        {
            Inventory.Clear();
            var ingredients = await _sqlService.BrowseIngredientsAsync();
            foreach (var ingredient in ingredients)
            {
                Inventory.Add(ingredient);
            }
        }

        public async Task SearchIngredientByNameAsync()
        {
            Inventory.Clear();
            var ingredients = await _sqlService.FindIngredientByNameWildcardAsync(SearchText);
            if (ingredients != null)
            {
                foreach (var ingredient in ingredients)
                {
                    Inventory.Add(ingredient);
                }
            }
        }



        //TODO: Add a method to save a new ingredient to the database and update the Inventory collection
        public async Task SaveIngredientAsync()
        {
            Ingredient newIngredient = new()
            {
                Name = "New Ingredient",
                Quantity = 2,
                Measurement = "item",
            };
            Inventory.Add(newIngredient);
            int result = await _sqlService.AddIngredientAsync(newIngredient);
            if (result != 1)
            {
                Inventory.Remove(newIngredient);
                //add some error handling here, maybe a message box to the user
            }
        }

        public async Task RemoveIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
                return;

            int result = await _sqlService.DeleteIngredientAsync(ingredient);
            if (result == 1)
            {
                Inventory.Remove(ingredient);
            }
        }

    }
}
