namespace RestaurantReservationNew.Db.Entities
{
    public class MenuItem
    {
        public int ItemId { get; set; } // Primary Key
        public int RestaurantId { get; set; } // Foreign Key
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Navigation Properties
        public Restaurant Restaurant { get; set; } // Many-to-One
        public ICollection<OrderItem> OrderItems { get; set; } // One-to-Many
    }

}
