using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class OrderItemService
    {
        private readonly OrderItemRepository _orderItemRepository;

        public OrderItemService(OrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task CreateOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.CreateAsync(orderItem);
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync()
        {
            return (List<OrderItem>)await _orderItemRepository.GetAllAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await _orderItemRepository.GetByIdAsync(id);
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            await _orderItemRepository.DeleteAsync(id);
        }
    }
}
