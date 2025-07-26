using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class navproptosalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "AspNetUsers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "isVertify",
                table: "AspNetUsers",
                newName: "IsVertify");

            migrationBuilder.AddColumn<int>(
                name: "SalaryID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SalaryID", "SecurityStamp" },
                values: new object[] { "5605164c-01c2-4660-8ec0-7c7db685c408", new DateTime(2025, 7, 25, 23, 44, 40, 184, DateTimeKind.Utc).AddTicks(2834), "AQAAAAIAAYagAAAAEBXD8mYpnIj5mZXGAN8Rl1ionr3K8DrPHFRNdVU6hzTqUuMkwyisUqOcnPkApbHc2w==", null, "b8eab2f0-c8ef-466b-ae7f-e5c7c3df624d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SalaryID", "SecurityStamp" },
                values: new object[] { "11a78a9d-46ec-4d9b-8aa7-a47001b542ce", new DateTime(2025, 7, 25, 23, 44, 40, 235, DateTimeKind.Utc).AddTicks(1620), "AQAAAAIAAYagAAAAEHo3wchcmYd8nYgKY47gt1lHEh96KeO4G/WRd1XDD/H0VMTyM3potPOjrFv2xIjmnw==", null, "a1728824-e997-4047-b8c7-c44f7e2de829" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SalaryID", "SecurityStamp" },
                values: new object[] { "b3f78312-e510-478b-a890-adc7479233ed", new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6263), "AQAAAAIAAYagAAAAELAsdOONqeu3FOlO8H21noNyhdx4I5rWSK5cgcYnabr1a7rxGYQROEDRnhkzchCryQ==", null, "10b00c8f-bc70-4ad9-b11b-bed625dd85ae" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                columns: new[] { "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6712), "OnTime" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                columns: new[] { "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6723), "Late" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 138, DateTimeKind.Utc).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 138, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 138, DateTimeKind.Utc).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 44, 40, 281, DateTimeKind.Utc).AddTicks(6760));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AspNetUsers",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "IsVertify",
                table: "AspNetUsers",
                newName: "isVertify");

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
                columns: new[] { "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(2149) });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                columns: new[] { "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 2, 7, 37, 16, 122, DateTimeKind.Utc).AddTicks(2264) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 15, 967, DateTimeKind.Utc).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 15, 967, DateTimeKind.Utc).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 7, 37, 15, 967, DateTimeKind.Utc).AddTicks(460));

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
    }
}
