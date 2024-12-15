using RestaurantReservation.Services;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservation.Controllers
{
    public class EmployeeController
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task ListAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Position: {employee.Position}, Restaurant ID: {employee.RestaurantId}");
            }
        }

        public async Task AddEmployee()
        {
            Console.WriteLine("Enter First Name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter Position:");
            var position = Console.ReadLine();

            Console.WriteLine("Enter Restaurant ID:");
            var restaurantId = int.Parse(Console.ReadLine());

            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Position = position,
                RestaurantId = restaurantId
            };

            await _employeeService.AddEmployeeAsync(employee);
            Console.WriteLine("Employee added successfully!");
        }

        public async Task GetEmployeeById()
        {
            Console.WriteLine("Enter Employee ID:");
            if (int.TryParse(Console.ReadLine(), out var employeeId))
            {
                try
                {
                    var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
                    Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Position: {employee.Position}, Restaurant ID: {employee.RestaurantId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
        }

        public async Task UpdateEmployee()
        {
            Console.WriteLine("Enter Employee ID to Update:");
            if (int.TryParse(Console.ReadLine(), out var employeeId))
            {
                try
                {
                    var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

                    Console.WriteLine($"Updating Employee: {employee.FirstName} {employee.LastName}");

                    Console.WriteLine("Enter New First Name (leave blank to keep current):");
                    var firstName = Console.ReadLine();
                    employee.FirstName = string.IsNullOrWhiteSpace(firstName) ? employee.FirstName : firstName;

                    Console.WriteLine("Enter New Last Name (leave blank to keep current):");
                    var lastName = Console.ReadLine();
                    employee.LastName = string.IsNullOrWhiteSpace(lastName) ? employee.LastName : lastName;

                    Console.WriteLine("Enter New Position (leave blank to keep current):");
                    var position = Console.ReadLine();
                    employee.Position = string.IsNullOrWhiteSpace(position) ? employee.Position : position;

                    Console.WriteLine("Enter New Restaurant ID (leave blank to keep current):");
                    var restaurantId = int.TryParse(Console.ReadLine(), out var newRestaurantId) ? newRestaurantId : employee.RestaurantId;
                    employee.RestaurantId = restaurantId;

                    await _employeeService.UpdateEmployeeAsync(employee);
                    Console.WriteLine("Employee updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
        }

        public async Task DeleteEmployee()
        {
            Console.WriteLine("Enter Employee ID to Delete:");
            if (int.TryParse(Console.ReadLine(), out var employeeId))
            {
                try
                {
                    await _employeeService.DeleteEmployeeAsync(employeeId);
                    Console.WriteLine("Employee deleted successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
        }

        public async Task ListManagers()
        {
            var managers = await _employeeService.GetManagersAsync();
            Console.WriteLine("Managers:");
            foreach (var manager in managers)
            {
                Console.WriteLine($"ID: {manager.EmployeeId}, Name: {manager.FirstName} {manager.LastName}, Position: {manager.Position}");
            }
        }

        public async Task ListEmployeeOrders()
        {
            Console.WriteLine("Enter Employee ID to View Orders:");
            if (int.TryParse(Console.ReadLine(), out var employeeId))
            {
                try
                {
                    var orders = await _employeeService.GetEmployeeOrdersAsync(employeeId);
                    Console.WriteLine("Orders:");
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
        }
        public async Task<List<EmployeeWithRestaurant>> GetEmployeesWithRestaurant()
        {
            return await _employeeService.GetEmployeesWithRestaurantAsync();
        }
    }
}
