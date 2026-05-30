using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Vehicles;
using CarRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<CarService> _logger;

        public CarService(CarRentalContext context, ILogger<CarService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Include(c => c.Model)
                    .ThenInclude(m => m!.Brand)
                .Include(c => c.Insurance)
                .OrderBy(c => c.Model!.Brand!.BrandName)
                .ThenBy(c => c.Model!.ModelName)
                .ToListAsync();
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            return await _context.Cars
                .Include(c => c.Model)
                    .ThenInclude(m => m!.Brand)
                .Include(c => c.Insurance)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car?> GetCarWithDetailsAsync(int id)
        {
            return await _context.Cars
                .Include(c => c.Model!.Brand)
                .Include(c => c.Insurance)
                .Include(c => c.Repairs!)
                    .ThenInclude(r => r.ServiceCenter)
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Client)
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Employee)
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Payments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Car>> SearchCarsAsync(string? searchString, int? brandId, int? modelId, 
            CarAvailability? status, decimal? minPrice, decimal? maxPrice)
        {
            var cars = _context.Cars
                .Include(c => c.Model)
                    .ThenInclude(m => m!.Brand)
                .Include(c => c.Insurance)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(c => c.RegistrationNumber.Contains(searchString) 
                                    || (c.Location != null && c.Location.Contains(searchString))
                                    || c.Model!.ModelName.Contains(searchString)
                                    || c.Model.Brand!.BrandName.Contains(searchString));
            }

            if (brandId.HasValue)
            {
                cars = cars.Where(c => c.Model!.BrandId == brandId);
            }

            if (modelId.HasValue)
            {
                cars = cars.Where(c => c.ModelId == modelId);
            }

            if (status.HasValue)
            {
                cars = cars.Where(c => c.AvailabilityStatus == status);
            }

            if (minPrice.HasValue)
            {
                cars = cars.Where(c => c.DailyPrice >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                cars = cars.Where(c => c.DailyPrice <= maxPrice);
            }

            return await cars.OrderBy(c => c.Model!.Brand!.BrandName)
                            .ThenBy(c => c.Model!.ModelName)
                            .ToListAsync();
        }

        public async Task<bool> RegistrationNumberExistsAsync(string registrationNumber, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Cars
                    .AnyAsync(c => c.RegistrationNumber == registrationNumber && c.Id != excludeId);
            }

            return await _context.Cars.AnyAsync(c => c.RegistrationNumber == registrationNumber);
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New car created: {car.RegistrationNumber} (ID: {car.Id})");
            return car;
        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            _context.Update(car);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Car updated: {car.RegistrationNumber} (ID: {car.Id})");
            return car;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _context.Cars
                .Include(c => c.Rentals)
                .Include(c => c.Repairs)
                .Include(c => c.Insurance)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return false;
            }

            // Delete related insurance and repairs
            if (car.Insurance != null)
            {
                _context.Insurances.Remove(car.Insurance);
            }

            if (car.Repairs != null && car.Repairs.Any())
            {
                _context.Repairs.RemoveRange(car.Repairs);
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Car deleted: {car.RegistrationNumber} (ID: {car.Id})");
            return true;
        }

        public async Task<bool> CanDeleteCarAsync(int id)
        {
            var rentalsCount = await _context.Rentals
                .CountAsync(r => r.CarId == id);

            return rentalsCount == 0;
        }

        public async Task<List<Model>> GetModelsByBrandAsync(int brandId)
        {
            return await _context.Models
                .Where(m => m.BrandId == brandId)
                .OrderBy(m => m.ModelName)
                .ToListAsync();
        }
    }
}
