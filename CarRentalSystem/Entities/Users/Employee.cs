using CarRentalSystem.Entities.Rentals;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Entities.Users
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public required string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Position name is too long")]
        public required string Position { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        [DataType(DataType.Currency)]
        public required decimal Salary { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public required string Phone { get; set; }
        public ICollection<Rental>? Rentals { get; set; }

    }
}
