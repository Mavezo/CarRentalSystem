using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(CarRentalContext context, ILogger<EmployeesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString, string searchType)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["SearchType"] = searchType;

            var employees = from e in _context.Employees
                           select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                switch (searchType)
                {
                    case "name":
                        employees = employees.Where(e => e.FirstName.Contains(searchString) 
                                                      || e.LastName.Contains(searchString));
                        break;
                    case "position":
                        employees = employees.Where(e => e.Position.Contains(searchString));
                        break;
                    case "phone":
                        employees = employees.Where(e => e.Phone.Contains(searchString));
                        break;
                    default:
                        employees = employees.Where(e => e.FirstName.Contains(searchString) 
                                                      || e.LastName.Contains(searchString)
                                                      || e.Position.Contains(searchString)
                                                      || e.Phone.Contains(searchString));
                        break;
                }
            }

            return View(await employees.OrderBy(e => e.LastName).ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Rentals!)
                    .ThenInclude(r => r.Car!.Model!.Brand)
                .Include(e => e.Rentals!)
                    .ThenInclude(r => r.Client)
                .Include(e => e.Rentals!)
                    .ThenInclude(r => r.Payments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Position,HireDate,Salary,Phone")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Check if phone already exists
                if (await _context.Employees.AnyAsync(e => e.Phone == employee.Phone))
                {
                    ModelState.AddModelError("Phone", "An employee with this phone number already exists.");
                    return View(employee);
                }

                _context.Add(employee);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation($"New employee created: {employee.FirstName} {employee.LastName} (ID: {employee.Id})");
                TempData["SuccessMessage"] = $"Employee {employee.FirstName} {employee.LastName} has been successfully created.";
                
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Position,HireDate,Salary,Phone")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if phone is being changed and if it's already taken by another employee
                    var existingPhoneEmployee = await _context.Employees
                        .FirstOrDefaultAsync(e => e.Phone == employee.Phone && e.Id != employee.Id);
                    
                    if (existingPhoneEmployee != null)
                    {
                        ModelState.AddModelError("Phone", "An employee with this phone number already exists.");
                        return View(employee);
                    }

                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                    
                    _logger.LogInformation($"Employee updated: {employee.FirstName} {employee.LastName} (ID: {employee.Id})");
                    TempData["SuccessMessage"] = $"Employee {employee.FirstName} {employee.LastName} has been successfully updated.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Rentals)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Rentals)
                .FirstOrDefaultAsync(e => e.Id == id);
            
            if (employee == null)
            {
                return NotFound();
            }

            // Check if employee has any rentals
            if (employee.Rentals != null && employee.Rentals.Any())
            {
                TempData["ErrorMessage"] = $"Cannot delete employee {employee.FirstName} {employee.LastName} because they have processed {employee.Rentals.Count} rental(s) in the system.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation($"Employee deleted: {employee.FirstName} {employee.LastName} (ID: {employee.Id})");
            TempData["SuccessMessage"] = $"Employee {employee.FirstName} {employee.LastName} has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
