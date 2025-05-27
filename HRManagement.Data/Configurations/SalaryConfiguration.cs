using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
{
    public void Configure(EntityTypeBuilder<Salary> builder)
    {
        builder.ToTable("Salaries");
        builder.HasKey(s => s.SalaryID);
        builder.Property(s => s.SalaryID)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(s => s.UserID)
            .IsRequired();
        builder.Property(s => s.BaseSalary)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(s => s.Allowances)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(s => s.Bonus)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(s => s.Deduction)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(s => s.Tax)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(s => s.NetSalary)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(s => s.SalaryPeriod)
            .IsRequired()
            .HasColumnType("date");
        builder.Property(s => s.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();
        builder.Property(s => s.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();
        builder.HasOne(s => s.User)
            .WithMany(u => u.Salaries)
            .HasForeignKey(s => s.UserID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}