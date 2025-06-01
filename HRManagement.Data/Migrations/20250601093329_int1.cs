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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    ContractTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.ContractTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLevels",
                columns: table => new
                {
                    EmployeeLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeLevelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLevels", x => x.EmployeeLevelID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    RefreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    EmployeeLevelID = table.Column<int>(type: "int", nullable: true),
                    ContractTypeID = table.Column<int>(type: "int", nullable: true),
                    PositionID = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ContractTypes_ContractTypeID",
                        column: x => x.ContractTypeID,
                        principalTable: "ContractTypes",
                        principalColumn: "ContractTypeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_EmployeeLevels_EmployeeLevelID",
                        column: x => x.EmployeeLevelID,
                        principalTable: "EmployeeLevels",
                        principalColumn: "EmployeeLevelID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Attendances",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkHours = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    OvertimeHours = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_Attendances_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    LeaveRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    ApproverID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.LeaveRequestID);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_AspNetUsers_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Allowances = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Deduction = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SalaryPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryID);
                    table.ForeignKey(
                        name: "FK_Salaries_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payslips",
                columns: table => new
                {
                    PayslipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SalaryID = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Generated"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips", x => x.PayslipID);
                    table.ForeignKey(
                        name: "FK_Payslips_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payslips_Salaries_SalaryID",
                        column: x => x.SalaryID,
                        principalTable: "Salaries",
                        principalColumn: "SalaryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "HR", "HR" },
                    { 3, null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "ContractTypes",
                columns: new[] { "ContractTypeID", "ContractTypeName" },
                values: new object[,]
                {
                    { 1, "Full-Time" },
                    { 2, "Part-Time" },
                    { 3, "Freelance" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreatedAt", "DepartmentName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 1, 9, 33, 28, 101, DateTimeKind.Utc).AddTicks(1413), "IT" },
                    { 2, new DateTime(2025, 6, 1, 9, 33, 28, 101, DateTimeKind.Utc).AddTicks(1420), "HR" },
                    { 3, new DateTime(2025, 6, 1, 9, 33, 28, 101, DateTimeKind.Utc).AddTicks(1421), "Finance" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeLevels",
                columns: new[] { "EmployeeLevelID", "EmployeeLevelName" },
                values: new object[,]
                {
                    { 1, "Junior" },
                    { 2, "Senior" },
                    { 3, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionID", "PositionName" },
                values: new object[,]
                {
                    { 1, "Software Engineer" },
                    { 2, "HR Specialist" },
                    { 3, "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContractTypeID", "CreatedAt", "DateOfBirth", "DepartmentID", "Email", "EmailConfirmed", "EmployeeLevelID", "FirstName", "HireDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionID", "ProfilePicture", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "cccf4ef0-9999-4614-a160-f5111327dfd9", 1, new DateTime(2025, 6, 1, 9, 33, 28, 169, DateTimeKind.Utc).AddTicks(3499), null, 1, "admin@example.com", false, 3, "Admin", null, "User", false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEEMwvsX1ZTTDQ+70id84/9H2wzf/5yYQJEQd1D0GnGhCr4khMVtYYlS8vnlhLENTHw==", null, false, 1, null, null, null, "3ee90e13-4714-4546-b618-5172e5256dd4", false, "admin" },
                    { 2, 0, "10ee91eb-50c9-4228-ad72-fa278b660f94", 1, new DateTime(2025, 6, 1, 9, 33, 28, 234, DateTimeKind.Utc).AddTicks(191), null, 2, "hr@example.com", false, 2, "HR", null, "User", false, null, "HR@EXAMPLE.COM", "HRUSER", "AQAAAAIAAYagAAAAEPe21UJ2AGLic+dmosUqHSowh29c0oMlHFmZIZWJWf/CKVoFk5x4TIi8qFHnLxGa9A==", null, false, 2, null, null, null, "67c643c7-d63f-480c-92ea-597419e76385", false, "hruser" },
                    { 3, 0, "ab0d41e2-a20b-44a5-8b65-74d7e370b380", 2, new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(4280), null, 3, "employee@example.com", false, 1, "Employee", null, "User", false, null, "EMPLOYEE@EXAMPLE.COM", "EMPLOYEE", "AQAAAAIAAYagAAAAEDc9uvLtMd2K743eJ50WyvHfjsy1wqhiLbRQrxgM0PGXPvuj/lANcD3/ygVgsYP00A==", null, false, 3, null, null, null, "4e662d60-f1d3-4195-9a3c-9abf9bf8f3ba", false, "employee" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceID", "AttendanceDate", "CheckInTime", "CheckOutTime", "CreatedAt", "Location", "OvertimeHours", "UserID", "WorkHours" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5205), "Office", 0.0m, 1, 8.0m },
                    { 2, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5242), "Office", 1.0m, 2, 8.0m }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "LeaveRequestID", "ApproverID", "CreatedAt", "EndDate", "LeaveType", "Reason", "StartDate", "Status", "UserID" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5483), new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave", "Sick leave", new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1 },
                    { 2, 1, new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5490), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave", "Vacation", new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", 2 }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "SalaryID", "Allowances", "BaseSalary", "Bonus", "CreatedAt", "Deduction", "NetSalary", "SalaryPeriod", "Tax", "UserID" },
                values: new object[,]
                {
                    { 1, 500.00m, 5000.00m, 200.00m, new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5304), 300.00m, 5000.00m, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400.00m, 1 },
                    { 2, 400.00m, 4000.00m, 150.00m, new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5309), 200.00m, 4050.00m, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.00m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Payslips",
                columns: new[] { "PayslipID", "CreatedAt", "FilePath", "IssueDate", "SalaryID", "Status", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5363), "/payslips/user1_june2025.pdf", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Generated", 1 },
                    { 2, new DateTime(2025, 6, 1, 9, 33, 28, 320, DateTimeKind.Utc).AddTicks(5369), "/payslips/user2_june2025.pdf", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Generated", 2 }
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
                name: "IX_AspNetUsers_ContractTypeID",
                table: "AspNetUsers",
                column: "ContractTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeLevelID",
                table: "AspNetUsers",
                column: "EmployeeLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PositionID",
                table: "AspNetUsers",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserID",
                table: "Attendances",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_ApproverID",
                table: "LeaveRequests",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_UserID",
                table: "LeaveRequests",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_SalaryID",
                table: "Payslips",
                column: "SalaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_UserID",
                table: "Payslips",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_UserID",
                table: "Salaries",
                column: "UserID");
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
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeeLevels");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
