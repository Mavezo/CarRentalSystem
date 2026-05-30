using CarRentalSystem.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModels
{
    public class BrandFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string BrandName { get; set; }

        public string? Country { get; set; }

        [StringLength(30)]
        public string? BodyType { get; set; }

        [Range(2000, 2025)]
        public int Year { get; set; }

        [StringLength(20)]
        public string? Transmission { get; set; }

        public Brand ToEntity()
        {
            return new Brand
            {
                Id = Id,
                BrandName = BrandName,
                Country = Country,
                BodyType = BodyType,
                Year = Year,
                Transmission = Transmission
            };
        }
    }
}
