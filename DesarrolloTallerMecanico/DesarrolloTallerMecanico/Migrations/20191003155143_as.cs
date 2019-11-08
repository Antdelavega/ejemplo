using Microsoft.EntityFrameworkCore.Migrations;

namespace DesarrolloTallerMecanico.Migrations
{
    public partial class @as : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MecanicoId",
                table: "ServicioMecanico",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServicioMecanico_MecanicoId",
                table: "ServicioMecanico",
                column: "MecanicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioMecanico_Mecanico_MecanicoId",
                table: "ServicioMecanico",
                column: "MecanicoId",
                principalTable: "Mecanico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioMecanico_Mecanico_MecanicoId",
                table: "ServicioMecanico");

            migrationBuilder.DropIndex(
                name: "IX_ServicioMecanico_MecanicoId",
                table: "ServicioMecanico");

            migrationBuilder.DropColumn(
                name: "MecanicoId",
                table: "ServicioMecanico");
        }
    }
}
