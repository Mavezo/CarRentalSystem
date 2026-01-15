using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Entities.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Controllers
{
    public class RentalsController : Controller
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<RentalsController> _logger;

        public RentalsController(CarRentalContext context, ILogger<RentalsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Rentals
        public async Task<IActionResult> Index(RentalStatus? status, DateTime? startDate, 
            DateTime? endDate, int? clientId, int? carId)
        {
            ViewData["Status"] = status;
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;
            ViewData["ClientId"] = clientId;
            ViewData["CarId"] = carId;

            var rentals = _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .Include(r => r.Employee)
                .Include(r => r.Payments)
                .AsQueryable();

            // Apply filters
            if (status.HasValue)
            {
                rentals = rentals.Where(r => r.Status == status);
            }

            if (startDate.HasValue)
            {
                rentals = rentals.Where(r => r.RentalDate >= startDate);
            }

            if (endDate.HasValue)
            {
                rentals = rentals.Where(r => r.ReturnDate <= endDate);
            }

            if (clientId.HasValue)
            {
                rentals = rentals.Where(r => r.ClientId == clientId);
            }

            if (carId.HasValue)
            {
                rentals = rentals.Where(r => r.CarId == carId);
            }

            return View(await rentals.OrderByDescending(r => r.RentalDate).ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Insurance)
                .Include(r => r.Employee)
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public async Task<IActionResult> Create(int? clientId, int? carId)
        {
            await PopulateDropdownsAsync(clientId, carId);
            
            var rental = new Rental
            {
                RentalDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(1),
                Status = RentalStatus.Reserved
            };

            if (clientId.HasValue)
            {
                rental.ClientId = clientId.Value;
            }

            if (carId.HasValue)
            {
                rental.CarId = carId.Value;
                var car = await _context.Cars.FindAsync(carId.Value);
                if (car != null)
                {
                    ViewData["DailyPrice"] = car.DailyPrice;
                }
            }

            return View(rental);
        }

        // POST: Rentals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,ClientId,EmployeeId,RentalDate,ReturnDate,Status")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                // Check if car is available
                var car = await _context.Cars
                    .Include(c => c.Model)
                        .ThenInclude(m => m!.Brand)
                    .FirstOrDefaultAsync(c => c.Id == rental.CarId);

                if (car == null)
                {
                    ModelState.AddModelError("CarId", "Selected car not found.");
                    await PopulateDropdownsAsync(rental.ClientId, rental.CarId);
                    return View(rental);
                }

                if (car.AvailabilityStatus != CarAvailability.Available)
                {
                    ModelState.AddModelError("CarId", $"Car is not available. Current status: {car.AvailabilityStatus}");
                    await PopulateDropdownsAsync(rental.ClientId, rental.CarId);
                    return View(rental);
                }

                // Check date validity
                if (rental.ReturnDate <= rental.RentalDate)
                {
                    ModelState.AddModelError("ReturnDate", "Return date must be after rental date.");
                    await PopulateDropdownsAsync(rental.ClientId, rental.CarId);
                    return View(rental);
                }

                // Check for overlapping rentals
                var hasOverlap = await _context.Rentals
                    .Where(r => r.CarId == rental.CarId && 
                               r.Status != RentalStatus.Cancelled &&
                               r.Status != RentalStatus.Completed)
                    .AnyAsync(r => 
                        (rental.RentalDate >= r.RentalDate && rental.RentalDate < r.ReturnDate) ||
                        (rental.ReturnDate > r.RentalDate && rental.ReturnDate <= r.ReturnDate) ||
                        (rental.RentalDate <= r.RentalDate && rental.ReturnDate >= r.ReturnDate));

                if (hasOverlap)
                {
                    ModelState.AddModelError("", "This car has overlapping rental dates.");
                    await PopulateDropdownsAsync(rental.ClientId, rental.CarId);
                    return View(rental);
                }

                // Update car status based on rental status
                if (rental.Status == RentalStatus.Active)
                {
                    car.AvailabilityStatus = CarAvailability.Rented;
                }
                else if (rental.Status == RentalStatus.Reserved)
                {
                    car.AvailabilityStatus = CarAvailability.Reserved;
                }

                _context.Add(rental);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"New rental created: ID {rental.Id}, Car: {car.Model?.Brand?.BrandName} {car.Model?.ModelName}, Client ID: {rental.ClientId}");
                TempData["SuccessMessage"] = $"Rental successfully created for {car.Model?.Brand?.BrandName} {car.Model?.ModelName}";

                return RedirectToAction(nameof(Details), new { id = rental.Id });
            }

            await PopulateDropdownsAsync(rental.ClientId, rental.CarId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            await PopulateDropdownsAsync(rental.ClientId, rental.CarId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,ClientId,EmployeeId,RentalDate,ReturnDate,Status")] Rental rental)
        {
            if (id != rental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingRental = await _context.Rentals
                        .Include(r => r.Car)
                        .FirstOrDefaultAsync(r => r.Id == id);

                    if (existingRental == null)
                    {
                        return NotFound();
                    }

                    var oldStatus = existingRental.Status;
                    var car = existingRental.Car;

                    // Check date validity
                    if (rental.ReturnDate <= rental.RentalDate)
                    {
                        ModelState.AddModelError("ReturnDate", "Return date must be after rental date.");
                        await PopulateDropdownsAsync(rental.ClientId, rental.CarId);
                        return View(rental);
                    }

                    // Update rental
                    existingRental.ClientId = rental.ClientId;
                    existingRental.EmployeeId = rental.EmployeeId;
                    existingRental.RentalDate = rental.RentalDate;
                    existingRental.ReturnDate = rental.ReturnDate;
                    existingRental.Status = rental.Status;

                    // Update car status if rental status changed
                    if (oldStatus != rental.Status && car != null)
                    {
                        if (rental.Status == RentalStatus.Active)
                        {
                            car.AvailabilityStatus = CarAvailability.Rented;
                        }
                        else if (rental.Status == RentalStatus.Reserved)
                        {
                            car.AvailabilityStatus = CarAvailability.Reserved;
                        }
                        else if (rental.Status == RentalStatus.Completed || rental.Status == RentalStatus.Cancelled)
                        {
                            // Check if there are other active/reserved rentals for this car
                            var hasOtherRentals = await _context.Rentals
                                .AnyAsync(r => r.CarId == car.Id && 
                                             r.Id != rental.Id &&
                                             (r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved));

                            if (!hasOtherRentals)
                            {
                                car.AvailabilityStatus = CarAvailability.Available;
                            }
                        }
                    }

                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Rental updated: ID {rental.Id}, New status: {rental.Status}");
                    TempData["SuccessMessage"] = "Rental successfully updated.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = rental.Id });
            }

            await PopulateDropdownsAsync(rental.ClientId, rental.CarId);
            return View(rental);
        }

        // GET: Rentals/Return/5
        public async Task<IActionResult> Return(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .Include(r => r.Employee)
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            if (rental.Status != RentalStatus.Active)
            {
                TempData["ErrorMessage"] = "Only active rentals can be returned.";
                return RedirectToAction(nameof(Details), new { id });
            }

            return View(rental);
        }

        // POST: Rentals/Return/5
        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnConfirmed(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            rental.Status = RentalStatus.Completed;
            rental.ReturnDate = DateTime.Now;

            if (rental.Car != null)
            {
                // Check if there are other active/reserved rentals for this car
                var hasOtherRentals = await _context.Rentals
                    .AnyAsync(r => r.CarId == rental.CarId && 
                                 r.Id != rental.Id &&
                                 (r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved));

                if (!hasOtherRentals)
                {
                    rental.Car.AvailabilityStatus = CarAvailability.Available;
                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Rental returned: ID {rental.Id}");
            TempData["SuccessMessage"] = "Car successfully returned.";

            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: Rentals/Cancel/5
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            if (rental.Status == RentalStatus.Completed || rental.Status == RentalStatus.Cancelled)
            {
                TempData["ErrorMessage"] = "Cannot cancel completed or already cancelled rentals.";
                return RedirectToAction(nameof(Details), new { id });
            }

            return View(rental);
        }

        // POST: Rentals/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            rental.Status = RentalStatus.Cancelled;

            if (rental.Car != null)
            {
                // Check if there are other active/reserved rentals for this car
                var hasOtherRentals = await _context.Rentals
                    .AnyAsync(r => r.CarId == rental.CarId && 
                                 r.Id != rental.Id &&
                                 (r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved));

                if (!hasOtherRentals)
                {
                    rental.Car.AvailabilityStatus = CarAvailability.Available;
                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Rental cancelled: ID {rental.Id}");
            TempData["SuccessMessage"] = "Rental successfully cancelled.";

            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car)
                    .ThenInclude(c => c!.Model)
                        .ThenInclude(m => m!.Brand)
                .Include(r => r.Employee)
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            // Check if rental has payments
            if (rental.Payments != null && rental.Payments.Any())
            {
                TempData["ErrorMessage"] = $"Cannot delete rental because it has {rental.Payments.Count} associated payment(s). Please delete the payments first.";
                return RedirectToAction(nameof(Delete), new { id });
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Rental deleted: ID {rental.Id}");
            TempData["SuccessMessage"] = "Rental successfully deleted.";

            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.Id == id);
        }

        private async Task PopulateDropdownsAsync(int? selectedClientId = null, int? selectedCarId = null)
        {
            // Clients dropdown
            ViewData["ClientId"] = new SelectList(
                await _context.Clients
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.FirstName)
                    .Select(c => new
                    {
                        c.Id,
                        FullName = c.FirstName + " " + c.LastName + " (" + c.Email + ")"
                    })
                    .ToListAsync(),
                "Id",
                "FullName",
                selectedClientId);

            // Available cars dropdown
            ViewData["CarId"] = new SelectList(
                await _context.Cars
                    .Include(c => c.Model)
                        .ThenInclude(m => m!.Brand)
                    .Where(c => c.AvailabilityStatus == CarAvailability.Available || c.Id == selectedCarId)
                    .OrderBy(c => c.Model!.Brand!.BrandName)
                    .ThenBy(c => c.Model!.ModelName)
                    .Select(c => new
                    {
                        c.Id,
                        CarInfo = c.Model!.Brand!.BrandName + " " + c.Model.ModelName + 
                                 " (" + c.RegistrationNumber + ") - " + c.DailyPrice + " PLN/day"
                    })
                    .ToListAsync(),
                "Id",
                "CarInfo",
                selectedCarId);

            // Employees dropdown
            ViewData["EmployeeId"] = new SelectList(
                await _context.Employees
                    .OrderBy(e => e.LastName)
                    .ThenBy(e => e.FirstName)
                    .Select(e => new
                    {
                        e.Id,
                        FullName = e.FirstName + " " + e.LastName + " - " + e.Position
                    })
                    .ToListAsync(),
                "Id",
                "FullName");
        }
    }
}
