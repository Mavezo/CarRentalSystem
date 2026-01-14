using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Entities.Rentals
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rental")]
        public int RentalId { get; set; }
        public Rental? Rental { get; set; }

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [StringLength(30)]
        public required PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CreditCard;

        [StringLength(20)]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    }
}
