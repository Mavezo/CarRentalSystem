using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(CarRentalContext context, ILogger<PaymentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Client)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Car!.Model!.Brand)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Employee)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Rental)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payment?> GetPaymentWithDetailsAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Client)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Car!.Model!.Brand)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Employee)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Payment>> SearchPaymentsAsync(int? rentalId, PaymentStatus? status, 
            PaymentMethod? method, DateTime? startDate, DateTime? endDate)
        {
            var payments = _context.Payments
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Client)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Car!.Model!.Brand)
                .Include(p => p.Rental)
                    .ThenInclude(r => r!.Employee)
                .AsQueryable();

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

            return await payments.OrderByDescending(p => p.PaymentDate).ToListAsync();
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New payment created: ID {payment.Id}, Rental {payment.RentalId}, Amount {payment.Amount:C}");
            return payment;
        }

        public async Task<Payment> UpdatePaymentAsync(Payment payment)
        {
            _context.Update(payment);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Payment updated: ID {payment.Id}, Status {payment.Status}");
            return payment;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return false;
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Payment deleted: ID {id}");
            return true;
        }

        public async Task<decimal> GetTotalPaidForRentalAsync(int rentalId)
        {
            return await _context.Payments
                .Where(p => p.RentalId == rentalId && p.Status == PaymentStatus.Completed)
                .SumAsync(p => p.Amount);
        }

        public async Task<decimal> CalculateRentalTotalCostAsync(int rentalId)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null || rental.Car == null)
            {
                return 0;
            }

            var rentalDays = rental.ReturnDate.HasValue
                ? (rental.ReturnDate.Value - rental.RentalDate).Days
                : (DateTime.Now - rental.RentalDate).Days;

            if (rentalDays < 1) rentalDays = 1;

            return rental.Car.DailyPrice * rentalDays;
        }

        public async Task<decimal> GetRemainingAmountAsync(int rentalId)
        {
            var totalCost = await CalculateRentalTotalCostAsync(rentalId);
            var totalPaid = await GetTotalPaidForRentalAsync(rentalId);
            var remainingAmount = totalCost - totalPaid;

            return Math.Max(0, remainingAmount);
        }

        public async Task<RentalPaymentInfo?> GetRentalPaymentInfoAsync(int rentalId)
        {
            var rental = await _context.Rentals
                .Include(r => r.Client)
                .Include(r => r.Car!.Model!.Brand)
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null)
            {
                return null;
            }

            var totalPaid = await GetTotalPaidForRentalAsync(rentalId);
            var totalCost = await CalculateRentalTotalCostAsync(rentalId);

            var rentalDays = rental.ReturnDate.HasValue
                ? (rental.ReturnDate.Value - rental.RentalDate).Days
                : (DateTime.Now - rental.RentalDate).Days;

            if (rentalDays < 1) rentalDays = 1;

            var remainingAmount = totalCost - totalPaid;

            return new RentalPaymentInfo
            {
                ClientName = $"{rental.Client?.FirstName} {rental.Client?.LastName}",
                CarInfo = $"{rental.Car?.Model?.Brand?.BrandName} {rental.Car?.Model?.ModelName}",
                RegistrationNumber = rental.Car?.RegistrationNumber ?? string.Empty,
                RentalDate = rental.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = rental.ReturnDate?.ToString("yyyy-MM-dd"),
                DailyPrice = rental.Car?.DailyPrice ?? 0,
                RentalDays = rentalDays,
                TotalCost = totalCost,
                TotalPaid = totalPaid,
                RemainingAmount = Math.Max(0, remainingAmount),
                Status = rental.Status.ToString()
            };
        }
    }
}
