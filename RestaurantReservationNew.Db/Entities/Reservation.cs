using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationNew.Db.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; } // Primary Key
        public int CustomerId { get; set; } // Foreign Key
        public int RestaurantId { get; set; } // Foreign Key
        public int? TableId { get; set; } // Foreign Key (nullable)
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; } // Many-to-One
        public Restaurant Restaurant { get; set; } // Many-to-One
        public Table Table { get; set; } // Many-to-One
        public ICollection<Order> Orders { get; set; } // One-to-Many
    }

}
