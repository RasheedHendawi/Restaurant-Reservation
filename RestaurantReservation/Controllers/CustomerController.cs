using RestaurantReservation.Services;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservation.Controllers
{
    public class CustomerController
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task AddCustomer()
        {
            Console.WriteLine("Enter First Name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            var email = Console.ReadLine();

            Console.WriteLine("Enter Phone Number:");
            var phoneNumber = Console.ReadLine();

            var newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            await _customerService.AddCustomerAsync(newCustomer);
            Console.WriteLine("Customer added successfully!");
        }

        public async Task ListAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Phone: {customer.PhoneNumber}");
            }
        }

        public async Task GetCustomerById()
        {
            Console.WriteLine("Enter Customer ID:");
            if (int.TryParse(Console.ReadLine(), out var customerId))
            {
                try
                {
                    var customer = await _customerService.GetCustomerByIdAsync(customerId);
                    Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Phone: {customer.PhoneNumber}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Customer ID.");
            }
        }

        public async Task UpdateCustomer()
        {
            Console.WriteLine("Enter Customer ID to Update:");
            if (int.TryParse(Console.ReadLine(), out var customerId))
            {
                try
                {
                    var customer = await _customerService.GetCustomerByIdAsync(customerId);

                    Console.WriteLine($"Updating Customer: {customer.FirstName} {customer.LastName}");

                    Console.WriteLine("Enter New First Name (leave blank to keep current):");
                    var firstName = Console.ReadLine();
                    customer.FirstName = string.IsNullOrWhiteSpace(firstName) ? customer.FirstName : firstName;

                    Console.WriteLine("Enter New Last Name (leave blank to keep current):");
                    var lastName = Console.ReadLine();
                    customer.LastName = string.IsNullOrWhiteSpace(lastName) ? customer.LastName : lastName;

                    Console.WriteLine("Enter New Email (leave blank to keep current):");
                    var email = Console.ReadLine();
                    customer.Email = string.IsNullOrWhiteSpace(email) ? customer.Email : email;

                    Console.WriteLine("Enter New Phone Number (leave blank to keep current):");
                    var phoneNumber = Console.ReadLine();
                    customer.PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? customer.PhoneNumber : phoneNumber;

                    await _customerService.UpdateCustomerAsync(customer);
                    Console.WriteLine("Customer updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Customer ID.");
            }
        }

        public async Task DeleteCustomer()
        {
            Console.WriteLine("Enter Customer ID to Delete:");
            if (int.TryParse(Console.ReadLine(), out var customerId))
            {
                try
                {
                    await _customerService.DeleteCustomerAsync(customerId);
                    Console.WriteLine("Customer deleted successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Customer ID.");
            }
        }
        public async Task ShowCustomersWithLargePartySizeAsync(int partySize)
        {
            var customers = await _customerService.GetCustomersWithLargePartySizeAsync(partySize);
            Console.WriteLine($"Customers with party size greater than {partySize}:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Phone: {customer.PhoneNumber}");
            }
        }
    }
}
