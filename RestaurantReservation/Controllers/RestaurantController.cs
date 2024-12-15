using RestaurantReservation.Services;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservation.Controllers
{
    public class RestaurantController
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task ShowAllRestaurantsAsync()
        {
            try
            {
                var restaurants = await _restaurantService.GetAllRestaurantsAsync();
                if (restaurants != null)
                {
                    foreach (var restaurant in restaurants)
                    {
                        Console.WriteLine($"Restaurant ID: {restaurant.RestaurantId}, Name: {restaurant.Name}, Address: {restaurant.Address}");
                    }
                }
                else
                {
                    Console.WriteLine("No restaurants available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching restaurants: {ex.Message}");
            }
        }

        public async Task CreateRestaurantAsync()
        {
            try
            {
                Console.WriteLine("Enter Restaurant Details:");

                Console.Write("Name: ");
                var name = Console.ReadLine();
                Console.Write("Address: ");
                var address = Console.ReadLine();
                Console.Write("Phone Number: ");
                var phoneNumber = Console.ReadLine();
                Console.Write("Opening Hours: ");
                var openingHours = Console.ReadLine();

                var restaurant = new Restaurant
                {
                    Name = name,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    OpeningHours = openingHours
                };

                var createdRestaurant = await _restaurantService.CreateRestaurantAsync(restaurant);
                Console.WriteLine($"Restaurant '{createdRestaurant.Name}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating restaurant: {ex.Message}");
            }
        }

        public async Task UpdateRestaurantAsync()
        {
            try
            {
                Console.Write("Enter Restaurant ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var existingRestaurant = await _restaurantService.GetRestaurantByIdAsync(id);

                if (existingRestaurant != null)
                {
                    Console.WriteLine($"Current Restaurant: Name: {existingRestaurant.Name}, Address: {existingRestaurant.Address}");
                    Console.Write("New Name (Leave blank to keep existing): ");
                    string newName = Console.ReadLine();
                    Console.Write("New Address (Leave blank to keep existing): ");
                    string newAddress = Console.ReadLine();
                    Console.Write("New Phone Number (Leave blank to keep existing): ");
                    string newPhoneNumber = Console.ReadLine();
                    Console.Write("New Opening Hours (Leave blank to keep existing): ");
                    string newOpeningHours = Console.ReadLine();

                    existingRestaurant.Name = string.IsNullOrEmpty(newName) ? existingRestaurant.Name : newName;
                    existingRestaurant.Address = string.IsNullOrEmpty(newAddress) ? existingRestaurant.Address : newAddress;
                    existingRestaurant.PhoneNumber = string.IsNullOrEmpty(newPhoneNumber) ? existingRestaurant.PhoneNumber : newPhoneNumber;
                    existingRestaurant.OpeningHours = string.IsNullOrEmpty(newOpeningHours) ? existingRestaurant.OpeningHours : newOpeningHours;

                    await _restaurantService.UpdateRestaurantAsync(id, existingRestaurant);
                    Console.WriteLine("Restaurant updated successfully.");
                }
                else
                {
                    Console.WriteLine("Restaurant not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating restaurant: {ex.Message}");
            }
        }

        public async Task DeleteRestaurantAsync()
        {
            try
            {
                Console.Write("Enter Restaurant ID to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                bool deleted = await _restaurantService.DeleteRestaurantAsync(id);
                if (deleted)
                {
                    Console.WriteLine("Restaurant deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Restaurant not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting restaurant: {ex.Message}");
            }
        }
        public async Task<decimal> GetTotalRevenueAsync(int restaurantId)
        {
            return await _restaurantService.GetTotalRevenueAsync(restaurantId);
        }
    }
}
