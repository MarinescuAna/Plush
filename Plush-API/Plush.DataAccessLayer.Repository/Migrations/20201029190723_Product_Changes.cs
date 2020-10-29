using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plush.DataAccessLayer.Repository.Migrations
{
    public partial class Product_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProviderDeliveries_ProviderDeliveryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProviderDeliveryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProviderDeliveryID",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostDatetime",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderID",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderID",
                table: "Products",
                column: "ProviderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ProviderID",
                table: "Products",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProviderID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProviderID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PostDatetime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProviderID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProviderDeliveryID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderDeliveryID",
                table: "Products",
                column: "ProviderDeliveryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProviderDeliveries_ProviderDeliveryID",
                table: "Products",
                column: "ProviderDeliveryID",
                principalTable: "ProviderDeliveries",
                principalColumn: "ProviderDeliveryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
