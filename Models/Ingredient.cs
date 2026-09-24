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
        public int Quantity { get; set; }
        public string Measurement { get; set; }
    }
}
