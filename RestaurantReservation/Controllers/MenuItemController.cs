using RestaurantReservation.Services;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservation.Controllers
{
    public class MenuItemController
    {
        private readonly MenuItemService _menuItemService;

        public MenuItemController(MenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public async Task ShowAllMenuItemsAsync()
        {
            try
            {
                List<MenuItem> menuItems = await _menuItemService.GetAllMenuItemsAsync();
                if (menuItems.Count > 0)
                {
                    Console.WriteLine("Menu Items:");
                    foreach (var item in menuItems)
                    {
                        Console.WriteLine($"ID: {item.ItemId}, Name: {item.Name}, Price: {item.Price:C}");
                    }
                }
                else
                {
                    Console.WriteLine("No menu items available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching menu items: {ex.Message}");
            }
        }

        public async Task AddMenuItemAsync()
        {
            try
            {
                Console.WriteLine("Enter Menu Item Details:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Description: ");
                string description = Console.ReadLine();
                Console.Write("Price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                var menuItem = new MenuItem
                {
                    Name = name,
                    Description = description,
                    Price = price
                };

                await _menuItemService.CreateMenuItemAsync(menuItem);
                Console.WriteLine("Menu item added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding menu item: {ex.Message}");
            }
        }

        public async Task UpdateMenuItemAsync()
        {
            try
            {
                Console.Write("Enter Menu Item ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var existingItem = await _menuItemService.GetMenuItemByIdAsync(id);

                if (existingItem != null)
                {
                    Console.WriteLine($"Current Name: {existingItem.Name}, Current Description: {existingItem.Description}, Current Price: {existingItem.Price}");
                    Console.Write("New Name (Leave blank to keep existing): ");
                    string newName = Console.ReadLine();
                    Console.Write("New Description (Leave blank to keep existing): ");
                    string newDescription = Console.ReadLine();
                    Console.Write("New Price (Leave blank to keep existing): ");
                    string newPriceInput = Console.ReadLine();

                    existingItem.Name = string.IsNullOrEmpty(newName) ? existingItem.Name : newName;
                    existingItem.Description = string.IsNullOrEmpty(newDescription) ? existingItem.Description : newDescription;
                    existingItem.Price = string.IsNullOrEmpty(newPriceInput) ? existingItem.Price : Convert.ToDecimal(newPriceInput);

                    await _menuItemService.UpdateMenuItemAsync(existingItem);
                    Console.WriteLine("Menu item updated successfully.");
                }
                else
                {
                    Console.WriteLine("Menu item not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating menu item: {ex.Message}");
            }
        }

        public async Task DeleteMenuItemAsync()
        {
            try
            {
                Console.Write("Enter Menu Item ID to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                await _menuItemService.DeleteMenuItemAsync(id);
                Console.WriteLine("Menu item deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting menu item: {ex.Message}");
            }
        }
    }
}
