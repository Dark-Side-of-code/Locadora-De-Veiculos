using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_De_Veiculos.Infra.Orm.Migrations
{
    public partial class Tabela_veiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(300)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(7)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Tipo_combustivel = table.Column<string>(type: "varchar(100)", nullable: false),
                    Capacidade_tanque = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ano = table.Column<DateTime>(type: "datetime", nullable: false),
                    Km_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    CategoriaDeVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusVeiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbVeiculo_TbCategoriaVeiculo_CategoriaDeVeiculosId",
                        column: x => x.CategoriaDeVeiculosId,
                        principalTable: "TbCategoriaVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbVeiculo_CategoriaDeVeiculosId",
                table: "TbVeiculo",
                column: "CategoriaDeVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbVeiculo");
        }
    }
}
