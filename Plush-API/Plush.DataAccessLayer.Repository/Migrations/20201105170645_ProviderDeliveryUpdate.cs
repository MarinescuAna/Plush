using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plush.DataAccessLayer.Repository.Migrations
{
    public partial class ProviderDeliveryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderDeliveries",
                table: "ProviderDeliveries");

            migrationBuilder.DropColumn(
                name: "ProviderDeliveryID",
                table: "ProviderDeliveries");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ProviderDeliveries",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderDeliveries",
                table: "ProviderDeliveries",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderDeliveries",
                table: "ProviderDeliveries");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ProviderDeliveries");

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderDeliveryID",
                table: "ProviderDeliveries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderDeliveries",
                table: "ProviderDeliveries",
                column: "ProviderDeliveryID");
        }
    }
}
