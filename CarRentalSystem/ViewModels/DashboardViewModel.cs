namespace CarRentalSystem.ViewModels
{
    public class DashboardViewModel
    {
        // Statistics
        public int TotalClients { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalCars { get; set; }
        public int AvailableCars { get; set; }
        public int ActiveRentals { get; set; }
        public int TotalRentals { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public decimal TotalRevenue { get; set; }
        
        // Status counts
        public int CarsInMaintenance { get; set; }
        public int ReservedCars { get; set; }
        public int OverdueRentals { get; set; }
        public int PendingPayments { get; set; }
        
        // Recent data for quick view
        public int RecentRepairs { get; set; }
        public int ExpiringInsurances { get; set; }
        
        // Daily revenue data for chart
        public List<decimal> DailyRevenueData { get; set; } = new List<decimal>();
        public List<string> DailyLabels { get; set; } = new List<string>();
    }
}
