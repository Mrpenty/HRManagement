using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class SalaryPeriodConfiguration : IEntityTypeConfiguration<SalaryPeriod>
{
    public void Configure(EntityTypeBuilder<SalaryPeriod> builder)
    {
        builder.ToTable("SalaryPeriods");
        builder.HasKey(sp => sp.SalaryPeriodID);
        builder.Property(sp => sp.SalaryPeriodID)
            .ValueGeneratedOnAdd();

        builder.Property(sp => sp.PeriodName)
            
            .HasMaxLength(50);


        builder.HasMany(sp => sp.Salaries)
            .WithOne(s => s.SalaryPeriod)
            .HasForeignKey(s => s.SalaryPeriodID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(sp => sp.Holidays)
            .WithMany(h => h.SalaryPeriods)
            .UsingEntity(j => j.ToTable("HolidaySalaryPeriods"));
    }
} 