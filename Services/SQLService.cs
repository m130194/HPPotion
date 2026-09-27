using HarryPotterPotions.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace HarryPotterPotions.Services
{
    
    public class SQLService
    {
        //how do I implement this?

        private SQLService _databaseService;
        private SQLiteAsyncConnection _database;

        //constructor
        public SQLService(string databasePath)
        {

            if (_databaseService == null)
            {
                //create database with provided location AppData folder in Windows. in mobile apps, the folder is protected within the app itself
                _databaseService = new SQLService(
                    Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData), "ingredients.db"
                    ));
            }
            //pass in database path
            _database = new SQLiteAsyncConnection(databasePath);
            //asynchronous set up database with generic type function inside constructor
            _database.CreateTableAsync<Ingredient>().Wait();
        } ⁠

        //Set up functionality - CRUD/BREAD operations
        public async Task<List<Ingredient>> BrowseIngredientsAsync()
        {
            //query table
            return await _database.Table<Ingredient>().ToListAsync();
        }

        public async Task<int> AddIngredientAsync(Ingredient ingredient)
        {
            return await _database.InsertAsync(ingredient);
        }

        public async Task<int> EditIngredientAsync(Ingredient ingredient)
        {
            return await _database.UpdateAsync(ingredient);
        }

        public async Task<int> DeleteIngredientAsync(Ingredient ingredient)
        {
            return await _database.DeleteAsync(ingredient);
        }

        public async Task<Ingredient> ReadIngredientAsync(int id)
        {
            return await _database.FindAsync<Ingredient>(id);
        }

    }
}
