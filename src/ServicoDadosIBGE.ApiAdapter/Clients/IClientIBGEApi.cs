using Refit;
using IBGEServicoDados.ApiAdapter.Models;

namespace ServicoDadosIBGE.ApiAdapter.Clients
{
    public interface IClientIBGEApi
    {
        [Get("/localidades/microrregioes")]
        Task<GetMicrorregioesDto> GetMicrorregioes(            
            [AliasAs("orderBy")] string orderBy);

        [Get("/localidades/estados/{state}/distritos")]
        Task<GetMicrorregioesDto> GetDistritos(            
            [AliasAs("state")] string state);
    }
}
