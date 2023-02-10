using CadastroClientQ.Domain.Models;

namespace CadastroClientQ.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Client> Add(Client client);
        Task<Client> Update(Client client);
        Task  Delete(int clientId);
        Task<Client> Get(int Id);
        Task<IEnumerable<Client>> GetAll();
        Task<bool> ClientExists(int clientId);
    }
}
