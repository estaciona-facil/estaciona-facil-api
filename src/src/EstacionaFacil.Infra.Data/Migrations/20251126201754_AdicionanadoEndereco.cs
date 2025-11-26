using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionaFacil.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionanadoEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Estacionamento",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinutosTolerancia",
                table: "Estacionamento",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Logradouro = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamento_EnderecoId",
                table: "Estacionamento",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estacionamento_Endereco_EnderecoId",
                table: "Estacionamento",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estacionamento_Endereco_EnderecoId",
                table: "Estacionamento");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Estacionamento_EnderecoId",
                table: "Estacionamento");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Estacionamento");

            migrationBuilder.DropColumn(
                name: "MinutosTolerancia",
                table: "Estacionamento");
        }
    }
}
