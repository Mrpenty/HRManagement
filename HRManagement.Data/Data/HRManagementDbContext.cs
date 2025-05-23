using HRManagement.Data.Data.Configurations;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data.Data
{
    public class HRManagementDbContext : IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public HRManagementDbContext(DbContextOptions<HRManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Payslip> Payslips { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            // Apply entity configurations
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new SalaryConfiguration());
            modelBuilder.ApplyConfiguration(new PayslipConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveRequestConfiguration());

            // Apply seeding
            SeedData.Seed(modelBuilder);
        }
    }
}
