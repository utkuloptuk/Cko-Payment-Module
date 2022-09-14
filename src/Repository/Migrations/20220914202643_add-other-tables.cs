using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addothertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "decimal(10,10)", precision: 10, scale: 10, nullable: false),
                    NetPrice = table.Column<decimal>(type: "decimal(10,10)", precision: 10, scale: 10, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("0d23ac2f-3a5d-466d-8cc6-f8f3dab296c7"),
                column: "CreationDate",
                value: new DateTime(2020, 9, 14, 23, 26, 43, 310, DateTimeKind.Local).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5314362a-5f87-4b38-9a88-1174d5999cc5"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 14, 23, 26, 43, 310, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("953a2bdc-7aab-46fa-9364-8858424ca7db"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 14, 23, 26, 43, 310, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f6db198c-8780-4687-b5f6-9aa2530c65eb"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 14, 23, 26, 43, 310, DateTimeKind.Local).AddTicks(8665));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("0d23ac2f-3a5d-466d-8cc6-f8f3dab296c7"),
                column: "CreationDate",
                value: new DateTime(2020, 9, 13, 13, 26, 30, 274, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("5314362a-5f87-4b38-9a88-1174d5999cc5"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 13, 13, 26, 30, 274, DateTimeKind.Local).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("953a2bdc-7aab-46fa-9364-8858424ca7db"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 13, 13, 26, 30, 274, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("f6db198c-8780-4687-b5f6-9aa2530c65eb"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 13, 13, 26, 30, 274, DateTimeKind.Local).AddTicks(6863));
        }
    }
}
