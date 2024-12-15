
namespace RestaurantReservationNew.Db.Entities
{
    public class EmployeeWithRestaurant
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Position { get; set; }
    }

}
