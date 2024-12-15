using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Contexts;
using RestaurantReservationNew.Db.Repositories;
using RestaurantReservation.Services;
using RestaurantReservation.Controllers;
using Microsoft.Extensions.Configuration;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<RestaurantReservationDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

        services.Scan(scan => scan
            .FromAssemblyOf<CustomerRepository>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
            .AsSelf()
            .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<CustomerService>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            .AsSelf()
            .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<CustomerController>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Controller")))
            .AsSelf()
            .WithScopedLifetime());

        services.AddLogging(config => config.AddConsole());
    })
    .Build();


var serviceProvider = host.Services;
var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Application started.");

var customerController = serviceProvider.GetRequiredService<CustomerController>();
var employeeController = serviceProvider.GetRequiredService<EmployeeController>();
var menuItemController = serviceProvider.GetRequiredService<MenuItemController>();
var orderController = serviceProvider.GetRequiredService<OrderController>();
var orderItemController = serviceProvider.GetRequiredService<OrderItemController>();
var restaurantController = serviceProvider.GetRequiredService<RestaurantController>();
var reservationController = serviceProvider.GetRequiredService<ReservationController>();
var tableController = serviceProvider.GetRequiredService<TableController>();

Console.WriteLine("Welcome to the Restaurant Reservation System");

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nSelect an option:");
    Console.WriteLine("1. Manage Restaurants");
    Console.WriteLine("2. Manage Tables");
    Console.WriteLine("3. Manage Reservations");
    Console.WriteLine("4. Manage Orders");
    Console.WriteLine("5. Manage Menu Items");
    Console.WriteLine("6. Manage Customers");
    Console.WriteLine("7. Manage Employees");
    Console.WriteLine("8. Show Reservation Details");
    Console.WriteLine("9. Show Employee Details");
    Console.WriteLine("10. Show Restaurant Revenue");
    Console.WriteLine("11. Show Customers with Large Party Size");
    Console.WriteLine("12. Exit");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            await ManageEntity(restaurantController, "Restaurant", new Func<Task>[]
            {
                restaurantController.ShowAllRestaurantsAsync,
                restaurantController.CreateRestaurantAsync,
                restaurantController.UpdateRestaurantAsync,
                restaurantController.DeleteRestaurantAsync
            });
            break;
        case "2":
            await ManageEntity(tableController, "Table", new Func<Task>[]
            {
                tableController.ShowAllTablesAsync,
                tableController.CreateTableAsync,
                tableController.UpdateTableAsync,
                tableController.DeleteTableAsync
            });
            break;
        case "3":
            await ManageEntity(reservationController, "Reservation", new Func<Task>[]
            {
                reservationController.ShowAllReservationsAsync,
                reservationController.CreateReservationAsync,
                reservationController.UpdateReservationAsync,
                reservationController.DeleteReservationAsync
            });
            break;
        case "4":
            await ManageEntity(orderController, "Order", new Func<Task>[]
            {
                orderController.ShowAllOrdersAsync,
                orderController.AddOrderAsync,
                orderController.UpdateOrderAsync,
                orderController.DeleteOrderAsync
            });
            break;
        case "5":
            await ManageEntity(menuItemController, "Menu Item", new Func<Task>[]
            {
                menuItemController.ShowAllMenuItemsAsync,
                menuItemController.UpdateMenuItemAsync,
                menuItemController.DeleteMenuItemAsync
            });
            break;
        case "6":
            await ManageEntity(customerController, "Customer", new Func<Task>[]
            {
                customerController.ListAllCustomers,
                customerController.AddCustomer,
                customerController.UpdateCustomer,
                customerController.DeleteCustomer
            });
            break;
        case "7":
            await ManageEntity(employeeController, "Employee", new Func<Task>[]
            {
                employeeController.ListAllEmployees,
                employeeController.AddEmployee,
                employeeController.UpdateEmployee,
                employeeController.DeleteEmployee
            });
            break;
        case "8":
            await ShowReservationsWithDetails();
            break;
        case "9":
            await ShowEmployeesWithRestaurant();
            break;
        case "10":
            await CalculateRestaurantRevenue();
            break;
        case "11":
            await ShowCustomersWithLargePartySize();
            break;
        case "12":
            exit = true;
            Console.WriteLine("Exiting application...");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

async Task ManageEntity<TController>(TController controller, string entityName, Func<Task>[] actions) where TController : class
{
    Console.WriteLine($"{entityName} Management:");
    Console.WriteLine("1. Show All");
    Console.WriteLine("2. Create");
    Console.WriteLine("3. Update");
    Console.WriteLine("4. Delete");

    var choice = Console.ReadLine();

    if (int.TryParse(choice, out int index) && index >= 1 && index <= actions.Length)
    {
        try
        {
            await actions[index - 1]();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"An error occurred while managing {entityName.ToLower()}.");
            Console.WriteLine($"An error occurred while managing {entityName.ToLower()}: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }
}
async Task ShowReservationsWithDetails()
{
    Console.WriteLine("Fetching reservations with customer and restaurant details...");
    var reservations = await reservationController.GetReservationsWithDetails();
    foreach (var reservation in reservations)
    {
        Console.WriteLine($"Reservation ID: {reservation.ReservationId}, " +
                          $"Customer: {reservation.CustomerName}, " +
                          $"Restaurant: {reservation.RestaurantName}, " +
                          $"Date: {reservation.ReservationDate}");
    }
}
async Task ShowEmployeesWithRestaurant()
{
    Console.WriteLine("Fetching employees with restaurant details...");
    var employees = await employeeController.GetEmployeesWithRestaurant();
    foreach (var employee in employees)
    {
        Console.WriteLine($"Employee ID: {employee.EmployeeId}, " +
                          $"Name: {employee.EmployeeName}, " +
                          $"Restaurant: {employee.RestaurantName}, " +
                          $"Position: {employee.Position}");
    }
}
async Task CalculateRestaurantRevenue()
{
    Console.Write("Enter the Restaurant ID: ");
    if (int.TryParse(Console.ReadLine(), out int restaurantId))
    {
        try
        {
            var revenue = await restaurantController.GetTotalRevenueAsync(restaurantId);
            Console.WriteLine($"Total Revenue for Restaurant ID {restaurantId}: {revenue:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating revenue: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Invalid Restaurant ID. Please enter a valid number.");
    }
}
async Task ShowCustomersWithLargePartySize()
{
    Console.Write("Enter the minimum party size: ");
    if (int.TryParse(Console.ReadLine(), out int partySize))
    {
        await customerController.ShowCustomersWithLargePartySizeAsync(partySize);
    }
    else
    {
        Console.WriteLine("Invalid party size. Please enter a valid number.");
    }
}


