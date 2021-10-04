using Microsoft.EntityFrameworkCore.Migrations;

namespace TacoTuesday.Migrations
{
    public partial class AddPhotoURLToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Restaurants",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Restaurants");
        }
    }
}
