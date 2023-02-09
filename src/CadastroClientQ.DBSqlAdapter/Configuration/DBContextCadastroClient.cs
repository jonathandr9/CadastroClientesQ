using CadastroClientQ.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CadastroClientQ.DBSqlAdapter.Configuration
{
    public class DBContextCadastroClient : DbContext
    {
        private readonly IConfiguration _configuration;
        public DBContextCadastroClient(
            DbContextOptions<DBContextCadastroClient> options,
            IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Client> Products { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteConnection"));
    }
}
