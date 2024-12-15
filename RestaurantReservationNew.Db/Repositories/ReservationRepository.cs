using Microsoft.EntityFrameworkCore;
using RestaurantReservationNew.Db.Contexts;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservationNew.Db.Repositories
{
    public class ReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
        public async Task CreateAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task<Reservation> GetByIdAsync(int id)
        {
             var reservation = await _context.Reservations.FirstOrDefaultAsync(e => e.ReservationId == id);
            return reservation ?? throw new Exception("Reservation Not Found");
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var res = await GetByIdAsync(id);
            if (res != null)
            {
                _context.Reservations.Remove(res);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _context.Reservations.Where(e => e.CustomerId==customerId).ToListAsync();
        }

        public async Task<List<ReservationWithDetails>> GetReservationsWithDetailsAsync()
        {
            return await _context.ReservationWithDetails.ToListAsync();
        }
    }
}
