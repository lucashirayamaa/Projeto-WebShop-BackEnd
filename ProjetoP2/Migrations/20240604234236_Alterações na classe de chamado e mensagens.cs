using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoP2.Migrations
{
    /// <inheritdoc />
    public partial class Alteraçõesnaclassedechamadoemensagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagems_Chamados_ChamadoId",
                table: "Mensagems");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagems_Usuarios_DestinatarioId",
                table: "Mensagems");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagems_Usuarios_RemetenteId",
                table: "Mensagems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensagems",
                table: "Mensagems");

            migrationBuilder.DropIndex(
                name: "IX_Mensagems_DestinatarioId",
                table: "Mensagems");

            migrationBuilder.DropColumn(
                name: "DestinatarioId",
                table: "Mensagems");

            migrationBuilder.RenameTable(
                name: "Mensagems",
                newName: "Mensagens");

            migrationBuilder.RenameIndex(
                name: "IX_Mensagems_RemetenteId",
                table: "Mensagens",
                newName: "IX_Mensagens_RemetenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Mensagems_ChamadoId",
                table: "Mensagens",
                newName: "IX_Mensagens_ChamadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensagens",
                table: "Mensagens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Chamados_ChamadoId",
                table: "Mensagens",
                column: "ChamadoId",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Usuarios_RemetenteId",
                table: "Mensagens",
                column: "RemetenteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Chamados_ChamadoId",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Usuarios_RemetenteId",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensagens",
                table: "Mensagens");

            migrationBuilder.RenameTable(
                name: "Mensagens",
                newName: "Mensagems");

            migrationBuilder.RenameIndex(
                name: "IX_Mensagens_RemetenteId",
                table: "Mensagems",
                newName: "IX_Mensagems_RemetenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Mensagens_ChamadoId",
                table: "Mensagems",
                newName: "IX_Mensagems_ChamadoId");

            migrationBuilder.AddColumn<int>(
                name: "DestinatarioId",
                table: "Mensagems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensagems",
                table: "Mensagems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagems_DestinatarioId",
                table: "Mensagems",
                column: "DestinatarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagems_Chamados_ChamadoId",
                table: "Mensagems",
                column: "ChamadoId",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagems_Usuarios_DestinatarioId",
                table: "Mensagems",
                column: "DestinatarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagems_Usuarios_RemetenteId",
                table: "Mensagems",
                column: "RemetenteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
