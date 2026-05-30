using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Vehicles;
using CarRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<BrandService> _logger;

        public BrandService(CarRentalContext context, ILogger<BrandService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Brand>> GetAllBrandsAsync()
        {
            return await _context.Brands
                .Include(b => b.Models)
                .OrderBy(b => b.BrandName)
                .ToListAsync();
        }

        public async Task<Brand?> GetBrandByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<Brand?> GetBrandWithModelsAsync(int id)
        {
            return await _context.Brands
                .Include(b => b.Models)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<string>> GetDistinctCountriesAsync()
        {
            return await _context.Brands
                .Where(b => !string.IsNullOrEmpty(b.Country))
                .Select(b => b.Country)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync() ?? new List<string>();
        }

        public async Task<List<string>> GetDistinctBodyTypesAsync()
        {
            return await _context.Brands
                .Where(b => !string.IsNullOrEmpty(b.BodyType))
                .Select(b => b.BodyType)
                .Distinct()
                .OrderBy(b => b)
                .ToListAsync() ?? new List<string>();
        }

        public async Task<List<Brand>> SearchBrandsAsync(string? searchString, string? country, string? bodyType)
        {
            var brands = _context.Brands
                .Include(b => b.Models)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                brands = brands.Where(b => b.BrandName.Contains(searchString) 
                                        || (b.Country != null && b.Country.Contains(searchString)));
            }

            if (!string.IsNullOrEmpty(country))
            {
                brands = brands.Where(b => b.Country == country);
            }

            if (!string.IsNullOrEmpty(bodyType))
            {
                brands = brands.Where(b => b.BodyType == bodyType);
            }

            return await brands.OrderBy(b => b.BrandName).ToListAsync();
        }

        public async Task<bool> BrandNameExistsAsync(string brandName, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Brands
                    .AnyAsync(b => b.BrandName == brandName && b.Id != excludeId);
            }

            return await _context.Brands.AnyAsync(b => b.BrandName == brandName);
        }

        public async Task<Brand> CreateBrandAsync(Brand brand)
        {
            _context.Add(brand);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New brand created: {brand.BrandName} (ID: {brand.Id})");
            return brand;
        }

        public async Task<Brand> UpdateBrandAsync(Brand brand)
        {
            _context.Update(brand);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Brand updated: {brand.BrandName} (ID: {brand.Id})");
            return brand;
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            var brand = await _context.Brands
                .Include(b => b.Models)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
            {
                return false;
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Brand deleted: {brand.BrandName} (ID: {brand.Id})");
            return true;
        }

        public async Task<bool> CanDeleteBrandAsync(int id)
        {
            var brand = await _context.Brands
                .Include(b => b.Models)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
            {
                return false;
            }

            return brand.Models == null || !brand.Models.Any();
        }

        public async Task<int> GetModelsCountAsync(int brandId)
        {
            return await _context.Models
                .CountAsync(m => m.BrandId == brandId);
        }
    }
}
