using CarRentalSystem.Entities.Vehicles;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IModelService
    {
        Task<List<Model>> GetAllModelsAsync();
        Task<Model?> GetModelByIdAsync(int id);
        Task<Model?> GetModelWithBrandAsync(int id);
        Task<List<Model>> SearchModelsAsync(string? searchString, int? brandId);
        Task<bool> ModelNameExistsForBrandAsync(string modelName, int brandId, int? excludeId = null);
        Task<Model> CreateModelAsync(Model model);
        Task<Model> UpdateModelAsync(Model model);
        Task<bool> DeleteModelAsync(int id);
        Task<bool> CanDeleteModelAsync(int id);
        Task<int> GetCarsCountAsync(int modelId);
    }
}
