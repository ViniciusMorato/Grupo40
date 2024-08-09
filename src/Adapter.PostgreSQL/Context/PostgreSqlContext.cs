using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapter.PostgreSQL.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) :
            base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
    }
}