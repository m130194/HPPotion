using HarryPotterPotions.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HarryPotterPotions.Services
{
    public class IngredientRepository
    {

        public ObservableCollection<ActualPotion> SavedPotions { get; } = new();

        public ObservableCollection<string> GetIngredientsForShoppingList()
        {
            var shoppingList = new ObservableCollection<string>();
            foreach (var potion in SavedPotions)
            {
                shoppingList.Add(potion.Ingredients);
                //foreach (var ingredient in potion.Ingredients)
                //{
                //    // Add ingredient to shopping list
                //    shoppingList.Add(ingredient.Name);
                //}
            }
            return shoppingList;
        }
}
}
