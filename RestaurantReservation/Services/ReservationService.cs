using RestaurantReservationNew.Db.Entities;
using RestaurantReservationNew.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }


        public async Task CreateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.CreateAsync(reservation);
        }


        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return (List<Reservation>)await _reservationRepository.GetAllAsync();
        }


        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }


        public async Task UpdateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateAsync(reservation);
        }


        public async Task DeleteReservationAsync(int id)
        {
            await _reservationRepository.DeleteAsync(id);
        }

        
        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _reservationRepository.GetReservationsByCustomerAsync(customerId);
        }
        public async Task<List<ReservationWithDetails>> GetReservationsWithDetailsAsync()
        {
            return await _reservationRepository.GetReservationsWithDetailsAsync();
        }
    }
}
