using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    /// <inheritdoc />
    public partial class ajusteentity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPessoaTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPessoaId = table.Column<int>(type: "int", nullable: false),
                    ArquivoProcessoTemplateId = table.Column<int>(type: "int", nullable: false),
                    CampoChave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoaTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoPessoaTemplate_ArquivoProcessotemplate_ArquivoProcessoTemplateId",
                        column: x => x.ArquivoProcessoTemplateId,
                        principalTable: "ArquivoProcessotemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoPessoaTemplate_TipoPessoa_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "TipoPessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoPessoaTemplate_ArquivoProcessoTemplateId",
                table: "TipoPessoaTemplate",
                column: "ArquivoProcessoTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPessoaTemplate_TipoPessoaId",
                table: "TipoPessoaTemplate",
                column: "TipoPessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoPessoaTemplate");
        }
    }
}
