using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos_Sitio.Migrations
{
    public partial class Anotacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_clienteid",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_produtoid",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "produtoid",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Produtos",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Clientes",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "endereco",
                table: "Clientes",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_clienteid",
                table: "Vendas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_produtoid",
                table: "Vendas",
                column: "produtoid",
                principalTable: "Produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_clienteid",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_produtoid",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "produtoid",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "endereco",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_clienteid",
                table: "Vendas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_produtoid",
                table: "Vendas",
                column: "produtoid",
                principalTable: "Produtos",
                principalColumn: "id");
        }
    }
}
