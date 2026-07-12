using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcesionariaQuiros.Migrations
{
    /// <inheritdoc />
    public partial class vehi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Vehiculos",
                newName: "PrecioVenta");

            migrationBuilder.RenameColumn(
                name: "Anio",
                table: "Vehiculos",
                newName: "ConcesionarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehiculos",
                newName: "VehiculoId");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Combustible",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extras",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Kilometraje",
                table: "Vehiculos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioCompra",
                table: "Vehiculos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TipoVehiculo",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Combustible",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Extras",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Kilometraje",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "PrecioCompra",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "TipoVehiculo",
                table: "Vehiculos");

            migrationBuilder.RenameColumn(
                name: "PrecioVenta",
                table: "Vehiculos",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "ConcesionarioId",
                table: "Vehiculos",
                newName: "Anio");

            migrationBuilder.RenameColumn(
                name: "VehiculoId",
                table: "Vehiculos",
                newName: "Id");
        }
    }
}
