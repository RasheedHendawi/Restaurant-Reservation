

namespace RestaurantReservationNew.Db.Entities
{
    public class ReservationWithDetails
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public DateTime ReservationDate { get; set; }
    }

}
