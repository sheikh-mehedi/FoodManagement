using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodManagement2.Migrations
{
    public partial class invalid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "Orders");
        }
    }
}
