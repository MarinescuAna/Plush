using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plush.DataAccessLayer.Repository.Migrations
{
    public partial class ShoppingFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProviderDeliveries_ProviderDeliveryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProviderID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Users_UserID",
                table: "Wishlists");

            migrationBuilder.DropTable(
                name: "ProviderDeliveries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProviderDeliveryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProviderDeliveryID",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Wishlists",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "UserEmailID",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProviderID",
                table: "Products",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Deliveries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserEmailID");

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    InformationID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.InformationID);
                    table.ForeignKey(
                        name: "FK_Informations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserEmailID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(nullable: false),
                    InformationID = table.Column<Guid>(nullable: false),
                    DeliveryID = table.Column<Guid>(nullable: false),
                    BasketID = table.Column<Guid>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    StatusOrder = table.Column<int>(nullable: false),
                    Payment = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Deliveries_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Deliveries",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Informations_InformationID",
                        column: x => x.InformationID,
                        principalTable: "Informations",
                        principalColumn: "InformationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                    table.ForeignKey(
                        name: "FK_Baskets_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baskets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_OrderId",
                table: "Baskets",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_UserID",
                table: "Informations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryID",
                table: "Orders",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InformationID",
                table: "Orders",
                column: "InformationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ProviderID",
                table: "Products",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Users_UserID",
                table: "Wishlists",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserEmailID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProviderID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Users_UserID",
                table: "Wishlists");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserEmailID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Deliveries");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProviderID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderDeliveryID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserID");

            migrationBuilder.CreateTable(
                name: "ProviderDeliveries",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ProviderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderDeliveries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProviderDeliveries_Deliveries_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Deliveries",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderDeliveries_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderDeliveryID",
                table: "Products",
                column: "ProviderDeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderDeliveries_DeliveryID",
                table: "ProviderDeliveries",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderDeliveries_ProviderID",
                table: "ProviderDeliveries",
                column: "ProviderID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Users_UserID",
                table: "Wishlists",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
