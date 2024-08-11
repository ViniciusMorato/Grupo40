using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adapter.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Insert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dominio",
                columns: new[] { "Chave", "Descricao", "DominioId" },
                values: new object[,]
                {
                    { "FormaPagamento", "CartaoCredito", 1 },
                    { "FormaPagamento", "CartaoDebito", 2 },
                    { "FormaPagamento", "Dinheiro", 3 },
                    { "FormaPagamento", "Pix", 4 },

                    { "StatusPedido", "Pendente", 1 },
                    { "StatusPedido", "Processando", 2 },
                    { "StatusPedido", "Concluído", 3 },
                    { "StatusPedido", "Cancelado", 4 },

                    { "TipoCartao", "Credito", 1 },
                    { "TipoCartao", "Debito", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dominio",
                keyColumn: "Chave",
                keyValues: new object[] { "FormaPagamento", "StatusPedido", "TipoCartao" });
        }
    }
}
