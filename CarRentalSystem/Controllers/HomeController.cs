using System.Diagnostics;
using CarRentalSystem.Models;
using CarRentalSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboardService _dashboardService;

        public HomeController(ILogger<HomeController> logger, IDashboardService dashboardService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _dashboardService.GetDashboardDataAsync();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string? message, string? description)
        {
            // Prefer explicit message query string when provided by middleware
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = message;
            }
            else if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }

            if (!string.IsNullOrEmpty(description))
            {
                ViewBag.ErrorDescription = description;
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
