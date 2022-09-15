using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class fixdecimalareas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(10,3)",
                precision: 10,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetPrice",
                table: "Invoices",
                type: "decimal(10,3)",
                precision: 10,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,10)",
                oldPrecision: 10,
                oldScale: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossPrice",
                table: "Invoices",
                type: "decimal(10,3)",
                precision: 10,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,10)",
                oldPrecision: 10,
                oldScale: 10);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("0d23ac2f-3a5d-466d-8cc6-f8f3dab296c7"),
                column: "CreationDate",
                value: new DateTime(2020, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("5314362a-5f87-4b38-9a88-1174d5999cc5"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("953a2bdc-7aab-46fa-9364-8858424ca7db"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9094));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("f6db198c-8780-4687-b5f6-9aa2530c65eb"),
                column: "CreationDate",
                value: new DateTime(2022, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f715b188-178e-4108-bb62-946cddd3270d"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 15, 13, 31, 37, 106, DateTimeKind.Local).AddTicks(9357));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(5,2)",
                precision: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)",
                oldPrecision: 10,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetPrice",
                table: "Invoices",
                type: "decimal(10,10)",
                precision: 10,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)",
                oldPrecision: 10,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossPrice",
                table: "Invoices",
                type: "decimal(10,10)",
                precision: 10,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)",
                oldPrecision: 10,
                oldScale: 3);

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f715b188-178e-4108-bb62-946cddd3270d"),
                column: "UpdatedTime",
                value: new DateTime(2022, 9, 14, 23, 53, 20, 490, DateTimeKind.Local).AddTicks(9842));
        }
    }
}
