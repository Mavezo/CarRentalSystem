using CarRentalSystem.Entities.Users;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<Employee?> GetEmployeeWithRentalsAsync(int id);
        Task<List<Employee>> SearchEmployeesAsync(string? searchString, string? searchType);
        Task<bool> PhoneExistsAsync(string phone, int? excludeId = null);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> CanDeleteEmployeeAsync(int id);
    }
}
