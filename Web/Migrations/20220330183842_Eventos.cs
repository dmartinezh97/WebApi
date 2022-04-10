using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class Eventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO_NEGOCIO");

            migrationBuilder.CreateTable(
                name: "EVENTOS",
                columns: table => new
                {
                    ID_EVENTO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NEGOCIO = table.Column<long>(type: "bigint", nullable: false),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_INICIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FECHA_FIN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HORA_INICIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HORA_FIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL_IMG_CABECERA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FECHA_MODIFICACION = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTOS", x => x.ID_EVENTO);
                    table.ForeignKey(
                        name: "FK_EVENTOS_NEGOCIOS_ID_NEGOCIO",
                        column: x => x.ID_NEGOCIO,
                        principalTable: "NEGOCIOS",
                        principalColumn: "ID_NEGOCIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NEGOCIO_USUARIO",
                columns: table => new
                {
                    ID_NEGOCIO_USUARIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO = table.Column<long>(type: "bigint", nullable: false),
                    ID_NEGOCIO = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGOCIO_USUARIO", x => x.ID_NEGOCIO_USUARIO);
                    table.ForeignKey(
                        name: "FK_NEGOCIO_USUARIO_NEGOCIOS_ID_NEGOCIO",
                        column: x => x.ID_NEGOCIO,
                        principalTable: "NEGOCIOS",
                        principalColumn: "ID_NEGOCIO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NEGOCIO_USUARIO_USUARIOS_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EVENTOS_ID_NEGOCIO",
                table: "EVENTOS",
                column: "ID_NEGOCIO");

            migrationBuilder.CreateIndex(
                name: "IX_NEGOCIO_USUARIO_ID_NEGOCIO",
                table: "NEGOCIO_USUARIO",
                column: "ID_NEGOCIO");

            migrationBuilder.CreateIndex(
                name: "IX_NEGOCIO_USUARIO_ID_USUARIO",
                table: "NEGOCIO_USUARIO",
                column: "ID_USUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVENTOS");

            migrationBuilder.DropTable(
                name: "NEGOCIO_USUARIO");

            migrationBuilder.CreateTable(
                name: "USUARIO_NEGOCIO",
                columns: table => new
                {
                    ID_USUARIO_NEGOCIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NEGOCIO = table.Column<long>(type: "bigint", nullable: false),
                    ID_USUARIO = table.Column<long>(type: "bigint", nullable: false)
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
    }
}
