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

        public async Task<Ingredient> ReadIngredientByNameAsync(string name)
        {
            await InitAsync();
            return await _connection.Table<Ingredient>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Ingredient> FindIngredientByNameAsync(string name)
        {
            await InitAsync();
            return await _connection.FindAsync<Ingredient>(i => i.Name == name);
        }

        public async Task<int> UpdateIngredientQuantityAsync(string name, int newQuantity)
        {
            await InitAsync();
            var ingredient = await _connection.Table<Ingredient>().Where(i => i.Name == name).FirstOrDefaultAsync();
            if (ingredient != null)
            {
                int rowsAffected = await _connection.ExecuteAsync(
                    "UPDATE Ingredient SET Quantity = ? WHERE Name = ?",
                    newQuantity,
                    name
                );
            }
            return 0; // Return 0 if the ingredient was not found
        }

    }
}
