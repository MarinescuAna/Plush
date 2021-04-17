using Microsoft.EntityFrameworkCore.Migrations;

namespace Plush.DataAccessLayer.Repository.Migrations
{
    public partial class RemoveSpecificationsProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Specification",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ages",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specification",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ages",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
