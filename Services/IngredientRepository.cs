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

        private ObservableCollection<string> _ingredients;
        public ObservableCollection<string> Ingredients
        {
            get
            {
                var shoppingList = new ObservableCollection<string>();
                foreach (ActualPotion potion in SavedPotions)
                {
                    string ingredientString = potion.Ingredients;
                    shoppingList = new ObservableCollection<string>(ingredientString.Split(',').Select(item => item.Trim()).Where(item => !string.IsNullOrEmpty(item)));
                }
                return shoppingList;
            }
        }


            
        }
}
