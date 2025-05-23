using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                var now = DateTime.UtcNow;

                // Seed Departments
                modelBuilder.Entity<Department>().HasData(
                    new Department { DepartmentID = 1, DepartmentName = "Human Resources", CreatedAt = now, UpdatedAt = now },
                    new Department { DepartmentID = 2, DepartmentName = "Information Technology", CreatedAt = now, UpdatedAt = now },
                    new Department { DepartmentID = 3, DepartmentName = "Finance", CreatedAt = now, UpdatedAt = now }
                );

                // Seed Employees
                modelBuilder.Entity<Employee>().HasData(
                    new Employee { EmployeeID = 1, FirstName = "Nguyen", LastName = "Van A", DateOfBirth = new DateTime(1990, 5, 15), Email = "nguyenvana@example.com", Phone = "0901234567", DepartmentID = 1, HireDate = new DateTime(2023, 1, 10), EmployeeStatus = "Senior", ContractType = "Full-time", Username = "nguyenvana", Role = "Admin", Position = "HR Manager", CreatedAt = now, UpdatedAt = now },
                    new Employee { EmployeeID = 2, FirstName = "Tran", LastName = "Thi B", DateOfBirth = new DateTime(1992, 8, 20), Email = "tranthib@example.com", Phone = "0909876543", DepartmentID = 2, HireDate = new DateTime(2022, 6, 15), ContractType = "Part-time", Username = "tranthib", Role = "HR", Position = "Recruiter", CreatedAt = now, UpdatedAt = now },
                    new Employee { EmployeeID = 3, FirstName = "Le", LastName = "Van C", DateOfBirth = new DateTime(1995, 3, 10), Email = "levanc@example.com", Phone = "0912345678", DepartmentID = 3, HireDate = new DateTime(2024, 1, 1), EmployeeStatus = "Intern", ContractType = "Part-time", Username = "levanc", Role = "Employee", Position = "Accountant", CreatedAt = now, UpdatedAt = now },
                    new Employee { EmployeeID = 4, FirstName = "Pham", LastName = "Thi D", DateOfBirth = new DateTime(1988, 3, 25), Email = "phamthid@example.com", Phone = "0923456789", DepartmentID = 1, HireDate = new DateTime(2025, 5, 1), EmployeeStatus = "Senior", ContractType = "Full-time", Username = "phamthid", Role = "Admin", Position = "Payroll Manager", CreatedAt = now, UpdatedAt = now }
                );

                // Seed Salaries
                modelBuilder.Entity<Salary>().HasData(
                    new Salary { SalaryID = 1, EmployeeID = 1, BaseSalary = 15000000, Allowance = 2000000, Bonus = 1000000, Deduction = 500000, Tax = 750000, NetSalary = 16750000, SalaryPeriod = new DateTime(2025, 5, 1), CreatedAt = now, UpdatedAt = now },
                    new Salary { SalaryID = 2, EmployeeID = 2, BaseSalary = 10000000, Allowance = 1000000, Bonus = 500000, Deduction = 300000, Tax = 500000, NetSalary = 10700000, SalaryPeriod = new DateTime(2025, 5, 1), CreatedAt = now, UpdatedAt = now },
                    new Salary { SalaryID = 3, EmployeeID = 3, BaseSalary = 5000000, Allowance = 500000, Bonus = 0, Deduction = 100000, Tax = 0, NetSalary = 5400000, SalaryPeriod = new DateTime(2025, 5, 1), CreatedAt = now, UpdatedAt = now },
                    new Salary { SalaryID = 4, EmployeeID = 4, BaseSalary = 20000000, Allowance = 3000000, Bonus = 1500000, Deduction = 600000, Tax = 1000000, NetSalary = 19900000, SalaryPeriod = new DateTime(2025, 5, 1), CreatedAt = now, UpdatedAt = now }
                );

                // Seed Payslips
                modelBuilder.Entity<Payslip>().HasData(
                    new Payslip { PayslipID = 1, EmployeeID = 1, SalaryID = 1, IssueDate = new DateTime(2025, 5, 5), FilePath = null, Status = "Generated", CreatedAt = now, UpdatedAt = now },
                    new Payslip { PayslipID = 2, EmployeeID = 2, SalaryID = 2, IssueDate = new DateTime(2025, 5, 5), FilePath = null, Status = "Sent", CreatedAt = now, UpdatedAt = now },
                    new Payslip { PayslipID = 3, EmployeeID = 3, SalaryID = 3, IssueDate = new DateTime(2025, 5, 5), FilePath = null, Status = "Generated", CreatedAt = now, UpdatedAt = now },
                    new Payslip { PayslipID = 4, EmployeeID = 4, SalaryID = 4, IssueDate = new DateTime(2025, 5, 5), FilePath = null, Status = "Generated", CreatedAt = now, UpdatedAt = now }
                );

                // Seed Attendances 
                modelBuilder.Entity<Attendance>().HasData(
                    new Attendance { AttendanceID = 1, EmployeeID = 1, CheckInTime = new DateTime(2025, 5, 20, 8, 0, 0), CheckOutTime = new DateTime(2025, 5, 20, 17, 0, 0), CheckInMethod = "Mobile", Location = "Office", WorkHours = 8.0m, OvertimeHours = 0, AttendanceDate = new DateTime(2025, 5, 20), CreatedAt = now, UpdatedAt = now },
                    new Attendance { AttendanceID = 2, EmployeeID = 2, CheckInTime = new DateTime(2025, 5, 20, 8, 30, 0), CheckOutTime = new DateTime(2025, 5, 20, 14, 0, 0), CheckInMethod = "CameraAI", Location = "Office", WorkHours = 5.5m, OvertimeHours = 0, AttendanceDate = new DateTime(2025, 5, 20), CreatedAt = now, UpdatedAt = now },
                    new Attendance { AttendanceID = 3, EmployeeID = 3, CheckInTime = new DateTime(2025, 5, 20, 9, 0, 0), CheckOutTime = new DateTime(2025, 5, 20, 15, 0, 0), CheckInMethod = "GPS", Location = "Office", WorkHours = 6.0m, OvertimeHours = 0, AttendanceDate = new DateTime(2025, 5, 20), CreatedAt = now, UpdatedAt = now },
                    new Attendance { AttendanceID = 4, EmployeeID = 4, CheckInTime = new DateTime(2025, 5, 20, 8, 15, 0), CheckOutTime = new DateTime(2025, 5, 20, 17, 15, 0), CheckInMethod = "Biometric", Location = "Office", WorkHours = 8.0m, OvertimeHours = 1.0m, AttendanceDate = new DateTime(2025, 5, 20), CreatedAt = now, UpdatedAt = now }
                );

                // Seed LeaveRequests
                modelBuilder.Entity<LeaveRequest>().HasData(
                    new LeaveRequest { LeaveRequestID = 1, EmployeeID = 1, LeaveType = "Annual", StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2025, 6, 3), Reason = "Rest", Status = "Pending", ApproverID = 2, CreatedAt = now, UpdatedAt = now },
                    new LeaveRequest { LeaveRequestID = 2, EmployeeID = 2, LeaveType = "Sick", StartDate = new DateTime(2025, 5, 22), EndDate = new DateTime(2025, 5, 23), Reason = "Health issue", Status = "Approved", ApproverID = 1, CreatedAt = now, UpdatedAt = now },
                    new LeaveRequest { LeaveRequestID = 3, EmployeeID = 3, LeaveType = "Annual", StartDate = new DateTime(2025, 6, 10), EndDate = new DateTime(2025, 6, 12), Reason = "Personal", Status = "Pending", ApproverID = 1, CreatedAt = now, UpdatedAt = now },
                    new LeaveRequest { LeaveRequestID = 4, EmployeeID = 4, LeaveType = "Annual", StartDate = new DateTime(2025, 6, 15), EndDate = new DateTime(2025, 6, 16), Reason = "Vacation", Status = "Pending", ApproverID = 1, CreatedAt = now, UpdatedAt = now }
                );
            }
        
            public static async Task SeedIdentityDataAsync(IServiceProvider serviceProvider)
            {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var logger = serviceProvider.GetRequiredService<ILogger<SeedData>>();

            logger.LogInformation("Starting role seeding at {Time}", DateTime.UtcNow);
            string[] roles = new[] { "Admin", "HR", "Employee" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    logger.LogInformation("Creating role: {Role}", role);
                    var result = await roleManager.CreateAsync(new IdentityRole(role));
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Role {Role} created successfully", role);
                    }
                    else
                    {
                        logger.LogError("Failed to create role {Role}: {Errors}", role, string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }

            logger.LogInformation("Starting user seeding at {Time}", DateTime.UtcNow);
            var employees = new[]
{
    new { Username = "nguyenvana", Email = "nguyenvana@example.com", Role = "Admin", Password = "Admin123!" },
    new { Username = "tranthib", Email = "tranthib@example.com", Role = "HR", Password = "Hr123!" },
    new { Username = "levanc", Email = "levanc@example.com", Role = "Employee", Password = "Employee123!" },
    new { Username = "phamthid", Email = "phamthid@example.com", Role = "Admin", Password = "Admin234!" }
};

            foreach (var emp in employees)
            {
                var user = await userManager.FindByNameAsync(emp.Username);
                if (user == null)
                {
                    logger.LogInformation("Creating user: {Username} with email {Email}", emp.Username, emp.Email);
                    user = new IdentityUser
                    {
                        UserName = emp.Username,
                        Email = emp.Email,
                        NormalizedUserName = emp.Username.ToUpper(),
                        NormalizedEmail = emp.Email.ToUpper()
                    };
                    var result = await userManager.CreateAsync(user, emp.Password);
                    if (result.Succeeded)
                    {
                        logger.LogInformation("User {Username} created successfully", emp.Username);
                        var roleResult = await userManager.AddToRoleAsync(user, emp.Role);
                        if (roleResult.Succeeded)
                        {
                            logger.LogInformation("Role {Role} assigned to user {Username}", emp.Role, emp.Username);
                        }
                        else
                        {
                            logger.LogError("Failed to assign role {Role} to user {Username}: {Errors}", emp.Role, emp.Username, string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                        }
                    }
                    else
                    {
                        logger.LogError("Failed to create user {Username}: {Errors}", emp.Username, string.Join(", ", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
                    }
                }
                else
                {
                    logger.LogWarning("User {Username} already exists, skipping creation", emp.Username);
                }
            }
            logger.LogInformation("User seeding completed at {Time}", DateTime.UtcNow);
        }
    }
}

