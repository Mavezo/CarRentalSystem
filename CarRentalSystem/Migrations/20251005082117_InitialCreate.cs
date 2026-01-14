using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.CheckConstraint("CK_Brand_Year_Range", "[Year] >= 2000 AND [Year] <= 2025");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.CheckConstraint("CK_Employee_Salary_Positive", "[Salary] >= 0");
                });

            migrationBuilder.CreateTable(
                name: "ServiceCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnershipStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.CheckConstraint("CK_Car_Mileage_Positive", "[Mileage] >= 0");
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurances_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.CheckConstraint("CK_Rental_Dates", "[ReturnDate] IS NULL OR [ReturnDate] >= [RentalDate]");
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ServiceCenterId = table.Column<int>(type: "int", nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_ServiceCenters_ServiceCenterId",
                        column: x => x.ServiceCenterId,
                        principalTable: "ServiceCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.CheckConstraint("CK_Payment_Amount_Positive", "[Amount] >= 0");
                    table.ForeignKey(
                        name: "FK_Payments_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BodyType", "BrandName", "Country", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, "Sedan", "Toyota", "Japan", "Automatic", 2022 },
                    { 2, "SUV", "BMW", "Germany", "Automatic", 2021 },
                    { 3, "Hatchback", "Ford", "USA", "Manual", 2020 },
                    { 4, "Coupe", "Audi", "Germany", "Automatic", 2021 },
                    { 5, "Sedan", "Volkswagen", "Germany", "Manual", 2022 },
                    { 6, "SUV", "Honda", "Japan", "Automatic", 2021 },
                    { 7, "Sedan", "Mercedes-Benz", "Germany", "Automatic", 2022 },
                    { 8, "Hatchback", "Kia", "South Korea", "Manual", 2020 },
                    { 9, "SUV", "Nissan", "Japan", "Automatic", 2021 },
                    { 10, "Coupe", "Chevrolet", "USA", "Manual", 2020 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "Email", "FirstName", "LastName", "PESEL", "PhoneNumber", "PostalCode" },
                values: new object[,]
                {
                    { 1, "Warszawa", "jan.kowalski@example.com", "Jan", "Kowalski", "88010112345", "600123456", "00-001" },
                    { 2, "Kraków", "anna.nowak@example.com", "Anna", "Nowak", "90020223456", "601234567", "30-002" },
                    { 3, "Gdańsk", "piotr.wisniewski@example.com", "Piotr", "Wiśniewski", "85030334567", "602345678", "80-003" },
                    { 4, "Poznań", "katarzyna.wojcik@example.com", "Katarzyna", "Wójcik", "92040445678", "603456789", "60-004" },
                    { 5, "Łódź", "michal.krawczyk@example.com", "Michał", "Krawczyk", "87050556789", "604567890", "90-005" },
                    { 6, "Wrocław", "agnieszka.kaminska@example.com", "Agnieszka", "Kamińska", "91060667890", "605678901", "50-006" },
                    { 7, "Szczecin", "tomasz.lewandowski@example.com", "Tomasz", "Lewandowski", "86070778901", "606789012", "70-007" },
                    { 8, "Bydgoszcz", "magdalena.zielinska@example.com", "Magdalena", "Zielińska", "93080889012", "607890123", "85-008" },
                    { 9, "Lublin", "lukasz.szymanski@example.com", "Łukasz", "Szymański", "88090990123", "608901234", "20-009" },
                    { 10, "Katowice", "ewa.dabrowska@example.com", "Ewa", "Dąbrowska", "90010101234", "609012345", "40-010" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "HireDate", "LastName", "Phone", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, "Piotr", new DateTime(2018, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nowak", "600111222", "Kierownik", 5500m },
                    { 2, "Anna", new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kowalska", "601222333", "Kasjer", 4200m },
                    { 3, "Michał", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wiśniewski", "602333444", "Specjalista ds. Wynajmu", 4800m },
                    { 4, "Katarzyna", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wójcik", "603444555", "Asystent", 4000m },
                    { 5, "Tomasz", new DateTime(2017, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamiński", "604555666", "Mechanik", 5000m },
                    { 6, "Magdalena", new DateTime(2019, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lewandowska", "605666777", "Specjalista ds. Klientów", 4700m },
                    { 7, "Łukasz", new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zieliński", "606777888", "Kierownik ds. Floty", 5600m },
                    { 8, "Ewa", new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szymańska", "607888999", "Asystent", 4100m },
                    { 9, "Paweł", new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dąbrowski", "608999000", "Specjalista ds. Wynajmu", 4500m },
                    { 10, "Agnieszka", new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kowalczyk", "609000111", "Kasjer", 4300m }
                });

            migrationBuilder.InsertData(
                table: "ServiceCenters",
                columns: new[] { "Id", "City", "Email", "Name", "PartnershipStartDate", "Phone" },
                values: new object[,]
                {
                    { 1, "Warszawa", "kontakt@warszawa-serwis.pl", "Auto Serwis Warszawa", new DateTime(2015, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "600111222" },
                    { 2, "Kraków", "biuro@mechanikakrakow.pl", "Mechanika Kraków", new DateTime(2016, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "601222333" },
                    { 3, "Gdańsk", "kontakt@serwisgdansk.pl", "Serwis Gdańsk", new DateTime(2017, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "602333444" },
                    { 4, "Poznań", "biuro@autonaprawapoznan.pl", "AutoNaprawa Poznań", new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "603444555" },
                    { 5, "Łódź", "kontakt@warsztatlodz.pl", "Warsztat Łódź", new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "604555666" },
                    { 6, "Wrocław", "biuro@wroclaw-serwis.pl", "Auto Serwis Wrocław", new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "605666777" },
                    { 7, "Szczecin", "kontakt@mechanikaszczecin.pl", "Mechanika Szczecin", new DateTime(2015, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "606777888" },
                    { 8, "Bydgoszcz", "biuro@serwisbydgoszcz.pl", "Serwis Bydgoszcz", new DateTime(2016, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "607888999" },
                    { 9, "Lublin", "kontakt@warsztatlublin.pl", "Warsztat Lublin", new DateTime(2017, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "608999000" },
                    { 10, "Katowice", "biuro@autonaprawakatowice.pl", "AutoNaprawa Katowice", new DateTime(2018, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "609000111" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "ModelName" },
                values: new object[,]
                {
                    { 1, 1, "Corolla" },
                    { 2, 1, "Camry" },
                    { 3, 2, "X5" },
                    { 4, 2, "3 Series" },
                    { 5, 3, "Focus" },
                    { 6, 3, "Mustang" },
                    { 7, 4, "A5" },
                    { 8, 5, "Passat" },
                    { 9, 6, "CR-V" },
                    { 10, 7, "C-Class" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "ModelId", "RegistrationNumber" },
                values: new object[,]
                {
                    { 1, "Available", 200m, "Warszawa", 15000, 1, "WA12345" },
                    { 2, "Available", 250m, "Warszawa", 22000, 2, "WA23456" },
                    { 3, "Maintenance", 400m, "Kraków", 30000, 3, "KR34567" },
                    { 4, "Rented", 350m, "Kraków", 18000, 4, "KR45678" },
                    { 5, "Available", 180m, "Gdańsk", 12000, 5, "GD56789" },
                    { 6, "Reserved", 220m, "Gdańsk", 25000, 6, "GD67890" },
                    { 7, "Available", 300m, "Poznań", 20000, 7, "PO78901" },
                    { 8, "Available", 210m, "Łódź", 15000, 8, "LO89012" },
                    { 9, "Rented", 240m, "Wrocław", 18000, 9, "WR90123" },
                    { 10, "Available", 260m, "Szczecin", 16000, 10, "SZ01234" }
                });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "CarId", "Company", "EndDate", "PolicyNumber", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "PZU", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-001", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Allianz", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-002", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Warta", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-003", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, "PZU", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-004", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, "Allianz", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-005", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, "Warta", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-006", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, "PZU", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-007", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, "Allianz", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-008", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, "Warta", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-009", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, "PZU", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-010", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "ClientId", "EmployeeId", "RentalDate", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 2, 2, 2, 2, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 3, 3, 3, 3, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 4, 4, 4, 4, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 5, 5, 5, 5, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 6, 6, 6, 6, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 7, 7, 7, 7, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 8, 8, 8, 8, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 9, 9, 9, 9, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 10, 10, 10, 10, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "CarId", "Cost", "Description", "RepairDate", "ServiceCenterId" },
                values: new object[,]
                {
                    { 1, 1, 500m, "Wymiana oleju", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 1200m, "Naprawa hamulców", new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, 800m, "Wymiana filtrów", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, 1500m, "Naprawa zawieszenia", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, 600m, "Wymiana klocków hamulcowych", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, 6, 2000m, "Naprawa skrzyni biegów", new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, 7, 700m, "Wymiana amortyzatorów", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, 8, 900m, "Przegląd okresowy", new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, 9, 1100m, "Naprawa układu wydechowego", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, 10, 1300m, "Wymiana akumulatora", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentMethod", "RentalId", "Status" },
                values: new object[,]
                {
                    { 1, 1000m, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 1, "Completed" },
                    { 2, 1200m, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 2, "Completed" },
                    { 3, 1500m, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 3, "Completed" },
                    { 4, 1300m, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 4, "Completed" },
                    { 5, 1100m, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 5, "Completed" },
                    { 6, 1400m, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 6, "Completed" },
                    { 7, 1250m, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 7, "Completed" },
                    { 8, 1350m, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 8, "Completed" },
                    { 9, 1450m, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 9, "Completed" },
                    { 10, 1550m, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 10, "Completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RegistrationNumber",
                table: "Cars",
                column: "RegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_CarId",
                table: "Insurances",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RentalId",
                table: "Payments",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ClientId",
                table: "Rentals",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_EmployeeId",
                table: "Rentals",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CarId",
                table: "Repairs",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ServiceCenterId",
                table: "Repairs",
                column: "ServiceCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "ServiceCenters");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
