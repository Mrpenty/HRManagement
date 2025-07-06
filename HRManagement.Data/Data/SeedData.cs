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
                new Department { DepartmentID = 1, DepartmentName = "IT", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { DepartmentID = 2, DepartmentName = "HR", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { DepartmentID = 3, DepartmentName = "Finance", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
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

             //Seed Positions
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
                    IsVerified = true,
                    DepartmentID = 1,
                    EmployeeLevelID = 3,
                    ContractTypeID = 1,
                    PositionID = 1,
                    Status = "Active",
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
                    IsVerified = true,
                    DepartmentID = 2,
                    EmployeeLevelID = 2,
                    ContractTypeID = 1,
                    PositionID = 2,
                    Status = "Active",
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
                    IsVerified = true,
                    DepartmentID = 3,
                    EmployeeLevelID = 1,
                    ContractTypeID = 2,
                    PositionID = 3,
                    Status = "Active",
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
                    AttendanceDate = DateTime.Parse("2025-06-01"),
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
                    AttendanceDate = DateTime.Parse("2025-06-01"),
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
                    LeaveType = "Annual Leave",
                    ApproverID = 1,
                    StartDate = DateTime.Parse("2025-06-04"),
                    EndDate = DateTime.Parse("2025-06-05"),
                    Reason = "Vacation",
                    Status = "Approved",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed DeductionReasons
            modelBuilder.Entity<DeductionReason>().HasData(
                new DeductionReason { DeductionReasonID = 1, ReasonName = "Late Arrival", Description = "Đi muộn", Amount = 50.00m },
                new DeductionReason { DeductionReasonID = 2, ReasonName = "Early Departure", Description = "Về sớm", Amount = 50.00m },
                new DeductionReason { DeductionReasonID = 3, ReasonName = "Absence", Description = "Vắng mặt", Amount = 200.00m },
                new DeductionReason { DeductionReasonID = 4, ReasonName = "Insurance", Description = "Bảo hiểm", Amount = 100.00m },
                new DeductionReason { DeductionReasonID = 5, ReasonName = "Tax", Description = "Thuế", Amount = 0.00m }
            );

            // Seed Holidays
            modelBuilder.Entity<Holiday>().HasData(
                new Holiday { HolidayID = 1, HolidayName = "New Year's Day", HolidayDate = DateTime.Parse("2025-01-01") },
                new Holiday { HolidayID = 2, HolidayName = "Independence Day", HolidayDate = DateTime.Parse("2025-09-02") },
                new Holiday { HolidayID = 3, HolidayName = "Christmas Day", HolidayDate = DateTime.Parse("2025-12-25") },
                new Holiday { HolidayID = 4, HolidayName = "Labor Day", HolidayDate = DateTime.Parse("2025-05-01") },
                new Holiday { HolidayID = 5, HolidayName = "Tet Holiday", HolidayDate = DateTime.Parse("2025-01-28") }
            );

            // Seed Deductions
            modelBuilder.Entity<Deduction>().HasData(
                new Deduction
                {
                    DeductionID = 1,
                    UserID = 1,
                    DeductionReasonID = 1,
                    Amount = 50.00m,
                    DeductionDate = DateTime.Parse("2025-06-01"),
                    Description = "Late arrival on Monday",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Deduction
                {
                    DeductionID = 2,
                    UserID = 2,
                    DeductionReasonID = 4,
                    Amount = 100.00m,
                    DeductionDate = DateTime.Parse("2025-06-01"),
                    Description = "Monthly insurance deduction",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed SalaryBonuses
            modelBuilder.Entity<SalaryBonus>().HasData(
                new SalaryBonus
                {
                    SalaryBonusID = 1,
                    UserID = 1,
                    BonusType = "Performance Bonus",
                    Amount = 500.00m,
                    BonusDate = DateTime.Parse("2025-06-01"),
                    Description = "Excellent performance in Q1",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SalaryBonus
                {
                    SalaryBonusID = 2,
                    UserID = 2,
                    BonusType = "Project Bonus",
                    Amount = 300.00m,
                    BonusDate = DateTime.Parse("2025-06-01"),
                    Description = "Successfully completed HR system project",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

          //   Seed PerformanceReviews
            modelBuilder.Entity<PerformanceReview>().HasData(
                new PerformanceReview
                {
                    PerformanceReviewID = 1,
                    UserID = 1,
                    ReviewerID = 2,
                    ReviewDate = DateTime.Parse("2025-06-01"),
                    Rating = 4.5m,
                    Comments = "Excellent performance, strong technical skills",
                    Status = "Completed",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PerformanceReview
                {
                    PerformanceReviewID = 2,
                    UserID = 2,
                    ReviewerID = 1,
                    ReviewDate = DateTime.Parse("2025-06-01"),
                    Rating = 4.0m,
                    Comments = "Good performance, needs improvement in communication",
                    Status = "Completed",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed SalaryPeriods
            modelBuilder.Entity<SalaryPeriod>().HasData(
                new SalaryPeriod { SalaryPeriodID = 1, PeriodName = "January 2025", StartDate = DateTime.Parse("2025-01-01"), EndDate = DateTime.Parse("2025-01-31") },
                new SalaryPeriod { SalaryPeriodID = 2, PeriodName = "February 2025", StartDate = DateTime.Parse("2025-02-01"), EndDate = DateTime.Parse("2025-02-28") },
                new SalaryPeriod { SalaryPeriodID = 3, PeriodName = "March 2025", StartDate = DateTime.Parse("2025-03-01"), EndDate = DateTime.Parse("2025-03-31") },
                new SalaryPeriod { SalaryPeriodID = 4, PeriodName = "April 2025", StartDate = DateTime.Parse("2025-04-01"), EndDate = DateTime.Parse("2025-04-30") },
                new SalaryPeriod { SalaryPeriodID = 5, PeriodName = "May 2025", StartDate = DateTime.Parse("2025-05-01"), EndDate = DateTime.Parse("2025-05-31") },
                new SalaryPeriod { SalaryPeriodID = 6, PeriodName = "June 2025", StartDate = DateTime.Parse("2025-06-01"), EndDate = DateTime.Parse("2025-06-30") }
            );



           //  Seed LeaveBalances
            modelBuilder.Entity<LeaveBalance>().HasData(
                new LeaveBalance
                {
                    LeaveBalanceID = 1,
                    UserID = 1,
                    LeaveType = "Annual Leave",
                    TotalDays = 12,
                    UsedDays = 3,
                    RemainingDays = 9,
                    Year = 2025,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new LeaveBalance
                {
                    LeaveBalanceID = 2,
                    UserID = 1,
                    LeaveType = "Sick Leave",
                    TotalDays = 10,
                    UsedDays = 1,
                    RemainingDays = 9,
                    Year = 2025,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new LeaveBalance
                {
                    LeaveBalanceID = 3,
                    UserID = 2,
                    LeaveType = "Annual Leave",
                    TotalDays = 12,
                    UsedDays = 5,
                    RemainingDays = 7,
                    Year = 2025,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new LeaveBalance
                {
                    LeaveBalanceID = 4,
                    UserID = 2,
                    LeaveType = "Sick Leave",
                    TotalDays = 10,
                    UsedDays = 2,
                    RemainingDays = 8,
                    Year = 2025,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new LeaveBalance
                {
                    LeaveBalanceID = 5,
                    UserID = 3,
                    LeaveType = "Annual Leave",
                    TotalDays = 12,
                    UsedDays = 0,
                    RemainingDays = 12,
                    Year = 2025,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new LeaveBalance
                {
                    LeaveBalanceID = 6,
                    UserID = 3,
                    LeaveType = "Sick Leave",
                    TotalDays = 10,
                    UsedDays = 0,
                    RemainingDays = 10,
                    Year = 2025,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}