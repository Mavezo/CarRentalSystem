using CarRentalSystem.Entities.Rentals;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModels
{
    public class RentalFormModel
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime RentalDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        public RentalStatus Status { get; set; } = RentalStatus.Reserved;

        public Rental ToEntity()
        {
            return new Rental
            {
                Id = Id,
                CarId = CarId,
                ClientId = ClientId,
                EmployeeId = EmployeeId,
                RentalDate = RentalDate,
                ReturnDate = ReturnDate,
                Status = Status
            };
        }
    }
}
