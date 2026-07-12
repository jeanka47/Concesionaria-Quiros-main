using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcesionariaQuiros.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Personas",
                newName: "Telefono");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Personas",
                newName: "telefono");
        }
    }
}
