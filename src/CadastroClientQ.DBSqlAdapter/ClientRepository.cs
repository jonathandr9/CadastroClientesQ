using CadastroClientQ.DBSqlAdapter.Configuration;
using CadastroClientQ.Domain.Models;
using CadastroClientQ.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientQ.DBSqlAdapter
{
    public class ClientRepository : IClientRepository
    {
        private readonly DBContextCadastroClient _context;

        public ClientRepository(DBContextCadastroClient context)
        {
            _context = context;
        }

        public async Task<Client> Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();

            return client;
        }

        public async Task Delete(int clientId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw($@"
                            DELETE Clients
                            WHERE Id = {clientId}");

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException(ex.Message);
                }
            }
        }

        public async Task<Client> Get(int id)
        {
            return _context.Clients.AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return _context.Clients.AsNoTracking().ToList();
        }

        public async Task<Client> Update(Client client)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var clientUpdate = await Get(client.Id);

                    clientUpdate.Name = client.Name;
                    clientUpdate.Age = client.Age;
                    clientUpdate.Sex = client.Sex;
                    clientUpdate.StateId = client.StateId;
                    clientUpdate.StateDescription = client.StateDescription;
                    clientUpdate.CityId = client.CityId;
                    clientUpdate.CityDescription = client.CityDescription;


                    _context.Clients.Update(clientUpdate);
                    _context.SaveChanges();

                    transaction.Commit();

                    return clientUpdate;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException(ex.Message);
                }
            }
        }
    }
}
