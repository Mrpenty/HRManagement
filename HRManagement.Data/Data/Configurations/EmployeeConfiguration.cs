using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.EmployeeID);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.DateOfBirth).IsRequired();
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(20);
            builder.Property(e => e.HireDate).IsRequired();
            builder.Property(e => e.EmployeeStatus).HasMaxLength(20).HasDefaultValue("Active"); ;
            builder.Property(e => e.ContractType).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Role).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Position).HasMaxLength(100);
            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();

            builder.HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Salaries)
                .WithOne()
                .HasForeignKey(s => s.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Payslips)
                .WithOne()
                .HasForeignKey(p => p.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Attendances)
                .WithOne()
                .HasForeignKey(a => a.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.LeaveRequests)
                .WithOne()
                .HasForeignKey(lr => lr.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.ApprovedLeaveRequests)
                .WithOne()
                .HasForeignKey(lr => lr.ApproverID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
