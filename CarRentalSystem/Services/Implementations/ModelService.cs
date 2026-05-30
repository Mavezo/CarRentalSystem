using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Vehicles;
using CarRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class ModelService : IModelService
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<ModelService> _logger;

        public ModelService(CarRentalContext context, ILogger<ModelService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Model>> GetAllModelsAsync()
        {
            return await _context.Models
                .Include(m => m.Brand)
                .OrderBy(m => m.Brand!.BrandName)
                .ThenBy(m => m.ModelName)
                .ToListAsync();
        }

        public async Task<Model?> GetModelByIdAsync(int id)
        {
            return await _context.Models
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Model?> GetModelWithBrandAsync(int id)
        {
            return await _context.Models
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Model>> SearchModelsAsync(string? searchString, int? brandId)
        {
            var models = _context.Models
                .Include(m => m.Brand)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                models = models.Where(m => m.ModelName.Contains(searchString) 
                                        || (m.Brand != null && m.Brand.BrandName.Contains(searchString)));
            }

            if (brandId.HasValue)
            {
                models = models.Where(m => m.BrandId == brandId);
            }

            return await models
                .OrderBy(m => m.Brand!.BrandName)
                .ThenBy(m => m.ModelName)
                .ToListAsync();
        }

        public async Task<bool> ModelNameExistsForBrandAsync(string modelName, int brandId, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Models
                    .AnyAsync(m => m.ModelName == modelName && m.BrandId == brandId && m.Id != excludeId);
            }

            return await _context.Models
                .AnyAsync(m => m.ModelName == modelName && m.BrandId == brandId);
        }

        public async Task<Model> CreateModelAsync(Model model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();

            var brand = await _context.Brands.FindAsync(model.BrandId);
            _logger.LogInformation($"New model created: {model.ModelName} (ID: {model.Id}) for brand {brand?.BrandName}");
            return model;
        }

        public async Task<Model> UpdateModelAsync(Model model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();

            var brand = await _context.Brands.FindAsync(model.BrandId);
            _logger.LogInformation($"Model updated: {model.ModelName} (ID: {model.Id}) for brand {brand?.BrandName}");
            return model;
        }

        public async Task<bool> DeleteModelAsync(int id)
        {
            var model = await _context.Models.FindAsync(id);

            if (model == null)
            {
                return false;
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Model deleted: {model.ModelName} (ID: {model.Id})");
            return true;
        }

        public async Task<bool> CanDeleteModelAsync(int id)
        {
            var carsCount = await _context.Cars
                .CountAsync(c => c.ModelId == id);

            return carsCount == 0;
        }

        public async Task<int> GetCarsCountAsync(int modelId)
        {
            return await _context.Cars
                .CountAsync(c => c.ModelId == modelId);
        }
    }
}
