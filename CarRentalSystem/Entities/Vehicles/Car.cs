using CarRentalSystem.Entities.Maintenance;
using CarRentalSystem.Entities.Rentals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Entities.Vehicles
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public Model? Model { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Registration number is not valid")]
        public required string RegistrationNumber { get; set; }

        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        public CarAvailability AvailabilityStatus { get; set; } = CarAvailability.Available;

        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal DailyPrice { get; set; }

        public string? Location { get; set; }

        public ICollection<Rental>? Rentals { get; set; }
        public Insurance? Insurance { get; set; }
        public ICollection<Repair>? Repairs { get; set; }
    }
}
