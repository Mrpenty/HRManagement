using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data.Data.Configurations
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("Salaries");
            builder.HasKey(s => s.SalaryID);
            builder.Property(s => s.BaseSalary).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Allowance).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Bonus).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Deduction).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Tax).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.NetSalary).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.SalaryPeriod).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired();

            builder.HasOne(s => s.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(s => s.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
