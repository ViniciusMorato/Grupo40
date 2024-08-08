using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Adapter.DataAccessLayer.Context
{
    public class PostgreSqlContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public PostgreSqlContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("AppSettings:connectionString"));
        }
    }
}