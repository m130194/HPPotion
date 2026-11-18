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
        public ObservableCollection<Potion> SavedPotionsToMake { get; } = new();

        /// <summary>
        /// Collection of items saved to the user's inventory. This collection is used to determine which ingredients the user already has and which ingredients they need to purchase for their potions.
        /// </summary>
        public ObservableCollection<Item> Inventory { get; } = new();

        /// <summary>
        /// "A list of all of the ingredients that my app knows about in a general form"
        /// </summary>
        public ObservableCollection<Ingredient> Ingredients { get; } = new();

        public Repository()
        {
            // Initialize the Ingredients collection with some sample ingredients
            Ingredients = [
                new Ingredient("Mandrake"),
            new Ingredient("Bezoar"),
            new Ingredient("Powdered Unicorn Horn"),
            new Ingredient("Mistletoe berries"),
            new Ingredient("Fire seeds"),
            new Ingredient("Powdered Graphorn horn"),
            new Ingredient("Billywig stings"),
            new Ingredient("Chizpurfle carapaces"),
            new Ingredient("Liquorice roots"),
            new Ingredient("Castor oil"),
            new Ingredient("Extract of Gurdyroot")
            ]
            ;
        }
        
        public ObservableCollection<Item> ShoppingCart { get; } = new();






        //Methods for SavedPotionsToMake
        public void AddPotionToSavedPotionsToMake(Potion newPotion)
        {
            SavedPotionsToMake.Add(newPotion);
        }



        //Methods for Inventory
        public void AddItemToInventory(Item newItem)
        {
            Inventory.Add(newItem);
        }
    }
}
