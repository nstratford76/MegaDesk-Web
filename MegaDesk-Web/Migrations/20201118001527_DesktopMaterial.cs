using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk_Web.Migrations
{
    public partial class DesktopMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialCost",
                table: "Desk");

            migrationBuilder.DropColumn(
                name: "SurfaceMaterial",
                table: "Desk");

            migrationBuilder.AddColumn<int>(
                name: "SurfaceMaterialDesktopMaterialID",
                table: "Desk",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DesktopMaterial",
                columns: table => new
                {
                    DesktopMaterialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesktopMaterial", x => x.DesktopMaterialID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desk_SurfaceMaterialDesktopMaterialID",
                table: "Desk",
                column: "SurfaceMaterialDesktopMaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Desk_DesktopMaterial_SurfaceMaterialDesktopMaterialID",
                table: "Desk",
                column: "SurfaceMaterialDesktopMaterialID",
                principalTable: "DesktopMaterial",
                principalColumn: "DesktopMaterialID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desk_DesktopMaterial_SurfaceMaterialDesktopMaterialID",
                table: "Desk");

            migrationBuilder.DropTable(
                name: "DesktopMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Desk_SurfaceMaterialDesktopMaterialID",
                table: "Desk");

            migrationBuilder.DropColumn(
                name: "SurfaceMaterialDesktopMaterialID",
                table: "Desk");

            migrationBuilder.AddColumn<int>(
                name: "MaterialCost",
                table: "Desk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurfaceMaterial",
                table: "Desk",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
