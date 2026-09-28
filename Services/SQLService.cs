using HarryPotterPotions.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.AccessControl;
using System.Text;

namespace HarryPotterPotions.Services
{

    public class SQLService
    {

        private SQLService _databaseService;
        private SQLiteAsyncConnection _connection;


        public async Task InitAsync()
        {
            if (_databaseService == null)
            {
                var databasePath =
                    Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData), "ingredients.db"
                    );

                //pass in database path
                _connection = new SQLiteAsyncConnection(databasePath);

                //asynchronous set up database with generic type function inside constructor
                _connection.CreateTableAsync<Ingredient>().Wait();
            }
        }

        //Set up functionality - CRUD/BREAD operations
        public async Task<List<Ingredient>> BrowseIngredientsAsync()
        {
            await InitAsync();
            //query table
            return await _connection.Table<Ingredient>().ToListAsync();
        }

        public async Task<int> AddIngredientAsync(Ingredient ingredient)
        {
            await InitAsync();
            return await _connection.InsertAsync(ingredient);
        }

        public async Task<int> EditIngredientAsync(Ingredient ingredient)
        {
            await InitAsync();
            return await _connection.UpdateAsync(ingredient);
        }

        public async Task<int> DeleteIngredientAsync(Ingredient ingredient)
        {
            await InitAsync();
            return await _connection.DeleteAsync(ingredient);
        }

        public async Task<Ingredient> ReadIngredientAsync(int id)
        {
            await InitAsync();
            return await _connection.FindAsync<Ingredient>(id);
        }

    }
}
