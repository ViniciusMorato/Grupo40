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
        public DbSet<UsuarioEndereco> UsuarioEndereco { get; set; } = null!;
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Pedido> Pedido { get; set; } = null!;
        public DbSet<PedidoItem> PedidoItem { get; set; } = null!;
    }
}