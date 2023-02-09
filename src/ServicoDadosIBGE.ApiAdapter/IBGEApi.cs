using AutoMapper;
using CadastroClientQ.Domain.Adapters;
using CadastroClientQ.Domain.Models;
using ServicoDadosIBGE.ApiAdapter.Clients;

namespace IBGEServicoDados.ApiAdapter
{
    public class IBGEApi : IIBGEApi
    {
        private readonly IClientIBGEApi _clientIBGEApi;
        private readonly IMapper _mapper;

        public IBGEApi(IClientIBGEApi clientIBGEApi,
            IMapper mapper)
        {
            _clientIBGEApi = clientIBGEApi;
            _mapper = mapper;
        }

        public async Task<IEnumerable<City>> GetCities(int stateId)
        {
            try
            {
                var returnApi = await _clientIBGEApi.GetCitites(stateId, "nome");

                var returnOfMethod = _mapper.Map<IEnumerable<City>>(returnApi);

                return returnOfMethod;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            try
            {
                var returnApi = await _clientIBGEApi.GetStates("nome");

                var returnOfMethod = _mapper.Map<IEnumerable<State>>(returnApi);

                return returnOfMethod;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
