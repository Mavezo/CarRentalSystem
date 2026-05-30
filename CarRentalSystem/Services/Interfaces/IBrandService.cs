using CarRentalSystem.Entities.Vehicles;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllBrandsAsync();
        Task<Brand?> GetBrandByIdAsync(int id);
        Task<Brand?> GetBrandWithModelsAsync(int id);
        Task<List<string>> GetDistinctCountriesAsync();
        Task<List<string>> GetDistinctBodyTypesAsync();
        Task<List<Brand>> SearchBrandsAsync(string? searchString, string? country, string? bodyType);
        Task<bool> BrandNameExistsAsync(string brandName, int? excludeId = null);
        Task<Brand> CreateBrandAsync(Brand brand);
        Task<Brand> UpdateBrandAsync(Brand brand);
        Task<bool> DeleteBrandAsync(int id);
        Task<bool> CanDeleteBrandAsync(int id);
        Task<int> GetModelsCountAsync(int brandId);
    }
}
