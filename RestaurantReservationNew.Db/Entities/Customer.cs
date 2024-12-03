using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationNew.Db.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; } // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation Properties
        public ICollection<Reservation> Reservations { get; set; } // One-to-Many
    }

}
