using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotterPotions.Models
{
    class Item
    {
        Ingredient Ingredient { get; set; }

        int Quantity { get; set; }

        public Item(Ingredient ingredient, int quantity)
        {
            Ingredient = ingredient;
            Quantity = quantity;
        }

    }
}
