using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_De_Veiculos.Infra.Orm.Migrations
{
    public partial class TbLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TbTaxas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoDeCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDoPlano = table.Column<string>(type: "varchar(300)", nullable: false),
                    valorEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataFinalPrevista = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TbCategoriaVeiculo_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TbCategoriaVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TbCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TbCondutor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbLocacao_TbFuncionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TbFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TbPlanoCobranca_PlanoDeCobrancaId",
                        column: x => x.PlanoDeCobrancaId,
                        principalTable: "TbPlanoCobranca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbLocacao_TbVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TbVeiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbTaxas_LocacaoId",
                table: "TbTaxas",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_CategoriaId",
                table: "TbLocacao",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_ClienteId",
                table: "TbLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_FuncionarioId",
                table: "TbLocacao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_PlanoDeCobrancaId",
                table: "TbLocacao",
                column: "PlanoDeCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_VeiculoId",
                table: "TbLocacao",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTaxas_TbLocacao_LocacaoId",
                table: "TbTaxas",
                column: "LocacaoId",
                principalTable: "TbLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTaxas_TbLocacao_LocacaoId",
                table: "TbTaxas");

            migrationBuilder.DropTable(
                name: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbTaxas_LocacaoId",
                table: "TbTaxas");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TbTaxas");
        }
    }
}
