using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Users;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString, string searchType)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["SearchType"] = searchType;

            var employees = await _employeeService.SearchEmployeesAsync(searchString, searchType);

            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetEmployeeWithRentalsAsync(id.Value);

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
        public async Task<IActionResult> Create(EmployeeFormModel formModel)
        {
            var employee = formModel.ToEntity();

            if (ModelState.IsValid)
            {
                if (await _employeeService.PhoneExistsAsync(employee.Phone))
                {
                    ModelState.AddModelError("Phone", "An employee with this phone number already exists.");
                    return View(employee);
                }

                await _employeeService.CreateEmployeeAsync(employee);
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

            var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeFormModel formModel)
        {
            var employee = formModel.ToEntity();

            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _employeeService.PhoneExistsAsync(employee.Phone, id))
                {
                    ModelState.AddModelError("Phone", "An employee with this phone number already exists.");
                    return View(employee);
                }

                await _employeeService.UpdateEmployeeAsync(employee);
                TempData["SuccessMessage"] = $"Employee {employee.FirstName} {employee.LastName} has been successfully updated.";
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

            var employee = await _employeeService.GetEmployeeWithRentalsAsync(id.Value);
            
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
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            
            if (employee == null)
            {
                return NotFound();
            }

            if (!await _employeeService.CanDeleteEmployeeAsync(id))
            {
                TempData["ErrorMessage"] = $"Cannot delete employee {employee.FirstName} {employee.LastName} because they have processed rental(s) in the system.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            await _employeeService.DeleteEmployeeAsync(id);
            TempData["SuccessMessage"] = $"Employee {employee.FirstName} {employee.LastName} has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }
    }
}
