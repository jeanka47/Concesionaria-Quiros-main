using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcesionariaQuiros.Migrations
{
    /// <inheritdoc />
    public partial class CambiarNombreRefaccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreRefacción",
                table: "Refacciones",
                newName: "NombreRefaccion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreRefaccion",
                table: "Refacciones",
                newName: "NombreRefacción");
        }
    }
}
