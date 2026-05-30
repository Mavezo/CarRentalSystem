using CarRentalSystem.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModels
{
    public class CarFormModel
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

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

        public Car ToEntity()
        {
            return new Car
            {
                Id = Id,
                ModelId = ModelId,
                RegistrationNumber = RegistrationNumber,
                Mileage = Mileage,
                AvailabilityStatus = AvailabilityStatus,
                DailyPrice = DailyPrice,
                Location = Location
            };
        }
    }
}
