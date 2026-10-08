using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace HarryPotterPotions.ViewModels
{


    public class ShoppingListViewModel
    {

        private readonly SQLService _sqlService;
        private readonly Repository _repository;

        public ObservableCollection<ActualPotion> SavedPotionsToMake =>
            _repository.SavedPotionsToMake;

        
        public Command ButtonDeleteIngredientCommand { get; private set; }
        public Command ButtonAddIngredientToInventoryCommand { get; private set; }
        


        public ShoppingListViewModel(SQLService SqlService, Repository repository)
        {
            _repository = repository;
            _sqlService = SqlService;
            AddIngredientsFromAllSavedPotion(_repository.SavedPotionsToMake);
            ButtonDeleteIngredientCommand = new Command<string>(RemoveIngredient);
            ButtonAddIngredientToInventoryCommand = new Command<string>(async (ingredient) => await AddIngredientToInventoryAsync(ingredient));
        }

        public ObservableCollection<string> ShoppingList { get; } = new();

        public void AddIngredientsFromAllSavedPotion(ObservableCollection<ActualPotion> savedPotions)
        {
            foreach (ActualPotion potion in savedPotions ?? SavedPotionsToMake)
            {
                if (potion == null || string.IsNullOrWhiteSpace(potion.Ingredients))
                    continue;

                var ingredients = potion.Ingredients
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim())
                    .Where(i => !string.IsNullOrEmpty(i));

                foreach (var ingredient in ingredients)
                {
                    if (!ShoppingList.Contains(ingredient))
                        ShoppingList.Add(ingredient);
                }
            }
        }

        //public void AddIngredientsFromAllSavedPotion(ObservableCollection<ActualPotion> savedPotions)
        //{
        //    foreach (ActualPotion potion in savedPotions ?? SavedPotionsToMake)
        //    {
        //        if (potion == null || potion.Ingredients == null || potion.Ingredients.Count == 0)
        //            continue;

        //        var ingredients = potion.Ingredients;

        //        foreach (var ingredient in ingredients)
        //        {
        //            var trimmed = ingredient?.Trim();
        //            if (string.IsNullOrEmpty(trimmed))
        //                continue;

        //            if (!ShoppingList.Contains(trimmed))
        //                ShoppingList.Add(trimmed);
        //        }
        //    }
        //}



        public void RemoveIngredient(string ingredient)
        {
            if (ShoppingList.Contains(ingredient))
            {
                ShoppingList.Remove(ingredient);
            }
        }

        public async Task AddIngredientToInventoryAsync(string ingredient)
        {
            //if (string.IsNullOrEmpty(ingredient))
                

            if (ShoppingList.Contains(ingredient))
            {
                Ingredient newIngredient = new()
                {
                    Name = ingredient,
                    Quantity = 1,
                    Measurement = "item"
                };
                //TODO: Add error handling
                int result = await _sqlService.AddIngredientAsync(newIngredient);
                //access Inventory observable collection from here?
                _repository.AddIngredientToIngredientInventory(newIngredient);
                


            }

            
        }
    }
}
