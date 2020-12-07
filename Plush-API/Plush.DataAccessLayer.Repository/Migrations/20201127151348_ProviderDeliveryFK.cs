using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plush.DataAccessLayer.Repository.Migrations
{
    public partial class ProviderDeliveryFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProviderID",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProviderID",
                table: "Products",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderDeliveryID",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderDeliveryID",
                table: "Products",
                column: "ProviderDeliveryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProviderDeliveries_ProviderDeliveryID",
                table: "Products",
                column: "ProviderDeliveryID",
                principalTable: "ProviderDeliveries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Products_ProviderDeliveries_ProviderDeliveryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProviderID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProviderDeliveryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProviderDeliveryID",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProviderID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ProviderID",
                table: "Products",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
