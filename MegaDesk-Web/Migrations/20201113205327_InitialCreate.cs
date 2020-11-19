using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk_Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    DeskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    Area = table.Column<int>(nullable: false),
                    AreaCost = table.Column<int>(nullable: false),
                    NumberofDrawers = table.Column<int>(nullable: false),
                    NumberofDrawersCost = table.Column<int>(nullable: false),
                    SurfaceMaterial = table.Column<int>(nullable: false),
                    MaterialCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.DeskID);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    DeskQuoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeskID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Shipping = table.Column<string>(nullable: true),
                    NumDesks = table.Column<int>(nullable: false),
                    ShippingCost = table.Column<float>(nullable: false),
                    NumDeskCost = table.Column<int>(nullable: false),
                    totalCost = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.DeskQuoteID);
                    table.ForeignKey(
                        name: "FK_DeskQuote_Desk_DeskID",
                        column: x => x.DeskID,
                        principalTable: "Desk",
                        principalColumn: "DeskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskID",
                table: "DeskQuote",
                column: "DeskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");

            migrationBuilder.DropTable(
                name: "Desk");
        }
    }
}
