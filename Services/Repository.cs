using HarryPotterPotions.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace HarryPotterPotions.Services
{
    public class Repository
    {
        /// <summary>
        /// Gets the collection of saved potions that the user wants to make. This collection is used to generate the shopping list of ingredients needed for those potions.
        /// </summary>
        public ObservableCollection<ActualPotion> SavedPotionsToMake { get; } = new();

        public ObservableCollection<Ingredient> Inventory { get; } = new();

        public void AddPotionToSavedPotionsToMake(ActualPotion newPotion)
        {
            SavedPotionsToMake.Add(newPotion);
        }
        public void AddIngredientToIngredientInventory(Ingredient newIngredient)
        {
            Inventory.Add(newIngredient);
        }
    }
}
