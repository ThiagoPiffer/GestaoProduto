using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    /// <inheritdoc />
    public partial class ajusteentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoasProcesso");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "Usuario",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "IdTipoPessoa",
                table: "TipoPessoaTemplate",
                newName: "TipoPessoaId");

            migrationBuilder.RenameColumn(
                name: "IdArquivoProcessoTemplate",
                table: "TipoPessoaTemplate",
                newName: "ArquivoProcessoTemplateId");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "TipoPessoa",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "Pessoas",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "idEmpresa",
                table: "ArquivoProcessotemplate",
                newName: "EmpresaId");

            migrationBuilder.CreateTable(
                name: "PessoaProcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessoId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    TipoPessoaId = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaProcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaProcesso_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaProcesso_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaProcesso_TipoPessoa_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "TipoPessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPessoaTemplate_ArquivoProcessoTemplateId",
                table: "TipoPessoaTemplate",
                column: "ArquivoProcessoTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPessoa_EmpresaId",
                table: "TipoPessoa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArquivoProcessotemplate_EmpresaId",
                table: "ArquivoProcessotemplate",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaProcesso_PessoaId",
                table: "PessoaProcesso",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaProcesso_ProcessoId",
                table: "PessoaProcesso",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaProcesso_TipoPessoaId",
                table: "PessoaProcesso",
                column: "TipoPessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArquivoProcessotemplate_Empresa_EmpresaId",
                table: "ArquivoProcessotemplate",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPessoa_Empresa_EmpresaId",
                table: "TipoPessoa",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPessoaTemplate_ArquivoProcessotemplate_ArquivoProcessoTemplateId",
                table: "TipoPessoaTemplate",
                column: "ArquivoProcessoTemplateId",
                principalTable: "ArquivoProcessotemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_EmpresaId",
                table: "Usuario",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArquivoProcessotemplate_Empresa_EmpresaId",
                table: "ArquivoProcessotemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoPessoa_Empresa_EmpresaId",
                table: "TipoPessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoPessoaTemplate_ArquivoProcessotemplate_ArquivoProcessoTemplateId",
                table: "TipoPessoaTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_EmpresaId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "PessoaProcesso");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_TipoPessoaTemplate_ArquivoProcessoTemplateId",
                table: "TipoPessoaTemplate");

            migrationBuilder.DropIndex(
                name: "IX_TipoPessoa_EmpresaId",
                table: "TipoPessoa");

            migrationBuilder.DropIndex(
                name: "IX_ArquivoProcessotemplate_EmpresaId",
                table: "ArquivoProcessotemplate");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Usuario",
                newName: "IdEmpresa");

            migrationBuilder.RenameColumn(
                name: "TipoPessoaId",
                table: "TipoPessoaTemplate",
                newName: "IdTipoPessoa");

            migrationBuilder.RenameColumn(
                name: "ArquivoProcessoTemplateId",
                table: "TipoPessoaTemplate",
                newName: "IdArquivoProcessoTemplate");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "TipoPessoa",
                newName: "IdEmpresa");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Pessoas",
                newName: "IdEmpresa");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "ArquivoProcessotemplate",
                newName: "idEmpresa");

            migrationBuilder.CreateTable(
                name: "PessoasProcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    ProcessoId = table.Column<int>(type: "int", nullable: false),
                    TipoPessoaId = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    TipoPessoaProcessoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasProcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoasProcesso_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoasProcesso_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoasProcesso_TipoPessoa_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "TipoPessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoasProcesso_PessoaId",
                table: "PessoasProcesso",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasProcesso_ProcessoId",
                table: "PessoasProcesso",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasProcesso_TipoPessoaId",
                table: "PessoasProcesso",
                column: "TipoPessoaId");
        }
    }
}
