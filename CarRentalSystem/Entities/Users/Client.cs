using CarRentalSystem.Entities.Rentals;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Entities.Users
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "National ID (PESEL) is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL must contain exactly 11 digits.")]
        public required string PESEL { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public required string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100)]
        public required string Email { get; set; }

        [StringLength(50, ErrorMessage = "City name is too long (max 50 characters).")]
        public string? City { get; set; }

        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Postal code must have the format XX-XXX.")]
        public string? PostalCode { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
