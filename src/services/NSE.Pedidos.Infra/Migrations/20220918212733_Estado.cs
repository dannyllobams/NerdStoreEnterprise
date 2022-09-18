using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Pedidos.Infra.Migrations
{
    public partial class Estado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LograEstadodouro",
                table: "Pedidos",
                newName: "Estado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Pedidos",
                newName: "LograEstadodouro");
        }
    }
}
