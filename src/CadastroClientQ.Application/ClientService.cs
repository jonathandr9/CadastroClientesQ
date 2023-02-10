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
            await ValidadeParameters(client);

            return await _clientRepository.Add(client);
        }

        public async Task Delete(int clientId)
        {
            if (await _clientRepository.ClientExists(clientId) == false)
                throw new InvalidOperationException("Client não encontrado na base!");

            await _clientRepository.Delete(clientId);
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

        public async Task<Client> Update(Client client)
        {
            await ValidadeParameters(client);

            if (await _clientRepository.ClientExists(client.Id) == false)
                throw new InvalidOperationException("Client não encontrado na base!");

            return await _clientRepository.Update(client);
        }

        private async Task<bool> ValidadeParameters(Client client)
        {
            if (client.Name == null ||
               client.Age == null ||
               client.Sex == null ||
               client.StateId == null ||
               client.StateDescription == null ||
               client.CityId == null ||
               client.CityDescription == null)
            {
                throw new ArgumentException("Necessário preencher todos os parâmetros do Cliente");
            }

            return true;
        }
    }
}
