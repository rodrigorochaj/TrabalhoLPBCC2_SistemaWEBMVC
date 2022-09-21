using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos_Sitio.Migrations
{
    public partial class PrimeiraCriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<int>(type: "int", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pago = table.Column<int>(type: "int", nullable: false),
                    entregue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    peso = table.Column<float>(type: "real", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(type: "int", nullable: true),
                    produtoid = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantidade = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Vendas_Produtos_produtoid",
                        column: x => x.produtoid,
                        principalTable: "Produtos",
                        principalColumn: "id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_clienteid",
                table: "Vendas",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_produtoid",
                table: "Vendas",
                column: "produtoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntregaVenda");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
