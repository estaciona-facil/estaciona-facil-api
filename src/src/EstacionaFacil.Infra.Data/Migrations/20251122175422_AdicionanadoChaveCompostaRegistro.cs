using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionaFacil.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionanadoChaveCompostaRegistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registro_EstacionamentoId",
                table: "Registro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registro",
                table: "Registro",
                columns: new[] { "EstacionamentoId", "VeiculoId", "DataEntrada" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registro",
                table: "Registro");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_EstacionamentoId",
                table: "Registro",
                column: "EstacionamentoId");
        }
    }
}
