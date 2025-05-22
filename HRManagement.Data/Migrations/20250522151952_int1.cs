using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class int1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContractType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.CheckConstraint("CK_ContractType", "[ContractType] IN ('Full-time', 'Part-time')");
                    table.CheckConstraint("CK_EmployeeStatus", "[EmployeeStatus] IN ('Intern', 'Fresher', 'Senior') OR [EmployeeStatus] IS NULL");
                    table.CheckConstraint("CK_Role", "[Role] IN ('Admin', 'HR', 'Employee')");
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckInMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WorkHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OvertimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_Attendances_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    LeaveRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApproverID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.LeaveRequestID);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryID);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payslips",
                columns: table => new
                {
                    PayslipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    SalaryID = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips", x => x.PayslipID);
                    table.ForeignKey(
                        name: "FK_Payslips_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payslips_Salaries_SalaryID",
                        column: x => x.SalaryID,
                        principalTable: "Salaries",
                        principalColumn: "SalaryID");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreatedAt", "DepartmentName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2584), "Human Resources", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2585) },
                    { 2, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2588), "Information Technology", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2589) },
                    { 3, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2590), "Finance", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2591) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "ContractType", "CreatedAt", "DateOfBirth", "DepartmentID", "Email", "EmployeeStatus", "FirstName", "HireDate", "LastName", "PasswordHash", "Phone", "Position", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, "Full-time", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2735), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "nguyenvana@example.com", "Senior", "Nguyen", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Van A", "Admin123", "0901234567", "HR Manager", "Admin", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2735), "nguyenvana" },
                    { 2, "Part-time", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2740), new DateTime(1992, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "tranthib@example.com", null, "Tran", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thi B", "HR123", "0909876543", "Recruiter", "HR", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2740), "tranthib" },
                    { 3, "Part-time", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2744), new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "levanc@example.com", "Intern", "Le", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Van C", "Employee123", "0912345678", "Accountant", "Employee", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2744), "levanc" },
                    { 4, "Full-time", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2747), new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "phamthid@example.com", "Senior", "Pham", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thi D", "Admin234", "0923456789", "Payroll Manager", "Admin", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2748), "phamthid" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceID", "AttendanceDate", "CheckInMethod", "CheckInTime", "CheckOutTime", "CreatedAt", "EmployeeID", "Location", "OvertimeHours", "UpdatedAt", "WorkHours" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile", new DateTime(2025, 5, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2847), 1, "Office", 0m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2848), 8.0m },
                    { 2, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CameraAI", new DateTime(2025, 5, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2852), 2, "Office", 0m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2852), 5.5m },
                    { 3, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "GPS", new DateTime(2025, 5, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2855), 3, "Office", 0m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2855), 6.0m },
                    { 4, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biometric", new DateTime(2025, 5, 20, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 17, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2859), 4, "Office", 1.0m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2859), 8.0m }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "LeaveRequestID", "ApproverID", "CreatedAt", "EmployeeID", "EndDate", "LeaveType", "Reason", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2919), 1, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Rest", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2920) },
                    { 2, 1, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2922), 2, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick", "Health issue", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2923) },
                    { 3, 1, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2925), 3, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Personal", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2926) },
                    { 4, 1, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2928), 4, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Vacation", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2928) }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "SalaryID", "Allowance", "BaseSalary", "Bonus", "CreatedAt", "Deduction", "EmployeeID", "NetSalary", "SalaryPeriod", "Tax", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2000000m, 15000000m, 1000000m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2779), 500000m, 1, 16750000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 750000m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2780) },
                    { 2, 1000000m, 10000000m, 500000m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2784), 300000m, 2, 10700000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500000m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2784) },
                    { 3, 500000m, 5000000m, 0m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2787), 100000m, 3, 5400000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2787) },
                    { 4, 3000000m, 20000000m, 1500000m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2790), 600000m, 4, 19900000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000000m, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2791) }
                });

            migrationBuilder.InsertData(
                table: "Payslips",
                columns: new[] { "PayslipID", "CreatedAt", "EmployeeID", "FilePath", "IssueDate", "SalaryID", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2813), 1, null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Generated", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2814) },
                    { 2, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2816), 2, null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sent", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2817) },
                    { 3, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2819), 3, null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Generated", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2819) },
                    { 4, new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2821), 4, null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Generated", new DateTime(2025, 5, 22, 22, 19, 51, 938, DateTimeKind.Local).AddTicks(2822) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeID",
                table: "Attendances",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Username",
                table: "Employees",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_ApproverID",
                table: "LeaveRequests",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeID",
                table: "LeaveRequests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_EmployeeID",
                table: "Payslips",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_SalaryID",
                table: "Payslips",
                column: "SalaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeID",
                table: "Salaries",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Payslips");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
