using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plush.DataAccessLayer.Repository.Migrations
{
    public partial class Bug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Ages = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryID);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageID = table.Column<Guid>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ContactData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AccessToken = table.Column<string>(nullable: true),
                    AccessTokenExp = table.Column<DateTime>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false),
                    ProviderID = table.Column<Guid>(nullable: false),
                    ImageID = table.Column<Guid>(nullable: false),
                    PostDatetime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderDeliveries",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProviderID = table.Column<Guid>(nullable: false),
                    DeliveryID = table.Column<Guid>(nullable: false),
                    Specification = table.Column<string>(nullable: true),
                    DeliveryCompany = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
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
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageID",
                table: "Products",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderID",
                table: "Products",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderDeliveries_DeliveryID",
                table: "ProviderDeliveries",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderDeliveries_ProviderID",
                table: "ProviderDeliveries",
                column: "ProviderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProviderDeliveries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
