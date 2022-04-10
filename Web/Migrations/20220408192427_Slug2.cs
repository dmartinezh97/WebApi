using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class Slug2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "NEGOCIOS",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NEGOCIOS_SLUG",
                table: "NEGOCIOS",
                column: "SLUG",
                unique: true,
                filter: "[SLUG] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NEGOCIOS_SLUG",
                table: "NEGOCIOS");

            migrationBuilder.AlterColumn<string>(
                name: "SLUG",
                table: "NEGOCIOS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
