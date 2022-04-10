using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class AddServicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MAXIMO_VENTAS",
                table: "EVENTOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ESTADOS_SERVICIO",
                columns: table => new
                {
                    ID_ESTADO_SERVICIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS_SERVICIO", x => x.ID_ESTADO_SERVICIO);
                });

            migrationBuilder.CreateTable(
                name: "SERVICIOS",
                columns: table => new
                {
                    ID_SERVICIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRECIO = table.Column<double>(type: "float", nullable: false),
                    PRECIO_EN_PUERTA = table.Column<double>(type: "float", nullable: false),
                    VISIBILIDAD = table.Column<double>(type: "float", nullable: false),
                    CANTIDAD = table.Column<int>(type: "int", nullable: false),
                    FECHA_INICIO_VENTA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FECHA_FIN_VENTA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_ESTADO_SERVICIO = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICIOS", x => x.ID_SERVICIO);
                    table.ForeignKey(
                        name: "FK_SERVICIOS_ESTADOS_SERVICIO_ID_ESTADO_SERVICIO",
                        column: x => x.ID_ESTADO_SERVICIO,
                        principalTable: "ESTADOS_SERVICIO",
                        principalColumn: "ID_ESTADO_SERVICIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICIO_EVENTO",
                columns: table => new
                {
                    ID_SERVICIO_EVENTO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_SERVICIO = table.Column<long>(type: "bigint", nullable: false),
                    ID_EVENTO = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICIO_EVENTO", x => x.ID_SERVICIO_EVENTO);
                    table.ForeignKey(
                        name: "FK_SERVICIO_EVENTO_EVENTOS_ID_EVENTO",
                        column: x => x.ID_EVENTO,
                        principalTable: "EVENTOS",
                        principalColumn: "ID_EVENTO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SERVICIO_EVENTO_SERVICIOS_ID_SERVICIO",
                        column: x => x.ID_SERVICIO,
                        principalTable: "SERVICIOS",
                        principalColumn: "ID_SERVICIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIO_EVENTO_ID_EVENTO",
                table: "SERVICIO_EVENTO",
                column: "ID_EVENTO");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIO_EVENTO_ID_SERVICIO",
                table: "SERVICIO_EVENTO",
                column: "ID_SERVICIO");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIOS_ID_ESTADO_SERVICIO",
                table: "SERVICIOS",
                column: "ID_ESTADO_SERVICIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SERVICIO_EVENTO");

            migrationBuilder.DropTable(
                name: "SERVICIOS");

            migrationBuilder.DropTable(
                name: "ESTADOS_SERVICIO");

            migrationBuilder.DropColumn(
                name: "MAXIMO_VENTAS",
                table: "EVENTOS");
        }
    }
}
