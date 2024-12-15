using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Entities;
namespace RestaurantReservationNew.Db.Contexts
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ReservationWithDetails> ReservationWithDetails { get; set; }
        public DbSet<EmployeeWithRestaurant> EmployeeWithRestaurant { get; set; }

        public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> option)
            : base(option) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<Table>()
                .HasOne(t => t.Restaurant)
                .WithMany(r => r.Tables)
                .HasForeignKey(t => t.RestaurantId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Restaurant)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RestaurantId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Reservation)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany(mi => mi.OrderItems)
                .HasForeignKey(oi => oi.ItemId);

            modelBuilder.Entity<MenuItem>()
                .HasKey(e => e.ItemId);

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.MenuItems)
                .HasForeignKey(m => m.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MenuItem>()
                .HasMany(m => m.OrderItems)
                .WithOne(r => r.MenuItem)
                .HasForeignKey(m => m.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("DECIMAL(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("DECIMAL(18, 2)");


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReservationWithDetails>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vw_ReservationsWithDetails");
            });

            modelBuilder.Entity<EmployeeWithRestaurant>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vw_EmployeesWithRestaurant");
            });

            modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890" },
            new Customer { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "2345678901" },
            new Customer { CustomerId = 3, FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com", PhoneNumber = "3456789012" },
            new Customer { CustomerId = 4, FirstName = "Alice", LastName = "White", Email = "alice.white@example.com", PhoneNumber = "4567890123" },
            new Customer { CustomerId = 5, FirstName = "Tom", LastName = "Black", Email = "tom.black@example.com", PhoneNumber = "5678901234" }
            );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { RestaurantId = 1, Name = "The Gourmet Spot", Address = "123 Main Street", PhoneNumber = "9876543210", OpeningHours = "9 AM - 10 PM" },
                new Restaurant { RestaurantId = 2, Name = "Pizza Palace", Address = "456 Elm Street", PhoneNumber = "8765432109", OpeningHours = "11 AM - 11 PM" },
                new Restaurant { RestaurantId = 3, Name = "Sushi Central", Address = "789 Oak Street", PhoneNumber = "7654321098", OpeningHours = "12 PM - 9 PM" },
                new Restaurant { RestaurantId = 4, Name = "Steakhouse Deluxe", Address = "321 Pine Street", PhoneNumber = "6543210987", OpeningHours = "10 AM - 10 PM" },
                new Restaurant { RestaurantId = 5, Name = "Vegan Haven", Address = "654 Maple Street", PhoneNumber = "5432109876", OpeningHours = "8 AM - 8 PM" }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantId = 1, Capacity = 2 },
                new Table { TableId = 3, RestaurantId = 2, Capacity = 6 },
                new Table { TableId = 4, RestaurantId = 3, Capacity = 8 },
                new Table { TableId = 5, RestaurantId = 4, Capacity = 10 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "Michael", LastName = "Johnson", Position = "Manager" },
                new Employee { EmployeeId = 2, RestaurantId = 2, FirstName = "Emily", LastName = "Davis", Position = "Chef" },
                new Employee { EmployeeId = 3, RestaurantId = 3, FirstName = "Chris", LastName = "Wilson", Position = "Waiter" },
                new Employee { EmployeeId = 4, RestaurantId = 4, FirstName = "Anna", LastName = "Brown", Position = "Host" },
                new Employee { EmployeeId = 5, RestaurantId = 5, FirstName = "David", LastName = "Clark", Position = "Manager" }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { ItemId = 1, RestaurantId = 1, Name = "Burger", Description = "Delicious beef burger", Price = 8.99M },
                new MenuItem { ItemId = 2, RestaurantId = 2, Name = "Pizza Margherita", Description = "Classic Italian pizza", Price = 10.99M },
                new MenuItem { ItemId = 3, RestaurantId = 3, Name = "Sushi Roll", Description = "Fresh sushi rolls", Price = 12.99M },
                new MenuItem { ItemId = 4, RestaurantId = 4, Name = "Steak", Description = "Juicy steak", Price = 15.99M },
                new MenuItem { ItemId = 5, RestaurantId = 5, Name = "Vegan Salad", Description = "Healthy vegan salad", Price = 9.99M }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = new DateTime(2024, 12, 3), PartySize = 4 },
                new Reservation { ReservationId = 2, CustomerId = 2, RestaurantId = 2, TableId = 3, ReservationDate = new DateTime(2024, 12, 4), PartySize = 2 },
                new Reservation { ReservationId = 3, CustomerId = 3, RestaurantId = 3, TableId = 4, ReservationDate = new DateTime(2024, 12, 5), PartySize = 6 },
                new Reservation { ReservationId = 4, CustomerId = 4, RestaurantId = 4, TableId = 5, ReservationDate = new DateTime(2024, 12, 6), PartySize = 8 },
                new Reservation { ReservationId = 5, CustomerId = 5, RestaurantId = 5, TableId = 2, ReservationDate = new DateTime(2024, 12, 7), PartySize = 10 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = new DateTime(2024, 12, 3), TotalAmount = 45.99M },
                new Order { OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = new DateTime(2024, 12, 4), TotalAmount = 20.99M },
                new Order { OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = new DateTime(2024, 12, 5), TotalAmount = 70.50M },
                new Order { OrderId = 4, ReservationId = 4, EmployeeId = 4, OrderDate = new DateTime(2024, 12, 6), TotalAmount = 90.00M },
                new Order { OrderId = 5, ReservationId = 5, EmployeeId = 5, OrderDate = new DateTime(2024, 12, 7), TotalAmount = 120.75M }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1, Quantity = 2 },
                new OrderItem { OrderItemId = 2, OrderId = 2, ItemId = 2, Quantity = 1 },
                new OrderItem { OrderItemId = 3, OrderId = 3, ItemId = 3, Quantity = 3 },
                new OrderItem { OrderItemId = 4, OrderId = 4, ItemId = 4, Quantity = 2 },
                new OrderItem { OrderItemId = 5, OrderId = 5, ItemId = 5, Quantity = 4 }
            );
        }
    }
}
