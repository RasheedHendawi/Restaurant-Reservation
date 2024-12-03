
namespace RestaurantReservationNew.Db.Entities
{
    public class Table
    {
        public int TableId { get; set; } // Primary Key
        public int RestaurantId { get; set; } // Foreign Key
        public int Capacity { get; set; }

        // Navigation Properties
        public Restaurant Restaurant { get; set; } // Many-to-One
        public ICollection<Reservation> Reservations { get; set; } // One-to-Many
    }

}
