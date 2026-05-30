using CarRentalSystem.Entities;
using CarRentalSystem.Entities.Users;
using CarRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly CarRentalContext _context;
        private readonly ILogger<ClientService> _logger;

        public ClientService(CarRentalContext context, ILogger<ClientService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client?> GetClientWithRentalsAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Car!.Model!.Brand)
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Employee)
                .Include(c => c.Rentals!)
                    .ThenInclude(r => r.Payments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Client>> SearchClientsAsync(string? searchString, string? searchType)
        {
            var clients = _context.Clients.AsQueryable();

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

            return await clients.OrderBy(c => c.LastName).ToListAsync();
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Clients
                    .AnyAsync(c => c.Email == email && c.Id != excludeId);
            }

            return await _context.Clients.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> PeselExistsAsync(string pesel, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Clients
                    .AnyAsync(c => c.PESEL == pesel && c.Id != excludeId);
            }

            return await _context.Clients.AnyAsync(c => c.PESEL == pesel);
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New client created: {client.FirstName} {client.LastName} (ID: {client.Id})");
            return client;
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Client updated: {client.FirstName} {client.LastName} (ID: {client.Id})");
            return client;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Rentals)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return false;
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Client deleted: {client.FirstName} {client.LastName} (ID: {client.Id})");
            return true;
        }

        public async Task<bool> CanDeleteClientAsync(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Rentals)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return false;
            }

            return client.Rentals == null || !client.Rentals.Any();
        }
    }
}
