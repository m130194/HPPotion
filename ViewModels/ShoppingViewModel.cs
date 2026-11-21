using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;



namespace HarryPotterPotions.ViewModels
{


    public class ShoppingViewModel
    {

        private readonly SQLService _sqlService;
        private readonly Repository _repository;

        public List<Ingredient> Ingredients =>
            _repository.Ingredients;

        public ObservableCollection<Item> ShoppingCart => _repository.ShoppingCart;

        public ObservableCollection<Item> Inventory => _repository.Inventory;

        public int TotalCartPrice => _repository.UserCart.TotalCartPrice;



        public Command HandleIngredientClickedAddCommand { get; private set; }
        public Command ButtonDeleteItemFromShoppingCartCommand { get; private set; }
        
        //public Command ButtonAddItemsToInventoryCommand { get; private set; }



        public ShoppingViewModel(SQLService sqlService, Repository repository)
        {
            _repository = repository;
            _sqlService = sqlService;
            HandleIngredientClickedAddCommand = new Command<Ingredient>(AddItemToShoppingCart);
            ButtonDeleteItemFromShoppingCartCommand = new Command<Item>(RemoveItemFromShoppingCart);
            
            //ButtonAddItemsToInventoryCommand = new Command<ObservableCollection<Item>>(AddItemsToInventory);
        }

        

        public void AddItemToShoppingCart(Ingredient ingredient)
        {
           _repository.AddItemToShoppingCart(ingredient);
        }


        public void RemoveItemFromShoppingCart(Item item)
        {
            _repository.RemoveItemFromShoppingCart(item);
        }







        //public void AddItemsToInventory(ObservableCollection<Item> items)
        //{
        //    foreach (var item in items)
        //    {
        //        var existingItem = Inventory.FirstOrDefault(i => i.Ingredient == item.Ingredient);
        //        if (existingItem != null)
        //        {
        //            existingItem.Quantity += item.Quantity;
        //        }
        //        else
        //        {
        //            Inventory.Add(item);
        //        }
        //    }
        //}

    }
}
