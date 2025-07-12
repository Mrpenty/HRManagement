using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data.Data;

public partial class SeedRoles
{
    public static class SeedData
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, DepartmentName = "IT", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Description="Phòng ban này là công nghệ thông tin" },
                new Department { DepartmentID = 2, DepartmentName = "HR", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Description="Phòng ban này để quản lý nhân sự" },
                new Department { DepartmentID = 3, DepartmentName = "Finance", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Description="Phòng ban này để quản lý lương" }
            );

            // Seed EmployeeLevels
            modelBuilder.Entity<EmployeeLevel>().HasData(
                new EmployeeLevel { EmployeeLevelID = 1, EmployeeLevelName = "Junior" },
                new EmployeeLevel { EmployeeLevelID = 2, EmployeeLevelName = "Senior" },
                new EmployeeLevel { EmployeeLevelID = 3, EmployeeLevelName = "Manager" }
            );

            // Seed ContractTypes
            modelBuilder.Entity<ContractType>().HasData(
                new ContractType { ContractTypeID = 1, ContractTypeName = "Full-Time" },
                new ContractType { ContractTypeID = 2, ContractTypeName = "Part-Time" },
                new ContractType { ContractTypeID = 3, ContractTypeName = "Freelance" }
            );

            // Seed Positions
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionID = 1, PositionName = "Software Engineer" },
                new Position { PositionID = 2, PositionName = "HR Specialist" },
                new Position { PositionID = 3, PositionName = "Accountant" }
            );

            // Seed Users
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Admin",
                    LastName = "User",
                    isVertify = true,
                    DepartmentID = 1,
                    EmployeeLevelID = 3,
                    ContractTypeID = 1,
                    PositionID = 1,
                    status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    UserName = "hruser",
                    NormalizedUserName = "HRUSER",
                    Email = "hr@example.com",
                    NormalizedEmail = "HR@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Hr@123"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "HR",
                    LastName = "User",
                    isVertify = true,
                    DepartmentID = 2,
                    EmployeeLevelID = 2,
                    ContractTypeID = 1,
                    PositionID = 2,
                    status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 3,
                    UserName = "employee",
                    NormalizedUserName = "EMPLOYEE",
                    Email = "employee@example.com",
                    NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Employee@123"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Employee",
                    LastName = "User",
                    isVertify = true,
                    DepartmentID = 3,
                    EmployeeLevelID = 1,
                    ContractTypeID = 2,
                    PositionID = 3,
                    status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed User Roles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // Admin
                new IdentityUserRole<int> { UserId = 2, RoleId = 2 }, // HR
                new IdentityUserRole<int> { UserId = 3, RoleId = 3 }  // Employee
            );

            // Seed Attendances
            modelBuilder.Entity<Attendance>().HasData(
                new Attendance
                {
                    AttendanceID = 1,
                    UserID = 1,
                    CheckInTime = DateTime.Parse("2025-06-30 08:00:00"),
                    CheckOutTime = DateTime.Parse("2025-06-30 16:00:00"),
                    Location = "Office",
                    WorkHours = 8.0m,
                    OvertimeHours = 0.0m,
                    AttendanceDate = DateTime.Parse("2025-06-30"),
                    Status = "OnTime",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Attendance
                {
                    AttendanceID = 2,
                    UserID = 2,
                    CheckInTime = DateTime.Parse("2025-07-01 09:00:00"),
                    CheckOutTime = DateTime.Parse("2025-07-01 18:00:00"),
                    Location = "Office",
                    WorkHours = 8.0m,
                    OvertimeHours = 1.0m,
                    AttendanceDate = DateTime.Parse("2025-07-01"),
                    Status = "Late",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );


            // Seed Salaries
            modelBuilder.Entity<Salary>().HasData(
                new Salary
                {
                    SalaryID = 1,
                    UserID = 1,
                    BaseSalary = 5000.00m,
                    Allowances = 500.00m,
                    Bonus = 200.00m,
                    Deduction = 300.00m,
                    Tax = 400.00m,
                    NetSalary = 5000.00m + 500.00m + 200.00m - 300.00m - 400.00m,
                    SalaryPeriod = DateTime.Parse("2025-06-01"),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Salary
                {
                    SalaryID = 2,
                    UserID = 2,
                    BaseSalary = 4000.00m,
                    Allowances = 400.00m,
                    Bonus = 150.00m,
                    Deduction = 200.00m,
                    Tax = 300.00m,
                    NetSalary = 4000.00m + 400.00m + 150.00m - 200.00m - 300.00m,
                    SalaryPeriod = DateTime.Parse("2025-06-01"),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed Payslips
            modelBuilder.Entity<Payslip>().HasData(
                new Payslip
                {
                    PayslipID = 1,
                    UserID = 1,
                    SalaryID = 1,
                    IssueDate = DateTime.Parse("2025-06-01"),
                    FilePath = "/payslips/user1_june2025.pdf",
                    Status = "Generated",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Payslip
                {
                    PayslipID = 2,
                    UserID = 2,
                    SalaryID = 2,
                    IssueDate = DateTime.Parse("2025-06-01"),
                    FilePath = "/payslips/user2_june2025.pdf",
                    Status = "Generated",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed LeaveRequests
            modelBuilder.Entity<LeaveRequest>().HasData(
                new LeaveRequest
                {
                    LeaveRequestID = 1,
                    UserID = 1,
                    LeaveType = "Sick Leave",
                    ApproverID = 2,
                    StartDate = DateTime.Parse("2025-06-02"),
                    EndDate = DateTime.Parse("2025-06-03"),
                    Reason = "Sick leave",
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new LeaveRequest
                {
                    LeaveRequestID = 2,
                    UserID = 2,
                    LeaveType = "Sick Leave",

                    ApproverID = 1,
                    StartDate = DateTime.Parse("2025-06-04"),
                    EndDate = DateTime.Parse("2025-06-05"),
                    Reason = "Vacation",
                    Status = "Approved",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}