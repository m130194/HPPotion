using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using HarryPotterPotions.Models;

namespace HarryPotterPotions.Services
{
    public class SQLService
    {
        //singleton should be here inside the class itself
        //static public SQLService Instance { get; set; }

        SQLiteAsyncConnection _database;

        //constructor
        public SQLService(string databasePath)
        {
            //pass in database path
            _database = new SQLiteAsyncConnection(databasePath);
            //asynchronous set up database with generic type function inside constructor
            _database.CreateTableAsync<Ingredient>().Wait(); //Can this be resolved using Async instead
        }

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
