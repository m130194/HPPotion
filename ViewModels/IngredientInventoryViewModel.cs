using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace HarryPotterPotions.ViewModels
{
    
    public class IngredientInventoryViewModel
    {
        public ObservableCollection<Ingredient> Inventory { get; set; } = new ObservableCollection<Ingredient>();
        
        private readonly SQLService _service;

        public ICommand ButtonRefreshCommand { get; private set; }
        public ICommand ButtonSaveCommand { get; private set; }

        public IngredientInventoryViewModel(SQLService sqlService)
        {
            //this line needs to be looked at
            _service = sqlService;

            ////initialize the command property in the constructor
            ButtonRefreshCommand = new Command(async () => await SeeIngredientsAsync());
            ////ButtonRefreshCommand.CanExecute
            ButtonSaveCommand = new Command(async () => await SaveIngredientAsync());
        }

        public async Task SeeIngredientsAsync()
        {
            //Inventory.Clear();
            var ingredients = await _service.BrowseIngredientsAsync();
            foreach (var ingredient in ingredients)
            {
                Inventory.Add(ingredient);
            }
        }
        public async Task SaveIngredientAsync()
        {
            Ingredient newIngredient = new()
            {
                Name = "New Ingredient",
                Quantity = 2,
                Measurement = "item",
            };
            int result = await _service.AddIngredientAsync(newIngredient);
            //if (result == 1)
            //{
            //    await SeeIngredientsAsync();
            //}
        }


    }
}
