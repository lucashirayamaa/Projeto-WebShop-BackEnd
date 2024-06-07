using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoP2.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandotabeladeMensagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Usuarios_RemetenteId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Conteudo",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Destinatario",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Chamados");

            migrationBuilder.RenameColumn(
                name: "RemetenteId",
                table: "Chamados",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Chamados_RemetenteId",
                table: "Chamados",
                newName: "IX_Chamados_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Assunto",
                table: "Chamados",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Chamados",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Mensagems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChamadoId = table.Column<int>(type: "int", nullable: false),
                    RemetenteId = table.Column<int>(type: "int", nullable: false),
                    DestinatarioId = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagems_Chamados_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "Chamados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensagems_Usuarios_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensagems_Usuarios_RemetenteId",
                        column: x => x.RemetenteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagems_ChamadoId",
                table: "Mensagems",
                column: "ChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagems_DestinatarioId",
                table: "Mensagems",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagems_RemetenteId",
                table: "Mensagems",
                column: "RemetenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioId",
                table: "Chamados",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioId",
                table: "Chamados");

            migrationBuilder.DropTable(
                name: "Mensagems");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Chamados");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Chamados",
                newName: "RemetenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Chamados_UsuarioId",
                table: "Chamados",
                newName: "IX_Chamados_RemetenteId");

            migrationBuilder.AlterColumn<string>(
                name: "Assunto",
                table: "Chamados",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Conteudo",
                table: "Chamados",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Destinatario",
                table: "Chamados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Chamados",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Chamados",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Usuarios_RemetenteId",
                table: "Chamados",
                column: "RemetenteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
