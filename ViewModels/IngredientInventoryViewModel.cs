using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace HarryPotterPotions.ViewModels
{
    public class IngredientInventoryViewModel
    {
        public ObservableCollection<Ingredient> Inventory { get; } = new ObservableCollection<Ingredient>();

        //static property referencing database
        //SQLService databaseService = App.DatabaseService;

        //static is accessible from the class level without instantiating
        private static SQLService databaseService = default!;

        public static SQLService DatabaseService
        {
            get
            {
                if (databaseService == null)
                {
                    //create database with provided location AppData folder in Windows. in mobile apps, the folder is protected within the app itself
                    databaseService = new SQLService(
                        Path.Combine(Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), "ingredients.db"
                        ));
                }
                return databaseService;
            }
            set { databaseService = value; }
        }


        ////declare the public ICommand property
        public ICommand ButtonRefreshCommand { get; private set; }
        public ICommand ButtonSaveCommand { get; private set; }

        public IngredientInventoryViewModel()
        {
            //this line needs to be looked at
            databaseService = DatabaseService;

            ////initialize the command property in the constructor
            ButtonRefreshCommand = new Command(async () => await SeeIngredientsAsync());
            ////ButtonRefreshCommand.CanExecute
            ButtonSaveCommand = new Command(async () => await SaveIngredientAsync());
        }

        public async Task SeeIngredientsAsync()
        {
            //Inventory.Clear();
            var ingredients = await databaseService.BrowseIngredientsAsync();
            foreach (var ingredient in ingredients)
            {
                Inventory.Add(ingredient);
            }
        }
        public async Task SaveIngredientAsync()
        {
            Ingredient newIngredient = new()
            {
                Name = "New Ingredient",
                Quantity = 1,
                Measurement = "item",
            };
            int result = await databaseService.AddIngredientAsync(newIngredient);
            //if (result == 1)
            //{
            //    await SeeIngredientsAsync();
            //}
        }


    }
}
