using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Entities.Vehicles;
using CarRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class RentalService : IRentalService
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<RentalService> _logger;

        public RentalService(CarRentalContext context, ILogger<RentalService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Rental>> GetAllRentalsAsync()
        {
            return await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .Include(r => r.Employee)
                .Include(r => r.Payments)
                .OrderByDescending(r => r.RentalDate)
                .ToListAsync();
        }

        public async Task<Rental?> GetRentalByIdAsync(int id)
        {
            return await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rental?> GetRentalWithDetailsAsync(int id)
        {
            return await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Insurance)
                .Include(r => r.Employee)
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Rental>> SearchRentalsAsync(RentalStatus? status, DateTime? startDate, 
            DateTime? endDate, int? clientId, int? carId)
        {
            var rentals = _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .Include(r => r.Employee)
                .Include(r => r.Payments)
                .AsQueryable();

            if (status.HasValue)
            {
                rentals = rentals.Where(r => r.Status == status);
            }

            if (startDate.HasValue)
            {
                rentals = rentals.Where(r => r.RentalDate >= startDate);
            }

            if (endDate.HasValue)
            {
                rentals = rentals.Where(r => r.ReturnDate <= endDate);
            }

            if (clientId.HasValue)
            {
                rentals = rentals.Where(r => r.ClientId == clientId);
            }

            if (carId.HasValue)
            {
                rentals = rentals.Where(r => r.CarId == carId);
            }

            return await rentals.OrderByDescending(r => r.RentalDate).ToListAsync();
        }

        public async Task<Rental> CreateRentalAsync(Rental rental)
        {
            _context.Add(rental);
            await _context.SaveChangesAsync();

            var car = await _context.Cars
                .Include(c => c.Model)
                    .ThenInclude(m => m!.Brand)
                .FirstOrDefaultAsync(c => c.Id == rental.CarId);

            _logger.LogInformation($"New rental created: ID {rental.Id}, Car: {car?.Model?.Brand?.BrandName} {car?.Model?.ModelName}, Client ID: {rental.ClientId}");
            return rental;
        }

        public async Task<Rental> UpdateRentalAsync(Rental rental)
        {
            _context.Update(rental);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Rental updated: ID {rental.Id}, New status: {rental.Status}");
            return rental;
        }

        public async Task<bool> DeleteRentalAsync(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return false;
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Rental deleted: ID {rental.Id}");
            return true;
        }

        public async Task<bool> CanDeleteRentalAsync(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return false;
            }

            return rental.Payments == null || !rental.Payments.Any();
        }

        public async Task<bool> CompleteRentalAsync(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null || rental.Status != RentalStatus.Active)
            {
                return false;
            }

            rental.Status = RentalStatus.Completed;
            rental.ReturnDate = DateTime.Now;

            if (rental.Car != null)
            {
                var hasOtherRentals = await _context.Rentals
                    .AnyAsync(r => r.CarId == rental.CarId && 
                                 r.Id != rental.Id &&
                                 (r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved));

                if (!hasOtherRentals)
                {
                    rental.Car.AvailabilityStatus = CarAvailability.Available;
                }
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Rental completed and returned: ID {rental.Id}");
            return true;
        }

        public async Task<bool> CancelRentalAsync(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null || !await CanCancelRentalAsync(id))
            {
                return false;
            }

            rental.Status = RentalStatus.Cancelled;

            if (rental.Car != null)
            {
                var hasOtherRentals = await _context.Rentals
                    .AnyAsync(r => r.CarId == rental.CarId && 
                                 r.Id != rental.Id &&
                                 (r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved));

                if (!hasOtherRentals)
                {
                    rental.Car.AvailabilityStatus = CarAvailability.Available;
                }
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Rental cancelled: ID {rental.Id}");
            return true;
        }

        public async Task<bool> HasOverlappingRentalsAsync(int carId, DateTime rentalDate, DateTime returnDate, int? excludeRentalId = null)
        {
            var query = _context.Rentals
                .Where(r => r.CarId == carId && 
                           r.Status != RentalStatus.Cancelled &&
                           r.Status != RentalStatus.Completed);

            if (excludeRentalId.HasValue)
            {
                query = query.Where(r => r.Id != excludeRentalId);
            }

            return await query.AnyAsync(r => 
                (rentalDate >= r.RentalDate && rentalDate < r.ReturnDate) ||
                (returnDate > r.RentalDate && returnDate <= r.ReturnDate) ||
                (rentalDate <= r.RentalDate && returnDate >= r.ReturnDate));
        }

        public async Task<bool> CanCancelRentalAsync(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return false;
            }

            return rental.Status != RentalStatus.Completed && rental.Status != RentalStatus.Cancelled;
        }
    }
}
