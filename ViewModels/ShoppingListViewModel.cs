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


    public class ShoppingListViewModel
    {

        private readonly SQLService _sqlService;
        private readonly Repository _repository;

        public ObservableCollection<Ingredient> Ingredients =>
            _repository.Ingredients;

        public ObservableCollection<Item> ShoppingCart => _repository.ShoppingCart;



        //public Command ButtonAddIngredientCommand { get; private set; }
        //public Command ButtonAddIngredientToInventoryCommand { get; private set; }



        public ShoppingListViewModel(SQLService SqlService, Repository repository)
        {
            _repository = repository;
            _sqlService = SqlService;
            //ButtonDeleteIngredientCommand = new Command<string>(AddIngredient);
            //ButtonAddIngredientToInventoryCommand = new Command<string>(async (ingredient) => await AddIngredientToInventoryAsync(ingredient));
        }

        

        public void AddIngredientToShoppingCart(Ingredient ingredient)
        {
            var existingItem = ShoppingCart.FirstOrDefault(i => i.Ingredient == ingredient);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                ShoppingCart.Add(new Item { Ingredient = ingredient, Quantity = 1 });
            }
        }




        public void RemoveIngredientfromShoppingCart(Item item)
        {
            ShoppingCart.Remove(item);
        }

    }
}
