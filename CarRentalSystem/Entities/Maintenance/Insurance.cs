using CarRentalSystem.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Entities.Maintenance
{
    public class Insurance
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car? Car { get; set; }

        [Required]
        [StringLength(100)]
        public required string Company { get; set; }

        [Required]
        [StringLength(30)]
        public required string PolicyNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
