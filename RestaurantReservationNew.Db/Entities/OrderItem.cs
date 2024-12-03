using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationNew.Db.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; } // Primary Key
        public int OrderId { get; set; } // Foreign Key
        public int ItemId { get; set; } // Foreign Key
        public int Quantity { get; set; }

        // Navigation Properties
        public Order Order { get; set; } // Many-to-One
        public MenuItem MenuItem { get; set; } // Many-to-One
    }

}
