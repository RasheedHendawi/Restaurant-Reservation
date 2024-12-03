using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationNew.Db.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OpeningHours { get; set; }

        // Navigation Properties
        public ICollection<Table> Tables { get; set; } // One-to-Many
        public ICollection<Employee> Employees { get; set; } // One-to-Many
        public ICollection<MenuItem> MenuItems { get; set; } // One-to-Many
        public ICollection<Reservation> Reservations { get; set; } // One-to-Many
    }

}
