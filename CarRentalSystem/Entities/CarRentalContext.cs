using CarRentalSystem.Entities.Maintenance;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Entities.Users;
using CarRentalSystem.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Entities
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ServiceCenter> ServiceCenters { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rental>()
               .Property(r => r.Status)
               .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .HasConversion<string>();

            modelBuilder.Entity<Car>()
                .Property(c => c.AvailabilityStatus)
                .HasConversion<string>();

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, BrandName = "Toyota", Country = "Japan", BodyType = "Sedan", Year = 2022, Transmission = "Automatic" },
                new Brand { Id = 2, BrandName = "BMW", Country = "Germany", BodyType = "SUV", Year = 2021, Transmission = "Automatic" },
                new Brand { Id = 3, BrandName = "Ford", Country = "USA", BodyType = "Hatchback", Year = 2020, Transmission = "Manual" },
                new Brand { Id = 4, BrandName = "Audi", Country = "Germany", BodyType = "Coupe", Year = 2021, Transmission = "Automatic" },
                new Brand { Id = 5, BrandName = "Volkswagen", Country = "Germany", BodyType = "Sedan", Year = 2022, Transmission = "Manual" },
                new Brand { Id = 6, BrandName = "Honda", Country = "Japan", BodyType = "SUV", Year = 2021, Transmission = "Automatic" },
                new Brand { Id = 7, BrandName = "Mercedes-Benz", Country = "Germany", BodyType = "Sedan", Year = 2022, Transmission = "Automatic" },
                new Brand { Id = 8, BrandName = "Kia", Country = "South Korea", BodyType = "Hatchback", Year = 2020, Transmission = "Manual" },
                new Brand { Id = 9, BrandName = "Nissan", Country = "Japan", BodyType = "SUV", Year = 2021, Transmission = "Automatic" },
                new Brand { Id = 10, BrandName = "Chevrolet", Country = "USA", BodyType = "Coupe", Year = 2020, Transmission = "Manual" }
            );

            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, ModelName = "Corolla", BrandId = 1 },
                new Model { Id = 2, ModelName = "Camry", BrandId = 1 },
                new Model { Id = 3, ModelName = "X5", BrandId = 2 },
                new Model { Id = 4, ModelName = "3 Series", BrandId = 2 },
                new Model { Id = 5, ModelName = "Focus", BrandId = 3 },
                new Model { Id = 6, ModelName = "Mustang", BrandId = 3 },
                new Model { Id = 7, ModelName = "A5", BrandId = 4 },
                new Model { Id = 8, ModelName = "Passat", BrandId = 5 },
                new Model { Id = 9, ModelName = "CR-V", BrandId = 6 },
                new Model { Id = 10, ModelName = "C-Class", BrandId = 7 }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FirstName = "Jan", LastName = "Kowalski", PESEL = "88010112345", PhoneNumber = "600123456", Email = "jan.kowalski@example.com", City = "Warszawa", PostalCode = "00-001" },
                new Client { Id = 2, FirstName = "Anna", LastName = "Nowak", PESEL = "90020223456", PhoneNumber = "601234567", Email = "anna.nowak@example.com", City = "Kraków", PostalCode = "30-002" },
                new Client { Id = 3, FirstName = "Piotr", LastName = "Wiśniewski", PESEL = "85030334567", PhoneNumber = "602345678", Email = "piotr.wisniewski@example.com", City = "Gdańsk", PostalCode = "80-003" },
                new Client { Id = 4, FirstName = "Katarzyna", LastName = "Wójcik", PESEL = "92040445678", PhoneNumber = "603456789", Email = "katarzyna.wojcik@example.com", City = "Poznań", PostalCode = "60-004" },
                new Client { Id = 5, FirstName = "Michał", LastName = "Krawczyk", PESEL = "87050556789", PhoneNumber = "604567890", Email = "michal.krawczyk@example.com", City = "Łódź", PostalCode = "90-005" },
                new Client { Id = 6, FirstName = "Agnieszka", LastName = "Kamińska", PESEL = "91060667890", PhoneNumber = "605678901", Email = "agnieszka.kaminska@example.com", City = "Wrocław", PostalCode = "50-006" },
                new Client { Id = 7, FirstName = "Tomasz", LastName = "Lewandowski", PESEL = "86070778901", PhoneNumber = "606789012", Email = "tomasz.lewandowski@example.com", City = "Szczecin", PostalCode = "70-007" },
                new Client { Id = 8, FirstName = "Magdalena", LastName = "Zielińska", PESEL = "93080889012", PhoneNumber = "607890123", Email = "magdalena.zielinska@example.com", City = "Bydgoszcz", PostalCode = "85-008" },
                new Client { Id = 9, FirstName = "Łukasz", LastName = "Szymański", PESEL = "88090990123", PhoneNumber = "608901234", Email = "lukasz.szymanski@example.com", City = "Lublin", PostalCode = "20-009" },
                new Client { Id = 10, FirstName = "Ewa", LastName = "Dąbrowska", PESEL = "90010101234", PhoneNumber = "609012345", Email = "ewa.dabrowska@example.com", City = "Katowice", PostalCode = "40-010" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Piotr", LastName = "Nowak", Position = "Kierownik", HireDate = new DateTime(2018, 5, 10), Salary = 5500m, Phone = "600111222" },
                new Employee { Id = 2, FirstName = "Anna", LastName = "Kowalska", Position = "Kasjer", HireDate = new DateTime(2019, 3, 15), Salary = 4200m, Phone = "601222333" },
                new Employee { Id = 3, FirstName = "Michał", LastName = "Wiśniewski", Position = "Specjalista ds. Wynajmu", HireDate = new DateTime(2020, 7, 1), Salary = 4800m, Phone = "602333444" },
                new Employee { Id = 4, FirstName = "Katarzyna", LastName = "Wójcik", Position = "Asystent", HireDate = new DateTime(2021, 1, 20), Salary = 4000m, Phone = "603444555" },
                new Employee { Id = 5, FirstName = "Tomasz", LastName = "Kamiński", Position = "Mechanik", HireDate = new DateTime(2017, 11, 5), Salary = 5000m, Phone = "604555666" },
                new Employee { Id = 6, FirstName = "Magdalena", LastName = "Lewandowska", Position = "Specjalista ds. Klientów", HireDate = new DateTime(2019, 6, 18), Salary = 4700m, Phone = "605666777" },
                new Employee { Id = 7, FirstName = "Łukasz", LastName = "Zieliński", Position = "Kierownik ds. Floty", HireDate = new DateTime(2018, 9, 12), Salary = 5600m, Phone = "606777888" },
                new Employee { Id = 8, FirstName = "Ewa", LastName = "Szymańska", Position = "Asystent", HireDate = new DateTime(2020, 2, 28), Salary = 4100m, Phone = "607888999" },
                new Employee { Id = 9, FirstName = "Paweł", LastName = "Dąbrowski", Position = "Specjalista ds. Wynajmu", HireDate = new DateTime(2021, 8, 10), Salary = 4500m, Phone = "608999000" },
                new Employee { Id = 10, FirstName = "Agnieszka", LastName = "Kowalczyk", Position = "Kasjer", HireDate = new DateTime(2019, 4, 22), Salary = 4300m, Phone = "609000111" }
            );

            modelBuilder.Entity<ServiceCenter>().HasData(
                new ServiceCenter { Id = 1, Name = "Auto Serwis Warszawa", City = "Warszawa", Phone = "600111222", Email = "kontakt@warszawa-serwis.pl", PartnershipStartDate = new DateTime(2015, 1, 10) },
                new ServiceCenter { Id = 2, Name = "Mechanika Kraków", City = "Kraków", Phone = "601222333", Email = "biuro@mechanikakrakow.pl", PartnershipStartDate = new DateTime(2016, 3, 15) },
                new ServiceCenter { Id = 3, Name = "Serwis Gdańsk", City = "Gdańsk", Phone = "602333444", Email = "kontakt@serwisgdansk.pl", PartnershipStartDate = new DateTime(2017, 5, 20) },
                new ServiceCenter { Id = 4, Name = "AutoNaprawa Poznań", City = "Poznań", Phone = "603444555", Email = "biuro@autonaprawapoznan.pl", PartnershipStartDate = new DateTime(2018, 7, 1) },
                new ServiceCenter { Id = 5, Name = "Warsztat Łódź", City = "Łódź", Phone = "604555666", Email = "kontakt@warsztatlodz.pl", PartnershipStartDate = new DateTime(2016, 9, 5) },
                new ServiceCenter { Id = 6, Name = "Auto Serwis Wrocław", City = "Wrocław", Phone = "605666777", Email = "biuro@wroclaw-serwis.pl", PartnershipStartDate = new DateTime(2017, 11, 10) },
                new ServiceCenter { Id = 7, Name = "Mechanika Szczecin", City = "Szczecin", Phone = "606777888", Email = "kontakt@mechanikaszczecin.pl", PartnershipStartDate = new DateTime(2015, 2, 12) },
                new ServiceCenter { Id = 8, Name = "Serwis Bydgoszcz", City = "Bydgoszcz", Phone = "607888999", Email = "biuro@serwisbydgoszcz.pl", PartnershipStartDate = new DateTime(2016, 4, 18) },
                new ServiceCenter { Id = 9, Name = "Warsztat Lublin", City = "Lublin", Phone = "608999000", Email = "kontakt@warsztatlublin.pl", PartnershipStartDate = new DateTime(2017, 6, 22) },
                new ServiceCenter { Id = 10, Name = "AutoNaprawa Katowice", City = "Katowice", Phone = "609000111", Email = "biuro@autonaprawakatowice.pl", PartnershipStartDate = new DateTime(2018, 8, 30) }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, ModelId = 1, RegistrationNumber = "WA12345", Mileage = 15000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 200m, Location = "Warszawa" },
                new Car { Id = 2, ModelId = 2, RegistrationNumber = "WA23456", Mileage = 22000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 250m, Location = "Warszawa" },
                new Car { Id = 3, ModelId = 3, RegistrationNumber = "KR34567", Mileage = 30000, AvailabilityStatus = CarAvailability.Maintenance, DailyPrice = 400m, Location = "Kraków" },
                new Car { Id = 4, ModelId = 4, RegistrationNumber = "KR45678", Mileage = 18000, AvailabilityStatus = CarAvailability.Rented, DailyPrice = 350m, Location = "Kraków" },
                new Car { Id = 5, ModelId = 5, RegistrationNumber = "GD56789", Mileage = 12000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 180m, Location = "Gdańsk" },
                new Car { Id = 6, ModelId = 6, RegistrationNumber = "GD67890", Mileage = 25000, AvailabilityStatus = CarAvailability.Reserved, DailyPrice = 220m, Location = "Gdańsk" },
                new Car { Id = 7, ModelId = 7, RegistrationNumber = "PO78901", Mileage = 20000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 300m, Location = "Poznań" },
                new Car { Id = 8, ModelId = 8, RegistrationNumber = "LO89012", Mileage = 15000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 210m, Location = "Łódź" },
                new Car { Id = 9, ModelId = 9, RegistrationNumber = "WR90123", Mileage = 18000, AvailabilityStatus = CarAvailability.Rented, DailyPrice = 240m, Location = "Wrocław" },
                new Car { Id = 10, ModelId = 10, RegistrationNumber = "SZ01234", Mileage = 16000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 260m, Location = "Szczecin" }
            );

            modelBuilder.Entity<Insurance>().HasData(
                new Insurance { Id = 1, CarId = 1, Company = "PZU", PolicyNumber = "PZU-001", StartDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2024, 1, 1) },
                new Insurance { Id = 2, CarId = 2, Company = "Allianz", PolicyNumber = "ALL-002", StartDate = new DateTime(2023, 2, 1), EndDate = new DateTime(2024, 2, 1) },
                new Insurance { Id = 3, CarId = 3, Company = "Warta", PolicyNumber = "WRT-003", StartDate = new DateTime(2023, 3, 1), EndDate = new DateTime(2024, 3, 1) },
                new Insurance { Id = 4, CarId = 4, Company = "PZU", PolicyNumber = "PZU-004", StartDate = new DateTime(2023, 4, 1), EndDate = new DateTime(2024, 4, 1) },
                new Insurance { Id = 5, CarId = 5, Company = "Allianz", PolicyNumber = "ALL-005", StartDate = new DateTime(2023, 5, 1), EndDate = new DateTime(2024, 5, 1) },
                new Insurance { Id = 6, CarId = 6, Company = "Warta", PolicyNumber = "WRT-006", StartDate = new DateTime(2023, 6, 1), EndDate = new DateTime(2024, 6, 1) },
                new Insurance { Id = 7, CarId = 7, Company = "PZU", PolicyNumber = "PZU-007", StartDate = new DateTime(2023, 7, 1), EndDate = new DateTime(2024, 7, 1) },
                new Insurance { Id = 8, CarId = 8, Company = "Allianz", PolicyNumber = "ALL-008", StartDate = new DateTime(2023, 8, 1), EndDate = new DateTime(2024, 8, 1) },
                new Insurance { Id = 9, CarId = 9, Company = "Warta", PolicyNumber = "WRT-009", StartDate = new DateTime(2023, 9, 1), EndDate = new DateTime(2024, 9, 1) },
                new Insurance { Id = 10, CarId = 10, Company = "PZU", PolicyNumber = "PZU-010", StartDate = new DateTime(2023, 10, 1), EndDate = new DateTime(2024, 10, 1) }
            );
            modelBuilder.Entity<Repair>().HasData(
                new Repair { Id = 1, CarId = 1, ServiceCenterId = 1, RepairDate = new DateTime(2023, 2, 10), Cost = 500m, Description = "Wymiana oleju" },
                new Repair { Id = 2, CarId = 2, ServiceCenterId = 2, RepairDate = new DateTime(2023, 3, 5), Cost = 1200m, Description = "Naprawa hamulców" },
                new Repair { Id = 3, CarId = 3, ServiceCenterId = 3, RepairDate = new DateTime(2023, 4, 15), Cost = 800m, Description = "Wymiana filtrów" },
                new Repair { Id = 4, CarId = 4, ServiceCenterId = 4, RepairDate = new DateTime(2023, 5, 20), Cost = 1500m, Description = "Naprawa zawieszenia" },
                new Repair { Id = 5, CarId = 5, ServiceCenterId = 5, RepairDate = new DateTime(2023, 6, 10), Cost = 600m, Description = "Wymiana klocków hamulcowych" },
                new Repair { Id = 6, CarId = 6, ServiceCenterId = 6, RepairDate = new DateTime(2023, 7, 12), Cost = 2000m, Description = "Naprawa skrzyni biegów" },
                new Repair { Id = 7, CarId = 7, ServiceCenterId = 7, RepairDate = new DateTime(2023, 8, 18), Cost = 700m, Description = "Wymiana amortyzatorów" },
                new Repair { Id = 8, CarId = 8, ServiceCenterId = 8, RepairDate = new DateTime(2023, 9, 22), Cost = 900m, Description = "Przegląd okresowy" },
                new Repair { Id = 9, CarId = 9, ServiceCenterId = 9, RepairDate = new DateTime(2023, 10, 5), Cost = 1100m, Description = "Naprawa układu wydechowego" },
                new Repair { Id = 10, CarId = 10, ServiceCenterId = 10, RepairDate = new DateTime(2023, 11, 1), Cost = 1300m, Description = "Wymiana akumulatora" }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental { Id = 1, ClientId = 1, CarId = 1, EmployeeId = 1, RentalDate = new DateTime(2023, 9, 1), ReturnDate = new DateTime(2023, 9, 5), Status = RentalStatus.Completed },
                new Rental { Id = 2, ClientId = 2, CarId = 2, EmployeeId = 2, RentalDate = new DateTime(2023, 9, 3), ReturnDate = new DateTime(2023, 9, 7), Status = RentalStatus.Completed },
                new Rental { Id = 3, ClientId = 3, CarId = 3, EmployeeId = 3, RentalDate = new DateTime(2023, 9, 5), ReturnDate = new DateTime(2023, 9, 10), Status = RentalStatus.Completed },
                new Rental { Id = 4, ClientId = 4, CarId = 4, EmployeeId = 4, RentalDate = new DateTime(2023, 9, 8), ReturnDate = new DateTime(2023, 9, 12), Status = RentalStatus.Completed },
                new Rental { Id = 5, ClientId = 5, CarId = 5, EmployeeId = 5, RentalDate = new DateTime(2023, 9, 10), ReturnDate = new DateTime(2023, 9, 15), Status = RentalStatus.Completed },
                new Rental { Id = 6, ClientId = 6, CarId = 6, EmployeeId = 6, RentalDate = new DateTime(2023, 9, 12), ReturnDate = new DateTime(2023, 9, 16), Status = RentalStatus.Completed },
                new Rental { Id = 7, ClientId = 7, CarId = 7, EmployeeId = 7, RentalDate = new DateTime(2023, 9, 14), ReturnDate = new DateTime(2023, 9, 18), Status = RentalStatus.Completed },
                new Rental { Id = 8, ClientId = 8, CarId = 8, EmployeeId = 8, RentalDate = new DateTime(2023, 9, 16), ReturnDate = new DateTime(2023, 9, 20), Status = RentalStatus.Completed },
                new Rental { Id = 9, ClientId = 9, CarId = 9, EmployeeId = 9, RentalDate = new DateTime(2023, 9, 18), ReturnDate = new DateTime(2023, 9, 23), Status = RentalStatus.Completed },
                new Rental { Id = 10, ClientId = 10, CarId = 10, EmployeeId = 10, RentalDate = new DateTime(2023, 9, 20), ReturnDate = new DateTime(2023, 9, 25), Status = RentalStatus.Completed }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, RentalId = 1, PaymentDate = new DateTime(2023, 9, 1), Amount = 1000m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 2, RentalId = 2, PaymentDate = new DateTime(2023, 9, 3), Amount = 1200m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 3, RentalId = 3, PaymentDate = new DateTime(2023, 9, 5), Amount = 1500m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 4, RentalId = 4, PaymentDate = new DateTime(2023, 9, 8), Amount = 1300m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 5, RentalId = 5, PaymentDate = new DateTime(2023, 9, 10), Amount = 1100m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 6, RentalId = 6, PaymentDate = new DateTime(2023, 9, 12), Amount = 1400m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 7, RentalId = 7, PaymentDate = new DateTime(2023, 9, 14), Amount = 1250m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 8, RentalId = 8, PaymentDate = new DateTime(2023, 9, 16), Amount = 1350m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 9, RentalId = 9, PaymentDate = new DateTime(2023, 9, 18), Amount = 1450m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 10, RentalId = 10, PaymentDate = new DateTime(2023, 9, 20), Amount = 1550m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed }
            );


            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.RegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable(t => t.HasCheckConstraint("CK_Employee_Salary_Positive", "[Salary] >= 0"));
            });

            modelBuilder.Entity<Car>(c =>
            {
                c.ToTable(t => t.HasCheckConstraint("CK_Car_Mileage_Positive", "[Mileage] >= 0"));
            });

            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable(t => t.HasCheckConstraint("CK_Brand_Year_Range", "[Year] >= 2000 AND [Year] <= 2025"));
            });

            modelBuilder.Entity<Rental>(r =>
            {
                r.ToTable(t => t.HasCheckConstraint("CK_Rental_Dates", "[ReturnDate] IS NULL OR [ReturnDate] >= [RentalDate]"));
            });
            modelBuilder.Entity<Payment>(p =>
            {
                p.ToTable(t => t.HasCheckConstraint("CK_Payment_Amount_Positive", "[Amount] >= 0"));
            });

        }

        public CarRentalContext(DbContextOptions options) : base(options)
        {
        }

    }
}
