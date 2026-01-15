using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<CarsController> _logger;

        public CarsController(CarRentalContext context, ILogger<CarsController> logger)
        {
            _context = context;
            _logger = logger;
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
            ViewBag.Brands = new SelectList(await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), "Id", "BrandName");
            ViewBag.Models = new SelectList(await _context.Models.OrderBy(m => m.ModelName).ToListAsync(), "Id", "ModelName");

            var cars = _context.Cars
                .Include(c => c.Model)
                    .ThenInclude(m => m!.Brand)
                .Include(c => c.Insurance)
                .AsQueryable();

            // Apply filters
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

            return View(await cars.OrderBy(c => c.Model!.Brand!.BrandName)
                                 .ThenBy(c => c.Model!.ModelName)
                                 .ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
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
                .FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = new SelectList(await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), "Id", "BrandName");
            ViewBag.Models = new SelectList(await _context.Models.OrderBy(m => m.ModelName).ToListAsync(), "Id", "ModelName");
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelId,RegistrationNumber,Mileage,AvailabilityStatus,DailyPrice,Location")] Car car)
        {
            if (ModelState.IsValid)
            {
                // Check if registration number already exists
                if (await _context.Cars.AnyAsync(c => c.RegistrationNumber == car.RegistrationNumber))
                {
                    ModelState.AddModelError("RegistrationNumber", "A car with this registration number already exists.");
                    ViewBag.Brands = new SelectList(await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), "Id", "BrandName");
                    ViewBag.Models = new SelectList(await _context.Models.OrderBy(m => m.ModelName).ToListAsync(), "Id", "ModelName", car.ModelId);
                    return View(car);
                }

                _context.Add(car);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation($"New car created: {car.RegistrationNumber} (ID: {car.Id})");
                TempData["SuccessMessage"] = $"Car {car.RegistrationNumber} has been successfully added.";
                
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Brands = new SelectList(await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), "Id", "BrandName");
            ViewBag.Models = new SelectList(await _context.Models.OrderBy(m => m.ModelName).ToListAsync(), "Id", "ModelName", car.ModelId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Model)
                    .ThenInclude(m => m!.Brand)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            ViewBag.Brands = new SelectList(await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), "Id", "BrandName", car.Model?.BrandId);
            ViewBag.Models = new SelectList(await _context.Models.OrderBy(m => m.ModelName).ToListAsync(), "Id", "ModelName", car.ModelId);
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
                try
                {
                    // Check if registration number is being changed and if it's already taken by another car
                    var existingCar = await _context.Cars
                        .FirstOrDefaultAsync(c => c.RegistrationNumber == car.RegistrationNumber && c.Id != car.Id);
                    
                    if (existingCar != null)
                    {
                        ModelState.AddModelError("RegistrationNumber", "A car with this registration number already exists.");
                        ViewBag.Brands = new SelectList(await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), "Id", "BrandName");
                        ViewBag.Models = new SelectList(await _context.Models.OrderBy(m => m.ModelName).ToListAsync(), "Id", "ModelName", car.ModelId);
                        return View(car);
                    }

                    _context.Update(car);
                    await _context.SaveChangesAsync();
                    
                    _logger.LogInformation($"Car updated: {car.RegistrationNumber} (ID: {car.Id})");
                    TempData["SuccessMessage"] = $"Car {car.RegistrationNumber} has been successfully updated.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Brands = new SelectList(await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), "Id", "BrandName");
            ViewBag.Models = new SelectList(await _context.Models.OrderBy(m => m.ModelName).ToListAsync(), "Id", "ModelName", car.ModelId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Model)
                    .ThenInclude(m => m!.Brand)
                .Include(c => c.Rentals)
                .Include(c => c.Repairs)
                .Include(c => c.Insurance)
                .FirstOrDefaultAsync(m => m.Id == id);
            
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
            var car = await _context.Cars
                .Include(c => c.Rentals)
                .Include(c => c.Repairs)
                .Include(c => c.Insurance)
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (car == null)
            {
                return NotFound();
            }

            // Check if car has any rentals, repairs, or insurance
            if (car.Rentals != null && car.Rentals.Any())
            {
                TempData["ErrorMessage"] = $"Cannot delete car {car.RegistrationNumber} because it has {car.Rentals.Count} rental(s) in the system.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            // Delete related insurance and repairs first
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
            TempData["SuccessMessage"] = $"Car {car.RegistrationNumber} has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }

        // API endpoint to get models by brand
        [HttpGet]
        public async Task<JsonResult> GetModelsByBrand(int brandId)
        {
            var models = await _context.Models
                .Where(m => m.BrandId == brandId)
                .OrderBy(m => m.ModelName)
                .Select(m => new { id = m.Id, name = m.ModelName })
                .ToListAsync();

            return Json(models);
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
