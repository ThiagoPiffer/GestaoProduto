using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    /// <inheritdoc />
    public partial class eventoprocessostatuspersonalizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventoStatusPersonalizado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MensagemNotificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidaCondicao = table.Column<bool>(type: "bit", nullable: false),
                    MaiorQue = table.Column<bool>(type: "bit", nullable: false),
                    MenorQue = table.Column<bool>(type: "bit", nullable: false),
                    IgualA = table.Column<bool>(type: "bit", nullable: false),
                    ValorControle = table.Column<int>(type: "int", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoStatusPersonalizado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoStatusPersonalizado_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessoStatusPersonalizado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MensagemNotificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidaCondicao = table.Column<bool>(type: "bit", nullable: false),
                    MaiorQue = table.Column<bool>(type: "bit", nullable: false),
                    MenorQue = table.Column<bool>(type: "bit", nullable: false),
                    IgualA = table.Column<bool>(type: "bit", nullable: false),
                    ValorControle = table.Column<int>(type: "int", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessoStatusPersonalizado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessoStatusPersonalizado_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventoStatusPersonalizado_EmpresaId",
                table: "EventoStatusPersonalizado",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessoStatusPersonalizado_EmpresaId",
                table: "ProcessoStatusPersonalizado",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoStatusPersonalizado");

            migrationBuilder.DropTable(
                name: "ProcessoStatusPersonalizado");
        }
    }
}
