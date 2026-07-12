using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcesionariaQuiros.Migrations
{
    /// <inheritdoc />
    public partial class CambiarNombreReparacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoReparación",
                table: "Reparaciones",
                newName: "TipoReparacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoReparacion",
                table: "Reparaciones",
                newName: "TipoReparación");
        }
    }
}
