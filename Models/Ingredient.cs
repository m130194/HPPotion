using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HarryPotterPotions.Models
{
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Name { get; set; }

        public int MarketPrice { get; set; }

        public Ingredient(string name)
        {
            Name = name;
        }

        public Ingredient(string name, int marketPrice)
        {
            Name = name;
            MarketPrice = marketPrice;
        }

    }
}
