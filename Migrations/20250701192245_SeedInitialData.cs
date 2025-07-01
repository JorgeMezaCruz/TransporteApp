using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransporteApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Transportes",
                columns: new[] { "Id", "Ancho", "Color", "Largo", "NumeroPasajeros", "NumeroRuedas", "Secuencia", "Tipo" },
                values: new object[,]
                {
                    { 1, 5.4m, "Blanco", 32.5m, 180, 6, 3, "Avion" },
                    { 2, 1.8m, "Rojo", 4.2m, 5, 4, 1, "Automovil" },
                    { 3, 6.1m, "Azul", 40.0m, 200, 8, 6, "Avion" },
                    { 4, 1.75m, "Negro", 4.0m, 4, 4, 2, "Automovil" },
                    { 5, 5.8m, "Gris", 35.3m, 150, 10, 5, "Avion" },
                    { 6, 1.9m, "Verde", 4.5m, 5, 4, 4, "Automovil" }
                });

            migrationBuilder.InsertData(
                table: "Automoviles",
                columns: new[] { "Id", "Conductor" },
                values: new object[,]
                {
                    { 2, "Diana" },
                    { 4, "Sofía" },
                    { 6, "Roberto" }
                });

            migrationBuilder.InsertData(
                table: "Aviones",
                columns: new[] { "Id", "Copiloto", "Piloto" },
                values: new object[,]
                {
                    { 1, "Pedro", "Luis" },
                    { 3, "Marco", "Carlos" },
                    { 5, "Jorge", "Andrea" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Automoviles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Automoviles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Automoviles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Aviones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aviones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Aviones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transportes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transportes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transportes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transportes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transportes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transportes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
