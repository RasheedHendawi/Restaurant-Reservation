using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.CreateAsync(order);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return (List<Order>)await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<List<OrderItem>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _orderRepository.ListOrdersAndMenuItemsAsync(reservationId);
        }

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int restaurantId)
        {
            return await _orderRepository.ListOrderedMenuItemsAsync(restaurantId);
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _orderRepository.CalculateAvarageOrderAmountAsync(employeeId);
        }
    }
}
