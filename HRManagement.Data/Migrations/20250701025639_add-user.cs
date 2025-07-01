using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVertify",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "isVertify", "status" },
                values: new object[] { "f307b44b-ff2a-4115-b816-433d4040e003", new DateTime(2025, 7, 1, 2, 56, 37, 608, DateTimeKind.Utc).AddTicks(5986), "AQAAAAIAAYagAAAAEJ9evaU9Y3VxUc9Tux47CwMRWCKQPDDiMi65zHIs+3DwYyTC/5McrTKr/wbutp6rJg==", "932fae74-68bb-4bdd-9a12-54d9855030b6", true, "Active" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "isVertify", "status" },
                values: new object[] { "7ca41c49-d790-4ed5-a2f2-49e18e111312", new DateTime(2025, 7, 1, 2, 56, 37, 681, DateTimeKind.Utc).AddTicks(7786), "AQAAAAIAAYagAAAAEPcxp+UEVwTNWx28Y0Ygwxu6swaYoWu/heS7Z5d4hJlCNrNrk56EoNSEsIoG69lyog==", "dc76d139-840b-44ce-9f70-d32ac6116454", true, "Active" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "isVertify", "status" },
                values: new object[] { "d5d6cd08-2a45-4757-b435-deba8dc385a1", new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(5273), "AQAAAAIAAYagAAAAEFT3blWk+zJG9cZhzAo9SjUFiDVaJa23Me5LoiuuiHeSp5JrMZbwMvLLkENn1zZfcw==", "a25895d3-de00-42f2-9358-6ef045810b1c", true, "Active" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 541, DateTimeKind.Utc).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 541, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 541, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6414));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVertify",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "status",
                table: "AspNetUsers");

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
    }
}
