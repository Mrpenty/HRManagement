using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_SalaryAjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryAdjustments",
                columns: table => new
                {
                    SalaryAdjustmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAdjustments", x => x.SalaryAdjustmentID);
                    table.ForeignKey(
                        name: "FK_SalaryAdjustments_Salaries_SalaryID",
                        column: x => x.SalaryID,
                        principalTable: "Salaries",
                        principalColumn: "SalaryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "305c3183-841c-4d56-b072-a8268122b648", new DateTime(2025, 7, 23, 14, 21, 2, 62, DateTimeKind.Utc).AddTicks(82), "AQAAAAIAAYagAAAAEBaUwv33u7ZeRLWFSmgyz/7Bn7YnJZyBiNPkJvzU14zHcuSmH9Hyskpof+3rbgLDVQ==", "d6d2a294-95ac-4461-bd8e-35c71cabc843" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f2bcdb8-fe12-46dd-84fe-9ffdea626873", new DateTime(2025, 7, 23, 14, 21, 2, 126, DateTimeKind.Utc).AddTicks(621), "AQAAAAIAAYagAAAAEL5h/55PmFvZVvobartlXxYyfiNPYRkGk4JJ3Ofr5pLk88D/5Dl+swvxZ5tWkIj7uQ==", "abee305f-58b1-407a-b44f-5fcd3c761ff1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d739cb57-932e-44fb-8fbb-7089f4229d46", new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(4939), "AQAAAAIAAYagAAAAEJEOnA9upC3BwGmdJ43zdfgohown0cr0WNaDPC+DUKBbK6di8co6D+43wKArObGJ6A==", "9d8668dc-01c7-4404-9124-dc779b884673" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 1, 998, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 1, 998, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 1, 998, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 14, 21, 2, 190, DateTimeKind.Utc).AddTicks(5819));

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdjustments_SalaryID",
                table: "SalaryAdjustments",
                column: "SalaryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryAdjustments");

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
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 3, 37, 54, 255, DateTimeKind.Utc).AddTicks(3114));

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
    }
}
