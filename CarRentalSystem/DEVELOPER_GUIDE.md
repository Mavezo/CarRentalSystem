# Service Layer Quick Reference Guide

## How to Use Services in Controllers

### Example: Using Brand Service

```csharp
public class BrandsController : Controller
{
    private readonly IBrandService _brandService;

    // Inject the service via constructor
    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task<IActionResult> Index()
    {
        // Call service methods instead of DbContext
        var brands = await _brandService.GetAllBrandsAsync();
        return View(brands);
    }
}
```

## Available Services and Methods

### IBrandService
```csharp
// Retrieval
GetAllBrandsAsync()
GetBrandByIdAsync(int id)
GetBrandWithModelsAsync(int id)

// Search & Filters
SearchBrandsAsync(string? searchString, string? country, string? bodyType)
GetDistinctCountriesAsync()
GetDistinctBodyTypesAsync()

// Validation
BrandNameExistsAsync(string brandName, int? excludeId = null)

// CRUD
CreateBrandAsync(Brand brand)
UpdateBrandAsync(Brand brand)
DeleteBrandAsync(int id)

// Business Logic
CanDeleteBrandAsync(int id)
GetModelsCountAsync(int brandId)
```

### IModelService
```csharp
// Retrieval
GetAllModelsAsync()
GetModelByIdAsync(int id)
GetModelWithBrandAsync(int id)

// Search
SearchModelsAsync(string? searchString, int? brandId)

// Validation
ModelNameExistsForBrandAsync(string modelName, int brandId, int? excludeId = null)

// CRUD
CreateModelAsync(Model model)
UpdateModelAsync(Model model)
DeleteModelAsync(int id)

// Business Logic
CanDeleteModelAsync(int id)
GetCarsCountAsync(int modelId)
```

### ICarService
```csharp
// Retrieval
GetAllCarsAsync()
GetCarByIdAsync(int id)
GetCarWithDetailsAsync(int id)

// Search
SearchCarsAsync(string? searchString, int? brandId, int? modelId, 
                CarAvailability? status, decimal? minPrice, decimal? maxPrice)

// Validation
RegistrationNumberExistsAsync(string registrationNumber, int? excludeId = null)

// CRUD
CreateCarAsync(Car car)
UpdateCarAsync(Car car)
DeleteCarAsync(int id)

// Business Logic
CanDeleteCarAsync(int id)
GetModelsByBrandAsync(int brandId)
```

### IClientService
```csharp
// Retrieval
GetAllClientsAsync()
GetClientByIdAsync(int id)
GetClientWithRentalsAsync(int id)

// Search
SearchClientsAsync(string? searchString, string? searchType)

// Validation
EmailExistsAsync(string email, int? excludeId = null)
PeselExistsAsync(string pesel, int? excludeId = null)

// CRUD
CreateClientAsync(Client client)
UpdateClientAsync(Client client)
DeleteClientAsync(int id)

// Business Logic
CanDeleteClientAsync(int id)
```

### IEmployeeService
```csharp
// Retrieval
GetAllEmployeesAsync()
GetEmployeeByIdAsync(int id)
GetEmployeeWithRentalsAsync(int id)

// Search
SearchEmployeesAsync(string? searchString, string? searchType)

// Validation
PhoneExistsAsync(string phone, int? excludeId = null)

// CRUD
CreateEmployeeAsync(Employee employee)
UpdateEmployeeAsync(Employee employee)
DeleteEmployeeAsync(int id)

// Business Logic
CanDeleteEmployeeAsync(int id)
```

### IRentalService
```csharp
// Retrieval
GetAllRentalsAsync()
GetRentalByIdAsync(int id)
GetRentalWithDetailsAsync(int id)

// Search
SearchRentalsAsync(RentalStatus? status, DateTime? startDate, 
                   DateTime? endDate, int? clientId, int? carId)

// CRUD
CreateRentalAsync(Rental rental)
UpdateRentalAsync(Rental rental)
DeleteRentalAsync(int id)

// Business Logic
CanDeleteRentalAsync(int id)
CompleteRentalAsync(int id)
CancelRentalAsync(int id)
HasOverlappingRentalsAsync(int carId, DateTime rentalDate, DateTime returnDate, int? excludeRentalId = null)
CanCancelRentalAsync(int id)
```

### IPaymentService
```csharp
// Retrieval
GetAllPaymentsAsync()
GetPaymentByIdAsync(int id)
GetPaymentWithDetailsAsync(int id)

// Search
SearchPaymentsAsync(int? rentalId, PaymentStatus? status, 
                    PaymentMethod? method, DateTime? startDate, DateTime? endDate)

// CRUD
CreatePaymentAsync(Payment payment)
UpdatePaymentAsync(Payment payment)
DeletePaymentAsync(int id)

// Business Logic
GetTotalPaidForRentalAsync(int rentalId)
CalculateRentalTotalCostAsync(int rentalId)
GetRemainingAmountAsync(int rentalId)
GetRentalPaymentInfoAsync(int rentalId)
```

## Common Patterns

### Pattern 1: List with Search
```csharp
public async Task<IActionResult> Index(string searchString, int? brandId)
{
    var items = await _service.SearchAsync(searchString, brandId);
    return View(items);
}
```

### Pattern 2: Create with Validation
```csharp
public async Task<IActionResult> Create(Item item)
{
    if (ModelState.IsValid)
    {
        if (await _service.NameExistsAsync(item.Name))
        {
            ModelState.AddModelError("Name", "Already exists");
            return View(item);
        }
        
        await _service.CreateAsync(item);
        TempData["SuccessMessage"] = "Created successfully";
        return RedirectToAction(nameof(Index));
    }
    return View(item);
}
```

### Pattern 3: Edit with Validation
```csharp
public async Task<IActionResult> Edit(int id, Item item)
{
    if (id != item.Id) return NotFound();
    
    if (ModelState.IsValid)
    {
        if (await _service.NameExistsAsync(item.Name, id))
        {
            ModelState.AddModelError("Name", "Already exists");
            return View(item);
        }
        
        await _service.UpdateAsync(item);
        TempData["SuccessMessage"] = "Updated successfully";
        return RedirectToAction(nameof(Index));
    }
    return View(item);
}
```

### Pattern 4: Delete with Checks
```csharp
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (!await _service.CanDeleteAsync(id))
    {
        TempData["ErrorMessage"] = "Cannot delete - related records exist";
        return RedirectToAction(nameof(Delete), new { id });
    }
    
    await _service.DeleteAsync(id);
    TempData["SuccessMessage"] = "Deleted successfully";
    return RedirectToAction(nameof(Index));
}
```

## Adding New Services

1. Create interface in `Services/Interfaces/INewService.cs`
2. Create implementation in `Services/Implementations/NewService.cs`
3. Register in `Program.cs`:
   ```csharp
   builder.Services.AddScoped<INewService, NewService>();
   ```
4. Inject in controller:
   ```csharp
   private readonly INewService _service;
   public MyController(INewService service) => _service = service;
   ```

## Best Practices

? **DO:**
- Inject services via constructor
- Use async/await methods
- Call service methods instead of DbContext
- Log important operations
- Handle null checks properly
- Use specific methods (GetById vs GetAll + filtering)

? **DON'T:**
- Inject DbContext into controllers
- Mix service calls with DbContext queries
- Create new service instances with `new`
- Ignore async/await patterns
- Write business logic in controllers
