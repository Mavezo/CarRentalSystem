using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Rentals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(CarRentalContext context, ILogger<PaymentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Payments
        public async Task<IActionResult> Index(int? rentalId, PaymentStatus? status, 
            PaymentMethod? method, DateTime? startDate, DateTime? endDate)
        {
            ViewData["RentalId"] = rentalId;
            ViewData["Status"] = status;
            ViewData["Method"] = method;
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;

            var payments = _context.Payments
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Client)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Car!.Model!.Brand)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Employee)
                .AsQueryable();

            // Apply filters
            if (rentalId.HasValue)
            {
                payments = payments.Where(p => p.RentalId == rentalId);
            }

            if (status.HasValue)
            {
                payments = payments.Where(p => p.Status == status);
            }

            if (method.HasValue)
            {
                payments = payments.Where(p => p.PaymentMethod == method);
            }

            if (startDate.HasValue)
            {
                payments = payments.Where(p => p.PaymentDate >= startDate);
            }

            if (endDate.HasValue)
            {
                payments = payments.Where(p => p.PaymentDate <= endDate);
            }

            return View(await payments.OrderByDescending(p => p.PaymentDate).ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Client)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Car!.Model!.Brand)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public async Task<IActionResult> Create(int? rentalId)
        {
            if (rentalId.HasValue)
            {
                var rental = await _context.Rentals
                    .Include(r => r.Client)
                    .Include(r => r.Car!.Model!.Brand)
                    .Include(r => r.Payments)
                    .FirstOrDefaultAsync(r => r.Id == rentalId);

                if (rental == null)
                {
                    TempData["ErrorMessage"] = "Rental not found.";
                    return RedirectToAction("Index", "Rentals");
                }

                ViewBag.Rental = rental;
                ViewBag.RentalId = rentalId;
            }
            else
            {
                // Load all active rentals for dropdown
                ViewBag.Rentals = new SelectList(
                    await _context.Rentals
                        .Include(r => r.Client)
                        .Include(r => r.Car!.Model!.Brand)
                        .Where(r => r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved)
                        .OrderByDescending(r => r.RentalDate)
                        .ToListAsync(),
                    "Id",
                    "Id");
            }

            return View();
        }

        // POST: Payments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RentalId,PaymentDate,Amount,PaymentMethod,Status")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                // Validate rental exists
                var rental = await _context.Rentals.FindAsync(payment.RentalId);
                if (rental == null)
                {
                    ModelState.AddModelError("RentalId", "Invalid rental selected.");
                    await PrepareCreateViewData(payment.RentalId);
                    return View(payment);
                }

                // Validate amount
                if (payment.Amount <= 0)
                {
                    ModelState.AddModelError("Amount", "Amount must be greater than zero.");
                    await PrepareCreateViewData(payment.RentalId);
                    return View(payment);
                }

                _context.Add(payment);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"New payment created: ID {payment.Id}, Rental {payment.RentalId}, Amount {payment.Amount:C}");
                TempData["SuccessMessage"] = $"Payment of {payment.Amount:C} has been successfully recorded.";

                return RedirectToAction(nameof(Details), new { id = payment.Id });
            }

            await PrepareCreateViewData(payment.RentalId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Client)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Car!.Model!.Brand)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null)
            {
                return NotFound();
            }

            ViewBag.Rental = payment.Rental;
            return View(payment);
        }

        // POST: Payments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentalId,PaymentDate,Amount,PaymentMethod,Status")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Validate amount
                    if (payment.Amount <= 0)
                    {
                        ModelState.AddModelError("Amount", "Amount must be greater than zero.");
                        var rental = await _context.Rentals
                            .Include(r => r.Client)
                            .Include(r => r.Car!.Model!.Brand)
                            .FirstOrDefaultAsync(r => r.Id == payment.RentalId);
                        ViewBag.Rental = rental;
                        return View(payment);
                    }

                    _context.Update(payment);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Payment updated: ID {payment.Id}, Status {payment.Status}");
                    TempData["SuccessMessage"] = "Payment has been successfully updated.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = payment.Id });
            }

            var rentalData = await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car!.Model!.Brand)
                .FirstOrDefaultAsync(r => r.Id == payment.RentalId);
            ViewBag.Rental = rentalData;
            return View(payment);
        }

        // API endpoint to get rental information
        [HttpGet]
        public async Task<JsonResult> GetRentalInfo(int rentalId)
        {
            var rental = await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car!.Model!.Brand)
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null)
            {
                return Json(new { success = false, message = "Rental not found" });
            }

            var totalPaid = rental.Payments?
                .Where(p => p.Status == PaymentStatus.Completed)
                .Sum(p => p.Amount) ?? 0;

            // Calculate rental duration and suggested amount
            var rentalDays = rental.ReturnDate.HasValue
                ? (rental.ReturnDate.Value - rental.RentalDate).Days
                : (DateTime.Now - rental.RentalDate).Days;

            if (rentalDays < 1) rentalDays = 1;

            var totalCost = rental.Car?.DailyPrice * rentalDays ?? 0;
            var remainingAmount = totalCost - totalPaid;

            return Json(new
            {
                success = true,
                clientName = $"{rental.Client?.FirstName} {rental.Client?.LastName}",
                carInfo = $"{rental.Car?.Model?.Brand?.BrandName} {rental.Car?.Model?.ModelName}",
                registrationNumber = rental.Car?.RegistrationNumber,
                rentalDate = rental.RentalDate.ToString("yyyy-MM-dd"),
                returnDate = rental.ReturnDate?.ToString("yyyy-MM-dd"),
                dailyPrice = rental.Car?.DailyPrice,
                rentalDays = rentalDays,
                totalCost = totalCost,
                totalPaid = totalPaid,
                remainingAmount = Math.Max(0, remainingAmount),
                status = rental.Status.ToString()
            });
        }

        private async Task PrepareCreateViewData(int? rentalId)
        {
            if (rentalId.HasValue)
            {
                var rental = await _context.Rentals
                    .Include(r => r.Client)
                    .Include(r => r.Car!.Model!.Brand)
                    .Include(r => r.Payments)
                    .FirstOrDefaultAsync(r => r.Id == rentalId);

                ViewBag.Rental = rental;
                ViewBag.RentalId = rentalId;
            }
            else
            {
                ViewBag.Rentals = new SelectList(
                    await _context.Rentals
                        .Include(r => r.Client)
                        .Include(r => r.Car!.Model!.Brand)
                        .Where(r => r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved)
                        .OrderByDescending(r => r.RentalDate)
                        .ToListAsync(),
                    "Id",
                    "Id");
            }
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
