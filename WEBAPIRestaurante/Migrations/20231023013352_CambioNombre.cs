using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIRestaurante.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Platos",
                table: "Platos");

            migrationBuilder.RenameTable(
                name: "Platos",
                newName: "Menu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "IdPlato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Platos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platos",
                table: "Platos",
                column: "IdPlato");
        }
    }
}
