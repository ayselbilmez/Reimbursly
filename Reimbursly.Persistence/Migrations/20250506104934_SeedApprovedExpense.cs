using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reimbursly.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedApprovedExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedById",
                table: "Expenses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"),
                column: "PasswordHash",
                value: "$2a$11$D98K3R3iFiKeI7xq1QPX5Ox/UBVdDgPqbqppw4ZM5I.qkza2DmE.K");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"),
                column: "PasswordHash",
                value: "$2a$11$sneqoM59TqH7Y5dxG4pmAuvQhhXh8pG6ngp1Y8Ko/rUV2WeRFO.Ki");

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"),
                columns: new[] { "ApprovedById", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 5, 6, 10, 49, 34, 210, DateTimeKind.Utc).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f2222222-2222-2222-2222-222222222222"),
                columns: new[] { "ApprovedById", "CreatedAt" },
                values: new object[] { new Guid("e1111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 1, 10, 49, 34, 210, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f3333333-3333-3333-3333-333333333333"),
                columns: new[] { "ApprovedById", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 5, 6, 10, 49, 34, 210, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 6, 10, 49, 34, 210, DateTimeKind.Utc).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 6, 10, 49, 34, 210, DateTimeKind.Utc).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 6, 10, 49, 34, 210, DateTimeKind.Utc).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 6, 10, 49, 34, 210, DateTimeKind.Utc).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c5555555-5555-5555-5555-555555555555"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 6, 10, 49, 34, 210, DateTimeKind.Utc).AddTicks(8253));

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ApprovedById",
                table: "Expenses",
                column: "ApprovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_ApprovedById",
                table: "Expenses",
                column: "ApprovedById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_ApprovedById",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ApprovedById",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "Expenses");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"),
                column: "PasswordHash",
                value: "$2a$11$d5vCSPuaIHefeb3t3oVtzec6RHl.Wc8YdHd7L0m8s4LZUzAibNFmG");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"),
                column: "PasswordHash",
                value: "$2a$11$cv./UrLq398BcXnjRv8QROMaQIuY9D8KxqceJv4jqS.8/4KbIdRIG");

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(2927));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("f3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "RejectionReasons",
                keyColumn: "Id",
                keyValue: new Guid("c5555555-5555-5555-5555-555555555555"),
                column: "RejectedAt",
                value: new DateTime(2025, 5, 5, 22, 1, 47, 26, DateTimeKind.Utc).AddTicks(8663));
        }
    }
}
