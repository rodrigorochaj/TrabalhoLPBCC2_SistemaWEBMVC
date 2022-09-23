using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos_Sitio.Migrations
{
    public partial class Correcoes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pago",
                table: "Entregas");

            migrationBuilder.AddColumn<int>(
                name: "pago",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vendaid",
                table: "Entregas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_vendaid",
                table: "Entregas",
                column: "vendaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Vendas_vendaid",
                table: "Entregas",
                column: "vendaid",
                principalTable: "Vendas",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_Vendas_vendaid",
                table: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Entregas_vendaid",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "pago",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "vendaid",
                table: "Entregas");

            migrationBuilder.AddColumn<int>(
                name: "pago",
                table: "Entregas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
