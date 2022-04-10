using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class UsuarioNegocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO_NEGOCIO",
                columns: table => new
                {
                    ID_USUARIO_NEGOCIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO = table.Column<long>(type: "bigint", nullable: false),
                    ID_NEGOCIO = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_NEGOCIO", x => x.ID_USUARIO_NEGOCIO);
                    table.ForeignKey(
                        name: "FK_USUARIO_NEGOCIO_NEGOCIOS_ID_NEGOCIO",
                        column: x => x.ID_NEGOCIO,
                        principalTable: "NEGOCIOS",
                        principalColumn: "ID_NEGOCIO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_NEGOCIO_USUARIOS_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_NEGOCIO_ID_NEGOCIO",
                table: "USUARIO_NEGOCIO",
                column: "ID_NEGOCIO");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_NEGOCIO_ID_USUARIO",
                table: "USUARIO_NEGOCIO",
                column: "ID_USUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO_NEGOCIO");
        }
    }
}
