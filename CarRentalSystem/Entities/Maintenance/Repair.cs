using CarRentalSystem.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Entities.Maintenance
{
    public class Repair
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car? Car { get; set; }

        [ForeignKey("ServiceCenter")]
        public int ServiceCenterId { get; set; }
        public ServiceCenter? ServiceCenter { get; set; }

        [DataType(DataType.Date)]
        public DateTime RepairDate { get; set; }

        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }
    }
}
