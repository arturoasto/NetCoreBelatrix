using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 40, nullable: false),
                    last_name = table.Column<string>(maxLength: 40, nullable: false),
                    city = table.Column<string>(maxLength: 40, nullable: false),
                    country = table.Column<string>(maxLength: 40, nullable: false),
                    phone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(maxLength: 40, nullable: false),
                    contact_name = table.Column<string>(maxLength: 50, nullable: false),
                    contact_title = table.Column<string>(maxLength: 40, nullable: false),
                    city = table.Column<string>(maxLength: 40, nullable: false),
                    country = table.Column<string>(maxLength: 40, nullable: false),
                    phone = table.Column<string>(maxLength: 30, nullable: false),
                    fax = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_date = table.Column<DateTime>(nullable: false),
                    order_number = table.Column<string>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    total_amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "customer_id",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(maxLength: 50, nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(nullable: false),
                    package = table.Column<string>(maxLength: 30, nullable: false),
                    is_discontinued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "supplier_id",
                        column: x => x.SupplierId,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => x.id);
                    table.ForeignKey(
                        name: "order_id",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "product_id",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "customer_name__idx",
                table: "customer",
                columns: new[] { "last_name", "first_name" });

            migrationBuilder.CreateIndex(
                name: "order__customer_id__idx",
                table: "order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "order__order_date__idx",
                table: "order",
                column: "order_date");

            migrationBuilder.CreateIndex(
                name: "order_item__order_id__idx",
                table: "order_item",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "order_item__product_id__idx",
                table: "order_item",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "product_name__idx",
                table: "product",
                column: "product_name");

            migrationBuilder.CreateIndex(
                name: "product_supplier_id__idx",
                table: "product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "supplier_name__idx",
                table: "supplier",
                column: "company_name");

            migrationBuilder.CreateIndex(
                name: "supplier_country__idx",
                table: "supplier",
                column: "country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
