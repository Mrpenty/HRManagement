using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApproverNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApproverNote",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c7e9792-b254-4dfd-a93d-0bc15252104b", new DateTime(2025, 6, 3, 2, 25, 47, 103, DateTimeKind.Utc).AddTicks(914), "AQAAAAIAAYagAAAAEFdbCY9gA9gFoRU18pin1U+WQiNRSrXAuSq6PdKQTmHO2laNi6IMUd6YxOuWFSiPwA==", "bf7676cf-6e2c-4cf4-876b-a2cd6c69e30b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a92ebb6-471f-4d0d-bc51-7b984e41abac", new DateTime(2025, 6, 3, 2, 25, 47, 184, DateTimeKind.Utc).AddTicks(4373), "AQAAAAIAAYagAAAAEHNjel3FbFllKNMlsTQYH4uGBGvkyO8TqQXpsewc3qD5KZ/Y9JI7/8SZQkkWdaX5qg==", "733bd6f3-3df1-4021-ba37-e3ef8af05f87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8ffc909-aff5-4754-8066-5fc5ff35e159", new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(2317), "AQAAAAIAAYagAAAAEA2t42qLk9VRKeeXJj/300joP9EtvL4HKjH06ZjkWwhcdGjOun5w3aWi5Aah1qj+mg==", "a6c6ddb7-e16b-4ac6-9a70-51e22448d0f0" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3268));

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 19, DateTimeKind.Utc).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 19, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 19, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                columns: new[] { "ApproverNote", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3634) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                columns: new[] { "ApproverNote", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3644) });

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3470));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproverNote",
                table: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cccf4ef0-9999-4614-a160-f5111327dfd9", new DateTime(2025, 6, 1, 9, 33, 28, 169, DateTimeKind.Utc).AddTicks(3499), "AQAAAAIAAYagAAAAEEMwvsX1ZTTDQ+70id84/9H2wzf/5yYQJEQd1D0GnGhCr4khMVtYYlS8vnlhLENTHw==", "3ee90e13-4714-4546-b618-5172e5256dd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10ee91eb-50c9-4228-ad72-fa278b660f94", new DateTime(2025, 6, 1, 9, 33, 28, 234, DateTimeKind.Utc).AddTicks(191), "AQAAAAIAAYagAAAAEPe21UJ2AGLic+dmosUqHSowh29c0oMlHFmZIZWJWf/CKVoFk5x4TIi8qFHnLxGa9A==", "67c643c7-d63f-480c-92ea-597419e76385" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab0d41e2-a20b-44a5-8b65-74d7e370b380", new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(4280), "AQAAAAIAAYagAAAAEDc9uvLtMd2K743eJ50WyvHfjsy1wqhiLbRQrxgM0PGXPvuj/lANcD3/ygVgsYP00A==", "4e662d60-f1d3-4195-9a3c-9abf9bf8f3ba" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5242));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 101, DateTimeKind.Utc).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 101, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 101, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5309));
        }
    }
}
