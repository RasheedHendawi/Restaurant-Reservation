using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class TableService
    {
        private readonly TableRepository _tableRepository;

        public TableService(TableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<Table> CreateTableAsync(Table table)
        {
            return await _tableRepository.CreateAsync(table);
        }

        public async Task<Table> GetTableByIdAsync(int id)
        {
            return await _tableRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _tableRepository.GetAllAsync();
        }

        public async Task<Table> UpdateTableAsync(int id, Table updatedTable)
        {
            return await _tableRepository.UpdateAsync(id, updatedTable);
        }

        public async Task<bool> DeleteTableAsync(int id)
        {
            return await _tableRepository.DeleteAsync(id);
        }
    }
}
