using CadastroClientQ.Domain.Models;

namespace CadastroClientQ.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetListClients();
        Task<IEnumerable<State>> GetAllStates();
        Task<IEnumerable<City>> GetCities(int stateId);
        Task<Client> AddClient(Client client);
    }
}
