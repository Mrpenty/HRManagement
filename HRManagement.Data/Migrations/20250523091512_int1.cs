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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Active"),
                    ContractType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID1",
                        column: x => x.DepartmentID1,
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
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    OvertimeHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
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
                    LeaveType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryID1 = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "SalaryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payslips_Salaries_SalaryID1",
                        column: x => x.SalaryID1,
                        principalTable: "Salaries",
                        principalColumn: "SalaryID");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreatedAt", "DepartmentName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), "Human Resources", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 2, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), "Information Technology", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 3, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), "Finance", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "ContractType", "CreatedAt", "DateOfBirth", "DepartmentID", "DepartmentID1", "Email", "EmployeeStatus", "FirstName", "HireDate", "LastName", "Phone", "Position", "Role", "UpdatedAt", "Username" },
                values: new object[] { 1, "Full-time", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "nguyenvana@example.com", "Senior", "Nguyen", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Van A", "0901234567", "HR Manager", "Admin", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), "nguyenvana" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "ContractType", "CreatedAt", "DateOfBirth", "DepartmentID", "DepartmentID1", "Email", "FirstName", "HireDate", "LastName", "Phone", "Position", "Role", "UpdatedAt", "Username" },
                values: new object[] { 2, "Part-time", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), new DateTime(1992, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "tranthib@example.com", "Tran", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thi B", "0909876543", "Recruiter", "HR", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), "tranthib" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "ContractType", "CreatedAt", "DateOfBirth", "DepartmentID", "DepartmentID1", "Email", "EmployeeStatus", "FirstName", "HireDate", "LastName", "Phone", "Position", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 3, "Part-time", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "levanc@example.com", "Intern", "Le", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Van C", "0912345678", "Accountant", "Employee", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), "levanc" },
                    { 4, "Full-time", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "phamthid@example.com", "Senior", "Pham", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thi D", "0923456789", "Payroll Manager", "Admin", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), "phamthid" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceID", "AttendanceDate", "CheckInMethod", "CheckInTime", "CheckOutTime", "CreatedAt", "EmployeeID", "Location", "OvertimeHours", "UpdatedAt", "WorkHours" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile", new DateTime(2025, 5, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 1, "Office", 0m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 8.0m },
                    { 2, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CameraAI", new DateTime(2025, 5, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 2, "Office", 0m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 5.5m },
                    { 3, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "GPS", new DateTime(2025, 5, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 3, "Office", 0m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 6.0m },
                    { 4, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biometric", new DateTime(2025, 5, 20, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 17, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 4, "Office", 1.0m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 8.0m }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "LeaveRequestID", "ApproverID", "CreatedAt", "EmployeeID", "EndDate", "LeaveType", "Reason", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 1, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Rest", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 2, 1, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 2, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick", "Health issue", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 3, 1, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 3, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Personal", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 4, 1, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 4, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Vacation", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "SalaryID", "Allowance", "BaseSalary", "Bonus", "CreatedAt", "Deduction", "EmployeeID", "NetSalary", "SalaryPeriod", "Tax", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2000000m, 15000000m, 1000000m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 500000m, 1, 16750000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 750000m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 2, 1000000m, 10000000m, 500000m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 300000m, 2, 10700000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500000m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 3, 500000m, 5000000m, 0m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 100000m, 3, 5400000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 4, 3000000m, 20000000m, 1500000m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 600000m, 4, 19900000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000000m, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) }
                });

            migrationBuilder.InsertData(
                table: "Payslips",
                columns: new[] { "PayslipID", "CreatedAt", "EmployeeID", "FilePath", "IssueDate", "SalaryID", "SalaryID1", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 1, null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Generated", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 2, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 2, null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Sent", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 3, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 3, null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "Generated", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) },
                    { 4, new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963), 4, null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, "Generated", new DateTime(2025, 5, 23, 9, 15, 10, 296, DateTimeKind.Utc).AddTicks(5963) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeID",
                table: "Attendances",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID1",
                table: "Employees",
                column: "DepartmentID1");

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
                name: "IX_Payslips_SalaryID1",
                table: "Payslips",
                column: "SalaryID1");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeID",
                table: "Salaries",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Payslips");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
