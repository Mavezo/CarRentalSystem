using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Entities.Maintenance
{
    public class ServiceCenter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime PartnershipStartDate { get; set; } = DateTime.Now;

        public ICollection<Repair>? Repairs { get; set; }
    }
}
