using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Entities.Vehicles;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<DashboardService> _logger;

        public DashboardService(CarRentalContext context, ILogger<DashboardService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            // Get current date
            var currentDate = DateTime.Now;
            var currentMonth = currentDate.Month;
            var currentYear = currentDate.Year;
            var currentDay = currentDate.Day;

            _logger.LogInformation($"Generating dashboard data for {currentDate:yyyy-MM-dd}. Month: {currentMonth}, Year: {currentYear}, Day: {currentDay}");

            // Log all payments for debugging
            var allPayments = await _context.Payments.ToListAsync();
            _logger.LogInformation($"Total Payments in DB: {allPayments.Count}");
            foreach (var payment in allPayments)
            {
                _logger.LogInformation($"Payment #{payment.Id}: Date={payment.PaymentDate}, Amount={payment.Amount}, Status={payment.Status}");
            }

            // Calculate daily revenue for current month up to today
            var dailyRevenueData = await CalculateDailyRevenueAsync(currentDay, currentMonth, currentYear);
            var dailyLabels = GenerateDailyLabels(currentDay, currentDate);

            _logger.LogInformation($"Total daily data points: {dailyRevenueData.Count}");
            _logger.LogInformation($"Daily Revenue Data: [{string.Join(", ", dailyRevenueData)}]");
            _logger.LogInformation($"Daily Labels: [{string.Join(", ", dailyLabels)}]");

            // Build and return the view model
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

                // Revenue - Calculate for current month
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
                DailyLabels = dailyLabels,

                // Current date
                CurrentDate = currentDate
            };

            _logger.LogInformation("Dashboard data generation completed successfully");
            return viewModel;
        }

        /// <summary>
        /// Calculates daily revenue for each day of the current month up to today.
        /// </summary>
        private async Task<List<decimal>> CalculateDailyRevenueAsync(int currentDay, int currentMonth, int currentYear)
        {
            var dailyRevenueData = new List<decimal>();

            for (int day = 1; day <= currentDay; day++)
            {
                var dayRevenue = await _context.Payments
                    .Where(p => p.PaymentDate.Day == day
                             && p.PaymentDate.Month == currentMonth
                             && p.PaymentDate.Year == currentYear
                             && p.Status == PaymentStatus.Completed)
                    .SumAsync(p => p.Amount);

                dailyRevenueData.Add(dayRevenue);
                _logger.LogInformation($"Day {day}: Revenue = ${dayRevenue}");
            }

            return dailyRevenueData;
        }

        /// <summary>
        /// Generates labels for each day in the current month format (e.g., "Jan 1", "Jan 2", etc.).
        /// </summary>
        private List<string> GenerateDailyLabels(int currentDay, DateTime currentDate)
        {
            var dailyLabels = new List<string>();
            var monthName = currentDate.ToString("MMM");

            for (int day = 1; day <= currentDay; day++)
            {
                dailyLabels.Add($"{monthName} {day}");
            }

            return dailyLabels;
        }
    }
}
