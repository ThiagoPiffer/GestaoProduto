using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    /// <inheritdoc />
    public partial class ajusteentity4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArquivoProcesso_Processos_ProcessoId",
                table: "ArquivoProcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaProcesso_Processos_ProcessoId",
                table: "PessoaProcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Processos_GrupoProcessos_GrupoProcessoId",
                table: "Processos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processos",
                table: "Processos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoProcessos",
                table: "GrupoProcessos");

            migrationBuilder.RenameTable(
                name: "Processos",
                newName: "Processo");

            migrationBuilder.RenameTable(
                name: "GrupoProcessos",
                newName: "GrupoProcesso");

            migrationBuilder.RenameIndex(
                name: "IX_Processos_GrupoProcessoId",
                table: "Processo",
                newName: "IX_Processo_GrupoProcessoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processo",
                table: "Processo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoProcesso",
                table: "GrupoProcesso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArquivoProcesso_Processo_ProcessoId",
                table: "ArquivoProcesso",
                column: "ProcessoId",
                principalTable: "Processo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaProcesso_Processo_ProcessoId",
                table: "PessoaProcesso",
                column: "ProcessoId",
                principalTable: "Processo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_GrupoProcesso_GrupoProcessoId",
                table: "Processo",
                column: "GrupoProcessoId",
                principalTable: "GrupoProcesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArquivoProcesso_Processo_ProcessoId",
                table: "ArquivoProcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaProcesso_Processo_ProcessoId",
                table: "PessoaProcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_GrupoProcesso_GrupoProcessoId",
                table: "Processo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processo",
                table: "Processo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoProcesso",
                table: "GrupoProcesso");

            migrationBuilder.RenameTable(
                name: "Processo",
                newName: "Processos");

            migrationBuilder.RenameTable(
                name: "GrupoProcesso",
                newName: "GrupoProcessos");

            migrationBuilder.RenameIndex(
                name: "IX_Processo_GrupoProcessoId",
                table: "Processos",
                newName: "IX_Processos_GrupoProcessoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processos",
                table: "Processos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoProcessos",
                table: "GrupoProcessos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArquivoProcesso_Processos_ProcessoId",
                table: "ArquivoProcesso",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaProcesso_Processos_ProcessoId",
                table: "PessoaProcesso",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_GrupoProcessos_GrupoProcessoId",
                table: "Processos",
                column: "GrupoProcessoId",
                principalTable: "GrupoProcessos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
