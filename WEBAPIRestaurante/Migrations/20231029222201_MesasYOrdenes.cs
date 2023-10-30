using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEBAPIRestaurante.Migrations
{
    /// <inheritdoc />
    public partial class MesasYOrdenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    IdMesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Orden = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.IdMesa);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id_Orden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMesa = table.Column<int>(type: "int", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id_Orden);
                });

            migrationBuilder.CreateTable(
                name: "PlatosOrdenados",
                columns: table => new
                {
                    Id_PlatoOrdenado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlato = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Entregado = table.Column<bool>(type: "bit", nullable: false),
                    platoIdPlato = table.Column<int>(type: "int", nullable: false),
                    OrdenId_Orden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatosOrdenados", x => x.Id_PlatoOrdenado);
                    table.ForeignKey(
                        name: "FK_PlatosOrdenados_Menu_platoIdPlato",
                        column: x => x.platoIdPlato,
                        principalTable: "Menu",
                        principalColumn: "IdPlato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatosOrdenados_Ordenes_OrdenId_Orden",
                        column: x => x.OrdenId_Orden,
                        principalTable: "Ordenes",
                        principalColumn: "Id_Orden");
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "IdMesa", "Estado", "Id_Orden" },
                values: new object[,]
                {
                    { 1, false, 0 },
                    { 2, false, 0 },
                    { 3, false, 0 },
                    { 4, false, 0 },
                    { 5, false, 0 },
                    { 6, false, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatosOrdenados_OrdenId_Orden",
                table: "PlatosOrdenados",
                column: "OrdenId_Orden");

            migrationBuilder.CreateIndex(
                name: "IX_PlatosOrdenados_platoIdPlato",
                table: "PlatosOrdenados",
                column: "platoIdPlato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "PlatosOrdenados");

            migrationBuilder.DropTable(
                name: "Ordenes");
        }
    }
}
