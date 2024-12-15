using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Contexts;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservationNew.Db.Repositories
{
    public class EmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context) 
        { 
            _context=context;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task CreateAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            return employee ?? throw new Exception("Not Found Employee");
        }
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var tmp = await GetByIdAsync(id);
            if (tmp != null)
            {
                _context.Employees.Remove(tmp);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Employee>> ListManagersAsync()
        {
            return await _context.Employees.Where(tmp => tmp.Position=="Manager").ToListAsync();
        }
        public async Task<List<EmployeeWithRestaurant>> GetEmployeesWithRestaurantAsync()
        {
            return await _context.EmployeeWithRestaurant.ToListAsync();
        }
    }
}
