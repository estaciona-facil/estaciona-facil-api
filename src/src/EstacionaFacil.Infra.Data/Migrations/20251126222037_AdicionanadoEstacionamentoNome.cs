using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionaFacil.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionanadoEstacionamentoNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Estacionamento",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Estacionamento");
        }
    }
}
