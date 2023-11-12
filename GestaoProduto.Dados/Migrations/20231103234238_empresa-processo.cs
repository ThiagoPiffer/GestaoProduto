using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    /// <inheritdoc />
    public partial class empresaprocesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Processo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "GrupoProcesso",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Processo_EmpresaId",
                table: "Processo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoProcesso_EmpresaId",
                table: "GrupoProcesso",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoProcesso_Empresa_EmpresaId",
                table: "GrupoProcesso",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Empresa_EmpresaId",
                table: "Processo",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoProcesso_Empresa_EmpresaId",
                table: "GrupoProcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Empresa_EmpresaId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_EmpresaId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_GrupoProcesso_EmpresaId",
                table: "GrupoProcesso");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "GrupoProcesso");
        }
    }
}
