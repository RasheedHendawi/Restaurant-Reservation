using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class MenuItemService
    {
        private readonly MenuItemRepository _menuItemRepository;

        public MenuItemService(MenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.CreateAsync(menuItem);
        }

        public async Task<List<MenuItem>> GetAllMenuItemsAsync()
        {
            return (List<MenuItem>)await _menuItemRepository.GetAllAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            return await _menuItemRepository.GetByIdAsync(id);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.UpdateAsync(menuItem);
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            await _menuItemRepository.DeleteAsync(id);
        }
    }
}
