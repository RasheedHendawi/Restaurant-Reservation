using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Contexts;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservationNew.Db.Repositories
{
    public class RestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context) 
        {
            _context = context;
        }

        public async Task<Restaurant> CreateAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }
        public async Task<Restaurant> GetByIdAsync(int id)
        {
            var tmp = await _context.Restaurants.FirstOrDefaultAsync(m => m.RestaurantId == id);
            return tmp ?? throw new Exception("RestaurantId Not Found");
        }
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }
        public async Task<Restaurant> UpdateRestaurantAsyn(int id, Restaurant updateRestaurant)
        {
            var neededResturant = await _context.Restaurants.FindAsync(id)
                ?? throw new Exception("Not Valid Restaurant");
            neededResturant.Name = updateRestaurant.Name;
            neededResturant.Address = updateRestaurant.Address;
            neededResturant.PhoneNumber = updateRestaurant.PhoneNumber;
            neededResturant.OpeningHours = updateRestaurant.OpeningHours;
            await _context.SaveChangesAsync();
            return neededResturant;
        }
        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var neededRestaurant = await _context.Restaurants.FindAsync(id); 
            if(neededRestaurant == null)
                return false;
            _context.Restaurants.Remove(neededRestaurant);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<decimal> GetTotalRevenueAsync(int restaurantId)
        {
            var sql = $"SELECT dbo.CalculateRestaurantRevenue({restaurantId})";
            var revenue = await _context.Database.ExecuteSqlRawAsync(sql);

            return Convert.ToDecimal(revenue);
        }


    }
}
