using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBook.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aerolineas",
                columns: table => new
                {
                    IdAerolinea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAerolinea = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerolineas", x => x.IdAerolinea);
                });

            migrationBuilder.CreateTable(
                name: "Pasajeros",
                columns: table => new
                {
                    IdPasajero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajeros", x => x.IdPasajero);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    IdVuelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVuelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AerolineaId = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.IdVuelo);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aerolineas_AerolineaId",
                        column: x => x.AerolineaId,
                        principalTable: "Aerolineas",
                        principalColumn: "IdAerolinea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPasajero = table.Column<int>(type: "int", nullable: false),
                    IdVuelo = table.Column<int>(type: "int", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasajeroIdPasajero = table.Column<int>(type: "int", nullable: true),
                    VueloIdVuelo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Pasajeros_PasajeroIdPasajero",
                        column: x => x.PasajeroIdPasajero,
                        principalTable: "Pasajeros",
                        principalColumn: "IdPasajero");
                    table.ForeignKey(
                        name: "FK_Reservas_Vuelos_VueloIdVuelo",
                        column: x => x.VueloIdVuelo,
                        principalTable: "Vuelos",
                        principalColumn: "IdVuelo");
                });

            migrationBuilder.CreateTable(
                name: "Itinerarios",
                columns: table => new
                {
                    IdItinerario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservaIdReserva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerarios", x => x.IdItinerario);
                    table.ForeignKey(
                        name: "FK_Itinerarios_Reservas_ReservaIdReserva",
                        column: x => x.ReservaIdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itinerarios_ReservaIdReserva",
                table: "Itinerarios",
                column: "ReservaIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PasajeroIdPasajero",
                table: "Reservas",
                column: "PasajeroIdPasajero");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VueloIdVuelo",
                table: "Reservas",
                column: "VueloIdVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itinerarios");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Pasajeros");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Aerolineas");
        }
    }
}
