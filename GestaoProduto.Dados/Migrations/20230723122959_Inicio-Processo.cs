using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProduto.Dados.Migrations
{
    public partial class InicioProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidade",
                table: "Produtos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFabricacao",
                table: "Produtos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataPrevista = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValorCausa = table.Column<double>(type: "float", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidade",
                table: "Produtos",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFabricacao",
                table: "Produtos",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
