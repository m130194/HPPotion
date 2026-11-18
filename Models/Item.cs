using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotterPotions.Models
{
    public class Item
    {
        public Ingredient Ingredient { get; }

        public int Quantity { get; set; }

        public Item(Ingredient ingredient, int quantity)
        {
            Ingredient = ingredient;
            Quantity = quantity;
        }

    }
}
