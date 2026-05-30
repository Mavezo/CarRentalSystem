using CarRentalSystem.Entities.Vehicles;

namespace CarRentalSystem.Services.Interfaces
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car?> GetCarByIdAsync(int id);
        Task<Car?> GetCarWithDetailsAsync(int id);
        Task<List<Car>> SearchCarsAsync(string? searchString, int? brandId, int? modelId, 
            CarAvailability? status, decimal? minPrice, decimal? maxPrice);
        Task<bool> RegistrationNumberExistsAsync(string registrationNumber, int? excludeId = null);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task<bool> DeleteCarAsync(int id);
        Task<bool> CanDeleteCarAsync(int id);
        Task<List<Model>> GetModelsByBrandAsync(int brandId);
    }
}
