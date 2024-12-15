using RestaurantReservation.Services;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservation.Controllers
{
    public class OrderItemController
    {
        private readonly OrderItemService _orderItemService;

        public OrderItemController(OrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // Display all order items
        public async Task ShowAllOrderItemsAsync()
        {
            try
            {
                List<OrderItem> orderItems = await _orderItemService.GetAllOrderItemsAsync();
                if (orderItems.Count > 0)
                {
                    Console.WriteLine("Order Items:");
                    foreach (var orderItem in orderItems)
                    {
                        Console.WriteLine($"Order Item ID: {orderItem.OrderItemId}, Order ID: {orderItem.OrderId}, Item ID: {orderItem.ItemId}, Quantity: {orderItem.Quantity}");
                    }
                }
                else
                {
                    Console.WriteLine("No order items available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching order items: {ex.Message}");
            }
        }

        // Add a new order item
        public async Task AddOrderItemAsync()
        {
            try
            {
                Console.WriteLine("Enter Order Item Details:");
                Console.Write("Order ID: ");
                int orderId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Menu Item ID: ");
                int itemId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                var orderItem = new OrderItem
                {
                    OrderId = orderId,
                    ItemId = itemId,
                    Quantity = quantity
                };

                await _orderItemService.CreateOrderItemAsync(orderItem);
                Console.WriteLine("Order Item added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order item: {ex.Message}");
            }
        }

        // Update an existing order item
        public async Task UpdateOrderItemAsync()
        {
            try
            {
                Console.Write("Enter Order Item ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var existingOrderItem = await _orderItemService.GetOrderItemByIdAsync(id);

                if (existingOrderItem != null)
                {
                    Console.WriteLine($"Current Order Item: Order ID: {existingOrderItem.OrderId}, Menu Item ID: {existingOrderItem.ItemId}, Quantity: {existingOrderItem.Quantity}");
                    Console.Write("New Order ID (Leave blank to keep existing): ");
                    string newOrderIdInput = Console.ReadLine();
                    Console.Write("New Menu Item ID (Leave blank to keep existing): ");
                    string newItemIdInput = Console.ReadLine();
                    Console.Write("New Quantity (Leave blank to keep existing): ");
                    string newQuantityInput = Console.ReadLine();

                    existingOrderItem.OrderId = string.IsNullOrEmpty(newOrderIdInput) ? existingOrderItem.OrderId : Convert.ToInt32(newOrderIdInput);
                    existingOrderItem.ItemId = string.IsNullOrEmpty(newItemIdInput) ? existingOrderItem.ItemId : Convert.ToInt32(newItemIdInput);
                    existingOrderItem.Quantity = string.IsNullOrEmpty(newQuantityInput) ? existingOrderItem.Quantity : Convert.ToInt32(newQuantityInput);

                    await _orderItemService.UpdateOrderItemAsync(existingOrderItem);
                    Console.WriteLine("Order Item updated successfully.");
                }
                else
                {
                    Console.WriteLine("Order Item not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating order item: {ex.Message}");
            }
        }

        // Delete an order item
        public async Task DeleteOrderItemAsync()
        {
            try
            {
                Console.Write("Enter Order Item ID to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                await _orderItemService.DeleteOrderItemAsync(id);
                Console.WriteLine("Order Item deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting order item: {ex.Message}");
            }
        }
    }
}
