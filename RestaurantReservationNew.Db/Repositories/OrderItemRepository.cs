using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Contexts;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservationNew.Db.Repositories
{
    public class OrderItemRepository(RestaurantReservationDbContext context)
    {
        private readonly RestaurantReservationDbContext _context = context;

        public async Task CreateAsync(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            var tmp = await _context.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == id);
            return tmp ?? throw new InvalidOperationException("OrderItem Not Found");
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await GetByIdAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}