using CarRentalSystem.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IDashboardService
    {
        /// <summary>
        /// Gets comprehensive dashboard data including counts, revenue, and daily statistics.
        /// </summary>
        /// <returns>DashboardViewModel with all dashboard metrics</returns>
        Task<DashboardViewModel> GetDashboardDataAsync();
    }
}
