using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_De_Veiculos.Infra.Orm.Migrations
{
    public partial class NovoAtributoLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoDoPlano",
                table: "TbLocacao",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDoPlano",
                table: "TbLocacao");
        }
    }
}
