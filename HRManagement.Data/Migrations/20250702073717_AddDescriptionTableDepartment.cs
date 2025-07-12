using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionTableDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a27c52c-79a3-4075-a945-cc3839debb09", new DateTime(2025, 7, 2, 7, 37, 16, 18, DateTimeKind.Utc).AddTicks(4072), "AQAAAAIAAYagAAAAEA7rbZVSyAqLH8fwmsgBAaKWg0zoYiJAtoL4k1Ax4DlBRjRgSJ8v7WQnaxt1eXLFjw==", "39b8eaf0-6d2e-4711-bc62-3d4ee1721c98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1beb30d5-c874-4f53-90f3-3dd96455dd64", new DateTime(2025, 7, 2, 7, 37, 16, 70, DateTimeKind.Utc).AddTicks(1172), "AQAAAAIAAYagAAAAEHBt3GESXL7Tppn038nVW3/5qxl+qgpH9UCgV2EaSUnCXu0vnZYXDKa0odRp6YI/Mw==", "0bf54b5c-cec7-480a-9200-d8586d68f857" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f94ba5c9-5b5d-4c5b-b6c7-6a718b0e1605", new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(1113), "AQAAAAIAAYagAAAAELW/1ZO6s6rLkkkb1CTZIXWQ5ohRE65pxB+cUQZvOEiJVqKfVVX4z5nkmlX+jHuixA==", "64e05de8-a9fe-44cc-bc6c-d765685a780c" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 7, 2, 7, 37, 15, 967, DateTimeKind.Utc).AddTicks(454), "Phòng ban này là công nghệ thông tin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 7, 2, 7, 37, 15, 967, DateTimeKind.Utc).AddTicks(459), "Phòng ban này để quản lý nhân sự" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 7, 2, 7, 37, 15, 967, DateTimeKind.Utc).AddTicks(460), "Phòng ban này để quản lý lương" });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(2358));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f307b44b-ff2a-4115-b816-433d4040e003", new DateTime(2025, 7, 1, 2, 56, 37, 608, DateTimeKind.Utc).AddTicks(5986), "AQAAAAIAAYagAAAAEJ9evaU9Y3VxUc9Tux47CwMRWCKQPDDiMi65zHIs+3DwYyTC/5McrTKr/wbutp6rJg==", "932fae74-68bb-4bdd-9a12-54d9855030b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ca41c49-d790-4ed5-a2f2-49e18e111312", new DateTime(2025, 7, 1, 2, 56, 37, 681, DateTimeKind.Utc).AddTicks(7786), "AQAAAAIAAYagAAAAEPcxp+UEVwTNWx28Y0Ygwxu6swaYoWu/heS7Z5d4hJlCNrNrk56EoNSEsIoG69lyog==", "dc76d139-840b-44ce-9f70-d32ac6116454" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5d6cd08-2a45-4757-b435-deba8dc385a1", new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(5273), "AQAAAAIAAYagAAAAEFT3blWk+zJG9cZhzAo9SjUFiDVaJa23Me5LoiuuiHeSp5JrMZbwMvLLkENn1zZfcw==", "a25895d3-de00-42f2-9358-6ef045810b1c" });

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
                value: new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(6137));

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
    }
}
