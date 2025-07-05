using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatusAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df940d45-1008-4961-adec-0f91dd386cfd", new DateTime(2025, 7, 2, 3, 37, 54, 141, DateTimeKind.Utc).AddTicks(751), "AQAAAAIAAYagAAAAEOK+coHrrw15ted8Fy5xbMAXcR2cubkwUbxpL4Xd8hgzeDfsUL2Df7LRQDq4yKzKpQ==", "99a715e1-9257-496f-9941-6e2f7310634c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a69b3f2-b756-4ad3-880b-45216c9a3e2a", new DateTime(2025, 7, 2, 3, 37, 54, 197, DateTimeKind.Utc).AddTicks(7875), "AQAAAAIAAYagAAAAEFfmL2+fhyLgBst5iyZ9g6OkNXov7gBVclWbBI6Px5cxkXH2WuJVtvGQNjyQzOtdQA==", "0992e392-ea78-4004-8047-06d690b7a699" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac4b622c-ae13-46b6-b357-8584bdba05af", new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(2626), "AQAAAAIAAYagAAAAEJqv9fEmU0DbondIMfZ6BdtLXQR4jDS4T4d3VY5x4P8zfje/mpHV8rUZK3+R1ZCa2Q==", "8edd8fb7-cdc4-4e74-89fa-63b5c5fcf941" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                columns: new[] { "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3101), "OnTime" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                columns: new[] { "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3114), "Late" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 84, DateTimeKind.Utc).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 84, DateTimeKind.Utc).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 84, DateTimeKind.Utc).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3154));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3159));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Attendances");

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
                columns: new[] { "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6298) });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                columns: new[] { "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 2, 56, 37, 751, DateTimeKind.Utc).AddTicks(6329) });

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
