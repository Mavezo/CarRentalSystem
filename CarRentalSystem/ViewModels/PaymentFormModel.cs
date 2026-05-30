using CarRentalSystem.Entities.Rentals;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModels
{
    public class PaymentFormModel
    {
        public int Id { get; set; }

        public int RentalId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CreditCard;

        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public Payment ToEntity()
        {
            return new Payment
            {
                Id = Id,
                RentalId = RentalId,
                PaymentDate = PaymentDate,
                Amount = Amount,
                PaymentMethod = PaymentMethod,
                Status = Status
            };
        }
    }
}
