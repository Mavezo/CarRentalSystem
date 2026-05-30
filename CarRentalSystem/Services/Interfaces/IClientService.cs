using CarRentalSystem.Entities.Users;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task<Client?> GetClientWithRentalsAsync(int id);
        Task<List<Client>> SearchClientsAsync(string? searchString, string? searchType);
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);
        Task<bool> PeselExistsAsync(string pesel, int? excludeId = null);
        Task<Client> CreateClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
        Task<bool> CanDeleteClientAsync(int id);
    }
}
