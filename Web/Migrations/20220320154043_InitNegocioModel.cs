using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class InitNegocioModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TIPO_NEGOCIO",
                columns: table => new
                {
                    ID_TIPO_NEGOCIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_NEGOCIO", x => x.ID_TIPO_NEGOCIO);
                });

            migrationBuilder.CreateTable(
                name: "NEGOCIOS",
                columns: table => new
                {
                    ID_NEGOCIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOGO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMG_CABECERA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_TIPO_NEGOCIO = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGOCIOS", x => x.ID_NEGOCIO);
                    table.ForeignKey(
                        name: "FK_NEGOCIOS_TIPO_NEGOCIO_ID_TIPO_NEGOCIO",
                        column: x => x.ID_TIPO_NEGOCIO,
                        principalTable: "TIPO_NEGOCIO",
                        principalColumn: "ID_TIPO_NEGOCIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NEGOCIOS_ID_TIPO_NEGOCIO",
                table: "NEGOCIOS",
                column: "ID_TIPO_NEGOCIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NEGOCIOS");

            migrationBuilder.DropTable(
                name: "TIPO_NEGOCIO");
        }
    }
}
