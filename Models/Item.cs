using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HarryPotterPotions.Models
{
    public class Item
    {
        [Primary Key, AutoIncrement]
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }

        public int Quantity { get; set; }

        public Item(Ingredient ingredient, int quantity)
        {
            Ingredient = ingredient;
            Quantity = quantity;
        }

    }
}
