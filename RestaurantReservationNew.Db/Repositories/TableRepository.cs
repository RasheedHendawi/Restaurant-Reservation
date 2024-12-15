using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Contexts;

namespace RestaurantReservationNew.Db.Repositories
{
    public class TableRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table> GetByIdAsync(int id)
        {
            var table = await _context.Tables
                .FirstOrDefaultAsync(t => t.TableId == id);
            return table ?? throw new Exception("Table not found");
        }

        public async Task<Table> CreateAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return table;
        }

        public async Task<Table> UpdateAsync(int id, Table updatedTable)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) throw new Exception("Table not found");

            table.Capacity = updatedTable.Capacity;
            await _context.SaveChangesAsync();
            return table;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
