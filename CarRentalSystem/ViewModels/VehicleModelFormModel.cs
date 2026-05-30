using CarRentalSystem.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModels
{
    public class VehicleModelFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string ModelName { get; set; }

        public int BrandId { get; set; }

        public Model ToEntity()
        {
            return new Model
            {
                Id = Id,
                ModelName = ModelName,
                BrandId = BrandId
            };
        }
    }
}
