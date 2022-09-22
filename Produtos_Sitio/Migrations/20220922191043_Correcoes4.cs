using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos_Sitio.Migrations
{
    public partial class Correcoes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "entregaid",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
