using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_De_Veiculos.Infra.Orm.Migrations
{
    public partial class AllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCategoriaVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategoriaVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(50)", nullable: false),
                    Tipo_Cliente = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Login = table.Column<string>(type: "varchar(50)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    TipoFuncionario = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTaxas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    TipoDeCobraca = table.Column<string>(type: "varchar(50)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTaxas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoDiario_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoDiario_ValorPorKM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoKM_Livre_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoKM_controlado_LimiteDeQuilometragem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoKM_controlado_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoKM_controlado_ValorPorKM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoriaDeVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPlanoCobranca_TbCategoriaVeiculo_CategoriaDeVeiculosId",
                        column: x => x.CategoriaDeVeiculosId,
                        principalTable: "TbCategoriaVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbCondutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(50)", nullable: false),
                    CNH = table.Column<string>(type: "varchar(50)", nullable: false),
                    Validade_CNH = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Edereco = table.Column<string>(type: "varchar(300)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCondutor_TbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbCondutor_ClienteId",
                table: "TbCondutor",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPlanoCobranca_CategoriaDeVeiculosId",
                table: "TbPlanoCobranca",
                column: "CategoriaDeVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbCondutor");

            migrationBuilder.DropTable(
                name: "TbFuncionario");

            migrationBuilder.DropTable(
                name: "TbPlanoCobranca");

            migrationBuilder.DropTable(
                name: "TbTaxas");

            migrationBuilder.DropTable(
                name: "TbCliente");

            migrationBuilder.DropTable(
                name: "TbCategoriaVeiculo");
        }
    }
}
