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
            .HasPrecision(18, 2);
        builder.Property(s => s.Bonus)
            .HasPrecision(18, 2);
        builder.Property(s => s.Deduction)
            .HasPrecision(18, 2);
        builder.Property(s => s.Tax)
            .HasPrecision(18, 2);
        builder.Property(s => s.NetSalary)
            .HasPrecision(18, 2);
        builder.Property(s => s.PositionAllowance)
            .HasPrecision(18, 2);
        builder.Property(s => s.ResponsibilityAllowance)
            .HasPrecision(18, 2);
        builder.Property(s => s.SeniorityAllowance)
            .HasPrecision(18, 2);
        builder.Property(s => s.TransportAllowance)
            .HasPrecision(18, 2);
        builder.Property(s => s.MealAllowance)
            .HasPrecision(18, 2);
        builder.Property(s => s.HousingAllowance)
            .HasPrecision(18, 2);
        builder.Property(s => s.SocialInsurance)
            .HasPrecision(18, 2);
        builder.Property(s => s.HealthInsurance)
            .HasPrecision(18, 2);
        builder.Property(s => s.UnemploymentInsurance)
            .HasPrecision(18, 2);
        builder.Property(s => s.GrossSalary)
            .HasPrecision(18, 2);
        builder.Property(s => s.SalaryPeriodID)
            .IsRequired();
        builder.Property(s => s.EffectiveDate)
            .IsRequired();
        builder.Property(s => s.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Draft");
        builder.Property(s => s.ApprovedBy);
        builder.Property(s => s.ApprovalNote)
            .HasMaxLength(500);
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
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.SalaryPeriod)
            .WithMany(sp => sp.Salaries)
            .HasForeignKey(s => s.SalaryPeriodID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Approver)
            .WithMany()
            .HasForeignKey(s => s.ApprovedBy)
            .OnDelete(DeleteBehavior.SetNull);
    }
}