using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Users;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: Clients
        public async Task<IActionResult> Index(string searchString, string searchType)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["SearchType"] = searchType;

            var clients = await _clientService.SearchClientsAsync(searchString, searchType);

            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientService.GetClientWithRentalsAsync(id.Value);

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
        public async Task<IActionResult> Create(ClientFormModel formModel)
        {
            var client = formModel.ToEntity();

            if (ModelState.IsValid)
            {
                if (await _clientService.EmailExistsAsync(client.Email))
                {
                    ModelState.AddModelError("Email", "A client with this email already exists.");
                    return View(client);
                }

                if (await _clientService.PeselExistsAsync(client.PESEL))
                {
                    ModelState.AddModelError("PESEL", "A client with this PESEL already exists.");
                    return View(client);
                }

                await _clientService.CreateClientAsync(client);
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

            var client = await _clientService.GetClientByIdAsync(id.Value);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientFormModel formModel)
        {
            var client = formModel.ToEntity();

            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _clientService.EmailExistsAsync(client.Email, id))
                {
                    ModelState.AddModelError("Email", "A client with this email already exists.");
                    return View(client);
                }

                if (await _clientService.PeselExistsAsync(client.PESEL, id))
                {
                    ModelState.AddModelError("PESEL", "A client with this PESEL already exists.");
                    return View(client);
                }

                await _clientService.UpdateClientAsync(client);
                TempData["SuccessMessage"] = $"Client {client.FirstName} {client.LastName} has been successfully updated.";
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

            var client = await _clientService.GetClientWithRentalsAsync(id.Value);
            
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
            var client = await _clientService.GetClientByIdAsync(id);
            
            if (client == null)
            {
                return NotFound();
            }

            if (!await _clientService.CanDeleteClientAsync(id))
            {
                TempData["ErrorMessage"] = $"Cannot delete client {client.FirstName} {client.LastName} because they have rental(s) in the system.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            await _clientService.DeleteClientAsync(id);
            TempData["SuccessMessage"] = $"Client {client.FirstName} {client.LastName} has been successfully deleted.";
            
            return RedirectToAction(nameof(Index));
        }
    }
}
