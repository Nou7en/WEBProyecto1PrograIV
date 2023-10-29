using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEBAPIRestaurante.Migrations
{
    /// <inheritdoc />
    public partial class PrimerosPlatosTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platos",
                columns: new[] { "IdPlato", "Descripcion", "ImagenUrl", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Arroz Frito al estilo Chino muy rico", "", "Chaulafan", 4.5 },
                    { 2, "Arroz y Tallarin la mejor combi", "", "Mixto", 6.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "IdPlato",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "IdPlato",
                keyValue: 2);
        }
    }
}
