using HarryPotterPotions.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace HarryPotterPotions.Services
{
    public class Repository : INotifyPropertyChanged
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
        public List<Ingredient> Ingredients { get; } = new();

        /// <summary>
        /// A collection representing the user's shopping cart
        /// </summary>
        public ObservableCollection<Item> ShoppingCart { get; } = new();

        public int TotalCartPrice => ShoppingCart.Sum(item => item.TotalPrice);
        //public int TotalCartPrice
        //{
        //    get
        //    {
        //        int totalPrice = 0;
        //        foreach (Item item in ShoppingCart)
        //        {
        //            totalPrice += item.TotalPrice;
        //        }
        //        return totalPrice;
        //    }
        //}

        public Repository()
        {
            // Initialize the Ingredients collection with some sample ingredients
            Ingredients = new List<Ingredient>()
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

            Item item = ShoppingCart.FirstOrDefault(item => item.Ingredient == ingredient);

            if (item is not null)
            {
                item.Quantity++;
            }
            else
            {
                Item newItem = new Item(ingredient, 1);
                ShoppingCart.Add(newItem);
            }


            //List<string> currentIngredients = [];
            //foreach (Item item in ShoppingCart)
            //{
            //    string ingredientName = item.Ingredient.Name;
            //    currentIngredients.Add(ingredientName);
            //}
            //if (currentIngredients.Contains(ingredient.Name))
            //{
            //    Item item = ShoppingCart.FirstOrDefault(item => item.Ingredient.Name == ingredient.Name);
            //    //get the current item

            //    //increment the quantity
            //    //item.Quantity++;

            //    // get the index of where the item currently is
            //    int index = ShoppingCart.IndexOf(item);

            //    // now remove the item
            //    ShoppingCart.RemoveAt(index);

            //    // now it's removed make the change
            //    item.Quantity++;

            //    // now add it back in (adding will make sure an event is fired)
            //    ShoppingCart.Insert(index, item);
            //}
            //else
            //{
            //    Item newItem = new Item(ingredient, 1);
            //    ShoppingCart.Add(newItem);
            //}
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
