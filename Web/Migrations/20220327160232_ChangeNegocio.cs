using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class ChangeNegocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LOGO",
                table: "NEGOCIOS",
                newName: "URL_LOGO");

            migrationBuilder.RenameColumn(
                name: "IMG_CABECERA",
                table: "NEGOCIOS",
                newName: "URL_IMG_CABECERA");

            migrationBuilder.AddColumn<string>(
                name: "DESCRIPCION",
                table: "NEGOCIOS",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRIPCION",
                table: "NEGOCIOS");

            migrationBuilder.RenameColumn(
                name: "URL_LOGO",
                table: "NEGOCIOS",
                newName: "LOGO");

            migrationBuilder.RenameColumn(
                name: "URL_IMG_CABECERA",
                table: "NEGOCIOS",
                newName: "IMG_CABECERA");
        }
    }
}
