using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    /// <inheritdoc />
    public partial class empresanotnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Processo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "GrupoProcesso",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
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

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Processo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "GrupoProcesso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
