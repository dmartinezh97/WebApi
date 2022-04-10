using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class QuitarServiciosEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SERVICIO_EVENTO");

            migrationBuilder.AlterColumn<bool>(
                name: "VISIBILIDAD",
                table: "SERVICIOS",
                type: "bit",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<long>(
                name: "ID_EVENTO",
                table: "SERVICIOS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIOS_ID_EVENTO",
                table: "SERVICIOS",
                column: "ID_EVENTO");

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICIOS_EVENTOS_ID_EVENTO",
                table: "SERVICIOS",
                column: "ID_EVENTO",
                principalTable: "EVENTOS",
                principalColumn: "ID_EVENTO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERVICIOS_EVENTOS_ID_EVENTO",
                table: "SERVICIOS");

            migrationBuilder.DropIndex(
                name: "IX_SERVICIOS_ID_EVENTO",
                table: "SERVICIOS");

            migrationBuilder.DropColumn(
                name: "ID_EVENTO",
                table: "SERVICIOS");

            migrationBuilder.AlterColumn<double>(
                name: "VISIBILIDAD",
                table: "SERVICIOS",
                type: "float",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "SERVICIO_EVENTO",
                columns: table => new
                {
                    ID_SERVICIO_EVENTO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_EVENTO = table.Column<long>(type: "bigint", nullable: false),
                    ID_SERVICIO = table.Column<long>(type: "bigint", nullable: false)
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
        }
    }
}
