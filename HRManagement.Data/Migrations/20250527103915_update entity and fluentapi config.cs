using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateentityandfluentapiconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmployeeID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_ApproverID",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeID",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Payslips_Employees_EmployeeID",
                table: "Payslips");

            migrationBuilder.DropForeignKey(
                name: "FK_Payslips_Salaries_SalaryID",
                table: "Payslips");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_EmployeeID",
                table: "Salaries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "LeaveRequestID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payslips",
                keyColumn: "PayslipID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "SalaryID",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Allowance",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "CheckInMethod",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Salaries",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Salaries_EmployeeID",
                table: "Salaries",
                newName: "IX_Salaries_UserID");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Payslips",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Payslips_EmployeeID",
                table: "Payslips",
                newName: "IX_Payslips_UserID");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "LeaveRequests",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_EmployeeID",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_UserID");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Attendances",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_EmployeeID",
                table: "Attendances",
                newName: "IX_Attendances_UserID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Salaries",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SalaryPeriod",
                table: "Salaries",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Salaries",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "Allowances",
                table: "Salaries",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payslips",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payslips",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Generated",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Payslips",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Payslips",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payslips",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LeaveRequests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Pending",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "LeaveRequests",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "LeaveRequests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "LeaveType",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveRequests",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Attendances",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceDate",
                table: "Attendances",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "HR", "HR" },
                    { 3, null, "Employee", "EMPLOYEE" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_UserID",
                table: "Attendances",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_ApproverID",
                table: "LeaveRequests",
                column: "ApproverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_UserID",
                table: "LeaveRequests",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payslips_AspNetUsers_UserID",
                table: "Payslips",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payslips_Salaries_SalaryID",
                table: "Payslips",
                column: "SalaryID",
                principalTable: "Salaries",
                principalColumn: "SalaryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_AspNetUsers_UserID",
                table: "Salaries",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_UserID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_ApproverID",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_UserID",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Payslips_AspNetUsers_UserID",
                table: "Payslips");

            migrationBuilder.DropForeignKey(
                name: "FK_Payslips_Salaries_SalaryID",
                table: "Payslips");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_AspNetUsers_UserID",
                table: "Salaries");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "EmployeeLevels");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropColumn(
                name: "Allowances",
                table: "Salaries");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Salaries",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Salaries_UserID",
                table: "Salaries",
                newName: "IX_Salaries_EmployeeID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Payslips",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Payslips_UserID",
                table: "Payslips",
                newName: "IX_Payslips_EmployeeID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "LeaveRequests",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_UserID",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_EmployeeID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Attendances",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_UserID",
                table: "Attendances",
                newName: "IX_Attendances_EmployeeID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Salaries",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SalaryPeriod",
                table: "Salaries",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Salaries",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<decimal>(
                name: "Allowance",
                table: "Salaries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payslips",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payslips",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Generated");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Payslips",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Payslips",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payslips",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LeaveRequests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Pending");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "LeaveRequests",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "LeaveType",
                table: "LeaveRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Attendances",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceDate",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "CheckInMethod",
                table: "Attendances",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    ContractType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmployeeID",
                table: "Attendances",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_ApproverID",
                table: "LeaveRequests",
                column: "ApproverID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeID",
                table: "LeaveRequests",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payslips_Employees_EmployeeID",
                table: "Payslips",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payslips_Salaries_SalaryID",
                table: "Payslips",
                column: "SalaryID",
                principalTable: "Salaries",
                principalColumn: "SalaryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_EmployeeID",
                table: "Salaries",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
