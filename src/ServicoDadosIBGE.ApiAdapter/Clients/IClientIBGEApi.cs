using Refit;
using IBGEServicoDados.ApiAdapter.Models;

namespace ServicoDadosIBGE.ApiAdapter.Clients
{
    public interface IClientIBGEApi
    {
        [Get("/localidades/estados")]
        Task<GetStatesDto> GetStates(            
            [AliasAs("orderBy")] string orderBy);

        [Get("/localidades/estados/{state}/distritos")]
        Task<GetStatesDto> GetCitites(            
            [AliasAs("state")] int stateId);
    }
}
