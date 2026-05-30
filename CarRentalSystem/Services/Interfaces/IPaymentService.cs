using CarRentalSystem.Entities.Rentals;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task<Payment?> GetPaymentWithDetailsAsync(int id);
        Task<List<Payment>> SearchPaymentsAsync(int? rentalId, PaymentStatus? status, 
            PaymentMethod? method, DateTime? startDate, DateTime? endDate);
        Task<Payment> CreatePaymentAsync(Payment payment);
        Task<Payment> UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(int id);
        Task<decimal> GetTotalPaidForRentalAsync(int rentalId);
        Task<decimal> CalculateRentalTotalCostAsync(int rentalId);
        Task<decimal> GetRemainingAmountAsync(int rentalId);
        Task<RentalPaymentInfo?> GetRentalPaymentInfoAsync(int rentalId);
    }

    public class RentalPaymentInfo
    {
        public string ClientName { get; set; } = string.Empty;
        public string CarInfo { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string RentalDate { get; set; } = string.Empty;
        public string? ReturnDate { get; set; }
        public decimal DailyPrice { get; set; }
        public int RentalDays { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
