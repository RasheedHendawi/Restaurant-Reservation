using RestaurantReservation.Services;
using RestaurantReservationNew.Db.Entities;

namespace RestaurantReservation.Controllers
{
    public class ReservationController
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        public async Task ShowAllReservationsAsync()
        {
            try
            {
                List<Reservation> reservations = await _reservationService.GetAllReservationsAsync();
                if (reservations.Count > 0)
                {
                    Console.WriteLine("Reservations:");
                    foreach (var reservation in reservations)
                    {
                        Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Customer ID: {reservation.CustomerId}, Restaurant ID: {reservation.RestaurantId}, Party Size: {reservation.PartySize}, Date: {reservation.ReservationDate}");
                    }
                }
                else
                {
                    Console.WriteLine("No reservations available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching reservations: {ex.Message}");
            }
        }

        public async Task CreateReservationAsync()
        {
            try
            {
                Console.WriteLine("Enter Reservation Details:");
                Console.Write("Customer ID: ");
                int customerId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Restaurant ID: ");
                int restaurantId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Table ID (Leave blank for no specific table): ");
                int? tableId = string.IsNullOrEmpty(Console.ReadLine()) ? (int?)null : Convert.ToInt32(Console.ReadLine());
                Console.Write("Party Size: ");
                int partySize = Convert.ToInt32(Console.ReadLine());
                Console.Write("Reservation Date (yyyy-MM-dd): ");
                DateTime reservationDate = Convert.ToDateTime(Console.ReadLine());

                var reservation = new Reservation
                {
                    CustomerId = customerId,
                    RestaurantId = restaurantId,
                    TableId = tableId,
                    PartySize = partySize,
                    ReservationDate = reservationDate
                };

                await _reservationService.CreateReservationAsync(reservation);
                Console.WriteLine("Reservation created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating reservation: {ex.Message}");
            }
        }

        public async Task UpdateReservationAsync()
        {
            try
            {
                Console.Write("Enter Reservation ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var existingReservation = await _reservationService.GetReservationByIdAsync(id);

                if (existingReservation != null)
                {
                    Console.WriteLine($"Current Reservation: Customer ID: {existingReservation.CustomerId}, Restaurant ID: {existingReservation.RestaurantId}, Party Size: {existingReservation.PartySize}, Date: {existingReservation.ReservationDate}");
                    Console.Write("New Customer ID (Leave blank to keep existing): ");
                    string newCustomerIdInput = Console.ReadLine();
                    Console.Write("New Restaurant ID (Leave blank to keep existing): ");
                    string newRestaurantIdInput = Console.ReadLine();
                    Console.Write("New Table ID (Leave blank to keep existing): ");
                    string newTableIdInput = Console.ReadLine();
                    Console.Write("New Party Size (Leave blank to keep existing): ");
                    string newPartySizeInput = Console.ReadLine();
                    Console.Write("New Reservation Date (Leave blank to keep existing): ");
                    string newReservationDateInput = Console.ReadLine();

                    existingReservation.CustomerId = string.IsNullOrEmpty(newCustomerIdInput) ? existingReservation.CustomerId : Convert.ToInt32(newCustomerIdInput);
                    existingReservation.RestaurantId = string.IsNullOrEmpty(newRestaurantIdInput) ? existingReservation.RestaurantId : Convert.ToInt32(newRestaurantIdInput);
                    existingReservation.TableId = string.IsNullOrEmpty(newTableIdInput) ? existingReservation.TableId : Convert.ToInt32(newTableIdInput);
                    existingReservation.PartySize = string.IsNullOrEmpty(newPartySizeInput) ? existingReservation.PartySize : Convert.ToInt32(newPartySizeInput);
                    existingReservation.ReservationDate = string.IsNullOrEmpty(newReservationDateInput) ? existingReservation.ReservationDate : Convert.ToDateTime(newReservationDateInput);

                    await _reservationService.UpdateReservationAsync(existingReservation);
                    Console.WriteLine("Reservation updated successfully.");
                }
                else
                {
                    Console.WriteLine("Reservation not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating reservation: {ex.Message}");
            }
        }

        public async Task DeleteReservationAsync()
        {
            try
            {
                Console.Write("Enter Reservation ID to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                await _reservationService.DeleteReservationAsync(id);
                Console.WriteLine("Reservation deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting reservation: {ex.Message}");
            }
        }

        public async Task ShowReservationsByCustomerAsync()
        {
            try
            {
                Console.Write("Enter Customer ID: ");
                int customerId = Convert.ToInt32(Console.ReadLine());
                List<Reservation> reservations = await _reservationService.GetReservationsByCustomerAsync(customerId);

                if (reservations.Count > 0)
                {
                    Console.WriteLine("Reservations for Customer:");
                    foreach (var reservation in reservations)
                    {
                        Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Restaurant ID: {reservation.RestaurantId}, Party Size: {reservation.PartySize}, Date: {reservation.ReservationDate}");
                    }
                }
                else
                {
                    Console.WriteLine("No reservations found for this customer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching reservations by customer: {ex.Message}");
            }
        }

        public async Task<List<ReservationWithDetails>> GetReservationsWithDetails()
        {
            return await _reservationService.GetReservationsWithDetailsAsync();
        }

    }
}
