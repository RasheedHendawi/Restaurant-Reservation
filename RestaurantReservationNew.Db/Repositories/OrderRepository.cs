using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Contexts;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservationNew.Db.Repositories
{
    public class OrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context) 
        {
            _context = context;
        }
        public async Task CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order =  await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            return order ?? throw new Exception("Order Not Found");
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<OrderItem>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _context.OrderItems
                .Where(e => e.Order.ReservationId == reservationId)
                .Include(e => e.MenuItem)
                .ToListAsync();
        }
        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int restaurantId)
        {
            return await _context.OrderItems.Where(e=> e.Order.ReservationId == restaurantId)
                .Select(e => e.MenuItem)
                .ToListAsync();
        }
        public async Task<decimal> CalculateAvarageOrderAmountAsync(int employeeId)
        {
            var employeeOrders = await _context.Orders.Where(e=> e.EmployeeId == employeeId)
                .Include(e => e.OrderItems).ToListAsync();
            var totalEmpOrders = employeeOrders.Count;

            if(totalEmpOrders == 0) return 0;

            decimal amount = 0;
            foreach (var order in employeeOrders)
            {
                amount += order.OrderItems.Sum(s => s.MenuItem.Price * s.Quantity);
            }
            return amount/ totalEmpOrders;
        }

    }
}
