using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;



namespace HarryPotterPotions.ViewModels
{


    public class ShoppingListViewModel
    {

        private readonly SQLService _sqlService;
        private readonly Repository _repository;

        public ObservableCollection<Potion> SavedPotionsToMake =>
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

        public void AddIngredientsFromAllSavedPotion(ObservableCollection<Potion> savedPotions)
        {
            foreach (Potion potion in savedPotions ?? SavedPotionsToMake)
            {
                if (potion == null || string.IsNullOrWhiteSpace(potion.Ingredients))
                    continue;

                var ingredients = potion.Ingredients
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim())
                    .Where(i => !string.IsNullOrEmpty(i));

                foreach (var ingredientLine in ingredients)
                {

                    if (!ShoppingList.Contains(ingredientLine))
                        ShoppingList.Add(ingredientLine);
                }
            }
        }

        //public void AddIngredientsFromAllSavedPotion(ObservableCollection<Potion> savedPotions)
        //{
        //    foreach (Potion potion in savedPotions ?? SavedPotionsToMake)
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

        public async Task AddIngredientToInventoryAsync(string ingredientLine)
        {
            //if (string.IsNullOrEmpty(ingredient))
                

            if (ShoppingList.Contains(ingredientLine))
            {
                // 1. Extract all numbers (\d+ matches one or more digits)
                MatchCollection numberMatches = Regex.Matches(ingredientLine, @"\d+");

                // This pattern splits:
                // - Between a letter and a digit (?<=[a-zA-Z])(?=\d)
                // - OR between a digit and a letter (?<=\d)(?=[a-zA-Z])
                string pattern = @"(?<=[a-zA-Z])(?=\d)|(?<=\d)(?=[a-zA-Z])";

                string[] ingredientNames = Regex.Split(ingredientLine, pattern);


                foreach (string ingredientName in ingredientNames)
                {
                    

                    Ingredient existingIngredient = await _sqlService.FindIngredientByNameAsync(ingredientName);
                    if (existingIngredient != null)
                    {
                        // If the ingredient exists, update its quantity
                        int quantityToAdd = 1; // Default quantity if no number is found
                        if (numberMatches.Count > 0)
                        {
                            quantityToAdd = int.Parse(numberMatches[0].Value);
                        }
                        //existingIngredient.Quantity += quantityToAdd;
                        await _sqlService.UpdateIngredientQuantityAsync(existingIngredient.Name, existingIngredient.Quantity + quantityToAdd);
                    }
                    else
                    {
                        int quantity = 1; // Default quantity if no number is found
                        if (numberMatches.Count > 0)
                        {
                            quantity = int.Parse(numberMatches[0].Value);
                        }
                        Ingredient newIngredient = new()
                        {
                            Name = ingredientName,
                            Quantity = quantity,
                            Measurement = "item"
                        };

                        //TODO: Add error handling
                        int result = await _sqlService.AddIngredientAsync(newIngredient);
                        //access Inventory observable collection from here?
                        _repository.AddIngredientToIngredientInventory(newIngredient);
                    }

                }

                ShoppingList.Remove(ingredientLine);

            }

            
        }
    }
}
