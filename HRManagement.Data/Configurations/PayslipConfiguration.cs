using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class PayslipConfiguration : IEntityTypeConfiguration<Payslip>
{
    public void Configure(EntityTypeBuilder<Payslip> builder)
    {
        builder.ToTable("Payslips");
        builder.HasKey(p => p.PayslipID);
        builder.Property(p => p.PayslipID)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(p => p.UserID)
            .IsRequired();
        builder.Property(p => p.SalaryID)
            .IsRequired();
        builder.Property(p => p.IssueDate)
            .IsRequired()
            .HasColumnType("date");
        builder.Property(p => p.FilePath)
            .IsRequired(false)
            .HasMaxLength(500);
        builder.Property(p => p.Status)
            .HasDefaultValue("Generated")
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();
        builder.HasOne(p => p.User)
            .WithMany(u => u.Payslips)
            .HasForeignKey(p => p.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.Salary)
            .WithMany(s => s.Payslips)
            .HasForeignKey(p => p.SalaryID)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}