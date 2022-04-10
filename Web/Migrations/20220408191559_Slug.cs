using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class Slug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SLUG",
                table: "NEGOCIOS",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SLUG",
                table: "NEGOCIOS");
        }
    }
}
