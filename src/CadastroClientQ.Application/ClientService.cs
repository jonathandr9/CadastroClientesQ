using CadastroClientQ.Domain.Adapters;
using CadastroClientQ.Domain.Models;
using CadastroClientQ.Domain.Repositories;
using CadastroClientQ.Domain.Services;

namespace CadastroClientQ.Application
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IIBGEApi _ibgeApi;

        public ClientService(IClientRepository clientRepository,
            IIBGEApi ibgeApi)
        {
            _clientRepository = clientRepository;
            _ibgeApi = ibgeApi;
        }

        public async Task<Client> AddClient(Client client)
        {
            return await _clientRepository.Add(client);
        }

        public async Task<IEnumerable<State>> GetAllStates()
        {
            return await _ibgeApi.GetStates();
        }

        public async Task<IEnumerable<City>> GetCities(int stateId)
        {
            return await _ibgeApi.GetCities(stateId);
        }

        public async Task<IEnumerable<Client>> GetListClients()
        {
            return await _clientRepository.GetAll();
        }
    }
}
