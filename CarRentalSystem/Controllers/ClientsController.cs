using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Controllers
{
    public class ClientsController : Controller
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(CarRentalContext context, ILogger<ClientsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Clients
        public async Task<IActionResult> Index(string searchString, string searchType)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["SearchType"] = searchType;

            var clients = from c in _context.Clients
                         select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                switch (searchType)
                {
                    case "name":
                        clients = clients.Where(c => c.FirstName.Contains(searchString) 
                                                  || c.LastName.Contains(searchString));
                        break;
                    case "email":
                        clients = clients.Where(c => c.Email.Contains(searchString));
                        break;
                    case "phone":
                        clients = clients.Where(c => c.PhoneNumber.Contains(searchString));
                        break;
                    case "pesel":
                        clients = clients.Where(c => c.PESEL.Contains(searchString));
                        break;
                    case "city":
                        clients = clients.Where(c => c.City != null && c.City.Contains(searchString));
                        break;
                    default:
                        clients = clients.Where(c => c.FirstName.Contains(searchString) 
                                                  || c.LastName.Contains(searchString)
                                                  || c.Email.Contains(searchString)
                                                  || c.PhoneNumber.Contains(searchString));
                        break;
                }
            }

            return View(await clients.OrderBy(c => c.LastName).ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Car!.Model!.Brand)
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Employee)
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Payments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PESEL,PhoneNumber,Email,City,PostalCode")] Client client)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                if (await _context.Clients.AnyAsync(c => c.Email == client.Email))
                {
                    ModelState.AddModelError("Email", "A client with this email already exists.");
                    return View(client);
                }

                // Check if PESEL already exists
                if (await _context.Clients.AnyAsync(c => c.PESEL == client.PESEL))
                {
                    ModelState.AddModelError("PESEL", "A client with this PESEL already exists.");
                    return View(client);
                }

                _context.Add(client);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation($"New client created: {client.FirstName} {client.LastName} (ID: {client.Id})");
                TempData["SuccessMessage"] = $"Client {client.FirstName} {client.LastName} has been successfully created.";
                
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PESEL,PhoneNumber,Email,City,PostalCode")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if email is being changed and if it's already taken by another client
                    var existingEmailClient = await _context.Clients
                        .FirstOrDefaultAsync(c => c.Email == client.Email && c.Id != client.Id);
                    
                    if (existingEmailClient != null)
                    {
                        ModelState.AddModelError("Email", "A client with this email already exists.");
                        return View(client);
                    }

                    // Check if PESEL is being changed and if it's already taken by another client
                    var existingPeselClient = await _context.Clients
                        .FirstOrDefaultAsync(c => c.PESEL == client.PESEL && c.Id != client.Id);
                    
                    if (existingPeselClient != null)
                    {
                        ModelState.AddModelError("PESEL", "A client with this PESEL already exists.");
                        return View(client);
                    }

                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    
                    _logger.LogInformation($"Client updated: {client.FirstName} {client.LastName} (ID: {client.Id})");
                    TempData["SuccessMessage"] = $"Client {client.FirstName} {client.LastName} has been successfully updated.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Rentals)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Rentals)
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (client == null)
            {
                return NotFound();
            }

            // Check if client has any rentals
            if (client.Rentals != null && client.Rentals.Any())
            {
                TempData["ErrorMessage"] = $"Cannot delete client {client.FirstName} {client.LastName} because they have {client.Rentals.Count} rental(s) in the system.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation($"Client deleted: {client.FirstName} {client.LastName} (ID: {client.Id})");
            TempData["SuccessMessage"] = $"Client {client.FirstName} {client.LastName} has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
