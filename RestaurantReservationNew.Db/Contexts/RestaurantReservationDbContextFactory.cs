using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantReservationNew.Db.Contexts
{
    public class RestaurantReservationDbContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
    {
        public RestaurantReservationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=RASHEEDHENDAWI\\SQLEXPRESS;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;");

            return new RestaurantReservationDbContext(optionsBuilder.Options);
        }
    }
}
