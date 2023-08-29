using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    public partial class createarquivoproesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Pessoas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "TipoPessoaProcesso",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Produtos",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "PessoasProcesso",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Pessoas",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "GrupoProcessos",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Fornecedores",
                type: "datetime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArquivoProcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtensaoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TamanhoArquivo = table.Column<long>(type: "bigint", nullable: false),
                    ProcessoId = table.Column<int>(type: "int", nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivoProcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArquivoProcesso_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArquivoProcesso_ProcessoId",
                table: "ArquivoProcesso",
                column: "ProcessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArquivoProcesso");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "TipoPessoaProcesso");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "PessoasProcesso");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "GrupoProcessos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Fornecedores");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Pessoas",
                type: "int",
                nullable: true);
        }
    }
}
