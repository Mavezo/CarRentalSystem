using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Vehicles;
using CarRentalSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalSystem.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly IModelService _modelService;

        public CarsController(ICarService carService, IBrandService brandService, IModelService modelService)
        {
            _carService = carService;
            _brandService = brandService;
            _modelService = modelService;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string searchString, int? brandId, int? modelId, 
            CarAvailability? status, decimal? minPrice, decimal? maxPrice)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["BrandId"] = brandId;
            ViewData["ModelId"] = modelId;
            ViewData["Status"] = status;
            ViewData["MinPrice"] = minPrice;
            ViewData["MaxPrice"] = maxPrice;

            // Get all brands and models for filter dropdowns
            var brands = await _brandService.GetAllBrandsAsync();
            var models = await _modelService.GetAllModelsAsync();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
            ViewBag.Models = new SelectList(models, "Id", "ModelName");

            var cars = await _carService.SearchCarsAsync(searchString, brandId, modelId, status, minPrice, maxPrice);

            return View(cars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carService.GetCarWithDetailsAsync(id.Value);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            var models = await _modelService.GetAllModelsAsync();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
            ViewBag.Models = new SelectList(models, "Id", "ModelName");
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelId,RegistrationNumber,Mileage,AvailabilityStatus,DailyPrice,Location")] Car car)
        {
            if (ModelState.IsValid)
            {
                if (await _carService.RegistrationNumberExistsAsync(car.RegistrationNumber))
                {
                    ModelState.AddModelError("RegistrationNumber", "A car with this registration number already exists.");
                    var brands = await _brandService.GetAllBrandsAsync();
                    var models = await _modelService.GetAllModelsAsync();
                    ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
                    ViewBag.Models = new SelectList(models, "Id", "ModelName", car.ModelId);
                    return View(car);
                }

                await _carService.CreateCarAsync(car);
                TempData["SuccessMessage"] = $"Car {car.RegistrationNumber} has been successfully added.";
                
                return RedirectToAction(nameof(Index));
            }

            var brandsList = await _brandService.GetAllBrandsAsync();
            var modelsList = await _modelService.GetAllModelsAsync();
            ViewBag.Brands = new SelectList(brandsList, "Id", "BrandName");
            ViewBag.Models = new SelectList(modelsList, "Id", "ModelName", car.ModelId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carService.GetCarByIdAsync(id.Value);

            if (car == null)
            {
                return NotFound();
            }

            var brands = await _brandService.GetAllBrandsAsync();
            var models = await _modelService.GetAllModelsAsync();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName", car.Model?.BrandId);
            ViewBag.Models = new SelectList(models, "Id", "ModelName", car.ModelId);
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelId,RegistrationNumber,Mileage,AvailabilityStatus,DailyPrice,Location")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _carService.RegistrationNumberExistsAsync(car.RegistrationNumber, id))
                {
                    ModelState.AddModelError("RegistrationNumber", "A car with this registration number already exists.");
                    var brands = await _brandService.GetAllBrandsAsync();
                    var models = await _modelService.GetAllModelsAsync();
                    ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
                    ViewBag.Models = new SelectList(models, "Id", "ModelName", car.ModelId);
                    return View(car);
                }

                await _carService.UpdateCarAsync(car);
                TempData["SuccessMessage"] = $"Car {car.RegistrationNumber} has been successfully updated.";
                return RedirectToAction(nameof(Index));
            }

            var brandsList = await _brandService.GetAllBrandsAsync();
            var modelsList = await _modelService.GetAllModelsAsync();
            ViewBag.Brands = new SelectList(brandsList, "Id", "BrandName");
            ViewBag.Models = new SelectList(modelsList, "Id", "ModelName", car.ModelId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carService.GetCarWithDetailsAsync(id.Value);
            
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            
            if (car == null)
            {
                return NotFound();
            }

            if (!await _carService.CanDeleteCarAsync(id))
            {
                TempData["ErrorMessage"] = $"Cannot delete car {car.RegistrationNumber} because it has associated rental(s) in the system.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            await _carService.DeleteCarAsync(id);
            TempData["SuccessMessage"] = $"Car {car.RegistrationNumber} has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }

        // API endpoint to get models by brand
        [HttpGet]
        public async Task<JsonResult> GetModelsByBrand(int brandId)
        {
            var models = await _carService.GetModelsByBrandAsync(brandId);
            var modelsList = models.Select(m => new { id = m.Id, name = m.ModelName }).ToList();
            return Json(modelsList);
        }
    }
}
