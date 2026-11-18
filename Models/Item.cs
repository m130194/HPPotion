using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using SQLite;

namespace HarryPotterPotions.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; } //how to fix errors with being readonly

        public int Quantity { get; set; }

        public int TotalPrice
        {
            get => Ingredient.MarketPrice * Quantity;
        }


        // Created parameterless constructor due to SQLite's requirement for a default constructor when using the ORM. This allows SQLite to create instances of the Item class when retrieving data from the database.
        public Item()
        {
            Quantity = 1;
        }

        public Item(Ingredient ingredient, int quantity)
        {
            Ingredient = ingredient;
            Quantity = quantity;
        }

    }
}
