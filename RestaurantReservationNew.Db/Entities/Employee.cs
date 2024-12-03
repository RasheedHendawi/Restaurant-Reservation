using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationNew.Db.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; } // Primary Key
        public int RestaurantId { get; set; } // Foreign Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        // Navigation Properties
        public Restaurant Restaurant { get; set; } // Many-to-One
        public ICollection<Order> Orders { get; set; } // One-to-Many
    }

}
