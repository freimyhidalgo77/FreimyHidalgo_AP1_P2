using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreimyHidalgo_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.ArticuloId);
                });

            migrationBuilder.CreateTable(
                name: "Combo",
                columns: table => new
                {
                    ComboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combo", x => x.ComboId);
                });

            migrationBuilder.CreateTable(
                name: "ComboDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ComboDetalles_Articulo_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulo",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboDetalles_Combo_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combo",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articulo",
                columns: new[] { "ArticuloId", "Costo", "Descripcion", "Precio", "existencia" },
                values: new object[,]
                {
                    { 1, 3400m, "Memoria RAM ", 1200m, 55 },
                    { 2, 5000m, "Monitor ", 2000m, 28 },
                    { 3, 4300m, "CPU ", 1250m, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetalles_ArticuloId",
                table: "ComboDetalles",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetalles_ComboId",
                table: "ComboDetalles",
                column: "ComboId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboDetalles");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Combo");
        }
    }
}
