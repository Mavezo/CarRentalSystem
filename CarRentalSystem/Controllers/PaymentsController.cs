using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalSystem.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IRentalService _rentalService;

        public PaymentsController(IPaymentService paymentService, IRentalService rentalService)
        {
            _paymentService = paymentService;
            _rentalService = rentalService;
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

            var payments = await _paymentService.SearchPaymentsAsync(rentalId, status, method, startDate, endDate);

            return View(payments);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _paymentService.GetPaymentWithDetailsAsync(id.Value);

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
                var rental = await _rentalService.GetRentalWithDetailsAsync(rentalId.Value);

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
                var rentals = await _rentalService.SearchRentalsAsync(RentalStatus.Active, null, null, null, null);
                ViewBag.Rentals = new SelectList(rentals, "Id", "Id");
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
                var rental = await _rentalService.GetRentalByIdAsync(payment.RentalId);
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

                await _paymentService.CreatePaymentAsync(payment);
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

            var payment = await _paymentService.GetPaymentWithDetailsAsync(id.Value);

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
                // Validate amount
                if (payment.Amount <= 0)
                {
                    ModelState.AddModelError("Amount", "Amount must be greater than zero.");
                    var rental = await _rentalService.GetRentalWithDetailsAsync(payment.RentalId);
                    ViewBag.Rental = rental;
                    return View(payment);
                }

                await _paymentService.UpdatePaymentAsync(payment);
                TempData["SuccessMessage"] = "Payment has been successfully updated.";
                return RedirectToAction(nameof(Details), new { id = payment.Id });
            }

            var rentalData = await _rentalService.GetRentalWithDetailsAsync(payment.RentalId);
            ViewBag.Rental = rentalData;
            return View(payment);
        }

        // API endpoint to get rental information
        [HttpGet]
        public async Task<JsonResult> GetRentalInfo(int rentalId)
        {
            var paymentInfo = await _paymentService.GetRentalPaymentInfoAsync(rentalId);

            if (paymentInfo == null)
            {
                return Json(new { success = false, message = "Rental not found" });
            }

            return Json(new
            {
                success = true,
                clientName = paymentInfo.ClientName,
                carInfo = paymentInfo.CarInfo,
                registrationNumber = paymentInfo.RegistrationNumber,
                rentalDate = paymentInfo.RentalDate,
                returnDate = paymentInfo.ReturnDate,
                dailyPrice = paymentInfo.DailyPrice,
                rentalDays = paymentInfo.RentalDays,
                totalCost = paymentInfo.TotalCost,
                totalPaid = paymentInfo.TotalPaid,
                remainingAmount = paymentInfo.RemainingAmount,
                status = paymentInfo.Status
            });
        }

        private async Task PrepareCreateViewData(int? rentalId)
        {
            if (rentalId.HasValue)
            {
                var rental = await _rentalService.GetRentalWithDetailsAsync(rentalId.Value);
                ViewBag.Rental = rental;
                ViewBag.RentalId = rentalId;
            }
            else
            {
                var rentals = await _rentalService.SearchRentalsAsync(RentalStatus.Active, null, null, null, null);
                ViewBag.Rentals = new SelectList(rentals, "Id", "Id");
            }
        }
    }
}
