using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class DeductionConfiguration : IEntityTypeConfiguration<Deduction>
{
    public void Configure(EntityTypeBuilder<Deduction> builder)
    {
        builder.ToTable("Deductions");
        builder.HasKey(d => d.DeductionID);
        builder.Property(d => d.DeductionID)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.UserID)
            .IsRequired();

        builder.Property(d => d.Amount)
            .HasColumnType("decimal(18,2)");

        builder.Property(d => d.Description)
            .HasMaxLength(500);

        

        builder.HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d => d.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Reason)
            .WithMany(dr => dr.Deductions)
            .HasForeignKey(d => d.DeductionReasonID)
            .OnDelete(DeleteBehavior.SetNull);
    }
} 