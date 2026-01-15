using System.Diagnostics;
using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Entities.Vehicles;
using CarRentalSystem.Models;
using CarRentalSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarRentalContext _context;

        public HomeController(ILogger<HomeController> logger, CarRentalContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get current date (or specific date for demo - January 15, 2026)
            var currentDate = DateTime.Now;
            var currentMonth = currentDate.Month;
            var currentYear = currentDate.Year;
            var currentDay = currentDate.Day;
            
            // Log for debugging
            _logger.LogInformation($"Current Date: {currentDate}, Month: {currentMonth}, Year: {currentYear}, Day: {currentDay}");
            
            // Check all payments in database
            var allPayments = await _context.Payments.ToListAsync();
            _logger.LogInformation($"Total Payments in DB: {allPayments.Count}");
            foreach (var payment in allPayments)
            {
                _logger.LogInformation($"Payment #{payment.Id}: Date={payment.PaymentDate}, Amount={payment.Amount}, Status={payment.Status}");
            }
            
            // Calculate daily revenue for current month up to today
            var dailyRevenueData = new List<decimal>();
            var dailyLabels = new List<string>();
            
            for (int day = 1; day <= currentDay; day++)
            {
                var dayRevenue = await _context.Payments
                    .Where(p => p.PaymentDate.Day == day
                             && p.PaymentDate.Month == currentMonth
                             && p.PaymentDate.Year == currentYear
                             && p.Status == PaymentStatus.Completed)
                    .SumAsync(p => p.Amount);
                
                dailyRevenueData.Add(dayRevenue);
                dailyLabels.Add($"Jan {day}");
                
                _logger.LogInformation($"Day {day}: Revenue = ${dayRevenue}");
            }
            
            _logger.LogInformation($"Total daily data points: {dailyRevenueData.Count}");
            _logger.LogInformation($"Daily Revenue Data: [{string.Join(", ", dailyRevenueData)}]");
            _logger.LogInformation($"Daily Labels: [{string.Join(", ", dailyLabels)}]");
            
            var viewModel = new DashboardViewModel
            {
                // Total counts
                TotalClients = await _context.Clients.CountAsync(),
                TotalEmployees = await _context.Employees.CountAsync(),
                TotalCars = await _context.Cars.CountAsync(),
                
                // Car availability
                AvailableCars = await _context.Cars
                    .CountAsync(c => c.AvailabilityStatus == CarAvailability.Available),
                
                ReservedCars = await _context.Cars
                    .CountAsync(c => c.AvailabilityStatus == CarAvailability.Reserved),
                
                CarsInMaintenance = await _context.Cars
                    .CountAsync(c => c.AvailabilityStatus == CarAvailability.Maintenance),
                
                // Rentals
                TotalRentals = await _context.Rentals.CountAsync(),
                
                ActiveRentals = await _context.Rentals
                    .CountAsync(r => r.Status == RentalStatus.Active || r.Status == RentalStatus.Reserved),
                
                OverdueRentals = await _context.Rentals
                    .CountAsync(r => r.Status == RentalStatus.Overdue),
                
                // Payments
                PendingPayments = await _context.Payments
                    .CountAsync(p => p.Status == PaymentStatus.Pending),
                
                // Revenue - Calculate for January 2026 (where our seed data is)
                MonthlyRevenue = await _context.Payments
                    .Where(p => p.PaymentDate.Month == currentMonth 
                             && p.PaymentDate.Year == currentYear
                             && p.Status == PaymentStatus.Completed)
                    .SumAsync(p => p.Amount),
                
                TotalRevenue = await _context.Payments
                    .Where(p => p.Status == PaymentStatus.Completed)
                    .SumAsync(p => p.Amount),
                
                // Maintenance
                RecentRepairs = await _context.Repairs
                    .CountAsync(r => r.RepairDate >= DateTime.Now.AddMonths(-1)),
                
                ExpiringInsurances = await _context.Insurances
                    .CountAsync(i => i.EndDate <= DateTime.Now.AddMonths(1) 
                                  && i.EndDate >= DateTime.Now),
                
                // Daily revenue data
                DailyRevenueData = dailyRevenueData,
                DailyLabels = dailyLabels
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
