using Microsoft.EntityFrameworkCore.Migrations;

namespace Agoda.HotelManagement.Infrastructure.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "HotelId", "City", "Price", "Room" },
                values: new object[,]
                {
                    { 1, "Bangkok", 1000, "Deluxe" },
                    { 24, "Ashburn", 1400, "Superior" },
                    { 23, "Amsterdam", 5000, "Deluxe" },
                    { 22, "Ashburn", 14000, "Sweet Suite" },
                    { 21, "Ashburn", 7000, "Deluxe" },
                    { 20, "Ashburn", 4444, "Superior" },
                    { 19, "Ashburn", 1000, "Superior" },
                    { 18, "Bangkok", 5300, "Sweet Suite" },
                    { 17, "Ashburn", 2800, "Deluxe" },
                    { 16, "Ashburn", 800, "Superior" },
                    { 15, "Bangkok", 900, "Deluxe" },
                    { 14, "Bangkok", 25000, "Sweet Suite" },
                    { 13, "Amsterdam", 1000, "Superior" },
                    { 12, "Ashburn", 1800, "Deluxe" },
                    { 11, "Bangkok", 60, "Deluxe" },
                    { 10, "Ashburn", 1100, "Superior" },
                    { 9, "Amsterdam", 30000, "Sweet Suite" },
                    { 8, "Bangkok", 2400, "Superior" },
                    { 7, "Ashburn", 1600, "Deluxe" },
                    { 6, "Bangkok", 2000, "Superior" },
                    { 5, "Ashburn", 1200, "Sweet Suite" },
                    { 4, "Amsterdam", 2200, "Deluxe" },
                    { 3, "Ashburn", 1300, "Sweet Suite" },
                    { 2, "Amsterdam", 2000, "Superior" },
                    { 25, "Ashburn", 1900, "Deluxe" },
                    { 26, "Amsterdam", 2300, "Deluxe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
