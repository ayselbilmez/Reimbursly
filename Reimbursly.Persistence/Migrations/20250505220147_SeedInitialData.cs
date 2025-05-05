using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reimbursly.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Iban",
                table: "Employees",
                newName: "IBAN");

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), "Transportation" },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), "Accommodation" },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), "Meal" },
                    { new Guid("a4444444-4444-4444-4444-444444444444"), "Refreshment" },
                    { new Guid("a5555555-5555-5555-5555-555555555555"), "Office Supplies" },
                    { new Guid("a6666666-6666-6666-6666-666666666666"), "Education" },
                    { new Guid("a7777777-7777-7777-7777-777777777777"), "Representation Expenses" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseLocations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-1111-1111-111111111111"), "İstanbul Office" },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), "Ankara Office" },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), "Home Office" },
                    { new Guid("b4444444-4444-4444-4444-444444444444"), "Client Location" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Cash" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Credit Card" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "HierarchyLevel", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "Assistant Specialist" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "Specialist" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "Manager" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 0, "Director" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 0, "CEO" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), 0, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "IBAN", "LastName", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { new Guid("e1111111-1111-1111-1111-111111111111"), "admin@company.com", "Admin", "TR330006100519786457841326", "User", "$2a$11$d5vCSPuaIHefeb3t3oVtzec6RHl.Wc8YdHd7L0m8s4LZUzAibNFmG", "+905555555555", new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("e2222222-2222-2222-2222-222222222222"), "demo@company.com", "Demo", "TR120006200340000005672235", "User", "$2a$11$cv./UrLq398BcXnjRv8QROMaQIuY9D8KxqceJv4jqS.8/4KbIdRIG", "+905544444444", new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "CreatedAt", "Description", "EmployeeId", "LocationId", "PaymentMethodId", "ReceiptPath", "Status" },
                values: new object[,]
                {
                    { new Guid("f1111111-1111-1111-1111-111111111111"), 150m, new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(2920), "Taxi fare to client meeting", new Guid("e2222222-2222-2222-2222-222222222222"), new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("77777777-7777-7777-7777-777777777777"), "uploads/receipts/receipt1.pdf", 0 },
                    { new Guid("f2222222-2222-2222-2222-222222222222"), 850m, new Guid("a2222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(2927), "Hotel for business trip", new Guid("e2222222-2222-2222-2222-222222222222"), new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("88888888-8888-8888-8888-888888888888"), "uploads/receipts/receipt2.pdf", 1 },
                    { new Guid("f3333333-3333-3333-3333-333333333333"), 500m, new Guid("a6666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(2947), "Online course subscription", new Guid("e2222222-2222-2222-2222-222222222222"), new Guid("b3333333-3333-3333-3333-333333333333"), new Guid("77777777-7777-7777-7777-777777777777"), "uploads/receipts/receipt3.pdf", 2 }
                });

            migrationBuilder.InsertData(
                table: "RejectionReasons",
                columns: new[] { "Id", "ApproverId", "ExpenseId", "Reason", "RejectedAt" },
                values: new object[,]
                {
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f3333333-3333-3333-3333-333333333333"), "Missing receipt", new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8644) },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f3333333-3333-3333-3333-333333333333"), "Exceeds budget", new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8648) },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f3333333-3333-3333-3333-333333333333"), "Invalid category", new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8657) },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f3333333-3333-3333-3333-333333333333"), "Insufficient details", new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8660) },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f3333333-3333-3333-3333-333333333333"), "Duplicate entry", new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8663) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: new Guid("a7777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "ExpenseLocations",
                keyColumn: "Id",
                keyValue: new Guid("b4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "ExpenseLocations",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "ExpenseLocations",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: new Guid("a6666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "ExpenseLocations",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.RenameColumn(
                name: "IBAN",
                table: "Employees",
                newName: "Iban");
        }
    }
}
