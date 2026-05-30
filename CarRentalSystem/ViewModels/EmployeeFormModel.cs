using CarRentalSystem.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModels
{
    public class EmployeeFormModel
    {
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
        public decimal Salary { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public required string Phone { get; set; }

        public Employee ToEntity()
        {
            return new Employee
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Position = Position,
                HireDate = HireDate,
                Salary = Salary,
                Phone = Phone
            };
        }
    }
}
