using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos_Sitio.Migrations
{
    public partial class Correcoes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntregaVenda");

            migrationBuilder.AddColumn<int>(
                name: "entregaid",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "apelido",
                table: "Usuarios",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "quantidade",
                table: "Produtos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_entregaid",
                table: "Vendas",
                column: "entregaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Entregas_entregaid",
                table: "Vendas",
                column: "entregaid",
                principalTable: "Entregas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Entregas_entregaid",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_entregaid",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "entregaid",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "apelido",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "EntregaVenda",
                columns: table => new
                {
                    entregaid = table.Column<int>(type: "int", nullable: false),
                    vendasid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregaVenda", x => new { x.entregaid, x.vendasid });
                    table.ForeignKey(
                        name: "FK_EntregaVenda_Entregas_entregaid",
                        column: x => x.entregaid,
                        principalTable: "Entregas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntregaVenda_Vendas_vendasid",
                        column: x => x.vendasid,
                        principalTable: "Vendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaVenda_vendasid",
                table: "EntregaVenda",
                column: "vendasid");
        }
    }
}
