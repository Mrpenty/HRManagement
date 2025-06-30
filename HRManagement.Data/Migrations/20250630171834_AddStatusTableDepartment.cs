using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusTableDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Departments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Inactive");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d8b3e56-eb14-4747-904d-bd424d52808e", new DateTime(2025, 6, 30, 17, 18, 32, 467, DateTimeKind.Utc).AddTicks(7716), "AQAAAAIAAYagAAAAELWjdZmizqzLlGsT8X1n+JXoCLBG+12AkKkTT0T3paLFXgkp30IVMmLgkqz+CvEQMg==", "ff4f639d-b3de-43c2-a290-c71aa4c14677" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47b001f7-04cc-4dae-b62d-171f256b9a01", new DateTime(2025, 6, 30, 17, 18, 32, 521, DateTimeKind.Utc).AddTicks(3635), "AQAAAAIAAYagAAAAEAo1Onye0Idgo4Jo7xW41qL2oGll/nGuaqxcXEQ1wirw6Jk4Hdzqug62ksP7oDZ9vg==", "8a4011bc-1ea2-470c-9a7c-795e6e5f6086" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd4e4439-195b-4ef9-b988-43ad6756b32e", new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(4718), "AQAAAAIAAYagAAAAED8JMiPm2No77bLS1ZxbNW4FhAQSBWIkJQaLh/vp456/p1AcaKAMQyGQOHzT8uQSJA==", "eccbd993-2d12-4af4-a203-d46f8dbde201" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 6, 30, 17, 18, 32, 414, DateTimeKind.Utc).AddTicks(492), "Inactive" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 6, 30, 17, 18, 32, 414, DateTimeKind.Utc).AddTicks(497), "Inactive" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 6, 30, 17, 18, 32, 414, DateTimeKind.Utc).AddTicks(499), "Inactive" });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(6233));

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
                value: new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 30, 17, 18, 32, 575, DateTimeKind.Utc).AddTicks(6034));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Departments");

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
