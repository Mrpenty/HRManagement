using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Data.Data
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, DepartmentName = "Human Resources", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Department { DepartmentID = 2, DepartmentName = "Information Technology", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Department { DepartmentID = 3, DepartmentName = "Finance", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Nguyen",
                    LastName = "Van A",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Email = "nguyenvana@example.com",
                    Phone = "0901234567",
                    DepartmentID = 1,
                    HireDate = new DateTime(2023, 1, 10),
                    EmployeeStatus = "Senior",
                    ContractType = "Full-time",
                    Username = "nguyenvana",
                    PasswordHash = "Admin123", // Placeholder, replace with actual hash
                    Role = "Admin",
                    Position = "HR Manager",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "Tran",
                    LastName = "Thi B",
                    DateOfBirth = new DateTime(1992, 8, 20),
                    Email = "tranthib@example.com",
                    Phone = "0909876543",
                    DepartmentID = 2,
                    HireDate = new DateTime(2022, 6, 15),
                    ContractType = "Part-time",
                    Username = "tranthib",
                    PasswordHash = "HR123", // Placeholder
                    Role = "HR",
                    Position = "Recruiter",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Employee
                {
                    EmployeeID = 3,
                    FirstName = "Le",
                    LastName = "Van C",
                    DateOfBirth = new DateTime(1995, 3, 10),
                    Email = "levanc@example.com",
                    Phone = "0912345678",
                    DepartmentID = 3,
                    HireDate = new DateTime(2024, 1, 1),
                    EmployeeStatus = "Intern",
                    ContractType = "Part-time",
                    Username = "levanc",
                    PasswordHash = "Employee123", // Placeholder
                    Role = "Employee",
                    Position = "Accountant",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Employee
                {
                    EmployeeID = 4,
                    FirstName = "Pham",
                    LastName = "Thi D",
                    DateOfBirth = new DateTime(1988, 3, 25),
                    Email = "phamthid@example.com",
                    Phone = "0923456789",
                    DepartmentID = 1,
                    HireDate = new DateTime(2025, 5, 1),
                    EmployeeStatus = "Senior",
                    ContractType = "Full-time",
                    Username = "phamthid",
                    PasswordHash = "Admin234", // Placeholder
                    Role = "Admin",
                    Position = "Payroll Manager",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Salaries
            modelBuilder.Entity<Salary>().HasData(
                new Salary
                {
                    SalaryID = 1,
                    EmployeeID = 1,
                    BaseSalary = 15000000,
                    Allowance = 2000000,
                    Bonus = 1000000,
                    Deduction = 500000,
                    Tax = 750000,
                    NetSalary = 16750000,
                    SalaryPeriod = new DateTime(2025, 5, 1),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Salary
                {
                    SalaryID = 2,
                    EmployeeID = 2,
                    BaseSalary = 10000000,
                    Allowance = 1000000,
                    Bonus = 500000,
                    Deduction = 300000,
                    Tax = 500000,
                    NetSalary = 10700000,
                    SalaryPeriod = new DateTime(2025, 5, 1),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Salary
                {
                    SalaryID = 3,
                    EmployeeID = 3,
                    BaseSalary = 5000000,
                    Allowance = 500000,
                    Bonus = 0,
                    Deduction = 100000,
                    Tax = 0,
                    NetSalary = 5400000,
                    SalaryPeriod = new DateTime(2025, 5, 1),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Salary
                {
                    SalaryID = 4,
                    EmployeeID = 4,
                    BaseSalary = 20000000,
                    Allowance = 3000000,
                    Bonus = 1500000,
                    Deduction = 600000,
                    Tax = 1000000,
                    NetSalary = 19900000,
                    SalaryPeriod = new DateTime(2025, 5, 1),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Payslips
            modelBuilder.Entity<Payslip>().HasData(
                new Payslip
                {
                    PayslipID = 1,
                    EmployeeID = 1,
                    SalaryID = 1,
                    IssueDate = new DateTime(2025, 5, 5),
                    FilePath = null,
                    Status = "Generated",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Payslip
                {
                    PayslipID = 2,
                    EmployeeID = 2,
                    SalaryID = 2,
                    IssueDate = new DateTime(2025, 5, 5),
                    FilePath = null,
                    Status = "Sent",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Payslip
                {
                    PayslipID = 3,
                    EmployeeID = 3,
                    SalaryID = 3,
                    IssueDate = new DateTime(2025, 5, 5),
                    FilePath = null,
                    Status = "Generated",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Payslip
                {
                    PayslipID = 4,
                    EmployeeID = 4,
                    SalaryID = 4,
                    IssueDate = new DateTime(2025, 5, 5),
                    FilePath = null,
                    Status = "Generated",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Attendance
            modelBuilder.Entity<Attendance>().HasData(
                new Attendance
                {
                    AttendanceID = 1,
                    EmployeeID = 1,
                    CheckInTime = new DateTime(2025, 5, 20, 8, 0, 0),
                    CheckOutTime = new DateTime(2025, 5, 20, 17, 0, 0),
                    CheckInMethod = "Mobile",
                    Location = "Office",
                    WorkHours = 8.0m,
                    OvertimeHours = 0,
                    AttendanceDate = new DateTime(2025, 5, 20),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Attendance
                {
                    AttendanceID = 2,
                    EmployeeID = 2,
                    CheckInTime = new DateTime(2025, 5, 20, 8, 30, 0),
                    CheckOutTime = new DateTime(2025, 5, 20, 14, 0, 0),
                    CheckInMethod = "CameraAI",
                    Location = "Office",
                    WorkHours = 5.5m,
                    OvertimeHours = 0,
                    AttendanceDate = new DateTime(2025, 5, 20),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Attendance
                {
                    AttendanceID = 3,
                    EmployeeID = 3,
                    CheckInTime = new DateTime(2025, 5, 20, 9, 0, 0),
                    CheckOutTime = new DateTime(2025, 5, 20, 15, 0, 0),
                    CheckInMethod = "GPS",
                    Location = "Office",
                    WorkHours = 6.0m,
                    OvertimeHours = 0,
                    AttendanceDate = new DateTime(2025, 5, 20),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Attendance
                {
                    AttendanceID = 4,
                    EmployeeID = 4,
                    CheckInTime = new DateTime(2025, 5, 20, 8, 15, 0),
                    CheckOutTime = new DateTime(2025, 5, 20, 17, 15, 0),
                    CheckInMethod = "Biometric",
                    Location = "Office",
                    WorkHours = 8.0m,
                    OvertimeHours = 1.0m,
                    AttendanceDate = new DateTime(2025, 5, 20),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed LeaveRequests
            modelBuilder.Entity<LeaveRequest>().HasData(
                new LeaveRequest
                {
                    LeaveRequestID = 1,
                    EmployeeID = 1,
                    LeaveType = "Annual",
                    StartDate = new DateTime(2025, 6, 1),
                    EndDate = new DateTime(2025, 6, 3),
                    Reason = "Rest",
                    Status = "Pending",
                    ApproverID = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new LeaveRequest
                {
                    LeaveRequestID = 2,
                    EmployeeID = 2,
                    LeaveType = "Sick",
                    StartDate = new DateTime(2025, 5, 22),
                    EndDate = new DateTime(2025, 5, 23),
                    Reason = "Health issue",
                    Status = "Approved",
                    ApproverID = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new LeaveRequest
                {
                    LeaveRequestID = 3,
                    EmployeeID = 3,
                    LeaveType = "Annual",
                    StartDate = new DateTime(2025, 6, 10),
                    EndDate = new DateTime(2025, 6, 12),
                    Reason = "Personal",
                    Status = "Pending",
                    ApproverID = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new LeaveRequest
                {
                    LeaveRequestID = 4,
                    EmployeeID = 4,
                    LeaveType = "Annual",
                    StartDate = new DateTime(2025, 6, 15),
                    EndDate = new DateTime(2025, 6, 16),
                    Reason = "Vacation",
                    Status = "Pending",
                    ApproverID = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}

