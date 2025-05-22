using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data.Data
{
    public class HRManagementDbContext : DbContext
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

            SeedData.Seed(modelBuilder);

            // Configure Employee
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Username)
                .IsUnique();

            // Configure EmployeeStatus (nullable, check constraint)
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeStatus)
                .HasConversion<string>()
                .IsRequired(false);
            modelBuilder.Entity<Employee>()
                .HasCheckConstraint("CK_EmployeeStatus", "[EmployeeStatus] IN ('Intern', 'Fresher', 'Senior') OR [EmployeeStatus] IS NULL");

            // Configure ContractType (required, check constraint)
            modelBuilder.Entity<Employee>()
                .Property(e => e.ContractType)
                .HasConversion<string>()
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .HasCheckConstraint("CK_ContractType", "[ContractType] IN ('Full-time', 'Part-time')");

            // Configure Role (required, check constraint)
            modelBuilder.Entity<Employee>()
                .Property(e => e.Role)
                .HasConversion<string>()
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .HasCheckConstraint("CK_Role", "[Role] IN ('Admin', 'HR', 'Employee')");

            // Configure Position (nullable, no check constraint needed)
            modelBuilder.Entity<Employee>()
                .Property(e => e.Position)
                .HasConversion<string>()
                .IsRequired(false);

            // Configure relationships
            modelBuilder.Entity<Employee>()
                 .HasMany(e => e.Salaries)
                 .WithOne(s => s.Employee)
                 .HasForeignKey(s => s.EmployeeID)
                 .OnDelete(DeleteBehavior.Cascade); // Deleting an Employee deletes related Salaries

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Payslips)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade); // Deleting an Employee deletes related Payslips

            modelBuilder.Entity<Payslip>()
                .HasOne(p => p.Salary)
                .WithMany(s => s.Payslips)
                .HasForeignKey(p => p.SalaryID)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascade on Salary deletion

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LeaveRequests)
                .WithOne(lr => lr.Employee)
                .HasForeignKey(lr => lr.EmployeeID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ApprovedLeaveRequests)
                .WithOne(lr => lr.Approver)
                .HasForeignKey(lr => lr.ApproverID)
                .IsRequired(false); // ApproverID can be null
        }
    }
}
