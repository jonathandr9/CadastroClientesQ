using CadastroClientQ.Domain.Adapters;
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



    }
}
