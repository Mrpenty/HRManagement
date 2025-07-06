using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
{
    public void Configure(EntityTypeBuilder<Holiday> builder)
    {
        builder.ToTable("Holidays");
        builder.HasKey(h => h.HolidayID);
        builder.Property(h => h.HolidayID)
            .ValueGeneratedOnAdd();

        builder.Property(h => h.HolidayName)
            .HasMaxLength(100);

        builder.Property(h => h.Description)
            .HasMaxLength(500);

        builder.Property(h => h.HolidayDate)
            .IsRequired();

        builder.Property(h => h.IsPaid)
            .HasDefaultValue(true);

        builder.HasMany(h => h.SalaryPeriods)
            .WithMany(sp => sp.Holidays)
            .UsingEntity(j => j.ToTable("HolidaySalaryPeriods"));
    }
} 