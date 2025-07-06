using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class EmployeeLevelConfiguration : IEntityTypeConfiguration<EmployeeLevel>
{
    public void Configure(EntityTypeBuilder<EmployeeLevel> builder)
    {
        builder.ToTable("EmployeeLevels");
        builder.HasKey(el => el.EmployeeLevelID);
        builder.Property(el => el.EmployeeLevelID)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(el => el.EmployeeLevelName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(el => el.MinSalary)
            .HasPrecision(18, 2);
        builder.Property(el => el.MaxSalary)
            .HasPrecision(18, 2);
        builder.Property(el => el.SalaryMultiplier)
            .HasPrecision(5, 2);
        builder.HasMany(el => el.Users)
            .WithOne(u => u.EmployeeLevel)
            .HasForeignKey(u => u.EmployeeLevelID)
            .OnDelete(DeleteBehavior.SetNull);
    }
}