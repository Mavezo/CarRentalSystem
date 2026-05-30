using CarRentalSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: Brands
        public async Task<IActionResult> Index(string searchString, string country, string bodyType)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["Country"] = country;
            ViewData["BodyType"] = bodyType;

            // Get distinct countries and body types for filters
            ViewBag.Countries = await _brandService.GetDistinctCountriesAsync();
            ViewBag.BodyTypes = await _brandService.GetDistinctBodyTypesAsync();

            var brands = await _brandService.SearchBrandsAsync(searchString, country, bodyType);

            return View(brands);
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _brandService.GetBrandWithModelsAsync(id.Value);

            if (brand == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("Id,BrandName,Country,BodyType,Year,Transmission")] CarRentalSystem.Entities.Vehicles.Brand brand)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.BrandNameExistsAsync(brand.BrandName))
                {
                    ModelState.AddModelError("BrandName", "A brand with this name already exists.");
                    return View(brand);
                }

                await _brandService.CreateBrandAsync(brand);
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

            var brand = await _brandService.GetBrandByIdAsync(id.Value);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandName,Country,BodyType,Year,Transmission")] CarRentalSystem.Entities.Vehicles.Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _brandService.BrandNameExistsAsync(brand.BrandName, id))
                {
                    ModelState.AddModelError("BrandName", "A brand with this name already exists.");
                    return View(brand);
                }

                await _brandService.UpdateBrandAsync(brand);
                TempData["SuccessMessage"] = $"Brand '{brand.BrandName}' has been successfully updated.";
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

            var brand = await _brandService.GetBrandWithModelsAsync(id.Value);
            
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
            if (!await _brandService.CanDeleteBrandAsync(id))
            {
                var brand = await _brandService.GetBrandByIdAsync(id);
                var modelsCount = await _brandService.GetModelsCountAsync(id);
                TempData["ErrorMessage"] = $"Cannot delete brand '{brand?.BrandName}' because it has {modelsCount} model(s) associated with it. Please delete the models first.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            var deletedBrand = await _brandService.GetBrandByIdAsync(id);
            await _brandService.DeleteBrandAsync(id);
            TempData["SuccessMessage"] = $"Brand '{deletedBrand?.BrandName}' has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }
    }
}
