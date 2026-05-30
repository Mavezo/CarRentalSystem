using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Entities.Vehicles;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IRentalService
    {
        Task<List<Rental>> GetAllRentalsAsync();
        Task<Rental?> GetRentalByIdAsync(int id);
        Task<Rental?> GetRentalWithDetailsAsync(int id);
        Task<List<Rental>> SearchRentalsAsync(RentalStatus? status, DateTime? startDate, 
            DateTime? endDate, int? clientId, int? carId);
        Task<Rental> CreateRentalAsync(Rental rental);
        Task<Rental> UpdateRentalAsync(Rental rental);
        Task<bool> DeleteRentalAsync(int id);
        Task<bool> CanDeleteRentalAsync(int id);
        Task<bool> CompleteRentalAsync(int id);
        Task<bool> CancelRentalAsync(int id);
        Task<bool> HasOverlappingRentalsAsync(int carId, DateTime rentalDate, DateTime returnDate, int? excludeRentalId = null);
        Task<bool> CanCancelRentalAsync(int id);
    }
}
