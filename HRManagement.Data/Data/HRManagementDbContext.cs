using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static HRManagement.Data.Data.SeedRoles;

namespace HRManagement.Data.Data
{
    public class HRManagementDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public HRManagementDbContext(DbContextOptions<HRManagementDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<EmployeeLevel> EmployeeLevels { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Payslip> Payslips { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<DeductionReason> DeductionReasons { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<SalaryBonus> SalaryBonuses { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<SalaryPeriod> SalaryPeriods { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRManagementDbContext).Assembly);
            SeedData.Configure(modelBuilder);

        }
    }
}
