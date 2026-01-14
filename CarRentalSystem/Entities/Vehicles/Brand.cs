using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CarRentalSystem.Entities.Vehicles
{
    public class Brand
    {
        [Key]
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

        public ICollection<Model>? Models { get; set; }

    }
}
