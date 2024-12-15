using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentException("Employee ID must be greater than zero.");

            return await _employeeRepository.GetByIdAsync(employeeId);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.FirstName) || string.IsNullOrWhiteSpace(employee.LastName))
                throw new ArgumentException("First name and last name are required.");

            if (employee.RestaurantId <= 0)
                throw new ArgumentException("Restaurant ID must be valid.");

            await _employeeRepository.CreateAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null || employee.EmployeeId <= 0)
                throw new ArgumentException("Invalid employee details.");

            if (employee.RestaurantId <= 0)
                throw new ArgumentException("Restaurant ID must be valid.");

            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentException("Employee ID must be greater than zero.");

            await _employeeRepository.DeleteAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetManagersAsync()
        {
            return await _employeeRepository.ListManagersAsync();
        }

        public async Task<IEnumerable<Order>> GetEmployeeOrdersAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            return employee.Orders;
        }

        public async Task<List<EmployeeWithRestaurant>> GetEmployeesWithRestaurantAsync()
        {
            return await _employeeRepository.GetEmployeesWithRestaurantAsync();
        }
    }
}
