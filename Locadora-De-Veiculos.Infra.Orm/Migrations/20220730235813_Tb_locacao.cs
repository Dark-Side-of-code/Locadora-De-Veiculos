using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_De_Veiculos.Infra.Orm.Migrations
{
    public partial class Tb_locacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId1",
                table: "TbTaxas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinalReal",
                table: "TbLocacao",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "NivelDoTanque",
                table: "TbLocacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QuilometragemDoVeiculo",
                table: "TbLocacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorGasolina",
                table: "TbLocacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "TbLocacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_TbTaxas_LocacaoId1",
                table: "TbTaxas",
                column: "LocacaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTaxas_TbLocacao_LocacaoId1",
                table: "TbTaxas",
                column: "LocacaoId1",
                principalTable: "TbLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTaxas_TbLocacao_LocacaoId1",
                table: "TbTaxas");

            migrationBuilder.DropIndex(
                name: "IX_TbTaxas_LocacaoId1",
                table: "TbTaxas");

            migrationBuilder.DropColumn(
                name: "LocacaoId1",
                table: "TbTaxas");

            migrationBuilder.DropColumn(
                name: "DataFinalReal",
                table: "TbLocacao");

            migrationBuilder.DropColumn(
                name: "NivelDoTanque",
                table: "TbLocacao");

            migrationBuilder.DropColumn(
                name: "QuilometragemDoVeiculo",
                table: "TbLocacao");

            migrationBuilder.DropColumn(
                name: "ValorGasolina",
                table: "TbLocacao");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "TbLocacao");
        }
    }
}
