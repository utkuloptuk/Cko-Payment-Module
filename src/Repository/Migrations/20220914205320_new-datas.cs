using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class newdatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("0d23ac2f-3a5d-466d-8cc6-f8f3dab296c7"),
                column: "CreationDate",
                value: new DateTime(2020, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("5314362a-5f87-4b38-9a88-1174d5999cc5"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("953a2bdc-7aab-46fa-9364-8858424ca7db"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("f6db198c-8780-4687-b5f6-9aa2530c65eb"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "ProductType", "Quantity", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"), "product4", 40m, 0, 2500, new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9844) },
                    { new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"), "product2", 20m, 3, 50, new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9836) },
                    { new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"), "product1", 10m, 4, 100, new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9830) },
                    { new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"), "product5", 50m, 2, 5, new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9846) },
                    { new Guid("f715b188-178e-4108-bb62-946cddd3270d"), "product3", 30m, 1, 10, new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9842) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f715b188-178e-4108-bb62-946cddd3270d"));

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

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
        }
    }
}
