using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HarryPotterPotions.Models
{
    public class Cart
    {
        public ObservableCollection<Item> CartItems { get; set; } = new(); //should this be here on in the Repository class? Intellisense thinks it should be here because the Cart class is responsible for managing the items in the cart, while the Repository class is responsible for managing the data and business logic of the application.

        public List<Ingredient> Ingredients { get; set; }
        public int TotalCartPrice
        {
            get
            {
                int totalPrice = 0;
                foreach (Item item in CartItems)
                {
                    totalPrice += item.ItemPrice;
                }
                return totalPrice;
            }
        }

        public Cart()
        {

        }

        public Cart(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}
