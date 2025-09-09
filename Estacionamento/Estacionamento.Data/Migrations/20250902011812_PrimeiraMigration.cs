using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.Data.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Cnh = table.Column<long>(type: "BIGINT", nullable: false),
                    Telefone = table.Column<string>(type: "CHAR(13)", nullable: false),
                    Celular = table.Column<string>(type: "CHAR(13)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Marca = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    Modelo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Placa = table.Column<string>(type: "CHAR(8)", nullable: false),
                    ProprietarioId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ProprietarioId",
                table: "Veiculo",
                column: "ProprietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Proprietario");
        }
    }
}
