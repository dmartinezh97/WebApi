using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class QuitarServicioTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERVICIOS_ESTADOS_SERVICIO_ID_ESTADO_SERVICIO",
                table: "SERVICIOS");

            migrationBuilder.DropTable(
                name: "ESTADOS_SERVICIO");

            migrationBuilder.DropIndex(
                name: "IX_SERVICIOS_ID_ESTADO_SERVICIO",
                table: "SERVICIOS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIOS_ID_ESTADO_SERVICIO",
                table: "SERVICIOS",
                column: "ID_ESTADO_SERVICIO");

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICIOS_ESTADOS_SERVICIO_ID_ESTADO_SERVICIO",
                table: "SERVICIOS",
                column: "ID_ESTADO_SERVICIO",
                principalTable: "ESTADOS_SERVICIO",
                principalColumn: "ID_ESTADO_SERVICIO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
