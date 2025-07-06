using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("Positions");
        builder.HasKey(p => p.PositionID);
        builder.Property(p => p.PositionID)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(p => p.PositionName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.BaseSalary)
            .HasPrecision(18, 2);
        builder.Property(p => p.MinSalary)
            .HasPrecision(18, 2);
        builder.Property(p => p.MaxSalary)
            .HasPrecision(18, 2);
        builder.HasMany(p => p.Users)
            .WithOne(u => u.Position)
            .HasForeignKey(u => u.PositionID)
            .OnDelete(DeleteBehavior.SetNull);        
    }
}