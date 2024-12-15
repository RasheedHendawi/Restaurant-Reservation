using RestaurantReservation.Services;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservation.Controllers
{
    public class OrderController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task ShowAllOrdersAsync()
        {
            try
            {
                List<Order> orders = await _orderService.GetAllOrdersAsync();
                if (orders.Count > 0)
                {
                    Console.WriteLine("Orders:");
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Order ID: {order.OrderId}, Reservation ID: {order.ReservationId}, Total Amount: {order.TotalAmount:C}");
                    }
                }
                else
                {
                    Console.WriteLine("No orders available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching orders: {ex.Message}");
            }
        }

        public async Task AddOrderAsync()
        {
            try
            {
                Console.WriteLine("Enter Order Details:");
                Console.Write("Reservation ID: ");
                int reservationId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Employee ID: ");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Order Date (yyyy-mm-dd): ");
                DateTime orderDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Total Amount: ");
                decimal totalAmount = Convert.ToDecimal(Console.ReadLine());

                var order = new Order
                {
                    ReservationId = reservationId,
                    EmployeeId = employeeId,
                    OrderDate = orderDate,
                    TotalAmount = totalAmount
                };

                await _orderService.CreateOrderAsync(order);
                Console.WriteLine("Order added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order: {ex.Message}");
            }
        }

        public async Task UpdateOrderAsync()
        {
            try
            {
                Console.Write("Enter Order ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var existingOrder = await _orderService.GetOrderByIdAsync(id);

                if (existingOrder != null)
                {
                    Console.WriteLine($"Current Order: Reservation ID: {existingOrder.ReservationId}, Employee ID: {existingOrder.EmployeeId}, Total Amount: {existingOrder.TotalAmount}");
                    Console.Write("New Reservation ID (Leave blank to keep existing): ");
                    string newReservationIdInput = Console.ReadLine();
                    Console.Write("New Employee ID (Leave blank to keep existing): ");
                    string newEmployeeIdInput = Console.ReadLine();
                    Console.Write("New Total Amount (Leave blank to keep existing): ");
                    string newTotalAmountInput = Console.ReadLine();

                    existingOrder.ReservationId = string.IsNullOrEmpty(newReservationIdInput) ? existingOrder.ReservationId : Convert.ToInt32(newReservationIdInput);
                    existingOrder.EmployeeId = string.IsNullOrEmpty(newEmployeeIdInput) ? existingOrder.EmployeeId : Convert.ToInt32(newEmployeeIdInput);
                    existingOrder.TotalAmount = string.IsNullOrEmpty(newTotalAmountInput) ? existingOrder.TotalAmount : Convert.ToDecimal(newTotalAmountInput);

                    await _orderService.UpdateOrderAsync(existingOrder);
                    Console.WriteLine("Order updated successfully.");
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating order: {ex.Message}");
            }
        }

        public async Task DeleteOrderAsync()
        {
            try
            {
                Console.Write("Enter Order ID to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                await _orderService.DeleteOrderAsync(id);
                Console.WriteLine("Order deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting order: {ex.Message}");
            }
        }
        public async Task ShowOrdersAndMenuItemsAsync()
        {
            try
            {
                Console.Write("Enter Reservation ID: ");
                int reservationId = Convert.ToInt32(Console.ReadLine());
                List<OrderItem> orderItems = await _orderService.ListOrdersAndMenuItemsAsync(reservationId);

                if (orderItems.Count > 0)
                {
                    Console.WriteLine("Order Items:");
                    foreach (var item in orderItems)
                    {
                        Console.WriteLine($"Menu Item: {item.MenuItem.Name}, Quantity: {item.Quantity}, Price: {item.MenuItem.Price:C}");
                    }
                }
                else
                {
                    Console.WriteLine("No order items found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching order items: {ex.Message}");
            }
        }

        public async Task ShowAverageOrderAmountAsync()
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                decimal averageAmount = await _orderService.CalculateAverageOrderAmountAsync(employeeId);
                Console.WriteLine($"Average Order Amount for Employee {employeeId}: {averageAmount:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating average order amount: {ex.Message}");
            }
        }
    }
}
