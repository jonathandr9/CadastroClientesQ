using CadastroClientQ.Domain.Models;

namespace CadastroClientQ.Domain.Adapters
{
    public interface IIBGEApi
    {
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<City>> GetCities(int stateId);
    }
}
