using PricePoint.Objects;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuItem = PricePoint.Objects.MenuItem;

namespace PricePoint
{
    public class LocalDbService
    {
        private const string DB_NAME = "pricepoint.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<User>();
            _connection.CreateTableAsync<MenuItem>();
            _connection.CreateTableAsync<Restaurant>();
        }
        public async Task<List<User>> GetUsers()
        {
            return await _connection.Table<User>().ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _connection.Table<User>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateUser(User user)
        {
            await _connection.InsertAsync(user);
        }
        public async Task UpdateUser(User user)
        {
            await _connection.UpdateAsync(user);
        }
        public async Task DeleteUser(User user)
        {
            await _connection.DeleteAsync(user);
        }
        public async Task<List<MenuItem>> GetMenuItems()
        {
            return await _connection.Table<MenuItem>().ToListAsync();
        }
        public async Task<MenuItem> GetMenuItemById(int id)
        {
            return await _connection.Table<MenuItem>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateMenuItem(MenuItem menuItem)
        {
            await _connection.InsertAsync(menuItem);
        }
        public async Task UpdateMenuItem(MenuItem menuItem)
        {
            await _connection.UpdateAsync(menuItem);
        }
        public async Task DeleteMenuItem(MenuItem menuItem)
        {
            await _connection.DeleteAsync(menuItem);
        }
        public async Task<List<Restaurant>> GetRestaurants()
        {
            return await _connection.Table<Restaurant>().ToListAsync();
        }
        public async Task<Restaurant> GetRestaurantById(int id)
        {
            return await _connection.Table<Restaurant>().Where(x => x.RestaurantId == id).FirstOrDefaultAsync();
        }
        public async Task CreateRestaurant(Restaurant restaurant)
        {
            await _connection.InsertAsync(restaurant);
        }
        public async Task UpdateRestaurant(Restaurant restaurant)
        {
            await _connection.UpdateAsync(restaurant);
        }
        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            await _connection.DeleteAsync(restaurant);
        }
    }
}
