
namespace RestaurantReservationNew.Db.Entities
{
    public class Order
    {
        public int OrderId { get; set; } // Primary Key
        public int ReservationId { get; set; } // Foreign Key
        public int EmployeeId { get; set; } // Foreign Key
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Navigation Properties
        public Reservation Reservation { get; set; } // Many-to-One
        public Employee Employee { get; set; } // Many-to-One
        public ICollection<OrderItem> OrderItems { get; set; } // One-to-Many
    }

}
