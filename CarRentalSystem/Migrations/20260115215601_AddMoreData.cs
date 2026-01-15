using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "Year",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                column: "Year",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                column: "Year",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                column: "Year",
                value: 2023);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BodyType", "BrandName", "Country", "Transmission", "Year" },
                values: new object[,]
                {
                    { 11, "Hatchback", "Peugeot", "France", "Manual", 2024 },
                    { 12, "SUV", "Renault", "France", "Automatic", 2023 },
                    { 13, "Sedan", "Citroën", "France", "Automatic", 2024 },
                    { 14, "SUV", "Volvo", "Sweden", "Automatic", 2024 },
                    { 15, "Hatchback", "SEAT", "Spain", "Manual", 2023 },
                    { 16, "Sedan", "Škoda", "Czech Republic", "Manual", 2024 },
                    { 17, "Hatchback", "Fiat", "Italy", "Manual", 2023 },
                    { 18, "Coupe", "Alfa Romeo", "Italy", "Automatic", 2024 },
                    { 19, "SUV", "Hyundai", "South Korea", "Automatic", 2024 },
                    { 20, "Sedan", "Mazda", "Japan", "Manual", 2023 },
                    { 21, "SUV", "Subaru", "Japan", "Automatic", 2024 },
                    { 22, "SUV", "Mitsubishi", "Japan", "Automatic", 2023 },
                    { 23, "Hatchback", "Suzuki", "Japan", "Manual", 2023 },
                    { 24, "SUV", "Jeep", "USA", "Automatic", 2024 },
                    { 25, "Sedan", "Cadillac", "USA", "Automatic", 2024 },
                    { 26, "Sedan", "Chrysler", "USA", "Automatic", 2023 },
                    { 27, "Coupe", "Dodge", "USA", "Automatic", 2024 },
                    { 28, "SUV", "Lincoln", "USA", "Automatic", 2024 },
                    { 29, "SUV", "Lexus", "Japan", "Automatic", 2024 },
                    { 30, "Sedan", "Infiniti", "Japan", "Automatic", 2023 },
                    { 31, "SUV", "Acura", "Japan", "Automatic", 2024 },
                    { 32, "Sedan", "Genesis", "South Korea", "Automatic", 2024 },
                    { 33, "Sedan", "Tesla", "USA", "Automatic", 2024 },
                    { 34, "SUV", "BYD", "China", "Automatic", 2024 },
                    { 35, "SUV", "Polestar", "Sweden", "Automatic", 2024 }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DailyPrice",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DailyPrice",
                value: 65m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Available", 75m, "Warszawa", 8000, "WA34567" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Available", 70m, "Warszawa", 12000, "WA45678" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Maintenance", 120m, "Kraków", 30000, "KR34567" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Rented", 95m, "Kraków", 18000, "KR45678" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { 110m, "Kraków", 25000, "KR56789" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { 105m, "Kraków", 20000, "KR67890" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Available", 45m, "Gdańsk", 12000, "GD56789" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Reserved", 85m, "Gdańsk", 25000, "GD67890" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "Email", "FirstName", "LastName", "PESEL", "PhoneNumber", "PostalCode" },
                values: new object[,]
                {
                    { 11, "Warszawa", "krzysztof.jankowski@example.com", "Krzysztof", "Jankowski", "89110101345", "610123456", "02-011" },
                    { 12, "Kraków", "monika.kowalczyk@example.com", "Monika", "Kowalczyk", "94120212456", "611234567", "31-012" },
                    { 13, "Gdańsk", "pawel.mazurek@example.com", "Paweł", "Mazurek", "83130323567", "612345678", "80-013" },
                    { 14, "Poznań", "joanna.krol@example.com", "Joanna", "Król", "91140434678", "613456789", "61-014" },
                    { 15, "Łódź", "robert.zajac@example.com", "Robert", "Zając", "86150545789", "614567890", "91-015" },
                    { 16, "Wrocław", "justyna.pawlak@example.com", "Justyna", "Pawlak", "89160656890", "615678901", "51-016" },
                    { 17, "Szczecin", "marcin.sikora@example.com", "Marcin", "Sikora", "92170767901", "616789012", "71-017" },
                    { 18, "Bydgoszcz", "aleksandra.baran@example.com", "Aleksandra", "Baran", "85180878012", "617890123", "85-018" },
                    { 19, "Lublin", "grzegorz.dudek@example.com", "Grzegorz", "Dudek", "88190989123", "618901234", "20-019" },
                    { 20, "Katowice", "beata.glowacka@example.com", "Beata", "Głowacka", "93200090234", "619012345", "40-020" },
                    { 21, "Gdynia", "rafal.michalski@example.com", "Rafał", "Michalski", "87210101345", "620123456", "81-021" },
                    { 22, "Toruń", "dorota.kubiak@example.com", "Dorota", "Kubiak", "90220212456", "621234567", "87-022" },
                    { 23, "Rzeszów", "dariusz.wlodarczyk@example.com", "Dariusz", "Włodarczyk", "84230323567", "622345678", "35-023" },
                    { 24, "Olsztyn", "malgorzata.czarnecka@example.com", "Małgorzata", "Czarnecka", "91240434678", "623456789", "10-024" },
                    { 25, "Kielce", "jacek.stepien@example.com", "Jacek", "Stępień", "89250545789", "624567890", "25-025" },
                    { 26, "Opole", "renata.urbanska@example.com", "Renata", "Urbańska", "92260656890", "625678901", "45-026" },
                    { 27, "Płock", "andrzej.gorski@example.com", "Andrzej", "Górski", "86270767901", "626789012", "09-027" },
                    { 28, "Słupsk", "izabela.kozlowska@example.com", "Izabela", "Kozłowska", "88280878012", "627890123", "76-028" },
                    { 29, "Tarnów", "mariusz.jaworski@example.com", "Mariusz", "Jaworski", "85290989123", "628901234", "33-029" },
                    { 30, "Legnica", "grazyna.sobczak@example.com", "Grażyna", "Sobczak", "94300090234", "629012345", "59-030" },
                    { 31, "Elbląg", "zbigniew.pietrzak@example.com", "Zbigniew", "Pietrzak", "83310101345", "630123456", "82-031" },
                    { 32, "Zamość", "danuta.sadowska@example.com", "Danuta", "Sadowska", "90320212456", "631234567", "22-032" },
                    { 33, "Chełm", "stanislaw.zawadzki@example.com", "Stanisław", "Zawadzki", "87330323567", "632345678", "22-033" },
                    { 34, "Grudziądz", "halina.olejniczak@example.com", "Halina", "Olejniczak", "91340434678", "633456789", "86-034" },
                    { 35, "Przemyśl", "ryszard.marciniak@example.com", "Ryszard", "Marciniak", "89350545789", "634567890", "37-035" },
                    { 36, "Warszawa", "natalia.kowalik@example.com", "Natalia", "Kowalik", "96360656890", "635678901", "03-036" },
                    { 37, "Kraków", "mateusz.rutkowski@example.com", "Mateusz", "Rutkowski", "95370767901", "636789012", "30-037" },
                    { 38, "Gdańsk", "wiktoria.malinowska@example.com", "Wiktoria", "Malinowska", "97380878012", "637890123", "80-038" },
                    { 39, "Poznań", "adrian.szewczyk@example.com", "Adrian", "Szewczyk", "98390989123", "638901234", "60-039" },
                    { 40, "Łódź", "julia.wozniak@example.com", "Julia", "Woźniak", "99400090234", "639012345", "90-040" },
                    { 41, "Wrocław", "jakub.adamski@example.com", "Jakub", "Adamski", "96410101345", "640123456", "50-041" },
                    { 42, "Gdynia", "zuzanna.kolodziej@example.com", "Zuzanna", "Kołodziej", "97420212456", "641234567", "81-042" },
                    { 43, "Szczecin", "bartosz.borkowski@example.com", "Bartosz", "Borkowski", "95430323567", "642345678", "70-043" },
                    { 44, "Radom", "oliwia.witkowska@example.com", "Oliwia", "Witkowska", "98440434678", "643456789", "26-044" },
                    { 45, "Sosnowiec", "kacper.chmielewski@example.com", "Kacper", "Chmielewski", "99450545789", "644567890", "41-045" },
                    { 46, "Warszawa", "helena.zakrzewska@example.com", "Helena", "Zakrzewska", "82460656890", "645678901", "00-046" },
                    { 47, "Kraków", "waldemar.jablonski@example.com", "Waldemar", "Jabłoński", "80470767901", "646789012", "31-047" },
                    { 48, "Gdańsk", "teresa.lis@example.com", "Teresa", "Lis", "78480878012", "647890123", "80-048" },
                    { 49, "Poznań", "kazimierz.czerwinski@example.com", "Kazimierz", "Czerwiński", "75490989123", "648901234", "61-049" },
                    { 50, "Wrocław", "elzbieta.jasinski@example.com", "Elżbieta", "Jasiński", "79500090234", "649012345", "51-050" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "HireDate", "LastName", "Phone", "Position", "Salary" },
                values: new object[,]
                {
                    { 11, "Robert", new DateTime(2015, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jankowski", "610111222", "Dyrektor Generalny", 8500m },
                    { 12, "Joanna", new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mazurek", "611222333", "Dyrektor ds. Operacyjnych", 7500m },
                    { 13, "Krzysztof", new DateTime(2017, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sikora", "612333444", "Kierownik ds. Finansów", 6500m },
                    { 14, "Monika", new DateTime(2018, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baran", "613444555", "Kierownik ds. Marketingu", 6000m },
                    { 15, "Marcin", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dudek", "614555666", "Kierownik ds. IT", 6800m },
                    { 16, "Justyna", new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Głowacka", "615666777", "Specjalista ds. Sprzedaży", 4600m },
                    { 17, "Rafał", new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michalski", "616777888", "Konsultant ds. Klientów", 4200m },
                    { 18, "Dorota", new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kubiak", "617888999", "Specjalista ds. Rezerwacji", 4400m },
                    { 19, "Dariusz", new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Włodarczyk", "618999000", "Przedstawiciel Handlowy", 4500m },
                    { 20, "Małgorzata", new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czarnecka", "619000111", "Koordynator Obsługi Klienta", 5000m },
                    { 21, "Jacek", new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stępień", "620111222", "Specjalista ds. Wynajmu", 4300m },
                    { 22, "Renata", new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Urbańska", "621222333", "Konsultant Telefoniczny", 3900m },
                    { 23, "Andrzej", new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Górski", "622333444", "Specjalista ds. Korporacyjnych", 5200m },
                    { 24, "Izabela", new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kozłowska", "623444555", "Asystent ds. Sprzedaży", 3800m },
                    { 25, "Mariusz", new DateTime(2018, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaworski", "624555666", "Kierownik Działu Sprzedaży", 5800m },
                    { 26, "Grażyna", new DateTime(2016, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sobczak", "625666777", "Starszy Mechanik", 5500m },
                    { 27, "Zbigniew", new DateTime(2017, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pietrzak", "626777888", "Diagnostyk Samochodowy", 5200m },
                    { 28, "Danuta", new DateTime(2019, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sadowska", "627888999", "Kontroler Jakości", 4800m },
                    { 29, "Stanisław", new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zawadzki", "628999000", "Mechanik", 4500m },
                    { 30, "Halina", new DateTime(2018, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olejniczak", "629000111", "Inspektor Floty", 5000m },
                    { 31, "Ryszard", new DateTime(2015, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marciniak", "630111222", "Kierownik Warsztatu", 6200m },
                    { 32, "Natalia", new DateTime(2021, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kowalik", "631222333", "Specjalista ds. Części", 4100m },
                    { 33, "Mateusz", new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rutkowski", "632333444", "Elektryk Samochodowy", 4700m },
                    { 34, "Wiktoria", new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malinowska", "633444555", "Asystent Techniczna", 3700m },
                    { 35, "Adrian", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szewczyk", "634555666", "Młodszy Mechanik", 4000m },
                    { 36, "Julia", new DateTime(2019, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Woźniak", "635666777", "Specjalista ds. HR", 5100m },
                    { 37, "Jakub", new DateTime(2018, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adamski", "636777888", "Księgowy", 5300m },
                    { 38, "Zuzanna", new DateTime(2020, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kołodziej", "637888999", "Administrator Systemu", 5600m },
                    { 39, "Bartosz", new DateTime(2021, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borkowski", "638999000", "Analityk Biznesowy", 5800m },
                    { 40, "Oliwia", new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Witkowska", "639000111", "Specjalista ds. Ubezpieczeń", 4900m },
                    { 41, "Kacper", new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chmielewski", "640111222", "Prawnik", 6500m },
                    { 42, "Helena", new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zakrzewska", "641222333", "Koordynator ds. Szkoleń", 4600m },
                    { 43, "Waldemar", new DateTime(2017, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jabłoński", "642333444", "Specjalista ds. Bezpieczeństwa", 5400m },
                    { 44, "Teresa", new DateTime(2016, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lis", "643444555", "Asystent Zarządu", 4700m },
                    { 45, "Kazimierz", new DateTime(2017, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czerwiński", "644555666", "Kierownik ds. Logistyki", 5900m },
                    { 46, "Elżbieta", new DateTime(2016, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jasiński", "645666777", "Kierownik Oddziału Warszawa", 6300m },
                    { 47, "Bogdan", new DateTime(2017, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nowicki", "646777888", "Kierownik Oddziału Kraków", 6100m },
                    { 48, "Krystyna", new DateTime(2018, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wieczorek", "647888999", "Kierownik Oddziału Gdańsk", 5900m },
                    { 49, "Tadeusz", new DateTime(2015, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maj", "648999000", "Inspektor Regionalny", 6400m },
                    { 50, "Janina", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaczmarek", "649000111", "Koordynator ds. Floty Regionalnej", 5700m }
                });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 1, "RAV4" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 1, "Prius" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 2, "X5" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 2, "3 Series" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 2, "X3" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 2, "5 Series" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 3, "Focus" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 3, "Mustang" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "ModelName" },
                values: new object[,]
                {
                    { 11, 3, "Escape" },
                    { 12, 3, "Explorer" },
                    { 13, 4, "A5" },
                    { 14, 4, "Q5" },
                    { 15, 4, "A4" },
                    { 16, 4, "Q7" },
                    { 17, 5, "Passat" },
                    { 18, 5, "Golf" },
                    { 19, 5, "Tiguan" },
                    { 20, 5, "Polo" },
                    { 21, 6, "CR-V" },
                    { 22, 6, "Civic" },
                    { 23, 6, "Accord" },
                    { 24, 6, "Pilot" },
                    { 25, 7, "C-Class" },
                    { 26, 7, "E-Class" },
                    { 27, 7, "GLC" },
                    { 28, 7, "A-Class" },
                    { 29, 8, "Sportage" },
                    { 30, 8, "Sorento" },
                    { 31, 8, "Optima" },
                    { 32, 8, "Rio" },
                    { 33, 9, "Altima" },
                    { 34, 9, "Rogue" },
                    { 35, 9, "Sentra" },
                    { 36, 9, "Pathfinder" },
                    { 37, 10, "Malibu" },
                    { 38, 10, "Equinox" },
                    { 39, 10, "Tahoe" },
                    { 40, 10, "Camaro" }
                });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 250m, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 390m, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 600m, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 475m, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 225m, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 450m, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 425m, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 275m, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 420m, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 400m, new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentMethod", "RentalId", "Status" },
                values: new object[,]
                {
                    { 66, 50m, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 1, "Completed" },
                    { 67, 25m, new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 3, "Completed" },
                    { 68, 75m, new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 5, "Completed" },
                    { 76, 50m, new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 2, "Completed" },
                    { 77, 75m, new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 6, "Failed" },
                    { 78, 40m, new DateTime(2026, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 8, "Completed" }
                });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 150m, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 350m, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 220m, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 450m, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 180m, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 600m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 200m, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 280m, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 320m, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 400m, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ServiceCenters",
                columns: new[] { "Id", "City", "Email", "Name", "PartnershipStartDate", "Phone" },
                values: new object[,]
                {
                    { 11, "Warszawa", "premium@bmwserwis.pl", "BMW Serwis Premium", new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "650111222" },
                    { 12, "Kraków", "serwis@mercedes-krakow.pl", "Mercedes Autoryzowany Serwis", new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "651222333" },
                    { 13, "Gdańsk", "centrum@audiserwis.pl", "Audi Service Center", new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "652333444" },
                    { 14, "Poznań", "partner@toyotapoznan.pl", "Toyota Autoryzowany Partner", new DateTime(2017, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "653444555" },
                    { 15, "Wrocław", "service@vwwroclaw.pl", "Volkswagen Service Point", new DateTime(2018, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "654555666" },
                    { 16, "Łódź", "quick@fordlodz.pl", "Ford Quick Service", new DateTime(2019, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "655666777" },
                    { 17, "Gdynia", "safety@volvogdynia.pl", "Volvo Safety Center", new DateTime(2020, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "656777888" },
                    { 18, "Toruń", "family@skodatorun.pl", "Škoda Family Service", new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "657888999" },
                    { 19, "Rzeszów", "express@peugeotrzeszow.pl", "Peugeot Express Serwis", new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "658999000" },
                    { 20, "Olsztyn", "city@renaultolsztyn.pl", "Renault City Service", new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "659000111" },
                    { 21, "Kielce", "express@autokielce.pl", "Auto Express Kielce", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "660111222" },
                    { 22, "Elbląg", "mobilny@serwispolnoc.pl", "Mobilny Serwis Północ", new DateTime(2020, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "661222333" },
                    { 23, "Białystok", "warsztat@podlaski.pl", "Warsztat Podlaski", new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "662333444" },
                    { 24, "Gliwice", "slask@serwisslask.pl", "Serwis Śląsk", new DateTime(2018, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "663444555" },
                    { 25, "Opole", "centrum@autoopole.pl", "Auto Centrum Opole", new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "664555666" },
                    { 26, "Słupsk", "morska@mechanika.pl", "Mechanika Morska", new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "665666777" },
                    { 27, "Tarnów", "malopolski@serwis.pl", "Serwis Małopolski", new DateTime(2021, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "666777888" },
                    { 28, "Zielona Góra", "zachod@autonaprawa.pl", "Auto Naprawa Zachód", new DateTime(2020, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "667888999" },
                    { 29, "Przemyśl", "podkarpacki@warsztat.pl", "Warsztat Podkarpacki", new DateTime(2021, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "668999000" },
                    { 30, "Legnica", "express@autoserwis.pl", "Express Auto Serwis", new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "669000111" },
                    { 31, "Warszawa", "service@tesla-warszawa.pl", "Tesla Service Center", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "670111222" },
                    { 32, "Kraków", "ev@specialistskrakow.pl", "EV Specialists Kraków", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "671222333" },
                    { 33, "Gdańsk", "hybrid@techgdansk.pl", "Hybrid Tech Gdańsk", new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "672333444" },
                    { 34, "Wrocław", "green@motorswroclaw.pl", "Green Motors Service", new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "673444555" },
                    { 35, "Poznań", "eco@drivepoznan.pl", "Eco Drive Center", new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "674555666" },
                    { 36, "Częstochowa", "quick@fixauto.pl", "Quick Fix Auto", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "675666777" },
                    { 37, "Radom", "budget@carservice.pl", "Budget Car Service", new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "676777888" },
                    { 38, "Płock", "fast@lanemechanics.pl", "Fast Lane Mechanics", new DateTime(2021, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "677888999" },
                    { 39, "Włocławek", "speed@service24h.pl", "Speed Service 24h", new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "678999000" },
                    { 40, "Siedlce", "autofix@express.pl", "Auto Fix Express", new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "679000111" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "ModelId", "RegistrationNumber" },
                values: new object[,]
                {
                    { 11, "Available", 60m, "Gdańsk", 15000, 11, "GD78901" },
                    { 12, "Available", 90m, "Gdańsk", 35000, 12, "GD89012" },
                    { 13, "Available", 85m, "Poznań", 20000, 13, "PO78901" },
                    { 14, "Available", 100m, "Poznań", 22000, 14, "PO89012" },
                    { 15, "Rented", 80m, "Poznań", 18000, 15, "PO90123" },
                    { 16, "Available", 130m, "Poznań", 28000, 16, "PO01234" },
                    { 17, "Available", 55m, "Łódź", 15000, 17, "LO89012" },
                    { 18, "Available", 50m, "Łódź", 10000, 18, "LO90123" },
                    { 19, "Available", 70m, "Łódź", 20000, 19, "LO01234" },
                    { 20, "Available", 45m, "Łódź", 8000, 20, "LO12345" },
                    { 21, "Rented", 70m, "Wrocław", 18000, 21, "WR90123" },
                    { 22, "Available", 55m, "Wrocław", 12000, 22, "WR01234" },
                    { 23, "Available", 65m, "Wrocław", 25000, 23, "WR12345" },
                    { 24, "Available", 80m, "Wrocław", 30000, 24, "WR23456" },
                    { 25, "Available", 110m, "Szczecin", 16000, 25, "SZ01234" },
                    { 26, "Available", 130m, "Szczecin", 22000, 26, "SZ12345" },
                    { 27, "Available", 115m, "Szczecin", 18000, 27, "SZ23456" },
                    { 28, "Available", 95m, "Szczecin", 14000, 28, "SZ34567" },
                    { 29, "Available", 60m, "Bydgoszcz", 20000, 29, "BY45678" },
                    { 30, "Available", 75m, "Bydgoszcz", 25000, 30, "BY56789" },
                    { 31, "Available", 65m, "Bydgoszcz", 15000, 31, "BY67890" },
                    { 32, "Available", 50m, "Bydgoszcz", 10000, 32, "BY78901" },
                    { 33, "Available", 70m, "Lublin", 28000, 33, "LU89012" },
                    { 34, "Available", 75m, "Lublin", 18000, 34, "LU90123" },
                    { 35, "Available", 60m, "Lublin", 22000, 35, "LU01234" },
                    { 36, "Maintenance", 85m, "Lublin", 32000, 36, "LU12345" },
                    { 37, "Available", 65m, "Katowice", 24000, 37, "KA23456" },
                    { 38, "Available", 70m, "Katowice", 19000, 38, "KA34567" },
                    { 39, "Available", 95m, "Katowice", 35000, 39, "KA45678" },
                    { 40, "Available", 90m, "Katowice", 15000, 40, "KA56789" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "ModelName" },
                values: new object[,]
                {
                    { 41, 11, "308" },
                    { 42, 11, "3008" },
                    { 43, 11, "208" },
                    { 44, 11, "5008" },
                    { 45, 12, "Clio" },
                    { 46, 12, "Megane" },
                    { 47, 12, "Kadjar" },
                    { 48, 12, "Captur" },
                    { 49, 13, "C4" },
                    { 50, 13, "C3" },
                    { 51, 13, "C5 Aircross" },
                    { 52, 13, "Berlingo" },
                    { 53, 14, "XC60" },
                    { 54, 14, "XC90" },
                    { 55, 14, "V60" },
                    { 56, 14, "S60" },
                    { 57, 15, "Leon" },
                    { 58, 15, "Ibiza" },
                    { 59, 15, "Ateca" },
                    { 60, 15, "Arona" },
                    { 61, 16, "Octavia" },
                    { 62, 16, "Superb" },
                    { 63, 16, "Karoq" },
                    { 64, 16, "Fabia" },
                    { 65, 17, "500" },
                    { 66, 17, "Panda" },
                    { 67, 17, "Tipo" },
                    { 68, 17, "500X" },
                    { 69, 18, "Giulia" },
                    { 70, 18, "Stelvio" },
                    { 71, 18, "Giulietta" },
                    { 72, 18, "4C" },
                    { 73, 19, "Elantra" },
                    { 74, 19, "Tucson" },
                    { 75, 19, "Santa Fe" },
                    { 76, 19, "Sonata" },
                    { 77, 20, "Mazda3" },
                    { 78, 20, "CX-5" },
                    { 79, 20, "Mazda6" },
                    { 80, 20, "CX-3" },
                    { 81, 21, "Outback" },
                    { 82, 21, "Forester" },
                    { 83, 21, "Impreza" },
                    { 84, 21, "XV" },
                    { 85, 22, "Outlander" },
                    { 86, 22, "ASX" },
                    { 87, 22, "Eclipse Cross" },
                    { 88, 22, "Lancer" },
                    { 89, 23, "Swift" },
                    { 90, 23, "Vitara" },
                    { 91, 23, "Baleno" },
                    { 92, 23, "Jimny" },
                    { 93, 24, "Cherokee" },
                    { 94, 24, "Grand Cherokee" },
                    { 95, 24, "Wrangler" },
                    { 96, 24, "Compass" },
                    { 97, 25, "Escalade" },
                    { 98, 25, "XT5" },
                    { 99, 25, "CT5" },
                    { 100, 25, "XT6" },
                    { 101, 33, "Model 3" },
                    { 102, 33, "Model Y" },
                    { 103, 33, "Model S" },
                    { 104, 33, "Model X" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "ClientId", "EmployeeId", "RentalDate", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 48, 9, 43, 17, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 53, 6, 15, 17, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 54, 7, 25, 18, new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 55, 8, 35, 19, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "CarId", "Cost", "Description", "RepairDate", "ServiceCenterId" },
                values: new object[,]
                {
                    { 11, 5, 850m, "Naprawa systemu iDrive BMW", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 15, 8, 520m, "Naprawa silnika BMW", new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 18, 7, 650m, "Wymiana pompy paliwa BMW", new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "ModelId", "RegistrationNumber" },
                values: new object[,]
                {
                    { 41, "Available", 55m, "Gdynia", 20000, 41, "GY67890" },
                    { 42, "Available", 50m, "Gdynia", 12000, 45, "GY78901" },
                    { 43, "Available", 58m, "Toruń", 18000, 49, "TR89012" },
                    { 44, "Available", 100m, "Rzeszów", 25000, 53, "RZ90123" },
                    { 45, "Available", 52m, "Olsztyn", 15000, 57, "OL01234" },
                    { 46, "Available", 60m, "Kielce", 22000, 61, "KI12345" },
                    { 47, "Available", 45m, "Opole", 8000, 65, "OP23456" },
                    { 48, "Available", 85m, "Płock", 18000, 69, "PL34567" },
                    { 49, "Available", 65m, "Słupsk", 20000, 77, "SL45678" },
                    { 50, "Available", 150m, "Tarnów", 5000, 101, "TA56789" }
                });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "CarId", "Company", "EndDate", "PolicyNumber", "StartDate" },
                values: new object[,]
                {
                    { 11, 11, "Uniqa", new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNQ-011", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 12, "PZU", new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-012", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 13, "Allianz", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-013", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 14, "Warta", new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-014", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 15, "PZU", new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-015", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 16, "Generali", new DateTime(2027, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN-016", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 17, "Uniqa", new DateTime(2027, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNQ-017", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 18, "PZU", new DateTime(2027, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-018", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 19, "Allianz", new DateTime(2027, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-019", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 20, "Warta", new DateTime(2027, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-020", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 21, "PZU", new DateTime(2027, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-021", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 22, "Generali", new DateTime(2027, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN-022", new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 23, "Uniqa", new DateTime(2027, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNQ-023", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 24, "PZU", new DateTime(2027, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-024", new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 25, "Allianz", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-025", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 26, "Warta", new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-026", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 27, "PZU", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-027", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 28, "Generali", new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN-028", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 29, "Uniqa", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNQ-029", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 30, "PZU", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-030", new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 31, "Allianz", new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-031", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 32, "Warta", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-032", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 33, "PZU", new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-033", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 34, "Generali", new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN-034", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 35, "Uniqa", new DateTime(2026, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNQ-035", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 36, "PZU", new DateTime(2026, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-036", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 37, "Allianz", new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-037", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 38, "Warta", new DateTime(2027, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-038", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 39, "PZU", new DateTime(2027, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-039", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 40, "Generali", new DateTime(2027, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN-040", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentMethod", "RentalId", "Status" },
                values: new object[,]
                {
                    { 48, 135m, new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 48, "Completed" },
                    { 53, 665m, new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 53, "Pending" },
                    { 54, 770m, new DateTime(2026, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 54, "Completed" },
                    { 55, 735m, new DateTime(2026, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 55, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "ClientId", "EmployeeId", "RentalDate", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 11, 17, 11, 3, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 12, 18, 12, 16, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 13, 25, 13, 3, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 14, 26, 14, 6, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 15, 29, 15, 9, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 16, 33, 16, 17, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 17, 37, 17, 18, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 21, 13, 46, 23, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 22, 14, 47, 23, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 23, 27, 48, 23, new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 24, 16, 49, 25, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 25, 28, 50, 25, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 31, 19, 26, 16, new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 32, 20, 27, 17, new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 33, 22, 28, 18, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 34, 23, 29, 19, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 35, 24, 30, 20, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 36, 30, 31, 21, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 37, 31, 32, 3, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 38, 32, 33, 6, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 39, 34, 34, 9, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 40, 35, 35, 16, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 41, 38, 36, 17, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 42, 39, 37, 18, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 43, 40, 38, 19, new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 45, 11, 40, 21, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 46, 12, 41, 3, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 49, 36, 44, 18, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 50, 37, 45, 19, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 51, 21, 1, 3, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 52, 15, 6, 16, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 56, 13, 12, 20, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reserved" },
                    { 57, 14, 22, 21, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reserved" },
                    { 58, 16, 32, 23, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reserved" },
                    { 59, 25, 42, 25, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reserved" },
                    { 60, 26, 50, 16, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reserved" },
                    { 61, 27, 47, 23, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 62, 28, 48, 25, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "CarId", "Cost", "Description", "RepairDate", "ServiceCenterId" },
                values: new object[,]
                {
                    { 12, 25, 750m, "Wymiana turbosprężarki Mercedes", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 13, 13, 680m, "Naprawa systemu quattro Audi", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 14, 26, 920m, "Wymiana modułu ESP Mercedes", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 16, 14, 380m, "Wymiana sprzęgła Audi", new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 17, 27, 450m, "Naprawa klimatyzacji Mercedes", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 19, 16, 780m, "Naprawa systemu nawigacji Audi", new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 20, 28, 320m, "Wymiana świec zapłonowych Mercedes", new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 21, 17, 250m, "Przegląd okresowy VW Passat", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 22, 18, 180m, "Wymiana oleju VW Golf", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 23, 21, 420m, "Naprawa układu kierowniczego Honda", new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 24, 22, 290m, "Wymiana tarcz hamulcowych Honda", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 25, 29, 350m, "Naprawa zawieszenia Kia Sportage", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 26, 33, 480m, "Wymiana rozrządu Nissan Altima", new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 27, 37, 360m, "Naprawa układu chłodzenia Chevrolet", new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 28, 19, 220m, "Wymiana filtrów VW Tiguan", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 29, 23, 540m, "Naprawa skrzyni biegów Honda Accord", new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 30, 31, 190m, "Wymiana świec zapłonowych Kia Optima", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 38, 12, 580m, "Naprawa systemu 4WD Ford Explorer", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 39, 35, 240m, "Wymiana pasków rozrządu Nissan Sentra", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 40, 39, 890m, "Naprawa silnika V8 Chevrolet Tahoe", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 42, 24, 480m, "Wymiana systemu hybrydowego Honda Pilot", new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 43, 20, 150m, "Przegląd techniczny VW Polo", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 44, 32, 280m, "Naprawa układu wydechowego Kia Rio", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 45, 40, 620m, "Wymiana turbosprężarki Chevrolet Camaro", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "CarId", "Company", "EndDate", "PolicyNumber", "StartDate" },
                values: new object[,]
                {
                    { 41, 41, "Uniqa", new DateTime(2027, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNQ-041", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 42, "PZU", new DateTime(2027, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-042", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 43, "Allianz", new DateTime(2027, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-043", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 44, "Warta", new DateTime(2027, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-044", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 45, "PZU", new DateTime(2027, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-045", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 46, "Generali", new DateTime(2027, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN-046", new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 47, "Uniqa", new DateTime(2027, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNQ-047", new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 48, "PZU", new DateTime(2027, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PZU-048", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 49, "Allianz", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL-049", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 50, "Warta", new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "WRT-050", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentMethod", "RentalId", "Status" },
                values: new object[,]
                {
                    { 11, 715m, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 11, "Completed" },
                    { 12, 350m, new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 12, "Completed" },
                    { 13, 1100m, new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 13, "Completed" },
                    { 14, 1820m, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 14, "Completed" },
                    { 15, 420m, new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 15, "Completed" },
                    { 16, 1050m, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 16, "Completed" },
                    { 17, 455m, new DateTime(2026, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 17, "Completed" },
                    { 21, 595m, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 21, "Completed" },
                    { 22, 700m, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 22, "Completed" },
                    { 23, 805m, new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 23, "Completed" },
                    { 24, 910m, new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 24, "Completed" },
                    { 25, 665m, new DateTime(2026, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 25, "Completed" },
                    { 31, 770m, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 31, "Completed" },
                    { 32, 315m, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 32, "Completed" },
                    { 33, 385m, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 33, "Completed" },
                    { 34, 455m, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 34, "Completed" },
                    { 35, 560m, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 35, "Completed" },
                    { 36, 525m, new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 36, "Completed" },
                    { 37, 455m, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 37, "Completed" },
                    { 38, 350m, new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 38, "Completed" },
                    { 39, 525m, new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 39, "Completed" },
                    { 40, 420m, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 40, "Completed" },
                    { 41, 210m, new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 41, "Completed" },
                    { 42, 285m, new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 42, "Completed" },
                    { 43, 270m, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 43, "Completed" },
                    { 45, 180m, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 45, "Completed" },
                    { 46, 270m, new DateTime(2026, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 46, "Completed" },
                    { 49, 255m, new DateTime(2026, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 49, "Completed" },
                    { 50, 195m, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 50, "Completed" },
                    { 51, 490m, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 51, "Pending" },
                    { 52, 560m, new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 52, "Completed" },
                    { 56, 595m, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 56, "Pending" },
                    { 57, 700m, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 57, "Pending" },
                    { 58, 910m, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 58, "Pending" },
                    { 59, 945m, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 59, "Completed" },
                    { 60, 1015m, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 60, "Pending" },
                    { 61, 10350m, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 61, "Completed" },
                    { 62, 8740m, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 62, "Completed" },
                    { 69, 100m, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 11, "Completed" },
                    { 70, 150m, new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 13, "Completed" },
                    { 71, 200m, new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 21, "Completed" },
                    { 72, 125m, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 25, "Completed" },
                    { 73, 80m, new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 31, "Completed" },
                    { 74, 30m, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 41, "Completed" },
                    { 79, 120m, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 14, "Refunded" },
                    { 80, 90m, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 22, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "ClientId", "EmployeeId", "RentalDate", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 18, 41, 18, 21, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 19, 43, 19, 19, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 20, 45, 20, 20, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 26, 44, 21, 17, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 27, 46, 22, 18, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 28, 47, 23, 19, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 29, 48, 24, 20, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 30, 49, 25, 21, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 44, 42, 39, 20, new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 47, 50, 42, 16, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 63, 44, 49, 23, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 64, 45, 46, 25, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 65, 46, 50, 23, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "CarId", "Cost", "Description", "RepairDate", "ServiceCenterId" },
                values: new object[,]
                {
                    { 31, 41, 380m, "Wymiana opon zimowych Peugeot 308", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 32, 44, 720m, "Naprawa systemu bezpieczeństwa Volvo XC60", new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 33, 45, 280m, "Wymiana akumulatora SEAT Leon", new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 18 },
                    { 34, 46, 320m, "Naprawa ogrzewania Škoda Octavia", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 21 },
                    { 35, 47, 160m, "Wymiana żarówek Fiat 500", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 25 },
                    { 36, 48, 650m, "Naprawa silnika Alfa Romeo Giulia", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 24 },
                    { 37, 49, 420m, "Wymiana sprzęgła Mazda3", new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 26 },
                    { 41, 50, 1200m, "Naprawa systemu Autopilot Tesla Model 3", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 31 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentMethod", "RentalId", "Status" },
                values: new object[,]
                {
                    { 18, 550m, new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 18, "Completed" },
                    { 19, 464m, new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 19, "Completed" },
                    { 20, 364m, new DateTime(2026, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 20, "Completed" },
                    { 26, 1500m, new DateTime(2026, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 26, "Completed" },
                    { 27, 480m, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 27, "Completed" },
                    { 28, 405m, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 28, "Completed" },
                    { 29, 1190m, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 29, "Completed" },
                    { 30, 455m, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 30, "Completed" },
                    { 44, 150m, new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "BLIK", 44, "Completed" },
                    { 47, 450m, new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 47, "Completed" },
                    { 63, 9000m, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 63, "Completed" },
                    { 64, 4680m, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 64, "Completed" },
                    { 65, 5460m, new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 65, "Pending" },
                    { 75, 50m, new DateTime(2026, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 47, "Completed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ServiceCenters",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: 2022);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: 2021);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: 2020);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "Year",
                value: 2021);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: 2022);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: 2021);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: 2022);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                column: "Year",
                value: 2020);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                column: "Year",
                value: 2021);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                column: "Year",
                value: 2020);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DailyPrice",
                value: 200m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DailyPrice",
                value: 250m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Maintenance", 400m, "Kraków", 30000, "KR34567" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Rented", 350m, "Kraków", 18000, "KR45678" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Available", 180m, "Gdańsk", 12000, "GD56789" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Reserved", 220m, "Gdańsk", 25000, "GD67890" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { 300m, "Poznań", 20000, "PO78901" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { 210m, "Łódź", 15000, "LO89012" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Rented", 240m, "Wrocław", 18000, "WR90123" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AvailabilityStatus", "DailyPrice", "Location", "Mileage", "RegistrationNumber" },
                values: new object[] { "Available", 260m, "Szczecin", 16000, "SZ01234" });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 2, "X5" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 2, "3 Series" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 3, "Focus" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 3, "Mustang" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 4, "A5" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 5, "Passat" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 6, "CR-V" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BrandId", "ModelName" },
                values: new object[] { 7, "C-Class" });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1000m, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1200m, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1500m, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1300m, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1100m, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1400m, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1250m, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1350m, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1450m, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Amount", "PaymentDate" },
                values: new object[] { 1550m, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "RentalDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 500m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 1200m, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 800m, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 1500m, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 600m, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 2000m, new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 700m, new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 900m, new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 1100m, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "RepairDate" },
                values: new object[] { 1300m, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
