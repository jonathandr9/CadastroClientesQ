using CadastroClientQ.Domain.Models;

namespace CadastroClientQ.Domain.Repositories
{
    public interface IClientRepository
    {
        Client Add(Client client);
        Client Update(Client client);
        void Delete(int clientId);
        Client Get(int Id);
        IEnumerable<Client> GetAll();
    }
}
