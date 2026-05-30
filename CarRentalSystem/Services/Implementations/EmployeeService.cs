using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Users;
using CarRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(CarRentalContext context, ILogger<EmployeeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee?> GetEmployeeWithRentalsAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Rentals!)
                    .ThenInclude(r => r.Car!.Model!.Brand)
                .Include(e => e.Rentals!)
                    .ThenInclude(r => r.Client)
                .Include(e => e.Rentals!)
                    .ThenInclude(r => r.Payments)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Employee>> SearchEmployeesAsync(string? searchString, string? searchType)
        {
            var employees = _context.Employees.AsQueryable();

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

            return await employees.OrderBy(e => e.LastName).ToListAsync();
        }

        public async Task<bool> PhoneExistsAsync(string phone, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Employees
                    .AnyAsync(e => e.Phone == phone && e.Id != excludeId);
            }

            return await _context.Employees.AnyAsync(e => e.Phone == phone);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New employee created: {employee.FirstName} {employee.LastName} (ID: {employee.Id})");
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Employee updated: {employee.FirstName} {employee.LastName} (ID: {employee.Id})");
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Rentals)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Employee deleted: {employee.FirstName} {employee.LastName} (ID: {employee.Id})");
            return true;
        }

        public async Task<bool> CanDeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Rentals)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return false;
            }

            return employee.Rentals == null || !employee.Rentals.Any();
        }
    }
}
