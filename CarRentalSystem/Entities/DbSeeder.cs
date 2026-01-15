using CarRentalSystem.Entities.Maintenance;
using CarRentalSystem.Entities.Rentals;
using CarRentalSystem.Entities.Users;
using CarRentalSystem.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Entities
{
    public static class DbSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedBrands(modelBuilder);
            SeedModels(modelBuilder);
            SeedClients(modelBuilder);
            SeedEmployees(modelBuilder);
            SeedServiceCenters(modelBuilder);
            SeedCars(modelBuilder);
            SeedInsurances(modelBuilder);
            SeedRepairs(modelBuilder);
            SeedRentals(modelBuilder);
            SeedPayments(modelBuilder);
        }

        private static void SeedBrands(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                // European Brands
                new Brand { Id = 1, BrandName = "Toyota", Country = "Japan", BodyType = "Sedan", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 2, BrandName = "BMW", Country = "Germany", BodyType = "SUV", Year = 2023, Transmission = "Automatic" },
                new Brand { Id = 3, BrandName = "Ford", Country = "USA", BodyType = "Hatchback", Year = 2023, Transmission = "Manual" },
                new Brand { Id = 4, BrandName = "Audi", Country = "Germany", BodyType = "Coupe", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 5, BrandName = "Volkswagen", Country = "Germany", BodyType = "Sedan", Year = 2024, Transmission = "Manual" },
                new Brand { Id = 6, BrandName = "Honda", Country = "Japan", BodyType = "SUV", Year = 2023, Transmission = "Automatic" },
                new Brand { Id = 7, BrandName = "Mercedes-Benz", Country = "Germany", BodyType = "Sedan", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 8, BrandName = "Kia", Country = "South Korea", BodyType = "Hatchback", Year = 2023, Transmission = "Manual" },
                new Brand { Id = 9, BrandName = "Nissan", Country = "Japan", BodyType = "SUV", Year = 2023, Transmission = "Automatic" },
                new Brand { Id = 10, BrandName = "Chevrolet", Country = "USA", BodyType = "Coupe", Year = 2023, Transmission = "Manual" },
                
                // Additional European Brands
                new Brand { Id = 11, BrandName = "Peugeot", Country = "France", BodyType = "Hatchback", Year = 2024, Transmission = "Manual" },
                new Brand { Id = 12, BrandName = "Renault", Country = "France", BodyType = "SUV", Year = 2023, Transmission = "Automatic" },
                new Brand { Id = 13, BrandName = "Citroën", Country = "France", BodyType = "Sedan", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 14, BrandName = "Volvo", Country = "Sweden", BodyType = "SUV", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 15, BrandName = "SEAT", Country = "Spain", BodyType = "Hatchback", Year = 2023, Transmission = "Manual" },
                new Brand { Id = 16, BrandName = "Škoda", Country = "Czech Republic", BodyType = "Sedan", Year = 2024, Transmission = "Manual" },
                new Brand { Id = 17, BrandName = "Fiat", Country = "Italy", BodyType = "Hatchback", Year = 2023, Transmission = "Manual" },
                new Brand { Id = 18, BrandName = "Alfa Romeo", Country = "Italy", BodyType = "Coupe", Year = 2024, Transmission = "Automatic" },
                
                // Asian Brands
                new Brand { Id = 19, BrandName = "Hyundai", Country = "South Korea", BodyType = "SUV", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 20, BrandName = "Mazda", Country = "Japan", BodyType = "Sedan", Year = 2023, Transmission = "Manual" },
                new Brand { Id = 21, BrandName = "Subaru", Country = "Japan", BodyType = "SUV", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 22, BrandName = "Mitsubishi", Country = "Japan", BodyType = "SUV", Year = 2023, Transmission = "Automatic" },
                new Brand { Id = 23, BrandName = "Suzuki", Country = "Japan", BodyType = "Hatchback", Year = 2023, Transmission = "Manual" },
                
                // American Brands
                new Brand { Id = 24, BrandName = "Jeep", Country = "USA", BodyType = "SUV", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 25, BrandName = "Cadillac", Country = "USA", BodyType = "Sedan", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 26, BrandName = "Chrysler", Country = "USA", BodyType = "Sedan", Year = 2023, Transmission = "Automatic" },
                new Brand { Id = 27, BrandName = "Dodge", Country = "USA", BodyType = "Coupe", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 28, BrandName = "Lincoln", Country = "USA", BodyType = "SUV", Year = 2024, Transmission = "Automatic" },
                
                // Luxury & Premium Brands
                new Brand { Id = 29, BrandName = "Lexus", Country = "Japan", BodyType = "SUV", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 30, BrandName = "Infiniti", Country = "Japan", BodyType = "Sedan", Year = 2023, Transmission = "Automatic" },
                new Brand { Id = 31, BrandName = "Acura", Country = "Japan", BodyType = "SUV", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 32, BrandName = "Genesis", Country = "South Korea", BodyType = "Sedan", Year = 2024, Transmission = "Automatic" },
                
                // Electric/Hybrid Focus
                new Brand { Id = 33, BrandName = "Tesla", Country = "USA", BodyType = "Sedan", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 34, BrandName = "BYD", Country = "China", BodyType = "SUV", Year = 2024, Transmission = "Automatic" },
                new Brand { Id = 35, BrandName = "Polestar", Country = "Sweden", BodyType = "SUV", Year = 2024, Transmission = "Automatic" }
            );
        }

        private static void SeedModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasData(
                // Toyota Models (BrandId = 1)
                new Model { Id = 1, ModelName = "Corolla", BrandId = 1 },
                new Model { Id = 2, ModelName = "Camry", BrandId = 1 },
                new Model { Id = 3, ModelName = "RAV4", BrandId = 1 },
                new Model { Id = 4, ModelName = "Prius", BrandId = 1 },
                
                // BMW Models (BrandId = 2)
                new Model { Id = 5, ModelName = "X5", BrandId = 2 },
                new Model { Id = 6, ModelName = "3 Series", BrandId = 2 },
                new Model { Id = 7, ModelName = "X3", BrandId = 2 },
                new Model { Id = 8, ModelName = "5 Series", BrandId = 2 },
                
                // Ford Models (BrandId = 3)
                new Model { Id = 9, ModelName = "Focus", BrandId = 3 },
                new Model { Id = 10, ModelName = "Mustang", BrandId = 3 },
                new Model { Id = 11, ModelName = "Escape", BrandId = 3 },
                new Model { Id = 12, ModelName = "Explorer", BrandId = 3 },
                
                // Audi Models (BrandId = 4)
                new Model { Id = 13, ModelName = "A5", BrandId = 4 },
                new Model { Id = 14, ModelName = "Q5", BrandId = 4 },
                new Model { Id = 15, ModelName = "A4", BrandId = 4 },
                new Model { Id = 16, ModelName = "Q7", BrandId = 4 },
                
                // Volkswagen Models (BrandId = 5)
                new Model { Id = 17, ModelName = "Passat", BrandId = 5 },
                new Model { Id = 18, ModelName = "Golf", BrandId = 5 },
                new Model { Id = 19, ModelName = "Tiguan", BrandId = 5 },
                new Model { Id = 20, ModelName = "Polo", BrandId = 5 },
                
                // Honda Models (BrandId = 6)
                new Model { Id = 21, ModelName = "CR-V", BrandId = 6 },
                new Model { Id = 22, ModelName = "Civic", BrandId = 6 },
                new Model { Id = 23, ModelName = "Accord", BrandId = 6 },
                new Model { Id = 24, ModelName = "Pilot", BrandId = 6 },
                
                // Mercedes-Benz Models (BrandId = 7)
                new Model { Id = 25, ModelName = "C-Class", BrandId = 7 },
                new Model { Id = 26, ModelName = "E-Class", BrandId = 7 },
                new Model { Id = 27, ModelName = "GLC", BrandId = 7 },
                new Model { Id = 28, ModelName = "A-Class", BrandId = 7 },
                
                // Kia Models (BrandId = 8)
                new Model { Id = 29, ModelName = "Sportage", BrandId = 8 },
                new Model { Id = 30, ModelName = "Sorento", BrandId = 8 },
                new Model { Id = 31, ModelName = "Optima", BrandId = 8 },
                new Model { Id = 32, ModelName = "Rio", BrandId = 8 },
                
                // Nissan Models (BrandId = 9)
                new Model { Id = 33, ModelName = "Altima", BrandId = 9 },
                new Model { Id = 34, ModelName = "Rogue", BrandId = 9 },
                new Model { Id = 35, ModelName = "Sentra", BrandId = 9 },
                new Model { Id = 36, ModelName = "Pathfinder", BrandId = 9 },
                
                // Chevrolet Models (BrandId = 10)
                new Model { Id = 37, ModelName = "Malibu", BrandId = 10 },
                new Model { Id = 38, ModelName = "Equinox", BrandId = 10 },
                new Model { Id = 39, ModelName = "Tahoe", BrandId = 10 },
                new Model { Id = 40, ModelName = "Camaro", BrandId = 10 },
                
                // Peugeot Models (BrandId = 11)
                new Model { Id = 41, ModelName = "308", BrandId = 11 },
                new Model { Id = 42, ModelName = "3008", BrandId = 11 },
                new Model { Id = 43, ModelName = "208", BrandId = 11 },
                new Model { Id = 44, ModelName = "5008", BrandId = 11 },
                
                // Renault Models (BrandId = 12)
                new Model { Id = 45, ModelName = "Clio", BrandId = 12 },
                new Model { Id = 46, ModelName = "Megane", BrandId = 12 },
                new Model { Id = 47, ModelName = "Kadjar", BrandId = 12 },
                new Model { Id = 48, ModelName = "Captur", BrandId = 12 },
                
                // Citroën Models (BrandId = 13)
                new Model { Id = 49, ModelName = "C4", BrandId = 13 },
                new Model { Id = 50, ModelName = "C3", BrandId = 13 },
                new Model { Id = 51, ModelName = "C5 Aircross", BrandId = 13 },
                new Model { Id = 52, ModelName = "Berlingo", BrandId = 13 },
                
                // Volvo Models (BrandId = 14)
                new Model { Id = 53, ModelName = "XC60", BrandId = 14 },
                new Model { Id = 54, ModelName = "XC90", BrandId = 14 },
                new Model { Id = 55, ModelName = "V60", BrandId = 14 },
                new Model { Id = 56, ModelName = "S60", BrandId = 14 },
                
                // SEAT Models (BrandId = 15)
                new Model { Id = 57, ModelName = "Leon", BrandId = 15 },
                new Model { Id = 58, ModelName = "Ibiza", BrandId = 15 },
                new Model { Id = 59, ModelName = "Ateca", BrandId = 15 },
                new Model { Id = 60, ModelName = "Arona", BrandId = 15 },
                
                // Škoda Models (BrandId = 16)
                new Model { Id = 61, ModelName = "Octavia", BrandId = 16 },
                new Model { Id = 62, ModelName = "Superb", BrandId = 16 },
                new Model { Id = 63, ModelName = "Karoq", BrandId = 16 },
                new Model { Id = 64, ModelName = "Fabia", BrandId = 16 },
                
                // Fiat Models (BrandId = 17)
                new Model { Id = 65, ModelName = "500", BrandId = 17 },
                new Model { Id = 66, ModelName = "Panda", BrandId = 17 },
                new Model { Id = 67, ModelName = "Tipo", BrandId = 17 },
                new Model { Id = 68, ModelName = "500X", BrandId = 17 },
                
                // Alfa Romeo Models (BrandId = 18)
                new Model { Id = 69, ModelName = "Giulia", BrandId = 18 },
                new Model { Id = 70, ModelName = "Stelvio", BrandId = 18 },
                new Model { Id = 71, ModelName = "Giulietta", BrandId = 18 },
                new Model { Id = 72, ModelName = "4C", BrandId = 18 },
                
                // Hyundai Models (BrandId = 19)
                new Model { Id = 73, ModelName = "Elantra", BrandId = 19 },
                new Model { Id = 74, ModelName = "Tucson", BrandId = 19 },
                new Model { Id = 75, ModelName = "Santa Fe", BrandId = 19 },
                new Model { Id = 76, ModelName = "Sonata", BrandId = 19 },
                
                // Mazda Models (BrandId = 20)
                new Model { Id = 77, ModelName = "Mazda3", BrandId = 20 },
                new Model { Id = 78, ModelName = "CX-5", BrandId = 20 },
                new Model { Id = 79, ModelName = "Mazda6", BrandId = 20 },
                new Model { Id = 80, ModelName = "CX-3", BrandId = 20 },
                
                // Subaru Models (BrandId = 21)
                new Model { Id = 81, ModelName = "Outback", BrandId = 21 },
                new Model { Id = 82, ModelName = "Forester", BrandId = 21 },
                new Model { Id = 83, ModelName = "Impreza", BrandId = 21 },
                new Model { Id = 84, ModelName = "XV", BrandId = 21 },
                
                // Mitsubishi Models (BrandId = 22)
                new Model { Id = 85, ModelName = "Outlander", BrandId = 22 },
                new Model { Id = 86, ModelName = "ASX", BrandId = 22 },
                new Model { Id = 87, ModelName = "Eclipse Cross", BrandId = 22 },
                new Model { Id = 88, ModelName = "Lancer", BrandId = 22 },
                
                // Suzuki Models (BrandId = 23)
                new Model { Id = 89, ModelName = "Swift", BrandId = 23 },
                new Model { Id = 90, ModelName = "Vitara", BrandId = 23 },
                new Model { Id = 91, ModelName = "Baleno", BrandId = 23 },
                new Model { Id = 92, ModelName = "Jimny", BrandId = 23 },
                
                // Jeep Models (BrandId = 24)
                new Model { Id = 93, ModelName = "Cherokee", BrandId = 24 },
                new Model { Id = 94, ModelName = "Grand Cherokee", BrandId = 24 },
                new Model { Id = 95, ModelName = "Wrangler", BrandId = 24 },
                new Model { Id = 96, ModelName = "Compass", BrandId = 24 },
                
                // Cadillac Models (BrandId = 25)
                new Model { Id = 97, ModelName = "Escalade", BrandId = 25 },
                new Model { Id = 98, ModelName = "XT5", BrandId = 25 },
                new Model { Id = 99, ModelName = "CT5", BrandId = 25 },
                new Model { Id = 100, ModelName = "XT6", BrandId = 25 },
                
                // Tesla Models (BrandId = 33)
                new Model { Id = 101, ModelName = "Model 3", BrandId = 33 },
                new Model { Id = 102, ModelName = "Model Y", BrandId = 33 },
                new Model { Id = 103, ModelName = "Model S", BrandId = 33 },
                new Model { Id = 104, ModelName = "Model X", BrandId = 33 }
            );
        }

        private static void SeedClients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                // Original Clients (1-10)
                new Client { Id = 1, FirstName = "Jan", LastName = "Kowalski", PESEL = "88010112345", PhoneNumber = "600123456", Email = "jan.kowalski@example.com", City = "Warszawa", PostalCode = "00-001" },
                new Client { Id = 2, FirstName = "Anna", LastName = "Nowak", PESEL = "90020223456", PhoneNumber = "601234567", Email = "anna.nowak@example.com", City = "Kraków", PostalCode = "30-002" },
                new Client { Id = 3, FirstName = "Piotr", LastName = "Wiśniewski", PESEL = "85030334567", PhoneNumber = "602345678", Email = "piotr.wisniewski@example.com", City = "Gdańsk", PostalCode = "80-003" },
                new Client { Id = 4, FirstName = "Katarzyna", LastName = "Wójcik", PESEL = "92040445678", PhoneNumber = "603456789", Email = "katarzyna.wojcik@example.com", City = "Poznań", PostalCode = "60-004" },
                new Client { Id = 5, FirstName = "Michał", LastName = "Krawczyk", PESEL = "87050556789", PhoneNumber = "604567890", Email = "michal.krawczyk@example.com", City = "Łódź", PostalCode = "90-005" },
                new Client { Id = 6, FirstName = "Agnieszka", LastName = "Kamińska", PESEL = "91060667890", PhoneNumber = "605678901", Email = "agnieszka.kaminska@example.com", City = "Wrocław", PostalCode = "50-006" },
                new Client { Id = 7, FirstName = "Tomasz", LastName = "Lewandowski", PESEL = "86070778901", PhoneNumber = "606789012", Email = "tomasz.lewandowski@example.com", City = "Szczecin", PostalCode = "70-007" },
                new Client { Id = 8, FirstName = "Magdalena", LastName = "Zielińska", PESEL = "93080889012", PhoneNumber = "607890123", Email = "magdalena.zielinska@example.com", City = "Bydgoszcz", PostalCode = "85-008" },
                new Client { Id = 9, FirstName = "Łukasz", LastName = "Szymański", PESEL = "88090990123", PhoneNumber = "608901234", Email = "lukasz.szymanski@example.com", City = "Lublin", PostalCode = "20-009" },
                new Client { Id = 10, FirstName = "Ewa", LastName = "Dąbrowska", PESEL = "90010101234", PhoneNumber = "609012345", Email = "ewa.dabrowska@example.com", City = "Katowice", PostalCode = "40-010" },
                
                // Additional Clients from Major Cities (11-25)
                new Client { Id = 11, FirstName = "Krzysztof", LastName = "Jankowski", PESEL = "89110101345", PhoneNumber = "610123456", Email = "krzysztof.jankowski@example.com", City = "Warszawa", PostalCode = "02-011" },
                new Client { Id = 12, FirstName = "Monika", LastName = "Kowalczyk", PESEL = "94120212456", PhoneNumber = "611234567", Email = "monika.kowalczyk@example.com", City = "Kraków", PostalCode = "31-012" },
                new Client { Id = 13, FirstName = "Paweł", LastName = "Mazurek", PESEL = "83130323567", PhoneNumber = "612345678", Email = "pawel.mazurek@example.com", City = "Gdańsk", PostalCode = "80-013" },
                new Client { Id = 14, FirstName = "Joanna", LastName = "Król", PESEL = "91140434678", PhoneNumber = "613456789", Email = "joanna.krol@example.com", City = "Poznań", PostalCode = "61-014" },
                new Client { Id = 15, FirstName = "Robert", LastName = "Zając", PESEL = "86150545789", PhoneNumber = "614567890", Email = "robert.zajac@example.com", City = "Łódź", PostalCode = "91-015" },
                new Client { Id = 16, FirstName = "Justyna", LastName = "Pawlak", PESEL = "89160656890", PhoneNumber = "615678901", Email = "justyna.pawlak@example.com", City = "Wrocław", PostalCode = "51-016" },
                new Client { Id = 17, FirstName = "Marcin", LastName = "Sikora", PESEL = "92170767901", PhoneNumber = "616789012", Email = "marcin.sikora@example.com", City = "Szczecin", PostalCode = "71-017" },
                new Client { Id = 18, FirstName = "Aleksandra", LastName = "Baran", PESEL = "85180878012", PhoneNumber = "617890123", Email = "aleksandra.baran@example.com", City = "Bydgoszcz", PostalCode = "85-018" },
                new Client { Id = 19, FirstName = "Grzegorz", LastName = "Dudek", PESEL = "88190989123", PhoneNumber = "618901234", Email = "grzegorz.dudek@example.com", City = "Lublin", PostalCode = "20-019" },
                new Client { Id = 20, FirstName = "Beata", LastName = "Głowacka", PESEL = "93200090234", PhoneNumber = "619012345", Email = "beata.glowacka@example.com", City = "Katowice", PostalCode = "40-020" },
                new Client { Id = 21, FirstName = "Rafał", LastName = "Michalski", PESEL = "87210101345", PhoneNumber = "620123456", Email = "rafal.michalski@example.com", City = "Gdynia", PostalCode = "81-021" },
                new Client { Id = 22, FirstName = "Dorota", LastName = "Kubiak", PESEL = "90220212456", PhoneNumber = "621234567", Email = "dorota.kubiak@example.com", City = "Toruń", PostalCode = "87-022" },
                new Client { Id = 23, FirstName = "Dariusz", LastName = "Włodarczyk", PESEL = "84230323567", PhoneNumber = "622345678", Email = "dariusz.wlodarczyk@example.com", City = "Rzeszów", PostalCode = "35-023" },
                new Client { Id = 24, FirstName = "Małgorzata", LastName = "Czarnecka", PESEL = "91240434678", PhoneNumber = "623456789", Email = "malgorzata.czarnecka@example.com", City = "Olsztyn", PostalCode = "10-024" },
                new Client { Id = 25, FirstName = "Jacek", LastName = "Stępień", PESEL = "89250545789", PhoneNumber = "624567890", Email = "jacek.stepien@example.com", City = "Kielce", PostalCode = "25-025" },
                
                // Clients from Smaller Cities (26-35)
                new Client { Id = 26, FirstName = "Renata", LastName = "Urbańska", PESEL = "92260656890", PhoneNumber = "625678901", Email = "renata.urbanska@example.com", City = "Opole", PostalCode = "45-026" },
                new Client { Id = 27, FirstName = "Andrzej", LastName = "Górski", PESEL = "86270767901", PhoneNumber = "626789012", Email = "andrzej.gorski@example.com", City = "Płock", PostalCode = "09-027" },
                new Client { Id = 28, FirstName = "Izabela", LastName = "Kozłowska", PESEL = "88280878012", PhoneNumber = "627890123", Email = "izabela.kozlowska@example.com", City = "Słupsk", PostalCode = "76-028" },
                new Client { Id = 29, FirstName = "Mariusz", LastName = "Jaworski", PESEL = "85290989123", PhoneNumber = "628901234", Email = "mariusz.jaworski@example.com", City = "Tarnów", PostalCode = "33-029" },
                new Client { Id = 30, FirstName = "Grażyna", LastName = "Sobczak", PESEL = "94300090234", PhoneNumber = "629012345", Email = "grazyna.sobczak@example.com", City = "Legnica", PostalCode = "59-030" },
                new Client { Id = 31, FirstName = "Zbigniew", LastName = "Pietrzak", PESEL = "83310101345", PhoneNumber = "630123456", Email = "zbigniew.pietrzak@example.com", City = "Elbląg", PostalCode = "82-031" },
                new Client { Id = 32, FirstName = "Danuta", LastName = "Sadowska", PESEL = "90320212456", PhoneNumber = "631234567", Email = "danuta.sadowska@example.com", City = "Zamość", PostalCode = "22-032" },
                new Client { Id = 33, FirstName = "Stanisław", LastName = "Zawadzki", PESEL = "87330323567", PhoneNumber = "632345678", Email = "stanislaw.zawadzki@example.com", City = "Chełm", PostalCode = "22-033" },
                new Client { Id = 34, FirstName = "Halina", LastName = "Olejniczak", PESEL = "91340434678", PhoneNumber = "633456789", Email = "halina.olejniczak@example.com", City = "Grudziądz", PostalCode = "86-034" },
                new Client { Id = 35, FirstName = "Ryszard", LastName = "Marciniak", PESEL = "89350545789", PhoneNumber = "634567890", Email = "ryszard.marciniak@example.com", City = "Przemyśl", PostalCode = "37-035" },
                
                // Young Generation Clients (36-45)
                new Client { Id = 36, FirstName = "Natalia", LastName = "Kowalik", PESEL = "96360656890", PhoneNumber = "635678901", Email = "natalia.kowalik@example.com", City = "Warszawa", PostalCode = "03-036" },
                new Client { Id = 37, FirstName = "Mateusz", LastName = "Rutkowski", PESEL = "95370767901", PhoneNumber = "636789012", Email = "mateusz.rutkowski@example.com", City = "Kraków", PostalCode = "30-037" },
                new Client { Id = 38, FirstName = "Wiktoria", LastName = "Malinowska", PESEL = "97380878012", PhoneNumber = "637890123", Email = "wiktoria.malinowska@example.com", City = "Gdańsk", PostalCode = "80-038" },
                new Client { Id = 39, FirstName = "Adrian", LastName = "Szewczyk", PESEL = "98390989123", PhoneNumber = "638901234", Email = "adrian.szewczyk@example.com", City = "Poznań", PostalCode = "60-039" },
                new Client { Id = 40, FirstName = "Julia", LastName = "Woźniak", PESEL = "99400090234", PhoneNumber = "639012345", Email = "julia.wozniak@example.com", City = "Łódź", PostalCode = "90-040" },
                new Client { Id = 41, FirstName = "Jakub", LastName = "Adamski", PESEL = "96410101345", PhoneNumber = "640123456", Email = "jakub.adamski@example.com", City = "Wrocław", PostalCode = "50-041" },
                new Client { Id = 42, FirstName = "Zuzanna", LastName = "Kołodziej", PESEL = "97420212456", PhoneNumber = "641234567", Email = "zuzanna.kolodziej@example.com", City = "Gdynia", PostalCode = "81-042" },
                new Client { Id = 43, FirstName = "Bartosz", LastName = "Borkowski", PESEL = "95430323567", PhoneNumber = "642345678", Email = "bartosz.borkowski@example.com", City = "Szczecin", PostalCode = "70-043" },
                new Client { Id = 44, FirstName = "Oliwia", LastName = "Witkowska", PESEL = "98440434678", PhoneNumber = "643456789", Email = "oliwia.witkowska@example.com", City = "Radom", PostalCode = "26-044" },
                new Client { Id = 45, FirstName = "Kacper", LastName = "Chmielewski", PESEL = "99450545789", PhoneNumber = "644567890", Email = "kacper.chmielewski@example.com", City = "Sosnowiec", PostalCode = "41-045" },
                
                // Business Clients & Premium Customers (46-50)
                new Client { Id = 46, FirstName = "Helena", LastName = "Zakrzewska", PESEL = "82460656890", PhoneNumber = "645678901", Email = "helena.zakrzewska@example.com", City = "Warszawa", PostalCode = "00-046" },
                new Client { Id = 47, FirstName = "Waldemar", LastName = "Jabłoński", PESEL = "80470767901", PhoneNumber = "646789012", Email = "waldemar.jablonski@example.com", City = "Kraków", PostalCode = "31-047" },
                new Client { Id = 48, FirstName = "Teresa", LastName = "Lis", PESEL = "78480878012", PhoneNumber = "647890123", Email = "teresa.lis@example.com", City = "Gdańsk", PostalCode = "80-048" },
                new Client { Id = 49, FirstName = "Kazimierz", LastName = "Czerwiński", PESEL = "75490989123", PhoneNumber = "648901234", Email = "kazimierz.czerwinski@example.com", City = "Poznań", PostalCode = "61-049" },
                new Client { Id = 50, FirstName = "Elżbieta", LastName = "Jasiński", PESEL = "79500090234", PhoneNumber = "649012345", Email = "elzbieta.jasinski@example.com", City = "Wrocław", PostalCode = "51-050" }
            );
        }

        private static void SeedEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                // Original Management & Core Staff (1-10)
                new Employee { Id = 1, FirstName = "Piotr", LastName = "Nowak", Position = "Kierownik", HireDate = new DateTime(2018, 5, 10), Salary = 5500m, Phone = "600111222" },
                new Employee { Id = 2, FirstName = "Anna", LastName = "Kowalska", Position = "Kasjer", HireDate = new DateTime(2019, 3, 15), Salary = 4200m, Phone = "601222333" },
                new Employee { Id = 3, FirstName = "Michał", LastName = "Wiśniewski", Position = "Specjalista ds. Wynajmu", HireDate = new DateTime(2020, 7, 1), Salary = 4800m, Phone = "602333444" },
                new Employee { Id = 4, FirstName = "Katarzyna", LastName = "Wójcik", Position = "Asystent", HireDate = new DateTime(2021, 1, 20), Salary = 4000m, Phone = "603444555" },
                new Employee { Id = 5, FirstName = "Tomasz", LastName = "Kamiński", Position = "Mechanik", HireDate = new DateTime(2017, 11, 5), Salary = 5000m, Phone = "604555666" },
                new Employee { Id = 6, FirstName = "Magdalena", LastName = "Lewandowska", Position = "Specjalista ds. Klientów", HireDate = new DateTime(2019, 6, 18), Salary = 4700m, Phone = "605666777" },
                new Employee { Id = 7, FirstName = "Łukasz", LastName = "Zieliński", Position = "Kierownik ds. Floty", HireDate = new DateTime(2018, 9, 12), Salary = 5600m, Phone = "606777888" },
                new Employee { Id = 8, FirstName = "Ewa", LastName = "Szymańska", Position = "Asystent", HireDate = new DateTime(2020, 2, 28), Salary = 4100m, Phone = "607888999" },
                new Employee { Id = 9, FirstName = "Paweł", LastName = "Dąbrowski", Position = "Specjalista ds. Wynajmu", HireDate = new DateTime(2021, 8, 10), Salary = 4500m, Phone = "608999000" },
                new Employee { Id = 10, FirstName = "Agnieszka", LastName = "Kowalczyk", Position = "Kasjer", HireDate = new DateTime(2019, 4, 22), Salary = 4300m, Phone = "609000111" },
                
                // Senior Management & Department Heads (11-15)
                new Employee { Id = 11, FirstName = "Robert", LastName = "Jankowski", Position = "Dyrektor Generalny", HireDate = new DateTime(2015, 1, 15), Salary = 8500m, Phone = "610111222" },
                new Employee { Id = 12, FirstName = "Joanna", LastName = "Mazurek", Position = "Dyrektor ds. Operacyjnych", HireDate = new DateTime(2016, 3, 20), Salary = 7500m, Phone = "611222333" },
                new Employee { Id = 13, FirstName = "Krzysztof", LastName = "Sikora", Position = "Kierownik ds. Finansów", HireDate = new DateTime(2017, 2, 10), Salary = 6500m, Phone = "612333444" },
                new Employee { Id = 14, FirstName = "Monika", LastName = "Baran", Position = "Kierownik ds. Marketingu", HireDate = new DateTime(2018, 8, 5), Salary = 6000m, Phone = "613444555" },
                new Employee { Id = 15, FirstName = "Marcin", LastName = "Dudek", Position = "Kierownik ds. IT", HireDate = new DateTime(2019, 11, 12), Salary = 6800m, Phone = "614555666" },
                
                // Customer Service & Sales Team (16-25)
                new Employee { Id = 16, FirstName = "Justyna", LastName = "Głowacka", Position = "Specjalista ds. Sprzedaży", HireDate = new DateTime(2020, 5, 18), Salary = 4600m, Phone = "615666777" },
                new Employee { Id = 17, FirstName = "Rafał", LastName = "Michalski", Position = "Konsultant ds. Klientów", HireDate = new DateTime(2021, 9, 3), Salary = 4200m, Phone = "616777888" },
                new Employee { Id = 18, FirstName = "Dorota", LastName = "Kubiak", Position = "Specjalista ds. Rezerwacji", HireDate = new DateTime(2020, 12, 7), Salary = 4400m, Phone = "617888999" },
                new Employee { Id = 19, FirstName = "Dariusz", LastName = "Włodarczyk", Position = "Przedstawiciel Handlowy", HireDate = new DateTime(2021, 6, 14), Salary = 4500m, Phone = "618999000" },
                new Employee { Id = 20, FirstName = "Małgorzata", LastName = "Czarnecka", Position = "Koordynator Obsługi Klienta", HireDate = new DateTime(2019, 10, 25), Salary = 5000m, Phone = "619000111" },
                new Employee { Id = 21, FirstName = "Jacek", LastName = "Stępień", Position = "Specjalista ds. Wynajmu", HireDate = new DateTime(2022, 1, 8), Salary = 4300m, Phone = "620111222" },
                new Employee { Id = 22, FirstName = "Renata", LastName = "Urbańska", Position = "Konsultant Telefoniczny", HireDate = new DateTime(2021, 11, 19), Salary = 3900m, Phone = "621222333" },
                new Employee { Id = 23, FirstName = "Andrzej", LastName = "Górski", Position = "Specjalista ds. Korporacyjnych", HireDate = new DateTime(2020, 4, 16), Salary = 5200m, Phone = "622333444" },
                new Employee { Id = 24, FirstName = "Izabela", LastName = "Kozłowska", Position = "Asystent ds. Sprzedaży", HireDate = new DateTime(2022, 3, 11), Salary = 3800m, Phone = "623444555" },
                new Employee { Id = 25, FirstName = "Mariusz", LastName = "Jaworski", Position = "Kierownik Działu Sprzedaży", HireDate = new DateTime(2018, 7, 22), Salary = 5800m, Phone = "624555666" },
                
                // Technical & Maintenance Staff (26-35)
                new Employee { Id = 26, FirstName = "Grażyna", LastName = "Sobczak", Position = "Starszy Mechanik", HireDate = new DateTime(2016, 12, 9), Salary = 5500m, Phone = "625666777" },
                new Employee { Id = 27, FirstName = "Zbigniew", LastName = "Pietrzak", Position = "Diagnostyk Samochodowy", HireDate = new DateTime(2017, 8, 14), Salary = 5200m, Phone = "626777888" },
                new Employee { Id = 28, FirstName = "Danuta", LastName = "Sadowska", Position = "Kontroler Jakości", HireDate = new DateTime(2019, 2, 6), Salary = 4800m, Phone = "627888999" },
                new Employee { Id = 29, FirstName = "Stanisław", LastName = "Zawadzki", Position = "Mechanik", HireDate = new DateTime(2020, 9, 21), Salary = 4500m, Phone = "628999000" },
                new Employee { Id = 30, FirstName = "Halina", LastName = "Olejniczak", Position = "Inspektor Floty", HireDate = new DateTime(2018, 5, 17), Salary = 5000m, Phone = "629000111" },
                new Employee { Id = 31, FirstName = "Ryszard", LastName = "Marciniak", Position = "Kierownik Warsztatu", HireDate = new DateTime(2015, 11, 3), Salary = 6200m, Phone = "630111222" },
                new Employee { Id = 32, FirstName = "Natalia", LastName = "Kowalik", Position = "Specjalista ds. Części", HireDate = new DateTime(2021, 4, 28), Salary = 4100m, Phone = "631222333" },
                new Employee { Id = 33, FirstName = "Mateusz", LastName = "Rutkowski", Position = "Elektryk Samochodowy", HireDate = new DateTime(2020, 1, 12), Salary = 4700m, Phone = "632333444" },
                new Employee { Id = 34, FirstName = "Wiktoria", LastName = "Malinowska", Position = "Asystent Techniczna", HireDate = new DateTime(2022, 7, 9), Salary = 3700m, Phone = "633444555" },
                new Employee { Id = 35, FirstName = "Adrian", LastName = "Szewczyk", Position = "Młodszy Mechanik", HireDate = new DateTime(2023, 2, 15), Salary = 4000m, Phone = "634555666" },
                
                // Administration & Support (36-45)
                new Employee { Id = 36, FirstName = "Julia", LastName = "Woźniak", Position = "Specjalista ds. HR", HireDate = new DateTime(2019, 6, 11), Salary = 5100m, Phone = "635666777" },
                new Employee { Id = 37, FirstName = "Jakub", LastName = "Adamski", Position = "Księgowy", HireDate = new DateTime(2018, 1, 24), Salary = 5300m, Phone = "636777888" },
                new Employee { Id = 38, FirstName = "Zuzanna", LastName = "Kołodziej", Position = "Administrator Systemu", HireDate = new DateTime(2020, 10, 7), Salary = 5600m, Phone = "637888999" },
                new Employee { Id = 39, FirstName = "Bartosz", LastName = "Borkowski", Position = "Analityk Biznesowy", HireDate = new DateTime(2021, 3, 18), Salary = 5800m, Phone = "638999000" },
                new Employee { Id = 40, FirstName = "Oliwia", LastName = "Witkowska", Position = "Specjalista ds. Ubezpieczeń", HireDate = new DateTime(2020, 8, 5), Salary = 4900m, Phone = "639000111" },
                new Employee { Id = 41, FirstName = "Kacper", LastName = "Chmielewski", Position = "Prawnik", HireDate = new DateTime(2019, 12, 13), Salary = 6500m, Phone = "640111222" },
                new Employee { Id = 42, FirstName = "Helena", LastName = "Zakrzewska", Position = "Koordynator ds. Szkoleń", HireDate = new DateTime(2018, 4, 29), Salary = 4600m, Phone = "641222333" },
                new Employee { Id = 43, FirstName = "Waldemar", LastName = "Jabłoński", Position = "Specjalista ds. Bezpieczeństwa", HireDate = new DateTime(2017, 9, 16), Salary = 5400m, Phone = "642333444" },
                new Employee { Id = 44, FirstName = "Teresa", LastName = "Lis", Position = "Asystent Zarządu", HireDate = new DateTime(2016, 6, 8), Salary = 4700m, Phone = "643444555" },
                new Employee { Id = 45, FirstName = "Kazimierz", LastName = "Czerwiński", Position = "Kierownik ds. Logistyki", HireDate = new DateTime(2017, 3, 27), Salary = 5900m, Phone = "644555666" },
                
                // Field Operations & Regional Staff (46-50)
                new Employee { Id = 46, FirstName = "Elżbieta", LastName = "Jasiński", Position = "Kierownik Oddziału Warszawa", HireDate = new DateTime(2016, 10, 14), Salary = 6300m, Phone = "645666777" },
                new Employee { Id = 47, FirstName = "Bogdan", LastName = "Nowicki", Position = "Kierownik Oddziału Kraków", HireDate = new DateTime(2017, 5, 21), Salary = 6100m, Phone = "646777888" },
                new Employee { Id = 48, FirstName = "Krystyna", LastName = "Wieczorek", Position = "Kierownik Oddziału Gdańsk", HireDate = new DateTime(2018, 2, 3), Salary = 5900m, Phone = "647888999" },
                new Employee { Id = 49, FirstName = "Tadeusz", LastName = "Maj", Position = "Inspektor Regionalny", HireDate = new DateTime(2015, 8, 18), Salary = 6400m, Phone = "648999000" },
                new Employee { Id = 50, FirstName = "Janina", LastName = "Kaczmarek", Position = "Koordynator ds. Floty Regionalnej", HireDate = new DateTime(2019, 9, 10), Salary = 5700m, Phone = "649000111" }
            );
        }

        private static void SeedServiceCenters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceCenter>().HasData(
                // Original Service Centers (1-10)
                new ServiceCenter { Id = 1, Name = "Auto Serwis Warszawa", City = "Warszawa", Phone = "600111222", Email = "kontakt@warszawa-serwis.pl", PartnershipStartDate = new DateTime(2015, 1, 10) },
                new ServiceCenter { Id = 2, Name = "Mechanika Kraków", City = "Kraków", Phone = "601222333", Email = "biuro@mechanikakrakow.pl", PartnershipStartDate = new DateTime(2016, 3, 15) },
                new ServiceCenter { Id = 3, Name = "Serwis Gdańsk", City = "Gdańsk", Phone = "602333444", Email = "kontakt@serwisgdansk.pl", PartnershipStartDate = new DateTime(2017, 5, 20) },
                new ServiceCenter { Id = 4, Name = "AutoNaprawa Poznań", City = "Poznań", Phone = "603444555", Email = "biuro@autonaprawapoznan.pl", PartnershipStartDate = new DateTime(2018, 7, 1) },
                new ServiceCenter { Id = 5, Name = "Warsztat Łódź", City = "Łódź", Phone = "604555666", Email = "kontakt@warsztatlodz.pl", PartnershipStartDate = new DateTime(2016, 9, 5) },
                new ServiceCenter { Id = 6, Name = "Auto Serwis Wrocław", City = "Wrocław", Phone = "605666777", Email = "biuro@wroclaw-serwis.pl", PartnershipStartDate = new DateTime(2017, 11, 10) },
                new ServiceCenter { Id = 7, Name = "Mechanika Szczecin", City = "Szczecin", Phone = "606777888", Email = "kontakt@mechanikaszczecin.pl", PartnershipStartDate = new DateTime(2015, 2, 12) },
                new ServiceCenter { Id = 8, Name = "Serwis Bydgoszcz", City = "Bydgoszcz", Phone = "607888999", Email = "biuro@serwisbydgoszcz.pl", PartnershipStartDate = new DateTime(2016, 4, 18) },
                new ServiceCenter { Id = 9, Name = "Warsztat Lublin", City = "Lublin", Phone = "608999000", Email = "kontakt@warsztatlublin.pl", PartnershipStartDate = new DateTime(2017, 6, 22) },
                new ServiceCenter { Id = 10, Name = "AutoNaprawa Katowice", City = "Katowice", Phone = "609000111", Email = "biuro@autonaprawakatowice.pl", PartnershipStartDate = new DateTime(2018, 8, 30) },
                
                // Premium & Specialized Service Centers (11-20)
                new ServiceCenter { Id = 11, Name = "BMW Serwis Premium", City = "Warszawa", Phone = "650111222", Email = "premium@bmwserwis.pl", PartnershipStartDate = new DateTime(2019, 1, 15) },
                new ServiceCenter { Id = 12, Name = "Mercedes Autoryzowany Serwis", City = "Kraków", Phone = "651222333", Email = "serwis@mercedes-krakow.pl", PartnershipStartDate = new DateTime(2019, 3, 20) },
                new ServiceCenter { Id = 13, Name = "Audi Service Center", City = "Gdańsk", Phone = "652333444", Email = "centrum@audiserwis.pl", PartnershipStartDate = new DateTime(2018, 11, 12) },
                new ServiceCenter { Id = 14, Name = "Toyota Autoryzowany Partner", City = "Poznań", Phone = "653444555", Email = "partner@toyotapoznan.pl", PartnershipStartDate = new DateTime(2017, 9, 8) },
                new ServiceCenter { Id = 15, Name = "Volkswagen Service Point", City = "Wrocław", Phone = "654555666", Email = "service@vwwroclaw.pl", PartnershipStartDate = new DateTime(2018, 5, 25) },
                new ServiceCenter { Id = 16, Name = "Ford Quick Service", City = "Łódź", Phone = "655666777", Email = "quick@fordlodz.pl", PartnershipStartDate = new DateTime(2019, 7, 14) },
                new ServiceCenter { Id = 17, Name = "Volvo Safety Center", City = "Gdynia", Phone = "656777888", Email = "safety@volvogdynia.pl", PartnershipStartDate = new DateTime(2020, 2, 18) },
                new ServiceCenter { Id = 18, Name = "Škoda Family Service", City = "Toruń", Phone = "657888999", Email = "family@skodatorun.pl", PartnershipStartDate = new DateTime(2019, 10, 5) },
                new ServiceCenter { Id = 19, Name = "Peugeot Express Serwis", City = "Rzeszów", Phone = "658999000", Email = "express@peugeotrzeszow.pl", PartnershipStartDate = new DateTime(2020, 6, 22) },
                new ServiceCenter { Id = 20, Name = "Renault City Service", City = "Olsztyn", Phone = "659000111", Email = "city@renaultolsztyn.pl", PartnershipStartDate = new DateTime(2020, 9, 15) },
                
                // Regional & Mobile Service Centers (21-30)
                new ServiceCenter { Id = 21, Name = "Auto Express Kielce", City = "Kielce", Phone = "660111222", Email = "express@autokielce.pl", PartnershipStartDate = new DateTime(2021, 1, 10) },
                new ServiceCenter { Id = 22, Name = "Mobilny Serwis Północ", City = "Elbląg", Phone = "661222333", Email = "mobilny@serwispolnoc.pl", PartnershipStartDate = new DateTime(2020, 11, 8) },
                new ServiceCenter { Id = 23, Name = "Warsztat Podlaski", City = "Białystok", Phone = "662333444", Email = "warsztat@podlaski.pl", PartnershipStartDate = new DateTime(2019, 12, 3) },
                new ServiceCenter { Id = 24, Name = "Serwis Śląsk", City = "Gliwice", Phone = "663444555", Email = "slask@serwisslask.pl", PartnershipStartDate = new DateTime(2018, 4, 17) },
                new ServiceCenter { Id = 25, Name = "Auto Centrum Opole", City = "Opole", Phone = "664555666", Email = "centrum@autoopole.pl", PartnershipStartDate = new DateTime(2019, 8, 12) },
                new ServiceCenter { Id = 26, Name = "Mechanika Morska", City = "Słupsk", Phone = "665666777", Email = "morska@mechanika.pl", PartnershipStartDate = new DateTime(2020, 3, 28) },
                new ServiceCenter { Id = 27, Name = "Serwis Małopolski", City = "Tarnów", Phone = "666777888", Email = "malopolski@serwis.pl", PartnershipStartDate = new DateTime(2021, 5, 6) },
                new ServiceCenter { Id = 28, Name = "Auto Naprawa Zachód", City = "Zielona Góra", Phone = "667888999", Email = "zachod@autonaprawa.pl", PartnershipStartDate = new DateTime(2020, 7, 19) },
                new ServiceCenter { Id = 29, Name = "Warsztat Podkarpacki", City = "Przemyśl", Phone = "668999000", Email = "podkarpacki@warsztat.pl", PartnershipStartDate = new DateTime(2021, 2, 24) },
                new ServiceCenter { Id = 30, Name = "Express Auto Serwis", City = "Legnica", Phone = "669000111", Email = "express@autoserwis.pl", PartnershipStartDate = new DateTime(2020, 12, 11) },
                
                // Electric & Hybrid Specialists (31-35)
                new ServiceCenter { Id = 31, Name = "Tesla Service Center", City = "Warszawa", Phone = "670111222", Email = "service@tesla-warszawa.pl", PartnershipStartDate = new DateTime(2022, 1, 15) },
                new ServiceCenter { Id = 32, Name = "EV Specialists Kraków", City = "Kraków", Phone = "671222333", Email = "ev@specialistskrakow.pl", PartnershipStartDate = new DateTime(2022, 3, 8) },
                new ServiceCenter { Id = 33, Name = "Hybrid Tech Gdańsk", City = "Gdańsk", Phone = "672333444", Email = "hybrid@techgdansk.pl", PartnershipStartDate = new DateTime(2021, 11, 22) },
                new ServiceCenter { Id = 34, Name = "Green Motors Service", City = "Wrocław", Phone = "673444555", Email = "green@motorswroclaw.pl", PartnershipStartDate = new DateTime(2022, 6, 10) },
                new ServiceCenter { Id = 35, Name = "Eco Drive Center", City = "Poznań", Phone = "674555666", Email = "eco@drivepoznan.pl", PartnershipStartDate = new DateTime(2022, 9, 14) },
                
                // Budget & Quick Service (36-40)
                new ServiceCenter { Id = 36, Name = "Quick Fix Auto", City = "Częstochowa", Phone = "675666777", Email = "quick@fixauto.pl", PartnershipStartDate = new DateTime(2021, 7, 5) },
                new ServiceCenter { Id = 37, Name = "Budget Car Service", City = "Radom", Phone = "676777888", Email = "budget@carservice.pl", PartnershipStartDate = new DateTime(2021, 4, 18) },
                new ServiceCenter { Id = 38, Name = "Fast Lane Mechanics", City = "Płock", Phone = "677888999", Email = "fast@lanemechanics.pl", PartnershipStartDate = new DateTime(2021, 9, 26) },
                new ServiceCenter { Id = 39, Name = "Speed Service 24h", City = "Włocławek", Phone = "678999000", Email = "speed@service24h.pl", PartnershipStartDate = new DateTime(2022, 2, 3) },
                new ServiceCenter { Id = 40, Name = "Auto Fix Express", City = "Siedlce", Phone = "679000111", Email = "autofix@express.pl", PartnershipStartDate = new DateTime(2021, 12, 15) }
            );
        }

        private static void SeedCars(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                // Economy Cars - Toyota (1-4)
                new Car { Id = 1, ModelId = 1, RegistrationNumber = "WA12345", Mileage = 15000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 50m, Location = "Warszawa" },
                new Car { Id = 2, ModelId = 2, RegistrationNumber = "WA23456", Mileage = 22000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 65m, Location = "Warszawa" },
                new Car { Id = 3, ModelId = 3, RegistrationNumber = "WA34567", Mileage = 8000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 75m, Location = "Warszawa" },
                new Car { Id = 4, ModelId = 4, RegistrationNumber = "WA45678", Mileage = 12000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 70m, Location = "Warszawa" },
                
                // Premium Cars - BMW (5-8)
                new Car { Id = 5, ModelId = 5, RegistrationNumber = "KR34567", Mileage = 30000, AvailabilityStatus = CarAvailability.Maintenance, DailyPrice = 120m, Location = "Kraków" },
                new Car { Id = 6, ModelId = 6, RegistrationNumber = "KR45678", Mileage = 18000, AvailabilityStatus = CarAvailability.Rented, DailyPrice = 95m, Location = "Kraków" },
                new Car { Id = 7, ModelId = 7, RegistrationNumber = "KR56789", Mileage = 25000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 110m, Location = "Kraków" },
                new Car { Id = 8, ModelId = 8, RegistrationNumber = "KR67890", Mileage = 20000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 105m, Location = "Kraków" },
                
                // Ford Fleet (9-12)
                new Car { Id = 9, ModelId = 9, RegistrationNumber = "GD56789", Mileage = 12000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 45m, Location = "Gdańsk" },
                new Car { Id = 10, ModelId = 10, RegistrationNumber = "GD67890", Mileage = 25000, AvailabilityStatus = CarAvailability.Reserved, DailyPrice = 85m, Location = "Gdańsk" },
                new Car { Id = 11, ModelId = 11, RegistrationNumber = "GD78901", Mileage = 15000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 60m, Location = "Gdańsk" },
                new Car { Id = 12, ModelId = 12, RegistrationNumber = "GD89012", Mileage = 35000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 90m, Location = "Gdańsk" },
                
                // Audi Luxury (13-16)
                new Car { Id = 13, ModelId = 13, RegistrationNumber = "PO78901", Mileage = 20000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 85m, Location = "Poznań" },
                new Car { Id = 14, ModelId = 14, RegistrationNumber = "PO89012", Mileage = 22000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 100m, Location = "Poznań" },
                new Car { Id = 15, ModelId = 15, RegistrationNumber = "PO90123", Mileage = 18000, AvailabilityStatus = CarAvailability.Rented, DailyPrice = 80m, Location = "Poznań" },
                new Car { Id = 16, ModelId = 16, RegistrationNumber = "PO01234", Mileage = 28000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 130m, Location = "Poznań" },
                
                // Volkswagen Family (17-20)
                new Car { Id = 17, ModelId = 17, RegistrationNumber = "LO89012", Mileage = 15000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 55m, Location = "Łódź" },
                new Car { Id = 18, ModelId = 18, RegistrationNumber = "LO90123", Mileage = 10000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 50m, Location = "Łódź" },
                new Car { Id = 19, ModelId = 19, RegistrationNumber = "LO01234", Mileage = 20000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 70m, Location = "Łódź" },
                new Car { Id = 20, ModelId = 20, RegistrationNumber = "LO12345", Mileage = 8000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 45m, Location = "Łódź" },
                
                // Honda Reliable (21-24)
                new Car { Id = 21, ModelId = 21, RegistrationNumber = "WR90123", Mileage = 18000, AvailabilityStatus = CarAvailability.Rented, DailyPrice = 70m, Location = "Wrocław" },
                new Car { Id = 22, ModelId = 22, RegistrationNumber = "WR01234", Mileage = 12000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 55m, Location = "Wrocław" },
                new Car { Id = 23, ModelId = 23, RegistrationNumber = "WR12345", Mileage = 25000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 65m, Location = "Wrocław" },
                new Car { Id = 24, ModelId = 24, RegistrationNumber = "WR23456", Mileage = 30000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 80m, Location = "Wrocław" },
                
                // Mercedes Premium (25-28)
                new Car { Id = 25, ModelId = 25, RegistrationNumber = "SZ01234", Mileage = 16000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 110m, Location = "Szczecin" },
                new Car { Id = 26, ModelId = 26, RegistrationNumber = "SZ12345", Mileage = 22000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 130m, Location = "Szczecin" },
                new Car { Id = 27, ModelId = 27, RegistrationNumber = "SZ23456", Mileage = 18000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 115m, Location = "Szczecin" },
                new Car { Id = 28, ModelId = 28, RegistrationNumber = "SZ34567", Mileage = 14000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 95m, Location = "Szczecin" },
                
                // Kia Budget (29-32)
                new Car { Id = 29, ModelId = 29, RegistrationNumber = "BY45678", Mileage = 20000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 60m, Location = "Bydgoszcz" },
                new Car { Id = 30, ModelId = 30, RegistrationNumber = "BY56789", Mileage = 25000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 75m, Location = "Bydgoszcz" },
                new Car { Id = 31, ModelId = 31, RegistrationNumber = "BY67890", Mileage = 15000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 65m, Location = "Bydgoszcz" },
                new Car { Id = 32, ModelId = 32, RegistrationNumber = "BY78901", Mileage = 10000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 50m, Location = "Bydgoszcz" },
                
                // Nissan Fleet (33-36)
                new Car { Id = 33, ModelId = 33, RegistrationNumber = "LU89012", Mileage = 28000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 70m, Location = "Lublin" },
                new Car { Id = 34, ModelId = 34, RegistrationNumber = "LU90123", Mileage = 18000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 75m, Location = "Lublin" },
                new Car { Id = 35, ModelId = 35, RegistrationNumber = "LU01234", Mileage = 22000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 60m, Location = "Lublin" },
                new Car { Id = 36, ModelId = 36, RegistrationNumber = "LU12345", Mileage = 32000, AvailabilityStatus = CarAvailability.Maintenance, DailyPrice = 85m, Location = "Lublin" },
                
                // Chevrolet American (37-40)
                new Car { Id = 37, ModelId = 37, RegistrationNumber = "KA23456", Mileage = 24000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 65m, Location = "Katowice" },
                new Car { Id = 38, ModelId = 38, RegistrationNumber = "KA34567", Mileage = 19000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 70m, Location = "Katowice" },
                new Car { Id = 39, ModelId = 39, RegistrationNumber = "KA45678", Mileage = 35000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 95m, Location = "Katowice" },
                new Car { Id = 40, ModelId = 40, RegistrationNumber = "KA56789", Mileage = 15000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 90m, Location = "Katowice" },
                
                // European Brands Mix (41-50)
                new Car { Id = 41, ModelId = 41, RegistrationNumber = "GY67890", Mileage = 20000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 55m, Location = "Gdynia" },
                new Car { Id = 42, ModelId = 45, RegistrationNumber = "GY78901", Mileage = 12000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 50m, Location = "Gdynia" },
                new Car { Id = 43, ModelId = 49, RegistrationNumber = "TR89012", Mileage = 18000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 58m, Location = "Toruń" },
                new Car { Id = 44, ModelId = 53, RegistrationNumber = "RZ90123", Mileage = 25000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 100m, Location = "Rzeszów" },
                new Car { Id = 45, ModelId = 57, RegistrationNumber = "OL01234", Mileage = 15000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 52m, Location = "Olsztyn" },
                new Car { Id = 46, ModelId = 61, RegistrationNumber = "KI12345", Mileage = 22000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 60m, Location = "Kielce" },
                new Car { Id = 47, ModelId = 65, RegistrationNumber = "OP23456", Mileage = 8000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 45m, Location = "Opole" },
                new Car { Id = 48, ModelId = 69, RegistrationNumber = "PL34567", Mileage = 18000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 85m, Location = "Płock" },
                new Car { Id = 49, ModelId = 77, RegistrationNumber = "SL45678", Mileage = 20000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 65m, Location = "Słupsk" },
                new Car { Id = 50, ModelId = 101, RegistrationNumber = "TA56789", Mileage = 5000, AvailabilityStatus = CarAvailability.Available, DailyPrice = 150m, Location = "Tarnów" }
            );
        }

        private static void SeedInsurances(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insurance>().HasData(
                // Original Insurance Policies - Extended to 2026-2027 (1-10)
                new Insurance { Id = 1, CarId = 1, Company = "PZU", PolicyNumber = "PZU-001", StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2026, 1, 1) },
                new Insurance { Id = 2, CarId = 2, Company = "Allianz", PolicyNumber = "ALL-002", StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2026, 2, 1) },
                new Insurance { Id = 3, CarId = 3, Company = "Warta", PolicyNumber = "WRT-003", StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2026, 3, 1) },
                new Insurance { Id = 4, CarId = 4, Company = "PZU", PolicyNumber = "PZU-004", StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2026, 4, 1) },
                new Insurance { Id = 5, CarId = 5, Company = "Allianz", PolicyNumber = "ALL-005", StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2026, 5, 1) },
                new Insurance { Id = 6, CarId = 6, Company = "Warta", PolicyNumber = "WRT-006", StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2026, 6, 1) },
                new Insurance { Id = 7, CarId = 7, Company = "PZU", PolicyNumber = "PZU-007", StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2026, 7, 1) },
                new Insurance { Id = 8, CarId = 8, Company = "Allianz", PolicyNumber = "ALL-008", StartDate = new DateTime(2024, 8, 1), EndDate = new DateTime(2026, 8, 1) },
                new Insurance { Id = 9, CarId = 9, Company = "Warta", PolicyNumber = "WRT-009", StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2026, 9, 1) },
                new Insurance { Id = 10, CarId = 10, Company = "PZU", PolicyNumber = "PZU-010", StartDate = new DateTime(2024, 10, 1), EndDate = new DateTime(2026, 10, 1) },
                
                // Cars 11-20 (11-20)
                new Insurance { Id = 11, CarId = 11, Company = "Uniqa", PolicyNumber = "UNQ-011", StartDate = new DateTime(2024, 11, 1), EndDate = new DateTime(2026, 11, 1) },
                new Insurance { Id = 12, CarId = 12, Company = "PZU", PolicyNumber = "PZU-012", StartDate = new DateTime(2024, 12, 1), EndDate = new DateTime(2026, 12, 1) },
                new Insurance { Id = 13, CarId = 13, Company = "Allianz", PolicyNumber = "ALL-013", StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2027, 1, 1) },
                new Insurance { Id = 14, CarId = 14, Company = "Warta", PolicyNumber = "WRT-014", StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2027, 2, 1) },
                new Insurance { Id = 15, CarId = 15, Company = "PZU", PolicyNumber = "PZU-015", StartDate = new DateTime(2025, 3, 1), EndDate = new DateTime(2027, 3, 1) },
                new Insurance { Id = 16, CarId = 16, Company = "Generali", PolicyNumber = "GEN-016", StartDate = new DateTime(2025, 4, 1), EndDate = new DateTime(2027, 4, 1) },
                new Insurance { Id = 17, CarId = 17, Company = "Uniqa", PolicyNumber = "UNQ-017", StartDate = new DateTime(2025, 5, 1), EndDate = new DateTime(2027, 5, 1) },
                new Insurance { Id = 18, CarId = 18, Company = "PZU", PolicyNumber = "PZU-018", StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2027, 6, 1) },
                new Insurance { Id = 19, CarId = 19, Company = "Allianz", PolicyNumber = "ALL-019", StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2027, 7, 1) },
                new Insurance { Id = 20, CarId = 20, Company = "Warta", PolicyNumber = "WRT-020", StartDate = new DateTime(2025, 8, 1), EndDate = new DateTime(2027, 8, 1) },
                
                // Cars 21-30 (21-30)
                new Insurance { Id = 21, CarId = 21, Company = "PZU", PolicyNumber = "PZU-021", StartDate = new DateTime(2025, 9, 1), EndDate = new DateTime(2027, 9, 1) },
                new Insurance { Id = 22, CarId = 22, Company = "Generali", PolicyNumber = "GEN-022", StartDate = new DateTime(2025, 10, 1), EndDate = new DateTime(2027, 10, 1) },
                new Insurance { Id = 23, CarId = 23, Company = "Uniqa", PolicyNumber = "UNQ-023", StartDate = new DateTime(2025, 11, 1), EndDate = new DateTime(2027, 11, 1) },
                new Insurance { Id = 24, CarId = 24, Company = "PZU", PolicyNumber = "PZU-024", StartDate = new DateTime(2025, 12, 1), EndDate = new DateTime(2027, 12, 1) },
                new Insurance { Id = 25, CarId = 25, Company = "Allianz", PolicyNumber = "ALL-025", StartDate = new DateTime(2024, 1, 15), EndDate = new DateTime(2026, 1, 15) },
                new Insurance { Id = 26, CarId = 26, Company = "Warta", PolicyNumber = "WRT-026", StartDate = new DateTime(2024, 2, 15), EndDate = new DateTime(2026, 2, 15) },
                new Insurance { Id = 27, CarId = 27, Company = "PZU", PolicyNumber = "PZU-027", StartDate = new DateTime(2024, 3, 15), EndDate = new DateTime(2026, 3, 15) },
                new Insurance { Id = 28, CarId = 28, Company = "Generali", PolicyNumber = "GEN-028", StartDate = new DateTime(2024, 4, 15), EndDate = new DateTime(2026, 4, 15) },
                new Insurance { Id = 29, CarId = 29, Company = "Uniqa", PolicyNumber = "UNQ-029", StartDate = new DateTime(2024, 5, 15), EndDate = new DateTime(2026, 5, 15) },
                new Insurance { Id = 30, CarId = 30, Company = "PZU", PolicyNumber = "PZU-030", StartDate = new DateTime(2024, 6, 15), EndDate = new DateTime(2026, 6, 15) },
                
                // Cars 31-40 (31-40)
                new Insurance { Id = 31, CarId = 31, Company = "Allianz", PolicyNumber = "ALL-031", StartDate = new DateTime(2024, 7, 15), EndDate = new DateTime(2026, 7, 15) },
                new Insurance { Id = 32, CarId = 32, Company = "Warta", PolicyNumber = "WRT-032", StartDate = new DateTime(2024, 8, 15), EndDate = new DateTime(2026, 8, 15) },
                new Insurance { Id = 33, CarId = 33, Company = "PZU", PolicyNumber = "PZU-033", StartDate = new DateTime(2024, 9, 15), EndDate = new DateTime(2026, 9, 15) },
                new Insurance { Id = 34, CarId = 34, Company = "Generali", PolicyNumber = "GEN-034", StartDate = new DateTime(2024, 10, 15), EndDate = new DateTime(2026, 10, 15) },
                new Insurance { Id = 35, CarId = 35, Company = "Uniqa", PolicyNumber = "UNQ-035", StartDate = new DateTime(2024, 11, 15), EndDate = new DateTime(2026, 11, 15) },
                new Insurance { Id = 36, CarId = 36, Company = "PZU", PolicyNumber = "PZU-036", StartDate = new DateTime(2024, 12, 15), EndDate = new DateTime(2026, 12, 15) },
                new Insurance { Id = 37, CarId = 37, Company = "Allianz", PolicyNumber = "ALL-037", StartDate = new DateTime(2025, 1, 15), EndDate = new DateTime(2027, 1, 15) },
                new Insurance { Id = 38, CarId = 38, Company = "Warta", PolicyNumber = "WRT-038", StartDate = new DateTime(2025, 2, 15), EndDate = new DateTime(2027, 2, 15) },
                new Insurance { Id = 39, CarId = 39, Company = "PZU", PolicyNumber = "PZU-039", StartDate = new DateTime(2025, 3, 15), EndDate = new DateTime(2027, 3, 15) },
                new Insurance { Id = 40, CarId = 40, Company = "Generali", PolicyNumber = "GEN-040", StartDate = new DateTime(2025, 4, 15), EndDate = new DateTime(2027, 4, 15) },
                
                // Cars 41-50 (41-50)
                new Insurance { Id = 41, CarId = 41, Company = "Uniqa", PolicyNumber = "UNQ-041", StartDate = new DateTime(2025, 5, 15), EndDate = new DateTime(2027, 5, 15) },
                new Insurance { Id = 42, CarId = 42, Company = "PZU", PolicyNumber = "PZU-042", StartDate = new DateTime(2025, 6, 15), EndDate = new DateTime(2027, 6, 15) },
                new Insurance { Id = 43, CarId = 43, Company = "Allianz", PolicyNumber = "ALL-043", StartDate = new DateTime(2025, 7, 15), EndDate = new DateTime(2027, 7, 15) },
                new Insurance { Id = 44, CarId = 44, Company = "Warta", PolicyNumber = "WRT-044", StartDate = new DateTime(2025, 8, 15), EndDate = new DateTime(2027, 8, 15) },
                new Insurance { Id = 45, CarId = 45, Company = "PZU", PolicyNumber = "PZU-045", StartDate = new DateTime(2025, 9, 15), EndDate = new DateTime(2027, 9, 15) },
                new Insurance { Id = 46, CarId = 46, Company = "Generali", PolicyNumber = "GEN-046", StartDate = new DateTime(2025, 10, 15), EndDate = new DateTime(2027, 10, 15) },
                new Insurance { Id = 47, CarId = 47, Company = "Uniqa", PolicyNumber = "UNQ-047", StartDate = new DateTime(2025, 11, 15), EndDate = new DateTime(2027, 11, 15) },
                new Insurance { Id = 48, CarId = 48, Company = "PZU", PolicyNumber = "PZU-048", StartDate = new DateTime(2025, 12, 15), EndDate = new DateTime(2027, 12, 15) },
                new Insurance { Id = 49, CarId = 49, Company = "Allianz", PolicyNumber = "ALL-049", StartDate = new DateTime(2024, 1, 20), EndDate = new DateTime(2026, 1, 20) },
                new Insurance { Id = 50, CarId = 50, Company = "Warta", PolicyNumber = "WRT-050", StartDate = new DateTime(2024, 2, 20), EndDate = new DateTime(2026, 2, 20) }
            );
        }

        private static void SeedRepairs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repair>().HasData(
                // Original Repairs (1-10)
                new Repair { Id = 1, CarId = 1, ServiceCenterId = 1, RepairDate = new DateTime(2024, 8, 10), Cost = 150m, Description = "Wymiana oleju" },
                new Repair { Id = 2, CarId = 2, ServiceCenterId = 2, RepairDate = new DateTime(2024, 9, 5), Cost = 350m, Description = "Naprawa hamulców" },
                new Repair { Id = 3, CarId = 3, ServiceCenterId = 3, RepairDate = new DateTime(2024, 10, 15), Cost = 220m, Description = "Wymiana filtrów" },
                new Repair { Id = 4, CarId = 4, ServiceCenterId = 4, RepairDate = new DateTime(2024, 11, 20), Cost = 450m, Description = "Naprawa zawieszenia" },
                new Repair { Id = 5, CarId = 5, ServiceCenterId = 5, RepairDate = new DateTime(2024, 12, 10), Cost = 180m, Description = "Wymiana klocków hamulcowych" },
                new Repair { Id = 6, CarId = 6, ServiceCenterId = 6, RepairDate = new DateTime(2025, 1, 12), Cost = 600m, Description = "Naprawa skrzyni biegów" },
                new Repair { Id = 7, CarId = 7, ServiceCenterId = 7, RepairDate = new DateTime(2025, 1, 18), Cost = 200m, Description = "Wymiana amortyzatorów" },
                new Repair { Id = 8, CarId = 8, ServiceCenterId = 8, RepairDate = new DateTime(2025, 1, 22), Cost = 280m, Description = "Przegląd okresowy" },
                new Repair { Id = 9, CarId = 9, ServiceCenterId = 9, RepairDate = new DateTime(2025, 1, 25), Cost = 320m, Description = "Naprawa układu wydechowego" },
                new Repair { Id = 10, CarId = 10, ServiceCenterId = 10, RepairDate = new DateTime(2025, 1, 28), Cost = 400m, Description = "Wymiana akumulatora" },
                
                // Premium Brand Repairs (11-20)
                new Repair { Id = 11, CarId = 5, ServiceCenterId = 11, RepairDate = new DateTime(2024, 8, 15), Cost = 850m, Description = "Naprawa systemu iDrive BMW" },
                new Repair { Id = 12, CarId = 25, ServiceCenterId = 12, RepairDate = new DateTime(2024, 9, 20), Cost = 750m, Description = "Wymiana turbosprężarki Mercedes" },
                new Repair { Id = 13, CarId = 13, ServiceCenterId = 13, RepairDate = new DateTime(2024, 10, 8), Cost = 680m, Description = "Naprawa systemu quattro Audi" },
                new Repair { Id = 14, CarId = 26, ServiceCenterId = 12, RepairDate = new DateTime(2024, 11, 12), Cost = 920m, Description = "Wymiana modułu ESP Mercedes" },
                new Repair { Id = 15, CarId = 8, ServiceCenterId = 11, RepairDate = new DateTime(2024, 12, 5), Cost = 520m, Description = "Naprawa silnika BMW" },
                new Repair { Id = 16, CarId = 14, ServiceCenterId = 13, RepairDate = new DateTime(2025, 1, 8), Cost = 380m, Description = "Wymiana sprzęgła Audi" },
                new Repair { Id = 17, CarId = 27, ServiceCenterId = 12, RepairDate = new DateTime(2025, 1, 15), Cost = 450m, Description = "Naprawa klimatyzacji Mercedes" },
                new Repair { Id = 18, CarId = 7, ServiceCenterId = 11, RepairDate = new DateTime(2025, 1, 22), Cost = 650m, Description = "Wymiana pompy paliwa BMW" },
                new Repair { Id = 19, CarId = 16, ServiceCenterId = 13, RepairDate = new DateTime(2025, 1, 29), Cost = 780m, Description = "Naprawa systemu nawigacji Audi" },
                new Repair { Id = 20, CarId = 28, ServiceCenterId = 12, RepairDate = new DateTime(2025, 2, 3), Cost = 320m, Description = "Wymiana świec zapłonowych Mercedes" },
                
                // Regular Maintenance & Repairs (21-30)
                new Repair { Id = 21, CarId = 17, ServiceCenterId = 15, RepairDate = new DateTime(2024, 9, 10), Cost = 250m, Description = "Przegląd okresowy VW Passat" },
                new Repair { Id = 22, CarId = 18, ServiceCenterId = 15, RepairDate = new DateTime(2024, 10, 5), Cost = 180m, Description = "Wymiana oleju VW Golf" },
                new Repair { Id = 23, CarId = 21, ServiceCenterId = 6, RepairDate = new DateTime(2024, 11, 8), Cost = 420m, Description = "Naprawa układu kierowniczego Honda" },
                new Repair { Id = 24, CarId = 22, ServiceCenterId = 6, RepairDate = new DateTime(2024, 12, 15), Cost = 290m, Description = "Wymiana tarcz hamulcowych Honda" },
                new Repair { Id = 25, CarId = 29, ServiceCenterId = 8, RepairDate = new DateTime(2025, 1, 10), Cost = 350m, Description = "Naprawa zawieszenia Kia Sportage" },
                new Repair { Id = 26, CarId = 33, ServiceCenterId = 9, RepairDate = new DateTime(2025, 1, 18), Cost = 480m, Description = "Wymiana rozrządu Nissan Altima" },
                new Repair { Id = 27, CarId = 37, ServiceCenterId = 10, RepairDate = new DateTime(2025, 1, 25), Cost = 360m, Description = "Naprawa układu chłodzenia Chevrolet" },
                new Repair { Id = 28, CarId = 19, ServiceCenterId = 15, RepairDate = new DateTime(2025, 2, 1), Cost = 220m, Description = "Wymiana filtrów VW Tiguan" },
                new Repair { Id = 29, CarId = 23, ServiceCenterId = 6, RepairDate = new DateTime(2025, 2, 8), Cost = 540m, Description = "Naprawa skrzyni biegów Honda Accord" },
                new Repair { Id = 30, CarId = 31, ServiceCenterId = 8, RepairDate = new DateTime(2025, 2, 12), Cost = 190m, Description = "Wymiana świec zapłonowych Kia Optima" },
                
                // Seasonal & Emergency Repairs (31-40)
                new Repair { Id = 31, CarId = 41, ServiceCenterId = 17, RepairDate = new DateTime(2024, 12, 1), Cost = 380m, Description = "Wymiana opon zimowych Peugeot 308" },
                new Repair { Id = 32, CarId = 44, ServiceCenterId = 17, RepairDate = new DateTime(2024, 12, 8), Cost = 720m, Description = "Naprawa systemu bezpieczeństwa Volvo XC60" },
                new Repair { Id = 33, CarId = 45, ServiceCenterId = 18, RepairDate = new DateTime(2024, 12, 18), Cost = 280m, Description = "Wymiana akumulatora SEAT Leon" },
                new Repair { Id = 34, CarId = 46, ServiceCenterId = 21, RepairDate = new DateTime(2025, 1, 5), Cost = 320m, Description = "Naprawa ogrzewania Škoda Octavia" },
                new Repair { Id = 35, CarId = 47, ServiceCenterId = 25, RepairDate = new DateTime(2025, 1, 12), Cost = 160m, Description = "Wymiana żarówek Fiat 500" },
                new Repair { Id = 36, CarId = 48, ServiceCenterId = 24, RepairDate = new DateTime(2025, 1, 20), Cost = 650m, Description = "Naprawa silnika Alfa Romeo Giulia" },
                new Repair { Id = 37, CarId = 49, ServiceCenterId = 26, RepairDate = new DateTime(2025, 1, 28), Cost = 420m, Description = "Wymiana sprzęgła Mazda3" },
                new Repair { Id = 38, CarId = 12, ServiceCenterId = 16, RepairDate = new DateTime(2025, 2, 5), Cost = 580m, Description = "Naprawa systemu 4WD Ford Explorer" },
                new Repair { Id = 39, CarId = 35, ServiceCenterId = 9, RepairDate = new DateTime(2025, 2, 10), Cost = 240m, Description = "Wymiana pasków rozrządu Nissan Sentra" },
                new Repair { Id = 40, CarId = 39, ServiceCenterId = 10, RepairDate = new DateTime(2025, 2, 15), Cost = 890m, Description = "Naprawa silnika V8 Chevrolet Tahoe" },
                
                // Recent & Specialized Repairs (41-45)
                new Repair { Id = 41, CarId = 50, ServiceCenterId = 31, RepairDate = new DateTime(2025, 2, 18), Cost = 1200m, Description = "Naprawa systemu Autopilot Tesla Model 3" },
                new Repair { Id = 42, CarId = 24, ServiceCenterId = 6, RepairDate = new DateTime(2025, 2, 22), Cost = 480m, Description = "Wymiana systemu hybrydowego Honda Pilot" },
                new Repair { Id = 43, CarId = 20, ServiceCenterId = 15, RepairDate = new DateTime(2025, 2, 25), Cost = 150m, Description = "Przegląd techniczny VW Polo" },
                new Repair { Id = 44, CarId = 32, ServiceCenterId = 8, RepairDate = new DateTime(2025, 3, 1), Cost = 280m, Description = "Naprawa układu wydechowego Kia Rio" },
                new Repair { Id = 45, CarId = 40, ServiceCenterId = 10, RepairDate = new DateTime(2025, 3, 5), Cost = 620m, Description = "Wymiana turbosprężarki Chevrolet Camaro" }
            );
        }

        private static void SeedRentals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasData(
                // Original Completed Rentals (1-10)
                new Rental { Id = 1, ClientId = 1, CarId = 1, EmployeeId = 1, RentalDate = new DateTime(2024, 7, 5), ReturnDate = new DateTime(2024, 7, 10), Status = RentalStatus.Completed },
                new Rental { Id = 2, ClientId = 2, CarId = 2, EmployeeId = 2, RentalDate = new DateTime(2024, 8, 12), ReturnDate = new DateTime(2024, 8, 18), Status = RentalStatus.Completed },
                new Rental { Id = 3, ClientId = 3, CarId = 3, EmployeeId = 3, RentalDate = new DateTime(2024, 9, 3), ReturnDate = new DateTime(2024, 9, 8), Status = RentalStatus.Completed },
                new Rental { Id = 4, ClientId = 4, CarId = 4, EmployeeId = 4, RentalDate = new DateTime(2024, 10, 15), ReturnDate = new DateTime(2024, 10, 20), Status = RentalStatus.Completed },
                new Rental { Id = 5, ClientId = 5, CarId = 5, EmployeeId = 5, RentalDate = new DateTime(2024, 11, 8), ReturnDate = new DateTime(2024, 11, 13), Status = RentalStatus.Completed },
                new Rental { Id = 6, ClientId = 6, CarId = 6, EmployeeId = 6, RentalDate = new DateTime(2024, 12, 10), ReturnDate = new DateTime(2024, 12, 16), Status = RentalStatus.Completed },
                new Rental { Id = 7, ClientId = 7, CarId = 7, EmployeeId = 7, RentalDate = new DateTime(2025, 1, 5), ReturnDate = new DateTime(2025, 1, 10), Status = RentalStatus.Completed },
                new Rental { Id = 8, ClientId = 8, CarId = 8, EmployeeId = 8, RentalDate = new DateTime(2025, 1, 12), ReturnDate = new DateTime(2025, 1, 17), Status = RentalStatus.Completed },
                new Rental { Id = 9, ClientId = 9, CarId = 9, EmployeeId = 9, RentalDate = new DateTime(2025, 1, 18), ReturnDate = new DateTime(2025, 1, 24), Status = RentalStatus.Completed },
                new Rental { Id = 10, ClientId = 10, CarId = 10, EmployeeId = 10, RentalDate = new DateTime(2025, 1, 25), ReturnDate = new DateTime(2025, 1, 30), Status = RentalStatus.Completed },
                
                // Summer Holiday Rentals (11-20)
                new Rental { Id = 11, ClientId = 11, CarId = 17, EmployeeId = 3, RentalDate = new DateTime(2024, 7, 1), ReturnDate = new DateTime(2024, 7, 14), Status = RentalStatus.Completed },
                new Rental { Id = 12, ClientId = 12, CarId = 18, EmployeeId = 16, RentalDate = new DateTime(2024, 7, 15), ReturnDate = new DateTime(2024, 7, 22), Status = RentalStatus.Completed },
                new Rental { Id = 13, ClientId = 13, CarId = 25, EmployeeId = 3, RentalDate = new DateTime(2024, 8, 1), ReturnDate = new DateTime(2024, 8, 10), Status = RentalStatus.Completed },
                new Rental { Id = 14, ClientId = 14, CarId = 26, EmployeeId = 6, RentalDate = new DateTime(2024, 8, 5), ReturnDate = new DateTime(2024, 8, 19), Status = RentalStatus.Completed },
                new Rental { Id = 15, ClientId = 15, CarId = 29, EmployeeId = 9, RentalDate = new DateTime(2024, 8, 20), ReturnDate = new DateTime(2024, 8, 27), Status = RentalStatus.Completed },
                new Rental { Id = 16, ClientId = 16, CarId = 33, EmployeeId = 17, RentalDate = new DateTime(2024, 9, 1), ReturnDate = new DateTime(2024, 9, 15), Status = RentalStatus.Completed },
                new Rental { Id = 17, ClientId = 17, CarId = 37, EmployeeId = 18, RentalDate = new DateTime(2024, 9, 10), ReturnDate = new DateTime(2024, 9, 17), Status = RentalStatus.Completed },
                new Rental { Id = 18, ClientId = 18, CarId = 41, EmployeeId = 21, RentalDate = new DateTime(2024, 9, 20), ReturnDate = new DateTime(2024, 9, 30), Status = RentalStatus.Completed },
                new Rental { Id = 19, ClientId = 19, CarId = 43, EmployeeId = 19, RentalDate = new DateTime(2024, 10, 1), ReturnDate = new DateTime(2024, 10, 8), Status = RentalStatus.Completed },
                new Rental { Id = 20, ClientId = 20, CarId = 45, EmployeeId = 20, RentalDate = new DateTime(2024, 10, 12), ReturnDate = new DateTime(2024, 10, 19), Status = RentalStatus.Completed },
                
                // Business & Corporate Rentals (21-30)
                new Rental { Id = 21, ClientId = 46, CarId = 13, EmployeeId = 23, RentalDate = new DateTime(2024, 9, 5), ReturnDate = new DateTime(2024, 9, 12), Status = RentalStatus.Completed },
                new Rental { Id = 22, ClientId = 47, CarId = 14, EmployeeId = 23, RentalDate = new DateTime(2024, 10, 3), ReturnDate = new DateTime(2024, 10, 10), Status = RentalStatus.Completed },
                new Rental { Id = 23, ClientId = 48, CarId = 27, EmployeeId = 23, RentalDate = new DateTime(2024, 10, 25), ReturnDate = new DateTime(2024, 11, 1), Status = RentalStatus.Completed },
                new Rental { Id = 24, ClientId = 49, CarId = 16, EmployeeId = 25, RentalDate = new DateTime(2024, 11, 5), ReturnDate = new DateTime(2024, 11, 12), Status = RentalStatus.Completed },
                new Rental { Id = 25, ClientId = 50, CarId = 28, EmployeeId = 25, RentalDate = new DateTime(2024, 11, 15), ReturnDate = new DateTime(2024, 11, 22), Status = RentalStatus.Completed },
                new Rental { Id = 26, ClientId = 21, CarId = 44, EmployeeId = 17, RentalDate = new DateTime(2024, 11, 20), ReturnDate = new DateTime(2024, 12, 5), Status = RentalStatus.Completed },
                new Rental { Id = 27, ClientId = 22, CarId = 46, EmployeeId = 18, RentalDate = new DateTime(2024, 12, 1), ReturnDate = new DateTime(2024, 12, 8), Status = RentalStatus.Completed },
                new Rental { Id = 28, ClientId = 23, CarId = 47, EmployeeId = 19, RentalDate = new DateTime(2024, 12, 12), ReturnDate = new DateTime(2024, 12, 19), Status = RentalStatus.Completed },
                new Rental { Id = 29, ClientId = 24, CarId = 48, EmployeeId = 20, RentalDate = new DateTime(2024, 12, 20), ReturnDate = new DateTime(2025, 1, 3), Status = RentalStatus.Completed },
                new Rental { Id = 30, ClientId = 25, CarId = 49, EmployeeId = 21, RentalDate = new DateTime(2025, 1, 8), ReturnDate = new DateTime(2025, 1, 15), Status = RentalStatus.Completed },
                
                // Winter & Holiday Season Rentals (31-40)
                new Rental { Id = 31, ClientId = 26, CarId = 19, EmployeeId = 16, RentalDate = new DateTime(2024, 12, 22), ReturnDate = new DateTime(2025, 1, 2), Status = RentalStatus.Completed },
                new Rental { Id = 32, ClientId = 27, CarId = 20, EmployeeId = 17, RentalDate = new DateTime(2024, 12, 28), ReturnDate = new DateTime(2025, 1, 4), Status = RentalStatus.Completed },
                new Rental { Id = 33, ClientId = 28, CarId = 22, EmployeeId = 18, RentalDate = new DateTime(2025, 1, 6), ReturnDate = new DateTime(2025, 1, 13), Status = RentalStatus.Completed },
                new Rental { Id = 34, ClientId = 29, CarId = 23, EmployeeId = 19, RentalDate = new DateTime(2025, 1, 15), ReturnDate = new DateTime(2025, 1, 22), Status = RentalStatus.Completed },
                new Rental { Id = 35, ClientId = 30, CarId = 24, EmployeeId = 20, RentalDate = new DateTime(2025, 1, 20), ReturnDate = new DateTime(2025, 1, 27), Status = RentalStatus.Completed },
                new Rental { Id = 36, ClientId = 31, CarId = 30, EmployeeId = 21, RentalDate = new DateTime(2025, 2, 1), ReturnDate = new DateTime(2025, 2, 8), Status = RentalStatus.Completed },
                new Rental { Id = 37, ClientId = 32, CarId = 31, EmployeeId = 3, RentalDate = new DateTime(2025, 2, 5), ReturnDate = new DateTime(2025, 2, 12), Status = RentalStatus.Completed },
                new Rental { Id = 38, ClientId = 33, CarId = 32, EmployeeId = 6, RentalDate = new DateTime(2025, 2, 10), ReturnDate = new DateTime(2025, 2, 17), Status = RentalStatus.Completed },
                new Rental { Id = 39, ClientId = 34, CarId = 34, EmployeeId = 9, RentalDate = new DateTime(2025, 2, 15), ReturnDate = new DateTime(2025, 2, 22), Status = RentalStatus.Completed },
                new Rental { Id = 40, CarId = 35, ClientId = 35, EmployeeId = 16, RentalDate = new DateTime(2025, 2, 20), ReturnDate = new DateTime(2025, 2, 27), Status = RentalStatus.Completed },
                
                // Young Clients Weekend Rentals (41-50)
                new Rental { Id = 41, ClientId = 36, CarId = 38, EmployeeId = 17, RentalDate = new DateTime(2024, 11, 29), ReturnDate = new DateTime(2024, 12, 2), Status = RentalStatus.Completed },
                new Rental { Id = 42, ClientId = 37, CarId = 39, EmployeeId = 18, RentalDate = new DateTime(2024, 12, 6), ReturnDate = new DateTime(2024, 12, 9), Status = RentalStatus.Completed },
                new Rental { Id = 43, ClientId = 38, CarId = 40, EmployeeId = 19, RentalDate = new DateTime(2024, 12, 13), ReturnDate = new DateTime(2024, 12, 16), Status = RentalStatus.Completed },
                new Rental { Id = 44, ClientId = 39, CarId = 42, EmployeeId = 20, RentalDate = new DateTime(2024, 12, 27), ReturnDate = new DateTime(2024, 12, 30), Status = RentalStatus.Completed },
                new Rental { Id = 45, ClientId = 40, CarId = 11, EmployeeId = 21, RentalDate = new DateTime(2025, 1, 3), ReturnDate = new DateTime(2025, 1, 6), Status = RentalStatus.Completed },
                new Rental { Id = 46, ClientId = 41, CarId = 12, EmployeeId = 3, RentalDate = new DateTime(2025, 1, 10), ReturnDate = new DateTime(2025, 1, 13), Status = RentalStatus.Completed },
                new Rental { Id = 47, ClientId = 42, CarId = 50, EmployeeId = 16, RentalDate = new DateTime(2025, 1, 17), ReturnDate = new DateTime(2025, 1, 20), Status = RentalStatus.Completed },
                new Rental { Id = 48, ClientId = 43, CarId = 9, EmployeeId = 17, RentalDate = new DateTime(2025, 1, 24), ReturnDate = new DateTime(2025, 1, 27), Status = RentalStatus.Completed },
                new Rental { Id = 49, ClientId = 44, CarId = 36, EmployeeId = 18, RentalDate = new DateTime(2025, 1, 31), ReturnDate = new DateTime(2025, 2, 3), Status = RentalStatus.Completed },
                new Rental { Id = 50, ClientId = 45, CarId = 37, EmployeeId = 19, RentalDate = new DateTime(2025, 2, 7), ReturnDate = new DateTime(2025, 2, 10), Status = RentalStatus.Completed },
                
                // Current Active & Ongoing Rentals (51-60)
                new Rental { Id = 51, ClientId = 1, CarId = 21, EmployeeId = 3, RentalDate = new DateTime(2025, 3, 1), ReturnDate = new DateTime(2025, 3, 8), Status = RentalStatus.Active },
                new Rental { Id = 52, ClientId = 6, CarId = 15, EmployeeId = 16, RentalDate = new DateTime(2025, 3, 3), ReturnDate = new DateTime(2025, 3, 10), Status = RentalStatus.Active },
                new Rental { Id = 53, ClientId = 15, CarId = 6, EmployeeId = 17, RentalDate = new DateTime(2025, 3, 5), ReturnDate = new DateTime(2025, 3, 12), Status = RentalStatus.Active },
                new Rental { Id = 54, ClientId = 25, CarId = 7, EmployeeId = 18, RentalDate = new DateTime(2025, 3, 7), ReturnDate = new DateTime(2025, 3, 14), Status = RentalStatus.Active },
                new Rental { Id = 55, ClientId = 35, CarId = 8, EmployeeId = 19, RentalDate = new DateTime(2025, 3, 10), ReturnDate = new DateTime(2025, 3, 17), Status = RentalStatus.Active },
                new Rental { Id = 56, ClientId = 12, CarId = 13, EmployeeId = 20, RentalDate = new DateTime(2025, 3, 12), ReturnDate = new DateTime(2025, 3, 19), Status = RentalStatus.Reserved },
                new Rental { Id = 57, ClientId = 22, CarId = 14, EmployeeId = 21, RentalDate = new DateTime(2025, 3, 15), ReturnDate = new DateTime(2025, 3, 22), Status = RentalStatus.Reserved },
                new Rental { Id = 58, ClientId = 32, CarId = 16, EmployeeId = 23, RentalDate = new DateTime(2025, 3, 18), ReturnDate = new DateTime(2025, 3, 25), Status = RentalStatus.Reserved },
                new Rental { Id = 59, ClientId = 42, CarId = 25, EmployeeId = 25, RentalDate = new DateTime(2025, 3, 20), ReturnDate = new DateTime(2025, 3, 27), Status = RentalStatus.Reserved },
                new Rental { Id = 60, ClientId = 50, CarId = 26, EmployeeId = 16, RentalDate = new DateTime(2025, 3, 22), ReturnDate = new DateTime(2025, 3, 29), Status = RentalStatus.Reserved },
                
                // Long-term & Extended Rentals (61-65)
                new Rental { Id = 61, ClientId = 47, CarId = 27, EmployeeId = 23, RentalDate = new DateTime(2024, 10, 1), ReturnDate = new DateTime(2024, 12, 31), Status = RentalStatus.Completed },
                new Rental { Id = 62, ClientId = 48, CarId = 28, EmployeeId = 25, RentalDate = new DateTime(2024, 11, 1), ReturnDate = new DateTime(2025, 1, 31), Status = RentalStatus.Completed },
                new Rental { Id = 63, ClientId = 49, CarId = 44, EmployeeId = 23, RentalDate = new DateTime(2025, 1, 15), ReturnDate = new DateTime(2025, 4, 15), Status = RentalStatus.Active },
                new Rental { Id = 64, ClientId = 46, CarId = 45, EmployeeId = 25, RentalDate = new DateTime(2025, 2, 1), ReturnDate = new DateTime(2025, 5, 1), Status = RentalStatus.Active },
                new Rental { Id = 65, ClientId = 50, CarId = 46, EmployeeId = 23, RentalDate = new DateTime(2025, 3, 1), ReturnDate = new DateTime(2025, 6, 1), Status = RentalStatus.Active }
            );
        }

        private static void SeedPayments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasData(
                // Original Payments - January 2026 (1-10)
                new Payment { Id = 1, RentalId = 1, PaymentDate = new DateTime(2026, 1, 2), Amount = 250m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 2, RentalId = 2, PaymentDate = new DateTime(2026, 1, 3), Amount = 390m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 3, RentalId = 3, PaymentDate = new DateTime(2026, 1, 5), Amount = 600m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 4, RentalId = 4, PaymentDate = new DateTime(2026, 1, 6), Amount = 475m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 5, RentalId = 5, PaymentDate = new DateTime(2026, 1, 7), Amount = 225m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 6, RentalId = 6, PaymentDate = new DateTime(2026, 1, 8), Amount = 450m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 7, RentalId = 7, PaymentDate = new DateTime(2026, 1, 9), Amount = 425m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 8, RentalId = 8, PaymentDate = new DateTime(2026, 1, 10), Amount = 275m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 9, RentalId = 9, PaymentDate = new DateTime(2026, 1, 12), Amount = 420m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 10, RentalId = 10, PaymentDate = new DateTime(2026, 1, 14), Amount = 400m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                
                // Summer Holiday Rentals Payments (11-20)
                new Payment { Id = 11, RentalId = 11, PaymentDate = new DateTime(2026, 1, 15), Amount = 715m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 12, RentalId = 12, PaymentDate = new DateTime(2026, 1, 16), Amount = 350m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 13, RentalId = 13, PaymentDate = new DateTime(2026, 1, 17), Amount = 1100m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 14, RentalId = 14, PaymentDate = new DateTime(2026, 1, 18), Amount = 1820m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 15, RentalId = 15, PaymentDate = new DateTime(2026, 1, 19), Amount = 420m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 16, RentalId = 16, PaymentDate = new DateTime(2026, 1, 20), Amount = 1050m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 17, RentalId = 17, PaymentDate = new DateTime(2026, 1, 21), Amount = 455m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 18, RentalId = 18, PaymentDate = new DateTime(2026, 1, 22), Amount = 550m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 19, RentalId = 19, PaymentDate = new DateTime(2026, 1, 23), Amount = 464m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 20, RentalId = 20, PaymentDate = new DateTime(2026, 1, 24), Amount = 364m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                
                // Business & Corporate Rentals Payments (21-30)
                new Payment { Id = 21, RentalId = 21, PaymentDate = new DateTime(2026, 1, 25), Amount = 595m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 22, RentalId = 22, PaymentDate = new DateTime(2026, 1, 26), Amount = 700m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 23, RentalId = 23, PaymentDate = new DateTime(2026, 1, 27), Amount = 805m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 24, RentalId = 24, PaymentDate = new DateTime(2026, 1, 28), Amount = 910m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 25, RentalId = 25, PaymentDate = new DateTime(2026, 1, 29), Amount = 665m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 26, RentalId = 26, PaymentDate = new DateTime(2026, 1, 30), Amount = 1500m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 27, RentalId = 27, PaymentDate = new DateTime(2026, 1, 2), Amount = 480m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 28, RentalId = 28, PaymentDate = new DateTime(2026, 1, 3), Amount = 405m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 29, RentalId = 29, PaymentDate = new DateTime(2026, 1, 4), Amount = 1190m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 30, RentalId = 30, PaymentDate = new DateTime(2026, 1, 5), Amount = 455m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                
                // Winter & Holiday Season Rentals Payments (31-40)
                new Payment { Id = 31, RentalId = 31, PaymentDate = new DateTime(2026, 1, 6), Amount = 770m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 32, RentalId = 32, PaymentDate = new DateTime(2026, 1, 7), Amount = 315m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 33, RentalId = 33, PaymentDate = new DateTime(2026, 1, 8), Amount = 385m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 34, RentalId = 34, PaymentDate = new DateTime(2026, 1, 9), Amount = 455m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 35, RentalId = 35, PaymentDate = new DateTime(2026, 1, 10), Amount = 560m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 36, RentalId = 36, PaymentDate = new DateTime(2026, 1, 11), Amount = 525m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 37, RentalId = 37, PaymentDate = new DateTime(2026, 1, 12), Amount = 455m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 38, RentalId = 38, PaymentDate = new DateTime(2026, 1, 13), Amount = 350m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 39, RentalId = 39, PaymentDate = new DateTime(2026, 1, 14), Amount = 525m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 40, RentalId = 40, PaymentDate = new DateTime(2026, 1, 15), Amount = 420m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                
                // Young Clients Weekend Rentals Payments (41-50)
                new Payment { Id = 41, RentalId = 41, PaymentDate = new DateTime(2026, 1, 16), Amount = 210m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 42, RentalId = 42, PaymentDate = new DateTime(2026, 1, 17), Amount = 285m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 43, RentalId = 43, PaymentDate = new DateTime(2026, 1, 18), Amount = 270m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 44, RentalId = 44, PaymentDate = new DateTime(2026, 1, 19), Amount = 150m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 45, RentalId = 45, PaymentDate = new DateTime(2026, 1, 20), Amount = 180m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 46, RentalId = 46, PaymentDate = new DateTime(2026, 1, 21), Amount = 270m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 47, RentalId = 47, PaymentDate = new DateTime(2026, 1, 22), Amount = 450m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 48, RentalId = 48, PaymentDate = new DateTime(2026, 1, 23), Amount = 135m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 49, RentalId = 49, PaymentDate = new DateTime(2026, 1, 24), Amount = 255m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 50, RentalId = 50, PaymentDate = new DateTime(2026, 1, 25), Amount = 195m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                
                // Current Active Rentals - Pending/Processing Payments (51-60)
                new Payment { Id = 51, RentalId = 51, PaymentDate = new DateTime(2026, 1, 26), Amount = 490m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Pending },
                new Payment { Id = 52, RentalId = 52, PaymentDate = new DateTime(2026, 1, 27), Amount = 560m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 53, RentalId = 53, PaymentDate = new DateTime(2026, 1, 28), Amount = 665m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Pending },
                new Payment { Id = 54, RentalId = 54, PaymentDate = new DateTime(2026, 1, 29), Amount = 770m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 55, RentalId = 55, PaymentDate = new DateTime(2026, 1, 30), Amount = 735m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Pending },
                new Payment { Id = 56, RentalId = 56, PaymentDate = new DateTime(2026, 1, 2), Amount = 595m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Pending },
                new Payment { Id = 57, RentalId = 57, PaymentDate = new DateTime(2026, 1, 3), Amount = 700m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Pending },
                new Payment { Id = 58, RentalId = 58, PaymentDate = new DateTime(2026, 1, 4), Amount = 910m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Pending },
                new Payment { Id = 59, RentalId = 59, PaymentDate = new DateTime(2026, 1, 5), Amount = 945m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 60, RentalId = 60, PaymentDate = new DateTime(2026, 1, 6), Amount = 1015m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Pending },
                
                // Long-term & Extended Rentals Payments (61-65)
                new Payment { Id = 61, RentalId = 61, PaymentDate = new DateTime(2026, 1, 7), Amount = 10350m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 62, RentalId = 62, PaymentDate = new DateTime(2026, 1, 8), Amount = 8740m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 63, RentalId = 63, PaymentDate = new DateTime(2026, 1, 9), Amount = 9000m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 64, RentalId = 64, PaymentDate = new DateTime(2026, 1, 10), Amount = 4680m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 65, RentalId = 65, PaymentDate = new DateTime(2026, 1, 11), Amount = 5460m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Pending },
                
                // Additional Holiday and Special Occasion Payments (66-75)
                new Payment { Id = 66, RentalId = 1, PaymentDate = new DateTime(2026, 1, 12), Amount = 50m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 67, RentalId = 3, PaymentDate = new DateTime(2026, 1, 13), Amount = 25m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 68, RentalId = 5, PaymentDate = new DateTime(2026, 1, 14), Amount = 75m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 69, RentalId = 11, PaymentDate = new DateTime(2026, 1, 15), Amount = 100m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 70, RentalId = 13, PaymentDate = new DateTime(2026, 1, 16), Amount = 150m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 71, RentalId = 21, PaymentDate = new DateTime(2026, 1, 17), Amount = 200m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 72, RentalId = 25, PaymentDate = new DateTime(2026, 1, 18), Amount = 125m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 73, RentalId = 31, PaymentDate = new DateTime(2026, 1, 19), Amount = 80m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 74, RentalId = 41, PaymentDate = new DateTime(2026, 1, 20), Amount = 30m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Completed },
                new Payment { Id = 75, RentalId = 47, PaymentDate = new DateTime(2026, 1, 21), Amount = 50m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                
                // Late Payment Fees and Adjustments (76-80)
                new Payment { Id = 76, RentalId = 2, PaymentDate = new DateTime(2026, 1, 22), Amount = 50m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed },
                new Payment { Id = 77, RentalId = 6, PaymentDate = new DateTime(2026, 1, 23), Amount = 75m, PaymentMethod = PaymentMethod.CreditCard, Status = PaymentStatus.Failed },
                new Payment { Id = 78, RentalId = 8, PaymentDate = new DateTime(2026, 1, 24), Amount = 40m, PaymentMethod = PaymentMethod.Cash, Status = PaymentStatus.Completed },
                new Payment { Id = 79, RentalId = 14, PaymentDate = new DateTime(2026, 1, 25), Amount = 120m, PaymentMethod = PaymentMethod.BLIK, Status = PaymentStatus.Refunded },
                new Payment { Id = 80, RentalId = 22, PaymentDate = new DateTime(2026, 1, 26), Amount = 90m, PaymentMethod = PaymentMethod.BankTransfer, Status = PaymentStatus.Completed }
            );
        }
    }
}
