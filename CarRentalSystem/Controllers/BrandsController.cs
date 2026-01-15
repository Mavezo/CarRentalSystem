using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Controllers
{
    public class BrandsController : Controller
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<BrandsController> _logger;

        public BrandsController(CarRentalContext context, ILogger<BrandsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Brands
        public async Task<IActionResult> Index(string searchString, string country, string bodyType)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["Country"] = country;
            ViewData["BodyType"] = bodyType;

            // Get distinct countries and body types for filters
            ViewBag.Countries = await _context.Brands
                .Where(b => !string.IsNullOrEmpty(b.Country))
                .Select(b => b.Country)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            ViewBag.BodyTypes = await _context.Brands
                .Where(b => !string.IsNullOrEmpty(b.BodyType))
                .Select(b => b.BodyType)
                .Distinct()
                .OrderBy(b => b)
                .ToListAsync();

            var brands = _context.Brands
                .Include(b => b.Models)
                .AsQueryable();

            // Apply filters
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

            return View(await brands.OrderBy(b => b.BrandName).ToListAsync());
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .Include(b => b.Models)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (brand == null)
            {
                return NotFound();
            }

            // Get cars count for each model
            var modelCounts = await _context.Models
                .Where(m => m.BrandId == id)
                .Select(m => new
                {
                    ModelId = m.Id,
                    CarsCount = _context.Cars.Count(c => c.ModelId == m.Id)
                })
                .ToListAsync();

            ViewBag.ModelCounts = modelCounts.ToDictionary(m => m.ModelId, m => m.CarsCount);

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandName,Country,BodyType,Year,Transmission")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                // Check if brand name already exists
                if (await _context.Brands.AnyAsync(b => b.BrandName == brand.BrandName))
                {
                    ModelState.AddModelError("BrandName", "A brand with this name already exists.");
                    return View(brand);
                }

                _context.Add(brand);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation($"New brand created: {brand.BrandName} (ID: {brand.Id})");
                TempData["SuccessMessage"] = $"Brand '{brand.BrandName}' has been successfully added.";
                
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandName,Country,BodyType,Year,Transmission")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if brand name is being changed and if it's already taken by another brand
                    var existingBrand = await _context.Brands
                        .FirstOrDefaultAsync(b => b.BrandName == brand.BrandName && b.Id != brand.Id);
                    
                    if (existingBrand != null)
                    {
                        ModelState.AddModelError("BrandName", "A brand with this name already exists.");
                        return View(brand);
                    }

                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                    
                    _logger.LogInformation($"Brand updated: {brand.BrandName} (ID: {brand.Id})");
                    TempData["SuccessMessage"] = $"Brand '{brand.BrandName}' has been successfully updated.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .Include(b => b.Models)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _context.Brands
                .Include(b => b.Models)
                .FirstOrDefaultAsync(b => b.Id == id);
            
            if (brand == null)
            {
                return NotFound();
            }

            // Check if brand has any models
            if (brand.Models != null && brand.Models.Any())
            {
                TempData["ErrorMessage"] = $"Cannot delete brand '{brand.BrandName}' because it has {brand.Models.Count} model(s) associated with it. Please delete the models first.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation($"Brand deleted: {brand.BrandName} (ID: {brand.Id})");
            TempData["SuccessMessage"] = $"Brand '{brand.BrandName}' has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
    }
}
