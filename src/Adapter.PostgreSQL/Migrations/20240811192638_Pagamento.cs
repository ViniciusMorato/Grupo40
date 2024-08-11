using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Adapter.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Pagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartaoCredito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PessoaId = table.Column<int>(type: "integer", nullable: false),
                    TipoCartao = table.Column<int>(type: "integer", nullable: false),
                    NomeNoCartao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Numero = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Vencimento = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    CVV = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartaoCredito_Usuarios_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dominio",
                columns: table => new
                {
                    Chave = table.Column<string>(type: "text", nullable: false),
                    DominioId = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dominio", x => new { x.Chave, x.DominioId });
                });

            migrationBuilder.CreateTable(
                name: "PedidoCartaoCredito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<int>(type: "integer", nullable: false),
                    CartaoCreditoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoCartaoCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoCartaoCredito_CartaoCredito_CartaoCreditoId",
                        column: x => x.CartaoCreditoId,
                        principalTable: "CartaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoCartaoCredito_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCredito_PessoaId",
                table: "CartaoCredito",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCartaoCredito_CartaoCreditoId",
                table: "PedidoCartaoCredito",
                column: "CartaoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCartaoCredito_PedidoId",
                table: "PedidoCartaoCredito",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dominio");

            migrationBuilder.DropTable(
                name: "PedidoCartaoCredito");

            migrationBuilder.DropTable(
                name: "CartaoCredito");
        }
    }
}
