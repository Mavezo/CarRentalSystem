using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Controllers
{
    public class ModelsController : Controller
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<ModelsController> _logger;

        public ModelsController(CarRentalContext context, ILogger<ModelsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Models
        public async Task<IActionResult> Index(string searchString, int? brandId)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["BrandId"] = brandId;

            // Get all brands for filter dropdown
            ViewBag.Brands = new SelectList(
                await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), 
                "Id", 
                "BrandName"
            );

            var models = _context.Models
                .Include(m => m.Brand)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(searchString))
            {
                models = models.Where(m => m.ModelName.Contains(searchString) 
                                        || (m.Brand != null && m.Brand.BrandName.Contains(searchString)));
            }

            if (brandId.HasValue)
            {
                models = models.Where(m => m.BrandId == brandId);
            }

            var modelsList = await models
                .OrderBy(m => m.Brand!.BrandName)
                .ThenBy(m => m.ModelName)
                .ToListAsync();

            // Get cars count for each model
            var modelCounts = await _context.Models
                .Select(m => new
                {
                    ModelId = m.Id,
                    CarsCount = _context.Cars.Count(c => c.ModelId == m.Id)
                })
                .ToListAsync();

            ViewBag.ModelCounts = modelCounts.ToDictionary(m => m.ModelId, m => m.CarsCount);

            return View(modelsList);
        }

        // GET: Models/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = new SelectList(
                await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), 
                "Id", 
                "BrandName"
            );
            return View();
        }

        // POST: Models/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelName,BrandId")] Model model)
        {
            if (ModelState.IsValid)
            {
                // Check if model name already exists for this brand
                if (await _context.Models.AnyAsync(m => m.ModelName == model.ModelName && m.BrandId == model.BrandId))
                {
                    ModelState.AddModelError("ModelName", "A model with this name already exists for the selected brand.");
                    ViewBag.Brands = new SelectList(
                        await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), 
                        "Id", 
                        "BrandName", 
                        model.BrandId
                    );
                    return View(model);
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                
                var brand = await _context.Brands.FindAsync(model.BrandId);
                _logger.LogInformation($"New model created: {model.ModelName} (ID: {model.Id}) for brand {brand?.BrandName}");
                TempData["SuccessMessage"] = $"Model '{model.ModelName}' has been successfully added.";
                
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Brands = new SelectList(
                await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), 
                "Id", 
                "BrandName", 
                model.BrandId
            );
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (model == null)
            {
                return NotFound();
            }

            ViewBag.Brands = new SelectList(
                await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), 
                "Id", 
                "BrandName", 
                model.BrandId
            );
            return View(model);
        }

        // POST: Models/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelName,BrandId")] Model model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if model name is being changed and if it's already taken by another model for this brand
                    var existingModel = await _context.Models
                        .FirstOrDefaultAsync(m => m.ModelName == model.ModelName && m.BrandId == model.BrandId && m.Id != model.Id);
                    
                    if (existingModel != null)
                    {
                        ModelState.AddModelError("ModelName", "A model with this name already exists for the selected brand.");
                        ViewBag.Brands = new SelectList(
                            await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), 
                            "Id", 
                            "BrandName", 
                            model.BrandId
                        );
                        return View(model);
                    }

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    
                    var brand = await _context.Brands.FindAsync(model.BrandId);
                    _logger.LogInformation($"Model updated: {model.ModelName} (ID: {model.Id}) for brand {brand?.BrandName}");
                    TempData["SuccessMessage"] = $"Model '{model.ModelName}' has been successfully updated.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.Id))
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
            
            ViewBag.Brands = new SelectList(
                await _context.Brands.OrderBy(b => b.BrandName).ToListAsync(), 
                "Id", 
                "BrandName", 
                model.BrandId
            );
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (model == null)
            {
                return NotFound();
            }

            // Get cars count for this model
            ViewBag.CarsCount = await _context.Cars.CountAsync(c => c.ModelId == id);

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Models
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (model == null)
            {
                return NotFound();
            }

            // Check if model has any cars
            var carsCount = await _context.Cars.CountAsync(c => c.ModelId == id);
            if (carsCount > 0)
            {
                TempData["ErrorMessage"] = $"Cannot delete model '{model.ModelName}' because it has {carsCount} car(s) associated with it. Please delete the cars first.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation($"Model deleted: {model.ModelName} (ID: {model.Id})");
            TempData["SuccessMessage"] = $"Model '{model.ModelName}' has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
            return _context.Models.Any(e => e.Id == id);
        }
    }
}
