using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class customerusertypechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Age", "CreationDate", "Email", "LastName", "Name", "TelephoneNumber", "UserType" },
                values: new object[,]
                {
                    { new Guid("0d23ac2f-3a5d-466d-8cc6-f8f3dab296c7"), "new address1", 25, new DateTime(2020, 9, 13, 13, 26, 30, 274, DateTimeKind.Local).AddTicks(6866), "email4@example.com", "lastname1", "veteran", "33333333", 0 },
                    { new Guid("5314362a-5f87-4b38-9a88-1174d5999cc5"), "new address1", 25, new DateTime(2022, 9, 13, 13, 26, 30, 274, DateTimeKind.Local).AddTicks(6859), "email2@example.com", "lastname1", "employee", "22222222", 1 },
                    { new Guid("953a2bdc-7aab-46fa-9364-8858424ca7db"), "new address1", 25, new DateTime(2022, 9, 13, 13, 26, 30, 274, DateTimeKind.Local).AddTicks(6844), "email@example.com", "lastname1", "newbie", "111111111", 0 },
                    { new Guid("f6db198c-8780-4687-b5f6-9aa2530c65eb"), "new address1", 25, new DateTime(2022, 9, 13, 13, 26, 30, 274, DateTimeKind.Local).AddTicks(6863), "email3@example.com", "lastname1", "affiliate", "33333333", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("0d23ac2f-3a5d-466d-8cc6-f8f3dab296c7"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("5314362a-5f87-4b38-9a88-1174d5999cc5"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("953a2bdc-7aab-46fa-9364-8858424ca7db"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("f6db198c-8780-4687-b5f6-9aa2530c65eb"));
        }
    }
}
