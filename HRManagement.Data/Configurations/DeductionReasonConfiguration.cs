using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class DeductionReasonConfiguration : IEntityTypeConfiguration<DeductionReason>
{
    public void Configure(EntityTypeBuilder<DeductionReason> builder)
    {
        builder.ToTable("DeductionReasons");
        builder.HasKey(dr => dr.DeductionReasonID);
        builder.Property(dr => dr.DeductionReasonID)
            .ValueGeneratedOnAdd();

        builder.Property(dr => dr.ReasonName)
            .HasMaxLength(100);

        builder.Property(dr => dr.Description)
            .HasMaxLength(500);

        builder.Property(dr => dr.Unit)
            .HasMaxLength(20);

        builder.Property(dr => dr.BaseRate)
            .HasColumnType("decimal(18,2)");

        builder.Property(dr => dr.Multiplier)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(1.0m);

        builder.Property(dr => dr.Amount)
            .HasColumnType("decimal(18,2)");

        builder.HasMany(dr => dr.Deductions)
            .WithOne(d => d.Reason)
            .HasForeignKey(d => d.DeductionReasonID)
            .OnDelete(DeleteBehavior.SetNull);
    }
} 