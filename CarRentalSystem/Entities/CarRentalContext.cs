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

            // Configure enum conversions
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

            // Configure unique indexes
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.RegistrationNumber)
                .IsUnique();

            // Configure check constraints
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

            // Seed database with initial data
            DbSeeder.SeedData(modelBuilder);
        }

        public CarRentalContext(DbContextOptions options) : base(options)
        {
        }
    }
}
