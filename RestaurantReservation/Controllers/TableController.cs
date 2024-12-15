using RestaurantReservation.Services;
using RestaurantReservationNew.Db.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Controllers
{
    public class TableController
    {
        private readonly TableService _tableService;

        public TableController(TableService tableService)
        {
            _tableService = tableService;
        }

        // Show all tables
        public async Task ShowAllTablesAsync()
        {
            try
            {
                var tables = await _tableService.GetAllTablesAsync();
                if (tables != null)
                {
                    foreach (var table in tables)
                    {
                        Console.WriteLine($"Table ID: {table.TableId}, Capacity: {table.Capacity}");
                    }
                }
                else
                {
                    Console.WriteLine("No tables available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tables: {ex.Message}");
            }
        }

        // Create a new table
        public async Task CreateTableAsync()
        {
            try
            {
                Console.WriteLine("Enter Table Details:");

                Console.Write("Capacity: ");
                var capacity = Convert.ToInt32(Console.ReadLine());

                var table = new Table
                {
                    Capacity = capacity
                };

                var createdTable = await _tableService.CreateTableAsync(table);
                Console.WriteLine($"Table with Capacity {createdTable.Capacity} created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating table: {ex.Message}");
            }
        }

        // Update an existing table
        public async Task UpdateTableAsync()
        {
            try
            {
                Console.Write("Enter Table ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var existingTable = await _tableService.GetTableByIdAsync(id);

                if (existingTable != null)
                {
                    Console.WriteLine($"Current Table: Capacity: {existingTable.Capacity}");
                    Console.Write("New Capacity: ");
                    int newCapacity = Convert.ToInt32(Console.ReadLine());

                    existingTable.Capacity = newCapacity;

                    await _tableService.UpdateTableAsync(id, existingTable);
                    Console.WriteLine("Table updated successfully.");
                }
                else
                {
                    Console.WriteLine("Table not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating table: {ex.Message}");
            }
        }

        // Delete a table
        public async Task DeleteTableAsync()
        {
            try
            {
                Console.Write("Enter Table ID to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                bool deleted = await _tableService.DeleteTableAsync(id);
                if (deleted)
                {
                    Console.WriteLine("Table deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Table not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting table: {ex.Message}");
            }
        }
    }
}
