using CarRentalSystem.Entities.Users;
using CarRentalSystem.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Entities.Rentals
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car? Car { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [DataType(DataType.Date)]
        public DateTime RentalDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        public required RentalStatus Status { get; set; } = RentalStatus.Reserved;
        public ICollection<Payment>? Payments { get; set; }
    }
}
