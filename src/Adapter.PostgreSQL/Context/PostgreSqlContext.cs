using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Adapter.PostgreSQL.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando a relação um-para-muitos
            modelBuilder.Entity<Pedido>()
                .HasMany(c => c.PedidoItens)
                .WithOne(p => p.Pedido)
                .HasForeignKey(p => p.PedidoId);
            modelBuilder.Entity<Dominio>()
                .HasKey(d => new { d.Chave, d.DominioId});
        }

        public DbSet<Dominio> Dominio { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<UsuarioEndereco> UsuarioEndereco { get; set; } = null!;
        public DbSet<CartaoCredito> CartaoCredito { get; set; } = null!;
        public DbSet<PedidoCartaoCredito> PedidoCartaoCredito { get; set; } = null!;
        public DbSet<PedidoPix> PedidoPix { get; set; } = null!;
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Pedido> Pedido { get; set; } = null!;
        public DbSet<PedidoItem> PedidoItem { get; set; } = null!;
    }
}