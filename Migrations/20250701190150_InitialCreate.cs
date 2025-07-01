using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransporteApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Secuencia = table.Column<int>(type: "int", nullable: false),
                    NumeroRuedas = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Largo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ancho = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroPasajeros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Automoviles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Conductor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automoviles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automoviles_Transportes_Id",
                        column: x => x.Id,
                        principalTable: "Transportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aviones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Piloto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Copiloto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aviones_Transportes_Id",
                        column: x => x.Id,
                        principalTable: "Transportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automoviles");

            migrationBuilder.DropTable(
                name: "Aviones");

            migrationBuilder.DropTable(
                name: "Transportes");
        }
    }
}
