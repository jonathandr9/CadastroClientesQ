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

        public Client Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();

            return client;
        }

        public void Delete(int clientId)
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

        public Client Get(int id)
        {
            return _context.Clients.AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.AsNoTracking().ToList();
        }

        public Client Update(Client client)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var clientUpdate = Get(client.Id);

                    clientUpdate.Name = client.Name;
                    clientUpdate.Age = client.Age;
                    clientUpdate.Sex = client.Sex;
                    clientUpdate.State = client.State;
                    clientUpdate.City = client.City;


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
