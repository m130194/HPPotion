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

        public ObservableCollection<Ingredient> Ingredients =>
            _repository.Ingredients;

        public ObservableCollection<Item> ShoppingCart => _repository.ShoppingCart;

        public ObservableCollection<Item> Inventory => _repository.Inventory;



        public Command ButtonAddItemtoShoppingCartCommand { get; private set; }
        public Command ButtonDeleteItemFromShoppingCartCommand { get; private set; }
        
        //public Command ButtonAddItemsToInventoryCommand { get; private set; }



        public ShoppingViewModel(SQLService SqlService, Repository repository)
        {
            _repository = repository;
            _sqlService = SqlService;
            ButtonAddItemtoShoppingCartCommand = new Command<Item>(AddItemToShoppingCart);
            ButtonDeleteItemFromShoppingCartCommand = new Command<Item>(RemoveItemFromShoppingCart);
            
            //ButtonAddItemsToInventoryCommand = new Command<ObservableCollection<Item>>(AddItemsToInventory);
        }

        

        public void AddItemToShoppingCart(Item newItem)
        {
           ShoppingCart.Add(newItem);
        }

        public void RemoveItemFromShoppingCart(Item item)
        {
            ShoppingCart.Remove(item);
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
