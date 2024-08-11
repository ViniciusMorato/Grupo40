using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Adapter.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class FakeCartao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FakeCartao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoCartao = table.Column<int>(type: "integer", nullable: false),
                    NomeNoCartao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Numero = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Vencimento = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    CVV = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeCartao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakeCartao");
        }
    }
}
