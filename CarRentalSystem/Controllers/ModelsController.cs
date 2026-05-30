using CarRentalSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalSystem.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IModelService _modelService;
        private readonly IBrandService _brandService;

        public ModelsController(IModelService modelService, IBrandService brandService)
        {
            _modelService = modelService;
            _brandService = brandService;
        }

        // GET: Models
        public async Task<IActionResult> Index(string searchString, int? brandId)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["BrandId"] = brandId;

            // Get all brands for filter dropdown
            var brands = await _brandService.GetAllBrandsAsync();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName");

            var models = await _modelService.SearchModelsAsync(searchString, brandId);

            // Get cars count for each model
            var modelCounts = new Dictionary<int, int>();
            foreach (var model in models)
            {
                modelCounts[model.Id] = await _modelService.GetCarsCountAsync(model.Id);
            }
            ViewBag.ModelCounts = modelCounts;

            return View(models);
        }

        // GET: Models/Create
        public async Task<IActionResult> Create()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
            return View();
        }

        // POST: Models/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelName,BrandId")] CarRentalSystem.Entities.Vehicles.Model model)
        {
            if (ModelState.IsValid)
            {
                if (await _modelService.ModelNameExistsForBrandAsync(model.ModelName, model.BrandId))
                {
                    ModelState.AddModelError("ModelName", "A model with this name already exists for the selected brand.");
                    var brands = await _brandService.GetAllBrandsAsync();
                    ViewBag.Brands = new SelectList(brands, "Id", "BrandName", model.BrandId);
                    return View(model);
                }

                await _modelService.CreateModelAsync(model);
                TempData["SuccessMessage"] = $"Model '{model.ModelName}' has been successfully added.";
                
                return RedirectToAction(nameof(Index));
            }
            
            var brandsList = await _brandService.GetAllBrandsAsync();
            ViewBag.Brands = new SelectList(brandsList, "Id", "BrandName", model.BrandId);
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _modelService.GetModelWithBrandAsync(id.Value);
            
            if (model == null)
            {
                return NotFound();
            }

            var brands = await _brandService.GetAllBrandsAsync();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName", model.BrandId);
            return View(model);
        }

        // POST: Models/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelName,BrandId")] CarRentalSystem.Entities.Vehicles.Model model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _modelService.ModelNameExistsForBrandAsync(model.ModelName, model.BrandId, id))
                {
                    ModelState.AddModelError("ModelName", "A model with this name already exists for the selected brand.");
                    var brands = await _brandService.GetAllBrandsAsync();
                    ViewBag.Brands = new SelectList(brands, "Id", "BrandName", model.BrandId);
                    return View(model);
                }

                await _modelService.UpdateModelAsync(model);
                TempData["SuccessMessage"] = $"Model '{model.ModelName}' has been successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            
            var brandsList = await _brandService.GetAllBrandsAsync();
            ViewBag.Brands = new SelectList(brandsList, "Id", "BrandName", model.BrandId);
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _modelService.GetModelWithBrandAsync(id.Value);
            
            if (model == null)
            {
                return NotFound();
            }

            // Get cars count for this model
            ViewBag.CarsCount = await _modelService.GetCarsCountAsync(id.Value);

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _modelService.GetModelByIdAsync(id);
            
            if (model == null)
            {
                return NotFound();
            }

            if (!await _modelService.CanDeleteModelAsync(id))
            {
                var carsCount = await _modelService.GetCarsCountAsync(id);
                TempData["ErrorMessage"] = $"Cannot delete model '{model.ModelName}' because it has {carsCount} car(s) associated with it. Please delete the cars first.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            await _modelService.DeleteModelAsync(id);
            TempData["SuccessMessage"] = $"Model '{model.ModelName}' has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }
    }
}
