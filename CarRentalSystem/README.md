# Car Rental Management System

A comprehensive university project demonstrating a professional-grade car rental management application built with **ASP.NET Core 8**, **Entity Framework Core**, and **SQL Server**. This project implements a three-stage development approach covering foundational architecture, layered services, and persistent data storage.

## Table of Contents

- [Project Overview](#project-overview)
- [Technology Stack](#technology-stack)
- [System Architecture](#system-architecture)
- [Feature Overview](#feature-overview)
- [Development Stages](#development-stages)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Core Services](#core-services)
- [Database Configuration](#database-configuration)
- [Key Business Rules](#key-business-rules)
- [API Endpoints](#api-endpoints)
- [UI Features](#ui-features)
- [Testing](#testing)
- [Future Enhancements](#future-enhancements)
- [Contributing](#contributing)
- [License](#license)

---

## Project Overview

The **Car Rental Management System** is an enterprise-level application designed to manage all aspects of a car rental business. It handles vehicle inventory, client relationships, rental agreements, payments, maintenance tracking, and insurance management through an intuitive web interface.

### Key Objectives

✅ Demonstrate modern ASP.NET Core development practices  
✅ Implement clean architecture with layered services  
✅ Manage complex business logic with database persistence  
✅ Provide real-time dashboard analytics  
✅ Ensure data integrity and validation  
✅ Create a user-friendly Razor Pages UI  

---

## Technology Stack

| Layer | Technology | Version |
|-------|-----------|---------|
| **Framework** | ASP.NET Core | 8.0 |
| **Language** | C# | 12.0 |
| **ORM** | Entity Framework Core | Latest |
| **Database** | SQL Server (LocalDB) | Express |
| **Frontend** | Razor Pages | ASP.NET Core 8 |
| **UI Framework** | Bootstrap | 5.3 |
| **Icons** | Font Awesome | 6.x |
| **Charts** | Chart.js | 3.x |
| **Logging** | Built-in ILogger | ASP.NET Core |
| **Dependency Injection** | Built-in DI Container | ASP.NET Core |

---

## System Architecture

The application follows a **layered architecture** pattern with clear separation of concerns:

```
┌─────────────────────────────────────────────────────┐
│           Presentation Layer (UI)                   │
│    - Razor Pages                                    │
│    - Views & ViewModels                             │
│    - Bootstrap CSS Framework                        │
└──────────────────┬──────────────────────────────────┘
                   │
┌──────────────────▼──────────────────────────────────┐
│          Controllers Layer                          │
│    - HomeController (Dashboard)                     │
│    - RentalsController                              │
│    - CarsController                                 │
│    - ClientsController                              │
│    - EmployeesController                            │
│    - BrandsController                               │
│    - ModelsController                               │
│    - PaymentsController                             │
└──────────────────┬──────────────────────────────────┘
                   │
┌──────────────────▼──────────────────────────────────┐
│           Service Layer (Business Logic)            │
│    - IDashboardService / DashboardService           │
│    - IRentalService / RentalService                 │
│    - ICarService / CarService                       │
│    - IClientService / ClientService                 │
│    - IEmployeeService / EmployeeService             │
│    - IBrandService / BrandService                   │
│    - IModelService / ModelService                   │
│    - IPaymentService / PaymentService               │
└──────────────────┬──────────────────────────────────┘
                   │
┌──────────────────▼──────────────────────────────────┐
│          Data Access Layer (Persistence)            │
│    - CarRentalContext (DbContext)                   │
│    - Entity Framework Core                          │
│    - SQL Server Database                            │
│    - DbSeeder (Test Data)                           │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│        Cross-Cutting Concerns                       │
│    - Exception Handling Middleware                  │
│    - Custom AppException Class                      │
│    - Dependency Injection Container                 │
│    - Logging & Tracing                              │
└─────────────────────────────────────────────────────┘
```

---

## Feature Overview

### 1. **Vehicle Management** 🚗
- **Brands**: Create, read, update, delete car brands with details (country, body type, transmission)
- **Models**: Manage vehicle models within brands
- **Cars**: Full lifecycle management with:
  - Registration number tracking
  - Daily pricing configuration
  - Mileage monitoring
  - Real-time availability status
  - Location tracking

### 2. **Rental Management** 📋
- **Rental Creation**: Book vehicles with:
  - Client selection
  - Employee assignment
  - Rental & return date scheduling
  - Status tracking (Reserved, Active, Returned, Cancelled)
- **Rental Operations**:
  - Real-time availability checking
  - Return vehicle functionality
  - Rental cancellation
  - Rental history & details

### 3. **Client Management** 👥
- Client registration with:
  - Personal information (name, email, phone, address)
  - Document tracking (ID, license, passport)
  - Rental history
  - Email uniqueness validation

### 4. **Employee Management** 👔
- Employee records with:
  - Position management
  - Salary tracking (validated for non-negative values)
  - Hire date tracking
  - Performance monitoring

### 5. **Payment Processing** 💳
- **Payment Methods**: Cash, Credit Card, Debit Card, Bank Transfer
- **Payment Status**: Pending, Completed, Failed, Refunded
- **Features**:
  - Automatic payment tracking per rental
  - Monthly revenue calculation
  - Payment reconciliation
  - Revenue reporting & analytics

### 6. **Maintenance & Insurance** 🔧
- **Service Centers**: Track authorized maintenance facilities
- **Repairs**:
  - Repair request logging
  - Cost tracking
  - Completion status
- **Insurance**:
  - Policy tracking per vehicle
  - Expiration date monitoring
  - Coverage details

### 7. **Dashboard Analytics** 📊
- Real-time statistics:
  - Total clients, employees, vehicles
  - Active & overdue rentals
  - Available/reserved/maintenance vehicle counts
  - Daily revenue chart
- Monthly revenue overview
- Revenue trends visualization
- Quick action buttons for common operations

---

## Development Stages

### **STAGE I: Foundations, Models & First Interactions**

**Objectives**: Establish project skeleton and core domain models

**What Was Implemented**:

✅ **ASP.NET Core 8.0 Razor Pages Project** structure  
✅ **Domain Models** (Entities):
- `Brand`, `Model`, `Car` (Vehicle Management)
- `Client`, `Employee` (User Management)
- `Rental`, `Payment` (Rental Management)
- `Repair`, `Insurance`, `ServiceCenter` (Maintenance)

✅ **Controllers** with basic CRUD operations:
- HomeController (Dashboard)
- BrandsController, ModelsController, CarsController
- ClientsController, EmployeesController
- RentalsController, PaymentsController

✅ **Routing Configuration** for clean URL mapping  
✅ **In-Memory Data Storage** (RAM-based collections during initial development)  
✅ **DTO Pattern** for input validation  
✅ **View Models** for complex UI presentations  
✅ **Test Data Fixtures** in controllers

**Key Files**:
```
Controllers/
├── HomeController.cs
├── BrandsController.cs
├── ModelsController.cs
├── CarsController.cs
├── ClientsController.cs
├── EmployeesController.cs
├── RentalsController.cs
└── PaymentsController.cs

Entities/
├── Vehicles/
│   ├── Brand.cs
│   ├── Model.cs
│   ├── Car.cs
│   └── CarAvailability.cs
├── Users/
│   ├── Client.cs
│   └── Employee.cs
└── Rentals/
    ├── Rental.cs
    ├── Payment.cs
    ├── RentalStatus.cs
    ├── PaymentStatus.cs
    └── PaymentMethod.cs
```

---

### **STAGE II: Layered Architecture & System Core (Business Logic)**

**Objectives**: Implement professional service layer with dependency injection and business rules

**What Was Implemented**:

✅ **Service Layer** with complete separation of concerns:
- All business logic moved from controllers to services
- Controllers are now "thin" - only handling HTTP concerns
- Each service interfaces with database operations

✅ **Service Interfaces** (Contracts):
- `IBrandService`, `BrandService`
- `IModelService`, `ModelService`
- `ICarService`, `CarService`
- `IClientService`, `ClientService`
- `IEmployeeService`, `EmployeeService`
- `IRentalService`, `RentalService`
- `IPaymentService`, `PaymentService`
- `IDashboardService`, `DashboardService`

✅ **Business Rules Implementation** (Enforced in Services):
1. **Rental Availability Check**: Prevents booking unavailable vehicles
2. **Payment Validation**: Ensures correct payment status transitions
3. **Car Status Management**: Auto-updates availability based on rentals
4. **Overdue Rental Detection**: Identifies late returns for penalties
5. **Insurance Expiration Tracking**: Monitors policy validity
6. **Duplicate Prevention**: Unique email, registration number constraints

✅ **Dependency Injection** (Program.cs):
```csharp
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<ICarService, CarService>();
// ... etc
```

✅ **Exception Handling**:
- Custom `AppException` class with:
  - HTTP status codes
  - Error codes for fine-grained handling
  - Descriptive messages & logging
- `ExceptionHandlingMiddleware`:
  - Global error interception
  - User-friendly error messages
  - Structured error responses
  - Logging integration

✅ **Validation**:
- Data annotations (`[Required]`, `[StringLength]`, `[Range]`)
- Business logic validation in services
- Duplicate checking across the database

✅ **Advanced Service Features**:
- Search & filtering capabilities
- Pagination support
- Relationship eager loading
- Async/await pattern throughout
- Comprehensive logging with ILogger

**Key Files**:
```
Services/
├── Interfaces/
│   ├── IBrandService.cs
│   ├── IModelService.cs
│   ├── ICarService.cs
│   ├── IClientService.cs
│   ├── IEmployeeService.cs
│   ├── IRentalService.cs
│   ├── IPaymentService.cs
│   └── IDashboardService.cs
└── Implementations/
    ├── BrandService.cs
    ├── ModelService.cs
    ├── CarService.cs
    ├── ClientService.cs
    ├── EmployeeService.cs
    ├── RentalService.cs
    ├── PaymentService.cs
    └── DashboardService.cs

Middleware/
└── ExceptionHandlingMiddleware.cs

Exceptions/
└── AppException.cs
```

---

### **STAGE III: Persistence & Advanced Features**

**Objectives**: Implement permanent data storage and specialized functionality

**What Was Implemented**:

✅ **Entity Framework Core (Code-First)**:
- DbContext configuration
- Relationship mappings (one-to-many, many-to-many)
- Shadow properties for tracking
- Query optimization with eager loading

✅ **SQL Server Database** (LocalDB):
- Automatic migrations with Entity Framework
- Seeded test data (35 brands, 100+ models, 50+ cars, clients, employees)
- Database constraints:
  - Unique indexes (Email, RegistrationNumber)
  - Check constraints (Salary >= 0, Mileage >= 0)
  - Foreign key relationships with cascade rules

✅ **Migrations** (Automatic):
- `InitialCreate`: Core schema creation
- `PaymentDateChangeMigration`: Schema updates
- `PaymentFixV2`: Data corrections
- `AddMoreData`: Seeding operations

✅ **Advanced Features**:

1. **Dashboard Analytics**:
   - Daily revenue calculation
   - Monthly statistics aggregation
   - Real-time data aggregation
   - Performance-optimized queries

2. **Payment Processing**:
   - Monthly revenue tracking
   - Payment method tracking
   - Status lifecycle management
   - Rental-to-payment relationships

3. **Search & Filtering**:
   - Multi-criteria search across entities
   - Brand/Model filtering
   - Car availability filtering by status
   - Rental status filtering

4. **Data Seeding** (DbSeeder.cs):
   - 35 international car brands
   - 100+ vehicle models
   - 50+ car inventory
   - Sample clients, employees, rentals
   - Payment history
   - Maintenance records

✅ **Database Validation**:
- Referential integrity enforcement
- Check constraints for business rules
- Unique constraints for identifiers
- Data type validation

**Key Files**:
```
Entities/
├── CarRentalContext.cs (DbContext)
├── DbSeeder.cs (Test Data)
├── Maintenance/
│   ├── Repair.cs
│   ├── Insurance.cs
│   └── ServiceCenter.cs
└── [Other domain entities]

Migrations/
├── 20251005082117_InitialCreate.cs
├── 20260114232722_PaymentDateChangeMigration.cs
├── 20260115160232_PaymentFixV2.cs
├── 20260115212553_AddMoreDataV2.cs
└── [Additional migrations]
```

---

## Getting Started

### Prerequisites

- **Visual Studio 2022+** or Visual Studio Code
- **.NET 8 SDK** (or higher)
- **SQL Server LocalDB** (included with Visual Studio)
- **Git**

### Installation Steps

#### 1. **Clone Repository**

```bash
git clone https://github.com/Mavezo/CarRentalSystem.git
cd CarRentalSystem
```

#### 2. **Restore Dependencies**

```bash
dotnet restore
```

#### 3. **Configure Database Connection**

Open `appsettings.json` and verify the connection string:

```json
{
  "ConnectionStrings": {
    "CarRentalDB": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarRentalDB;Integrated Security=True;"
  }
}
```

#### 4. **Apply Database Migrations**

```bash
dotnet ef database update
```

Or in **Package Manager Console**:

```powershell
Update-Database
```

This will:
- Create the `CarRentalDB` database
- Create all tables and relationships
- Seed 100+ test records

#### 5. **Run Application**

```bash
dotnet run
```

Navigate to: `https://localhost:5001`

### First Steps

1. **Dashboard**: View system statistics and quick actions
2. **Vehicles**: Browse available cars by brand/model
3. **Rentals**: Create a new rental (requires selecting client and car)
4. **Payments**: Track and manage rental payments
5. **Reports**: View revenue analytics

---

## Project Structure

```
CarRentalSystem/
├── Controllers/              # MVC Controllers
│   ├── HomeController.cs
│   ├── BrandsController.cs
│   ├── ModelsController.cs
│   ├── CarsController.cs
│   ├── ClientsController.cs
│   ├── EmployeesController.cs
│   ├── RentalsController.cs
│   └── PaymentsController.cs
│
├── Views/                    # Razor Pages & Layouts
│   ├── Home/
│   │   ├── Index.cshtml     # Dashboard
│   │   └── Error.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── Brands/
│   ├── Models/
│   ├── Cars/
│   ├── Clients/
│   ├── Employees/
│   ├── Rentals/
│   └── Payments/
│
├── Entities/                 # Data Models
│   ├── CarRentalContext.cs   # DbContext
│   ├── DbSeeder.cs          # Test Data Seeding
│   ├── Vehicles/
│   │   ├── Brand.cs
│   │   ├── Model.cs
│   │   ├── Car.cs
│   │   └── CarAvailability.cs
│   ├── Users/
│   │   ├── Client.cs
│   │   └── Employee.cs
│   ├── Rentals/
│   │   ├── Rental.cs
│   │   ├── Payment.cs
│   │   ├── RentalStatus.cs
│   │   ├── PaymentStatus.cs
│   │   └── PaymentMethod.cs
│   └── Maintenance/
│       ├── Repair.cs
│       ├── Insurance.cs
│       └── ServiceCenter.cs
│
├── Services/                 # Business Logic Layer
│   ├── Interfaces/
│   │   ├── IBrandService.cs
│   │   ├── IModelService.cs
│   │   ├── ICarService.cs
│   │   ├── IClientService.cs
│   │   ├── IEmployeeService.cs
│   │   ├── IRentalService.cs
│   │   ├── IPaymentService.cs
│   │   └── IDashboardService.cs
│   └── Implementations/
│       ├── BrandService.cs
│       ├── ModelService.cs
│       ├── CarService.cs
│       ├── ClientService.cs
│       ├── EmployeeService.cs
│       ├── RentalService.cs
│       ├── PaymentService.cs
│       └── DashboardService.cs
│
├── ViewModels/              # View Models for UI
│   └── DashboardViewModel.cs
│
├── Middleware/              # Custom Middleware
│   └── ExceptionHandlingMiddleware.cs
│
├── Exceptions/              # Custom Exceptions
│   └── AppException.cs
│
├── Models/                  # Utility Models
│   └── ErrorViewModel.cs
│
├── Migrations/              # EF Core Migrations
│   ├── 20251005082117_InitialCreate.cs
│   ├── CarRentalContextModelSnapshot.cs
│   └── [Other migrations...]
│
├── wwwroot/                 # Static Files
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   └── lib/                 # Bootstrap, Font Awesome, Chart.js
│
├── Program.cs              # Application Entry Point
├── appsettings.json        # Configuration
├── appsettings.Development.json
├── CarRentalSystem.csproj   # Project File
├── README.md               # This file
└── DEVELOPER_GUIDE.md      # Service Usage Guide
```

---

## Core Services

### **DashboardService**

Provides comprehensive dashboard analytics and real-time statistics.

**Key Methods**:
```csharp
// Main dashboard data aggregation
Task<DashboardViewModel> GetDashboardDataAsync()

// Revenue calculations
Task<Dictionary<int, decimal>> CalculateDailyRevenueAsync(int day, int month, int year)
Task<decimal> CalculateMonthlyRevenueAsync(int month, int year)
```

**Returns**:
- Client, employee, car statistics
- Rental status breakdown
- Revenue metrics (daily, monthly, total)
- Chart data for UI visualization

---

### **RentalService**

Manages all rental operations with business logic enforcement.

**Key Methods**:
```csharp
Task<List<Rental>> GetAllRentalsAsync()
Task<Rental?> GetRentalByIdAsync(int id)
Task<List<Rental>> SearchRentalsAsync(string? searchString, RentalStatus? status)
Task<Rental> CreateRentalAsync(Rental rental)
Task<Rental> UpdateRentalAsync(Rental rental)
Task<Rental> ReturnRentalAsync(int id, DateTime returnDate)
Task<bool> DeleteRentalAsync(int id)

// Business Logic
Task<bool> CheckCarAvailabilityAsync(int carId, DateTime rentalDate, DateTime? returnDate)
Task<bool> IsRentalOverdueAsync(int id)
Task<decimal> CalculateRentalCostAsync(int carId, DateTime rentalDate, DateTime returnDate)
```

**Business Rules**:
- Cannot rent unavailable cars
- Cannot book overlapping rental periods
- Automatically updates car availability status
- Detects overdue rentals

---

### **CarService**

Vehicle inventory management with availability tracking.

**Key Methods**:
```csharp
Task<List<Car>> GetAllCarsAsync()
Task<Car?> GetCarByIdAsync(int id)
Task<Car?> GetCarWithDetailsAsync(int id)
Task<List<Car>> SearchCarsAsync(string? searchString, int? brandId, int? modelId, 
                                 CarAvailability? status, decimal? minPrice, decimal? maxPrice)
Task<Car> CreateCarAsync(Car car)
Task<Car> UpdateCarAsync(Car car)
Task<bool> DeleteCarAsync(int id)

// Business Logic
Task<bool> RegistrationNumberExistsAsync(string regNumber, int? excludeId = null)
Task<List<Model>> GetModelsByBrandAsync(int brandId)
Task<int> GetAvailableCarsCountAsync()
Task<int> GetCarsInMaintenanceCountAsync()
```

**Features**:
- Duplicate registration number prevention
- Multi-criteria search & filtering
- Availability status management
- Cost calculation

---

### **PaymentService**

Financial transaction management and reconciliation.

**Key Methods**:
```csharp
Task<List<Payment>> GetAllPaymentsAsync()
Task<Payment?> GetPaymentByIdAsync(int id)
Task<List<Payment>> SearchPaymentsAsync(string? searchString, PaymentStatus? status)
Task<Payment> CreatePaymentAsync(Payment payment)
Task<Payment> UpdatePaymentAsync(Payment payment)
Task<bool> DeletePaymentAsync(int id)

// Business Logic
Task<decimal> GetMonthlyRevenueAsync(int month, int year)
Task<decimal> GetTotalRevenueAsync()
Task<List<Payment>> GetOverduePaymentsAsync()
```

**Features**:
- Multiple payment methods (Cash, Card, Bank Transfer)
- Status tracking (Pending, Completed, Failed, Refunded)
- Revenue aggregation
- Overdue payment identification

---

### **ClientService**

Client/Customer relationship management.

**Key Methods**:
```csharp
Task<List<Client>> GetAllClientsAsync()
Task<Client?> GetClientByIdAsync(int id)
Task<List<Client>> SearchClientsAsync(string? searchString)
Task<Client> CreateClientAsync(Client client)
Task<Client> UpdateClientAsync(Client client)
Task<bool> DeleteClientAsync(int id)

// Business Logic
Task<bool> ClientEmailExistsAsync(string email, int? excludeId = null)
Task<List<Rental>> GetClientRentalsAsync(int clientId)
```

**Features**:
- Email uniqueness validation
- Complete rental history per client
- Document tracking (ID, License, Passport)

---

### **BrandService & ModelService**

Vehicle taxonomy management.

**Key Methods** (BrandService):
```csharp
Task<List<Brand>> GetAllBrandsAsync()
Task<Brand?> GetBrandByIdAsync(int id)
Task<List<Brand>> SearchBrandsAsync(string? searchString, string? country, string? bodyType)
Task<List<string>> GetDistinctCountriesAsync()
Task<List<string>> GetDistinctBodyTypesAsync()
Task<Brand> CreateBrandAsync(Brand brand)
Task<Brand> UpdateBrandAsync(Brand brand)
Task<bool> DeleteBrandAsync(int id)
```

**Features**:
- Brand catalog management
- Country & body type filtering
- Model association
- Cascade deletion prevention

---

## Database Configuration

### Connection String

**File**: `appsettings.json`

```json
{
  "ConnectionStrings": {
    "CarRentalDB": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarRentalDB;Integrated Security=True;"
  }
}
```

### Key Entities & Relationships

```
┌─────────────────────────────────────────────────────┐
│                    VEHICLES                         │
├─────────────────────────────────────────────────────┤
│ Brand                                               │
│   ├── 1 → Many: Models                              │
│                                                     │
│ Model                                               │
│   ├── 1 → Many: Cars                                │
│                                                     │
│ Car                                                 │
│   ├── 1 → Many: Rentals                             │
│   ├── 1 → 1: Insurance                              │
│   └── 1 → Many: Repairs                             │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│                     RENTALS                         │
├─────────────────────────────────────────────────────┤
│ Rental                                              │
│   ├── N → 1: Car                                    │
│   ├── N → 1: Client                                 │
│   ├── N → 1: Employee                               │
│   └── 1 → Many: Payments                            │
│                                                     │
│ Payment                                             │
│   └── N → 1: Rental                                 │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│                      USERS                          │
├─────────────────────────────────────────────────────┤
│ Client                                              │
│   └── 1 → Many: Rentals                             │
│                                                     │
│ Employee                                            │
│   └── 1 → Many: Rentals                             │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│                  MAINTENANCE                        │
├─────────────────────────────────────────────────────┤
│ Repair                                              │
│   ├── N → 1: Car                                    │
│   └── N → 1: ServiceCenter                          │
│                                                     │
│ Insurance                                           │
│   └── 1 → 1: Car                                    │
│                                                     │
│ ServiceCenter                                       │
│   └── 1 → Many: Repairs                             │
└─────────────────────────────────────────────────────┘
```

### Database Constraints

#### Unique Indexes
- `Client.Email` - Prevents duplicate email addresses
- `Car.RegistrationNumber` - Prevents duplicate registrations

#### Check Constraints
- `Employee.Salary >= 0` - Ensures non-negative salaries
- `Car.Mileage >= 0` - Ensures non-negative mileage

#### Enums (String-based)
- `RentalStatus`: Reserved, Active, Returned, Cancelled
- `PaymentStatus`: Pending, Completed, Failed, Refunded
- `PaymentMethod`: Cash, CreditCard, DebitCard, BankTransfer
- `CarAvailability`: Available, Reserved, Rented, InMaintenance

---

## Key Business Rules

### Rental Management

1. **Availability Check**
   - A car cannot be rented if its status is not "Available"
   - Prevents double-booking

2. **Automatic Status Updates**
   - Car status changes to "Rented" when rental is confirmed
   - Reverts to "Available" when rental is completed
   - Sets to "InMaintenance" when repairs are scheduled

3. **Overdue Detection**
   - System identifies rentals with return dates in the past
   - Automatic penalty calculation (optional feature)

4. **Cost Calculation**
   - Rental cost = Car.DailyPrice × Number of Days
   - Calculated at rental creation and confirmation

### Payment Management

1. **Status Lifecycle**
   - Pending → Completed (or Failed)
   - Failed payments can be retried
   - Completed payments support refunds

2. **Revenue Tracking**
   - Completed payments counted in revenue
   - Failed/Pending excluded from analytics
   - Monthly & daily aggregation

3. **Payment Reconciliation**
   - Each payment tied to specific rental
   - Multiple payments per rental supported (installments)

### Data Validation

1. **Email Uniqueness**
   - Prevents duplicate client registration
   - Enforced at database and service levels

2. **Registration Number Uniqueness**
   - Each car has unique registration
   - Prevents duplicate vehicle entries

3. **Referential Integrity**
   - Foreign keys enforce relationships
   - Cascade deletes on specific entities
   - Prevents orphaned records

---

## API Endpoints

### Dashboard
```
GET  /                          # Dashboard (Home)
```

### Brands
```
GET    /Brands                  # List all brands
GET    /Brands/{id}             # View brand details
GET    /Brands/Create           # Create form
POST   /Brands/Create           # Submit new brand
GET    /Brands/{id}/Edit        # Edit form
POST   /Brands/{id}/Edit        # Submit edit
POST   /Brands/{id}/Delete      # Confirm delete
```

### Models
```
GET    /Models                  # List all models
GET    /Models/{id}             # View model details
POST   /Models/Create           # Create new model
POST   /Models/{id}/Edit        # Update model
POST   /Models/{id}/Delete      # Delete model
```

### Cars
```
GET    /Cars                    # List all cars with filters
GET    /Cars/{id}               # View car details
POST   /Cars/Create             # Create new car
POST   /Cars/{id}/Edit          # Update car
POST   /Cars/{id}/Delete        # Delete car
```

### Rentals
```
GET    /Rentals                 # List all rentals
GET    /Rentals/{id}            # View rental details
POST   /Rentals/Create          # Create new rental
POST   /Rentals/{id}/Return     # Return rental
POST   /Rentals/{id}/Cancel     # Cancel rental
```

### Payments
```
GET    /Payments                # List all payments
GET    /Payments/{id}           # View payment details
POST   /Payments/Create         # Record new payment
POST   /Payments/{id}/Edit      # Update payment
```

### Clients
```
GET    /Clients                 # List all clients
GET    /Clients/{id}            # View client details
POST   /Clients/Create          # Register new client
POST   /Clients/{id}/Edit       # Update client
```

### Employees
```
GET    /Employees               # List all employees
GET    /Employees/{id}          # View employee details
POST   /Employees/Create        # Hire new employee
POST   /Employees/{id}/Edit     # Update employee
```

---

## UI Features

### Dashboard
- **Statistics Cards**: Real-time metrics display
- **Daily Revenue Chart**: Line chart visualization using Chart.js
- **Quick Actions**: Fast access to common operations
- **Module Navigation**: Card-based access to main features
- **Monthly Overview**: Revenue summary and key indicators

### Responsive Design
- **Bootstrap 5.3**: Mobile-first layout
- **Breakpoints**: 
  - Mobile: < 768px (1 column)
  - Tablet: 768px - 1200px (2-3 columns)
  - Desktop: > 1200px (4 columns)

### Interactive Elements
- **Font Awesome Icons**: Professional iconography
- **Toast Notifications**: Success/error feedback
- **Modals**: Confirm delete operations
- **Form Validation**: Client & server-side
- **Data Tables**: Sortable & filterable listings

### Charts & Analytics
- **Chart.js**: Interactive revenue visualization
- **Daily Breakdown**: Revenue per day chart
- **Monthly Summary**: Total monthly revenue
- **Real-time Updates**: Dashboard refreshes on each visit

---

## Testing

### Manual Testing Approach

1. **Create Test Data**
   - Application auto-seeds test data on first run
   - 35 brands, 100+ models, 50+ cars available
   - Sample clients, employees, rentals ready

2. **Test CRUD Operations**
   - Create: Add new brand/model/car/client
   - Read: View details and list pages
   - Update: Edit and save changes
   - Delete: Remove test records

3. **Test Business Rules**
   - Attempt to rent unavailable car (should fail)
   - Create overlapping rentals (should fail)
   - Complete rental and verify status changes
   - Process payment and verify revenue update

4. **Test Dashboard**
   - Verify statistics accuracy
   - Check chart data visualization
   - Confirm quick action links work
   - Test module navigation

### Example Test Scenarios

```
Scenario 1: Complete Rental Flow
├── Step 1: Create new client (if needed)
├── Step 2: Select available car
├── Step 3: Create rental for dates
├── Step 4: Verify car status changed to "Rented"
├── Step 5: Create payment record
├── Step 6: Return rental
├── Step 7: Verify car status changed to "Available"
└── Step 8: Check revenue updated in dashboard

Scenario 2: Availability Validation
├── Step 1: Attempt to rent unavailable car
├── Step 2: System should show error
├── Step 3: Verify car status prevented rental
└── Step 4: Verify error message displayed

Scenario 3: Search & Filter
├── Step 1: Search cars by brand
├── Step 2: Filter by price range
├── Step 3: Filter by availability status
├── Step 4: Verify correct results displayed
└── Step 5: Clear filters and try again
```

---

## Future Enhancements

### Planned Features

- [ ] **User Authentication**
  - Login/registration system
  - Role-based access control (Admin, Manager, Employee)
  - Session management

- [ ] **Advanced Reporting**
  - Monthly/yearly revenue reports
  - CSV export functionality
  - PDF invoice generation
  - Rental statistics per client

- [ ] **Inventory Management**
  - Low stock alerts
  - Automatic reordering
  - Supplier integration

- [ ] **Maintenance Scheduling**
  - Preventive maintenance plans
  - Maintenance reminders
  - Service history timeline

- [ ] **Insurance Management**
  - Policy expiration alerts
  - Automatic renewal reminders
  - Coverage verification

- [ ] **Analytics Dashboard**
  - Interactive KPI dashboards
  - Predictive analytics
  - Trend analysis

- [ ] **Mobile Application**
  - React Native cross-platform app
  - Booking on-the-go
  - Push notifications

- [ ] **API Layer**
  - RESTful API endpoints
  - Swagger/OpenAPI documentation
  - Third-party integrations

- [ ] **Performance Optimization**
  - Query optimization
  - Caching strategy
  - CDN integration

---

## Troubleshooting

### Common Issues

**Issue**: Database connection fails
```
Solution: Verify LocalDB is running
  1. Check: sqlLocalDB info mssqllocaldb
  2. Start if needed: sqllocaldb start mssqllocaldb
  3. Verify connection string in appsettings.json
```

**Issue**: Migration errors
```
Solution: Reset database
  1. dotnet ef database drop --force
  2. dotnet ef database update
  3. Alternatively: Update-Database in PM Console
```

**Issue**: Port already in use
```
Solution: Use different port
  1. dotnet run --urls "https://localhost:5555"
```

**Issue**: Missing test data
```
Solution: Re-seed database
  1. View DbSeeder.cs
  2. Ensure DbSeeder.SeedData() called in OnModelCreating()
  3. Delete and recreate database
```

---

## Contributing

### How to Contribute

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/new-feature`)
3. **Commit** changes (`git commit -am 'Add new feature'`)
4. **Push** to branch (`git push origin feature/new-feature`)
5. **Submit** a pull request

### Code Standards

- Follow **C# naming conventions** (PascalCase for classes, camelCase for variables)
- Use **async/await** pattern throughout
- Add **XML documentation** on public methods
- Write **meaningful commit messages**
- Include **unit tests** for new features

---

## License

This project is licensed under the **MIT License** - see the LICENSE file for details.

This is a **university educational project** demonstrating professional development practices.

---

## Author

**Project**: Car Rental Management System  
**Version**: 1.2  
**Repository**: https://github.com/Mavezo/CarRentalSystem  
**Branch**: version1.2  

---

## Quick Reference

### Quick Start (2 Minutes)
```bash
# 1. Clone & navigate
git clone https://github.com/Mavezo/CarRentalSystem.git
cd CarRentalSystem

# 2. Restore & migrate
dotnet restore
dotnet ef database update

# 3. Run
dotnet run

# 4. Access
# Open: https://localhost:5001
```

### Key Directories
- **Controllers**: `CarRentalSystem/Controllers/`
- **Services**: `CarRentalSystem/Services/`
- **Views**: `CarRentalSystem/Views/`
- **Entities**: `CarRentalSystem/Entities/`
- **Database**: `CarRentalSystem/Entities/CarRentalContext.cs`

### Useful Commands
```bash
# Add migration
dotnet ef migrations add MigrationName

# Remove last migration
dotnet ef migrations remove

# Update database
dotnet ef database update

# View database
# Open SQL Server Object Explorer in Visual Studio
# Connect to: (localdb)\mssqllocaldb
# Find: CarRentalDB database
```

---

**For more detailed developer information, see**: `DEVELOPER_GUIDE.md`

---

*Last Updated: January 2025*  
*Status: Active Development*
