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

        public ObservableCollection<Item> ShoppingCart { get; } = new();


        public Repository()
        {
            // Initialize the Ingredients collection with some sample ingredients
            Ingredients = new ObservableCollection<Ingredient>()
            {
                new Ingredient("Mandrake", 10),
                new Ingredient("Bezoar", 20),
                new Ingredient("Powdered Unicorn Horn", 15),
                new Ingredient("Mistletoe berries", 5),
                new Ingredient("Fire seeds", 25),
                new Ingredient("Powdered Graphorn horn", 30),
                new Ingredient("Billywig stings", 12),
                new Ingredient("Chizpurfle carapaces", 8),
                new Ingredient("Liquorice roots", 3),
                new Ingredient("Castor oil", 7),
                new Ingredient("Extract of Gurdyroot", 18)
            }
            ;
        }



        //Methods for ShoppingCart

        public void AddItemToShoppingCart(Ingredient ingredient)
        {
            Item newItem = new Item(ingredient, 1);
            ShoppingCart.Add(newItem);
        }

        public void RemoveItemFromShoppingCart(Item item)
        {
            ShoppingCart.Remove(item);
        }



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
