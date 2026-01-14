using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Entities.Vehicles
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string ModelName { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public Brand? Brand { get; set; }
    }

}
