using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Entities.Vehicles;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalSystem.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly ICarService _carService;
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;

        public RentalsController(IRentalService rentalService, ICarService carService, 
            IClientService clientService, IEmployeeService employeeService)
        {
            _rentalService = rentalService;
            _carService = carService;
            _clientService = clientService;
            _employeeService = employeeService;
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

            var rentals = await _rentalService.SearchRentalsAsync(status, startDate, endDate, clientId, carId);

            return View(rentals);
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _rentalService.GetRentalWithDetailsAsync(id.Value);

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
                var car = await _carService.GetCarByIdAsync(carId.Value);
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
        public async Task<IActionResult> Create(RentalFormModel formModel)
        {
            var rental = formModel.ToEntity();

            if (ModelState.IsValid)
            {
                // Check if car is available
                var car = await _carService.GetCarByIdAsync(rental.CarId);

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
                if (await _rentalService.HasOverlappingRentalsAsync(rental.CarId, rental.RentalDate, rental.ReturnDate.Value))
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

                await _rentalService.CreateRentalAsync(rental);
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

            var rental = await _rentalService.GetRentalByIdAsync(id.Value);

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
        public async Task<IActionResult> Edit(int id, RentalFormModel formModel)
        {
            var rental = formModel.ToEntity();

            if (id != rental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingRental = await _rentalService.GetRentalByIdAsync(id);

                if (existingRental == null)
                {
                    return NotFound();
                }

                var oldStatus = existingRental.Status;
                var car = await _carService.GetCarByIdAsync(existingRental.CarId);

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
                        var hasOtherRentals = await _rentalService.SearchRentalsAsync(null, null, null, null, car.Id);
                        var activeRentals = hasOtherRentals.Where(r => r.Id != rental.Id && 
                            (r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved)).Any();

                        if (!activeRentals)
                        {
                            car.AvailabilityStatus = CarAvailability.Available;
                        }
                    }
                }

                await _rentalService.UpdateRentalAsync(existingRental);
                TempData["SuccessMessage"] = "Rental successfully updated.";
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

            var rental = await _rentalService.GetRentalWithDetailsAsync(id.Value);

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
            if (!await _rentalService.CompleteRentalAsync(id))
            {
                return NotFound();
            }

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

            var rental = await _rentalService.GetRentalWithDetailsAsync(id.Value);

            if (rental == null)
            {
                return NotFound();
            }

            if (!await _rentalService.CanCancelRentalAsync(id.Value))
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
            if (!await _rentalService.CancelRentalAsync(id))
            {
                return NotFound();
            }

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

            var rental = await _rentalService.GetRentalWithDetailsAsync(id.Value);

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
            if (!await _rentalService.CanDeleteRentalAsync(id))
            {
                TempData["ErrorMessage"] = $"Cannot delete rental because it has associated payment(s). Please delete the payments first.";
                return RedirectToAction(nameof(Delete), new { id });
            }

            await _rentalService.DeleteRentalAsync(id);
            TempData["SuccessMessage"] = "Rental successfully deleted.";

            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdownsAsync(int? selectedClientId = null, int? selectedCarId = null)
        {
            // Clients dropdown
            var clients = await _clientService.GetAllClientsAsync();
            ViewData["ClientId"] = new SelectList(
                clients.Select(c => new
                {
                    c.Id,
                    FullName = c.FirstName + " " + c.LastName + " (" + c.Email + ")"
                }),
                "Id",
                "FullName",
                selectedClientId);

            // Available cars dropdown
            var allCars = await _carService.GetAllCarsAsync();
            var availableCars = allCars.Where(c => c.AvailabilityStatus == CarAvailability.Available || c.Id == selectedCarId).ToList();
            
            ViewData["CarId"] = new SelectList(
                availableCars.Select(c => new
                {
                    c.Id,
                    CarInfo = c.Model!.Brand!.BrandName + " " + c.Model.ModelName + 
                             " (" + c.RegistrationNumber + ") - " + c.DailyPrice + " PLN/day"
                }),
                "Id",
                "CarInfo",
                selectedCarId);

            // Employees dropdown
            var employees = await _employeeService.GetAllEmployeesAsync();
            ViewData["EmployeeId"] = new SelectList(
                employees.Select(e => new
                {
                    e.Id,
                    FullName = e.FirstName + " " + e.LastName + " - " + e.Position
                }),
                "Id",
                "FullName");
        }
    }
}
