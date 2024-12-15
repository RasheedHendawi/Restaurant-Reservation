using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName) || string.IsNullOrWhiteSpace(customer.LastName))
                throw new ArgumentException("First name and last name are required.");

            await _customerRepository.CreateAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            if (customerId <= 0)
                throw new ArgumentException("Customer ID must be greater than zero.");

            return await _customerRepository.GetByIdAsync(customerId);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            if (customer == null || customer.CustomerId <= 0)
                throw new ArgumentException("Invalid customer information.");

            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            if (customerId <= 0)
                throw new ArgumentException("Customer ID must be greater than zero.");

            await _customerRepository.DeleteAsync(customerId);
        }
        public async Task<List<Customer>> GetCustomersWithLargePartySizeAsync(int partySize)
        {
            return await _customerRepository.GetCustomersWithLargePartySizeAsync(partySize);
        }
    }
}
