using Refit;
using IBGEServicoDados.ApiAdapter.Models;

namespace ServicoDadosIBGE.ApiAdapter.Clients
{
    public interface IClientIBGEApi
    {
        [Get("/localidades/estados")]
        Task<IEnumerable<GetStatesDto>> GetStates(            
            [AliasAs("orderBy")] string orderBy);

        [Get("/localidades/estados/{state}/distritos")]
        Task<IEnumerable<GetCitiesDto>> GetCitites(            
            [AliasAs("state")] int stateId,
            [AliasAs("orderBy")] string orderBy);
    }
}
