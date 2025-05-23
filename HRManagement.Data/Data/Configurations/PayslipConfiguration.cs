using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data.Data.Configurations
{
    public class PayslipConfiguration : IEntityTypeConfiguration<Payslip>
    {
        public void Configure(EntityTypeBuilder<Payslip> builder)
        {
            builder.ToTable("Payslips");
            builder.HasKey(p => p.PayslipID);
            builder.Property(p => p.IssueDate).IsRequired();
            builder.Property(p => p.FilePath).HasMaxLength(255);
            builder.Property(p => p.Status).IsRequired().HasMaxLength(20);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt).IsRequired();

            builder.HasOne(p => p.Employee)
                .WithMany(e => e.Payslips)
                .HasForeignKey(p => p.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Salary)
                .WithMany()
                .HasForeignKey(p => p.SalaryID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
