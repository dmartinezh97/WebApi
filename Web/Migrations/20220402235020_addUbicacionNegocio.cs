using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class addUbicacionNegocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HORA_FIN",
                table: "EVENTOS");

            migrationBuilder.DropColumn(
                name: "HORA_INICIO",
                table: "EVENTOS");

            migrationBuilder.AddColumn<string>(
                name: "UBICACION",
                table: "NEGOCIOS",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UBICACION",
                table: "NEGOCIOS");

            migrationBuilder.AddColumn<string>(
                name: "HORA_FIN",
                table: "EVENTOS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HORA_INICIO",
                table: "EVENTOS",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
