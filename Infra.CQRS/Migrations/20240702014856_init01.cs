using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Data.CQRS.Migrations
{
    /// <inheritdoc />
    public partial class init01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoBarra = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValue: new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(457)),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QtdEstoque = table.Column<int>(type: "int", precision: 9, nullable: true, defaultValue: 0),
                    EstoqueMinimo = table.Column<int>(type: "int", precision: 9, nullable: true, defaultValue: 0),
                    EstoqueMaximo = table.Column<int>(type: "int", precision: 9, nullable: true, defaultValue: 0),
                    SaldoAnterior = table.Column<int>(type: "int", precision: 9, nullable: true, defaultValue: 0),
                    Localizacao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0.0m),
                    DtCreate = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValue: new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(5736)),
                    DtUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValue: new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(6388))
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.EstoqueId);
                    table.ForeignKey(
                        name: "FK_Estoque_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "ProdutoId", "CodigoBarra", "DataAtualizacao", "DataCriacao", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "123456", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1336), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1331), "Descrição do Produto 1", "Produto 1" },
                    { 2, "654321", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1355), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1354), "Descrição do Produto 2", "Produto 2" },
                    { 3, "789012", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1360), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1359), "Descrição do Produto 3", "Produto 3" },
                    { 4, "345678", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1364), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1363), "Descrição do Produto 4", "Produto 4" },
                    { 5, "901234", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1368), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1367), "Descrição do Produto 5", "Produto 5" },
                    { 6, "567890", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1371), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1370), "Descrição do Produto 6", "Produto 6" },
                    { 7, "234567", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1374), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1374), "Descrição do Produto 7", "Produto 7" },
                    { 8, "890123", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1378), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1377), "Descrição do Produto 8", "Produto 8" },
                    { 9, "456789", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1381), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1380), "Descrição do Produto 9", "Produto 9" },
                    { 10, "012345", new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1384), new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(1383), "Descrição do Produto 10", "Produto 10" }
                });

            migrationBuilder.InsertData(
                table: "Estoque",
                columns: new[] { "EstoqueId", "DtCreate", "EstoqueMaximo", "EstoqueMinimo", "Localizacao", "ProdutoId", "QtdEstoque", "SaldoAnterior", "ValorUnitario" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(9048), 200, 10, "A1", 1, 100, 90, 50.0m },
                    { 2, new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(9083), 250, 15, "A2", 2, 150, 140, 55.0m },
                    { 3, new DateTime(2024, 7, 2, 1, 48, 56, 223, DateTimeKind.Utc).AddTicks(9090), 300, 20, "A3", 3, 200, 190, 60.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
