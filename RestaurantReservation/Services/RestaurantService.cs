using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;

        public RestaurantService(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant)
        {
            return await _restaurantRepository.CreateAsync(restaurant);
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _restaurantRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _restaurantRepository.GetAllAsync();
        }

        public async Task<Restaurant> UpdateRestaurantAsync(int id, Restaurant updatedRestaurant)
        {
            return await _restaurantRepository.UpdateRestaurantAsyn(id, updatedRestaurant);
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            return await _restaurantRepository.DeleteRestaurantAsync(id);
        }
        public async Task<decimal> GetTotalRevenueAsync(int restaurantId)
        {
            return await _restaurantRepository.GetTotalRevenueAsync(restaurantId);
        }
    }
}
