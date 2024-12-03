using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Contexts;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservationNew.Db.Repositories
{
    public class ResturantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ResturantRepository(RestaurantReservationDbContext context) 
        {
            _context = context;
        }

        public async Task<Restaurant> CreateResuaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }
        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
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

    }
}
