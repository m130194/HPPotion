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

        public int Quantity { get; set; } = 1;

        //This is a placeholder for a future feature where the user can specify a custom price for an ingredient in their inventory. For now, it will default to the market price of the ingredient.
        public int TotalPrice
        {
            get => Ingredient.MarketPrice * Quantity;
        }


        // Created parameterless constructor due to SQLite's requirement for a default constructor when using the ORM. This allows SQLite to create instances of the Item class when retrieving data from the database.
        public Item()
        {
            
        }

        public Item(Ingredient ingredient, int quantity)
        {
            Ingredient = ingredient;
            Quantity = quantity;
        }

    }
}
