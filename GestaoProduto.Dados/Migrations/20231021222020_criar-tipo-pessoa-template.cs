using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    /// <inheritdoc />
    public partial class criartipopessoatemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoasProcesso_TipoPessoaProcesso_TipoPessoaProcessoId",
                table: "PessoasProcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_EmpresaId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoPessoaProcesso");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_PessoasProcesso_TipoPessoaProcessoId",
                table: "PessoasProcesso");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Idempresa",
                table: "Usuario",
                newName: "IdEmpresa");

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoaId",
                table: "PessoasProcesso",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoPessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPessoaTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoPessoa = table.Column<int>(type: "int", nullable: false),
                    IdArquivoProcessoTemplate = table.Column<int>(type: "int", nullable: false),
                    CampoChave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoaTemplate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoasProcesso_TipoPessoaId",
                table: "PessoasProcesso",
                column: "TipoPessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasProcesso_TipoPessoa_TipoPessoaId",
                table: "PessoasProcesso",
                column: "TipoPessoaId",
                principalTable: "TipoPessoa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoasProcesso_TipoPessoa_TipoPessoaId",
                table: "PessoasProcesso");

            migrationBuilder.DropTable(
                name: "TipoPessoa");

            migrationBuilder.DropTable(
                name: "TipoPessoaTemplate");

            migrationBuilder.DropIndex(
                name: "IX_PessoasProcesso_TipoPessoaId",
                table: "PessoasProcesso");

            migrationBuilder.DropColumn(
                name: "TipoPessoaId",
                table: "PessoasProcesso");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "Usuario",
                newName: "Idempresa");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoPessoaProcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoaProcesso", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasProcesso_TipoPessoaProcessoId",
                table: "PessoasProcesso",
                column: "TipoPessoaProcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasProcesso_TipoPessoaProcesso_TipoPessoaProcessoId",
                table: "PessoasProcesso",
                column: "TipoPessoaProcessoId",
                principalTable: "TipoPessoaProcesso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_EmpresaId",
                table: "Usuario",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
