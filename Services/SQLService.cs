
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
                        Environment.SpecialFolder.LocalApplicationData), "items.db"
                    );

                //pass in database path
                _connection = new SQLiteAsyncConnection(databasePath);

                //asynchronous set up database with generic type function inside constructor
                _connection.CreateTableAsync<Item>().Wait();
            }
        }

        //Set up functionality - CRUD/BREAD operations
        public async Task<List<Item>> BrowseItemsAsync()
        {
            await InitAsync();
            //query table
            return await _connection.Table<Item>().ToListAsync();
        }

        public async Task<int> AddItemAsync(Item item)
        {
            await InitAsync();
            return await _connection.InsertAsync(item);
        }

        public async Task<int> EditItemAsync(Item item)
        {
            await InitAsync();
            return await _connection.UpdateAsync(item);
        }

        public async Task<int> DeleteItemAsync(Item item)
        {
            await InitAsync();
            return await _connection.DeleteAsync(item);
        }

        public async Task<Item> ReadItemAsync(int id)
        {
            await InitAsync();
            return await _connection.FindAsync<Item>(id);
        }

        public async Task<Item> ReadItemByNameAsync(string name)
        {
            await InitAsync();
            return await _connection.Table<Item>().Where(i => i.Ingredient.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Item> FindItemByNameAsync(string name)
        {
            await InitAsync();
            return await _connection.FindAsync<Item>(i => i.Ingredient.Name == name);
        }

        public async Task<List<Item>> FindItemByNameWildcardAsync(string name)
        {
            await InitAsync();
            var items = await _connection.QueryAsync<Item>(
    "SELECT * FROM Item WHERE Name LIKE ?",
    $"%{name}%"
);
            return items; // Return all matching items
        }

        public async Task<int> UpdateItemQuantityByNameAsync(string name, int newQuantity)
        {
            await InitAsync();

            var item = await _connection.Table<Item>().Where(i => i.Ingredient.Name == name).FirstOrDefaultAsync();
            if (item != null)
            {
                int rowsAffected = await _connection.ExecuteAsync(
                    "UPDATE Item SET Quantity = ? WHERE Name = ?",
                    newQuantity,
                    name
                );
                return rowsAffected;
            }
            return 0; // Return 0 if the item was not found
        }

        public async Task<int> UpdateItemQuantityByIdAsync(int id, int newQuantity)
        {
            await InitAsync();
            var result = await _connection.FindAsync<Item>(id);
            if (result != null)
            {
                await _connection.ExecuteAsync(
                    "UPDATE Item SET Quantity = ? WHERE Id = ?",
                    newQuantity,
                    id
                );
            }
            return 0; // Return 0 if the item was not found
        }

    }
}
