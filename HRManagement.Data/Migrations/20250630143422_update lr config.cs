using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatelrconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LeaveType",
                table: "LeaveRequests",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApproverNote",
                table: "LeaveRequests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "097660a9-d2e3-4458-aa10-40eeba53f122", new DateTime(2025, 6, 30, 14, 34, 21, 114, DateTimeKind.Utc).AddTicks(9718), "AQAAAAIAAYagAAAAEMg87zFM2ayeYJGorjQjH5zaoIg49x9ijIh5YDDUXk7MI+f3JOoHcRElrXwjWxo0mg==", "91128bc3-04b1-415a-8058-6f1b642e6752" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed7f3dea-a1e3-4f13-8e03-bac81fceb0d0", new DateTime(2025, 6, 30, 14, 34, 21, 157, DateTimeKind.Utc).AddTicks(1162), "AQAAAAIAAYagAAAAEK6jUUE2vc7Krhdoo0GHY1EpfVjLud355v7DgV8y22mAwFxEG5MNq+ap2o3RK3Htlg==", "1b560790-e88c-4f14-bd2d-19d451f3039d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad908bdc-a906-42a3-a14d-1758d99b266c", new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(5241), "AQAAAAIAAYagAAAAEHXqMUbXRbIriiR+NK7Zg0XzPMOq0BGDzcKOC8ZcTU95udXYVXA6DX/xuJ8q1v9PTQ==", "74689dc2-0cfa-41ea-b1fd-96545bc1435b" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 70, DateTimeKind.Utc).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 70, DateTimeKind.Utc).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 70, DateTimeKind.Utc).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 14, 34, 21, 199, DateTimeKind.Utc).AddTicks(6097));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LeaveType",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ApproverNote",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

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
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 2, 25, 47, 260, DateTimeKind.Utc).AddTicks(3644));

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
    }
}
