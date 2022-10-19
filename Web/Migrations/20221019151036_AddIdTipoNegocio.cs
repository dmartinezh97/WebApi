using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class AddIdTipoNegocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdTipoNegocio",
                table: "Negocios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTipoNegocio",
                table: "Negocios");
        }
    }
}
