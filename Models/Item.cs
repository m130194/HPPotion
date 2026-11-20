using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace HarryPotterPotions.Models
{
    public class Item: INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; } //how to fix errors with being readonly?

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        //This is a placeholder for a future feature where the user can specify a custom price for an ingredient in their inventory. For now, it will default to the market price of the ingredient.


        public int TotalPrice
        {
            get => Ingredient.MarketPrice * Quantity;

        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
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
