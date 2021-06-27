using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerRowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 20, nullable: false),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerRowId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorRowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<string>(nullable: false),
                    VendorName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorRowId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderRowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(nullable: false),
                    ProductRowId = table.Column<int>(nullable: false),
                    CustomerRowId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderRowId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerRowId",
                        column: x => x.CustomerRowId,
                        principalTable: "Customers",
                        principalColumn: "CustomerRowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductRowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 20, nullable: false),
                    CategoryName = table.Column<string>(maxLength: 20, nullable: false),
                    UnitPrice = table.Column<int>(nullable: false),
                    VendorRowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductRowId);
                    table.ForeignKey(
                        name: "FK_Products_Vendors_VendorRowId",
                        column: x => x.VendorRowId,
                        principalTable: "Vendors",
                        principalColumn: "VendorRowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerRowId",
                table: "Orders",
                column: "CustomerRowId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderId",
                table: "Orders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorRowId",
                table: "Products",
                column: "VendorRowId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorId",
                table: "Vendors",
                column: "VendorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
