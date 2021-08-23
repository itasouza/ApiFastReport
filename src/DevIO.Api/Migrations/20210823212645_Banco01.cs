using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Api.Migrations
{
    public partial class Banco01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendasItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendasItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendasItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendasItens_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CreatedAt", "Descricao", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(3556), "Combustivel", null },
                    { 2, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(3565), "Lubrificantes", null },
                    { 3, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(3566), "Diversos", null }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CreatedAt", "Email", "Nome", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(7365), "sofia@mail.com", "Sofia Marli Porto", null },
                    { 2, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(7370), "raimunda@mail.com", "Raimunda Isis Olivia Vieira", null },
                    { 3, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(7372), "oliver@mail.com", "Oliver Arthur da Mota", null }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "CreatedAt", "Email", "Foto", "Nome", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 23, 21, 26, 44, 879, DateTimeKind.Utc).AddTicks(2714), "postocidade@mail.com", "", "Posto de Gasolina Cidade", null });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreatedAt", "Email", "Nome", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(6401), "fernandosilva@mail.com", "Fernando Silva", null },
                    { 2, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(6406), "marcos@mail.com", "Marcos", null },
                    { 3, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(6408), "ellena@mail.com", "Ellena", null },
                    { 4, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(6409), "Rafaela@mail.com", "Rafaela", null },
                    { 5, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(6410), "heloisa@mail.com", "Heloisa", null },
                    { 6, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(6412), "manuella@mail.com", "Manuella", null },
                    { 7, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(6413), "luan@mail.com", "Luan", null }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descricao", "Ean", "Preco", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5101), "Gasolina Aditivada", "9789563530701", 5.50m, null },
                    { 2, 1, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5377), "Gasolina Comum", "9789563530702", 5.10m, null },
                    { 3, 1, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5381), "Alcool Comum", "9789563530703", 4.00m, null },
                    { 4, 1, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5383), "Alcool Aditivado", "9789563530704", 4.15m, null },
                    { 5, 1, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5384), "Diesel", "9789563530705", 3.98m, null },
                    { 6, 2, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5386), "Óleo Lubrificante Motor 20w", "9789563530710", 20.00m, null },
                    { 7, 2, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5387), "Óleo Lubrificante Motor 40w", "9789563530711", 21.00m, null },
                    { 8, 3, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5389), "Água sem Gás", "9789563530720", 2.00m, null },
                    { 9, 3, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(5390), "Água com Gás", "9789563530721", 2.10m, null }
                });

            migrationBuilder.InsertData(
                table: "Vendas",
                columns: new[] { "Id", "ClienteId", "CreatedAt", "DataVenda", "TotalVenda", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(2021, 8, 25, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(8894), new DateTime(2021, 8, 25, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(8757), 200.00m, null },
                    { 1, 2, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(8435), new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(8147), 100.00m, null },
                    { 2, 3, new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(8754), new DateTime(2021, 8, 23, 21, 26, 44, 880, DateTimeKind.Utc).AddTicks(8751), 75.00m, null }
                });

            migrationBuilder.InsertData(
                table: "VendasItens",
                columns: new[] { "Id", "CreatedAt", "ProdutoId", "Quantidade", "TotalProduto", "UpdatedAt", "ValorProduto", "VendaId" },
                values: new object[,]
                {
                    { 4, null, 5, 50.24m, 200.00m, null, 3.98m, 3 },
                    { 1, null, 2, 18.18m, 100.00m, null, 5.50m, 1 },
                    { 2, null, 1, 9.80m, 50.00m, null, 5.10m, 2 },
                    { 3, null, 9, 12m, 25.00m, null, 2.10m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasItens_ProdutoId",
                table: "VendasItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasItens_VendaId",
                table: "VendasItens",
                column: "VendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VendasItens");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
